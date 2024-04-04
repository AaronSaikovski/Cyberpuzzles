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

namespace Crossword.App;

public class KeyboardInputHandler(CrosswordApp crosswordApp) : IKeyboardHandler
{
    #region Keyboard_Input_Handler



    public void HandleKeyboardKeyDown(Keys[] keysDown, Keys keyInFocus, KeyboardModifier keyboardModifier)
    {
        //Implement cheat - Ctrl+B
        if ((KeyboardModifier.Ctrl & keyboardModifier) == KeyboardModifier.Ctrl && keyInFocus == Keys.B)
        {
            //Console.WriteLine("Ctrl-B");
            crosswordApp.QuickSolver();
        }
        else
        {
            // check if game is finished
            if (!crosswordApp.IsFinished)
            {
                //handle key down..normal keys
                crosswordApp.KeyDown(keyInFocus);
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