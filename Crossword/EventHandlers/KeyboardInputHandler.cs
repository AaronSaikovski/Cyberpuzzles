////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     KeyboardHandler.cs                                    //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Version:    1.0                                                   //
//      Purpose:    Generic crosswordMain keyboard handler.                   //
//      Ref:        https://github.com/DavidFidge/InputHandlers           //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using InputHandlers.Keyboard;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public class KeyboardInputHandler(App.CrosswordMain crosswordMain) : IKeyboardHandler
{
    #region Keyboard_Input_Handler



    public void HandleKeyboardKeyDown(Keys[] keysDown, Keys keyInFocus, KeyboardModifier keyboardModifier)
    {
        //Implement cheat - Ctrl+B
        if ((KeyboardModifier.Ctrl & keyboardModifier) == KeyboardModifier.Ctrl && keyInFocus == Keys.B)
        {
            //Console.WriteLine("Ctrl-B");
            crosswordMain.QuickSolver();
        }
        else
        {
            // check if game is finished
            if (!crosswordMain.IsFinished)
            {
                //handle key down..normal keys
                crosswordMain.KeyDown(keyInFocus);
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