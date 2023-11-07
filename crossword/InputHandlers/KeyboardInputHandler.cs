using System;
using InputHandlers.Keyboard;
using Microsoft.Xna.Framework.Input;


////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     KeyboardHandler.cs                                    //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Version:    1.0                                                   //
//      Purpose:    Generic crossword keyboard handler.                   //
//      Ref:        https://github.com/DavidFidge/InputHandlers           //
//                                                                        //
////////////////////////////////////////////////////////////////////////////


namespace CyberPuzzles.Crossword.InputHandlers
{ 
    public class KeyboardInputHandler : IKeyboardHandler
    {
        #region Keyboard_Input_Handler
        
        //Crossword instance
        private readonly Crossword.App.Crossword _crossword;

        public KeyboardInputHandler(Crossword.App.Crossword crossword)
		{
            //get the instance of the crossword object
            _crossword = crossword;

        }
        public void HandleKeyboardKeyDown(Keys[] keysDown, Keys keyInFocus, KeyboardModifier keyboardModifier)
        {
            //Implement cheat - Ctrl+B
            if ((KeyboardModifier.Ctrl & keyboardModifier) == KeyboardModifier.Ctrl && keyInFocus == Keys.B)
            {
                //Console.WriteLine("Ctrl-B");
                _crossword.QuickSolver();
            }
            else
            {
                // check if game is finished
                if (!_crossword.BIsFinished)
                {
                    //handle key down..normal keys
                    _crossword.KeyDown(keysDown, keyInFocus);
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

