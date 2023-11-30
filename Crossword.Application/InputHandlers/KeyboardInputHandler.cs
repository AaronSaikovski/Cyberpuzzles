////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     KeyboardHandler.cs                                    //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Version:    1.0                                                   //
//      Purpose:    Generic crosswordApp keyboard handler.                   //
//      Ref:        https://github.com/DavidFidge/InputHandlers           //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using InputHandlers.Keyboard;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.InputHandlers
{
    public class KeyboardInputHandler(Crossword.App.CrosswordApp crosswordApp) : IKeyboardHandler
    {
        #region Keyboard_Input_Handler

        //CrosswordApp.Application instance
        //private readonly CrosswordApp.Application.CrosswordApp.Application _crosswordApp = crosswordApp;
        App.CrosswordApp _crosswordApp = crosswordApp;
        
        public void HandleKeyboardKeyDown(Keys[] keysDown, Keys keyInFocus, KeyboardModifier keyboardModifier)
        {
            //Implement cheat - Ctrl+B
            if ((KeyboardModifier.Ctrl & keyboardModifier) == KeyboardModifier.Ctrl && keyInFocus == Keys.B)
            {
                //Console.WriteLine("Ctrl-B");
                _crosswordApp.QuickSolver();
            }
            else
            {
                // check if game is finished
                if (!_crosswordApp.IsFinished)
                {
                    //handle key down..normal keys
                    _crosswordApp.KeyDown(keysDown, keyInFocus);
                }
            }
        }

        public void HandleKeyboardKeyLost(Keys[] keysDown, KeyboardModifier keyboardModifier)
        {
            //do nothing
        }

        public void HandleKeyboardKeyRepeat(Keys repeatingKey, KeyboardModifier keyboardModifier)
        {

        }

        //Keyup event
        public void HandleKeyboardKeysReleased()
        {
            //do nothing
        }

        #endregion
    }
}

