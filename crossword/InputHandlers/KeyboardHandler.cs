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

    public class KeyboardHandler : IKeyboardHandler
    {
        //Crossword instance
        private readonly Crossword.App.Crossword _crossword;

        public KeyboardHandler(Crossword.App.Crossword crossword)
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
                if (!_crossword.bIsFinished)
                {
                    //handle key down..normal keys
                    KeyDown(keysDown, keyInFocus);
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


        /*---------------------------------------------------------------*/

        //Keypress event - Display the character in the square region
        private void KeyDown(Keys[] keysDown, Keys keyInFocus)
        {
            //TODO - move this all back to Crossword main
            //if puzzle is finished...eat the event
            if (_crossword.bPuzzleFinished) return;
            switch (keyInFocus)
            {
                //Spacebar pressed to change orientation...bIsAcross.
                case Keys.Space:
                {
                    //Deselect the listbox based on direction
                    if (!_crossword.bIsAcross)
                        _crossword.lstClueDown.SelectedIndex = -1;
                    else
                        _crossword.lstClueAcross.SelectedIndex = -1;

                    //Sets the highlighting of the square.
                    _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, false);

                    //Change orientation if possible
                    if (_crossword.bIsAcross)
                    {
                        if (_crossword.sqCurrentSquare.CanFlipDirection(_crossword.bIsAcross))
                            _crossword.bIsAcross = false;
                    }
                    else
                    {
                        if (_crossword.sqCurrentSquare.CanFlipDirection(_crossword.bIsAcross))
                            _crossword.bIsAcross = true;
                    }

                    //Sets the highlighting of the square.
                    _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, true);
                    break;
                }
                //Set the focus if the tab key is pressed
                case Keys.Tab when _crossword.nTabPress == 0:
                    //Give the Across list the focus
                    _crossword.lstClueAcross.SelectedIndex = 0;
                    _crossword.nTabPress = 1;
                    _crossword.nFocusState = 1;
                    break;
                //Give the Down list the focus
                case Keys.Tab when _crossword.nTabPress == 1:
                    _crossword.lstClueDown.SelectedIndex = 0;
                    _crossword.nTabPress = 2;
                    _crossword.nFocusState = 2;
                    break;
                //Give the applet back the focus
                case Keys.Tab:
                {
                    if (_crossword.nTabPress == 2)
                    {
                        _crossword.nTabPress = 0;
                        _crossword.nFocusState = 0;
                    }

                    break;
                }
            }

            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            if (_crossword.nFocusState is 1 or 2)
            {
                NavigateList(_crossword.bIsAcross, keyInFocus);
            }


            //If the applet has the focus then allow the arrow keys to navigate around
            if (_crossword.nFocusState == 0)
            {
                NavigatePuzzle(keyInFocus);
            }


            switch (keyInFocus)
            {
                //Delete present square's contents if Delete key is pressed
                case Keys.Delete:
                    _crossword.sqCurrentSquare.SetLetter(' ', _crossword.bIsAcross);
                    //repaint();
                    break;
                //Check to see if a backspace was entered
                case Keys.Back:
                    _crossword.sqCurrentSquare.SetLetter(' ', _crossword.bIsAcross);
                    _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetPrevSq(_crossword.bIsAcross);
                    _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, true);
                    break;
                case >= Keys.A and <= Keys.Z:
                    //Sets the letter in the current square
                    _crossword.sqCurrentSquare.SetLetter(char.ToUpper((char)keyInFocus), _crossword.bIsAcross);

                    //get next sq or myself(same sq)  if not available
                    _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetNextSq(_crossword.bIsAcross);

                    //Sets the highlighting of the square.
                    _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, true);
                    break;
            }


            //update score
            //_crossword.clickedBtnCheck();
            _crossword.UpdateCrosswordScore();
        }

        
        /*---------------------------------------------------------------*/

        //Allows up and down navigation of the listbox contents.
        private void NavigateList(bool bIsAcross, Keys keyInFocus)
        {

            try
            {
                switch (bIsAcross)
                {
                    case true:
                        switch (keyInFocus)
                        {
                            //If Across then allow operations on the across list
                            case Keys.Up:
                            {
                                if (_crossword.lstClueAcross.SelectedIndex != 0)
                                {
                                    _crossword.lstClueAcross.SelectedIndex = _crossword.lstClueAcross.SelectedIndex - 1;
                                }

                                break;
                            }
                            case Keys.Down:
                                _crossword.lstClueAcross.SelectedIndex = _crossword.lstClueAcross.SelectedIndex + 1;
                                break;
                        }

                        // if (keyInFocus == Keys.Up)
                        // {
                        //     if (_crossword.lstClueAcross.SelectedIndex != 0)
                        //     {
                        //         _crossword.lstClueAcross.SelectedIndex = (_crossword.lstClueAcross.SelectedIndex - 1);
                        //     }
                        // }
                        // else if (keyInFocus == Keys.Down)
                        // {
                        //     _crossword.lstClueAcross.SelectedIndex = (_crossword.lstClueAcross.SelectedIndex + 1);
                        //
                        // }
                        break;
                    case false:
                        switch (keyInFocus)
                        {
                            //if Down
                            case Keys.Up:
                            {
                                if (_crossword.lstClueDown.SelectedIndex != 0)
                                {
                                    _crossword.lstClueDown.SelectedIndex = _crossword.lstClueDown.SelectedIndex - 1;
                                }

                                break;
                            }
                            case Keys.Down:
                                _crossword.lstClueDown.SelectedIndex = _crossword.lstClueDown.SelectedIndex + 1;
                                break;
                        }

                        break;
                }
            }
            catch (Exception e)
            { //Catch the exception
                Console.WriteLine("Exception " + e + " occurred in method NavigateList");
            }
        }



        /*---------------------------------------------------------------*/

        private void NavigatePuzzle(Keys keyInFocus)
        {
            try
            {

                //Deselect the listbox based on direction
                if (!_crossword.bIsAcross)
                    _crossword.lstClueDown.SelectedIndex = -1;
                else
                    _crossword.lstClueAcross.SelectedIndex = -1;

                //Sets the highlighting of the square.
                _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, false);

                switch (keyInFocus)
                {
                    //If left arrow key pressed get prev sq
                    case Keys.Left when _crossword.bIsAcross:
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetPrevSq(_crossword.bIsAcross);
                        break;
                    case Keys.Left:
                    {
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetPrevSq(!_crossword.bIsAcross);
                        if (_crossword.sqCurrentSquare.clDown == null)
                            _crossword.bIsAcross = !_crossword.bIsAcross;
                        break;
                    }
                    //If right arrow pressed get next sq
                    case Keys.Right when _crossword.bIsAcross:
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetNextSq(_crossword.bIsAcross);
                        break;
                    case Keys.Right:
                    {
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetNextSq(!_crossword.bIsAcross);
                        if (_crossword.sqCurrentSquare.clDown == null)
                            _crossword.bIsAcross = !_crossword.bIsAcross;
                        break;
                    }
                    //If up arrow key pressed
                    case Keys.Up when _crossword.bIsAcross:
                    {
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetPrevSq(!_crossword.bIsAcross);
                        if (_crossword.sqCurrentSquare.clAcross == null)
                        {
                            _crossword.bIsAcross = !_crossword.bIsAcross;
                        }

                        break;
                    }
                    case Keys.Up:
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetPrevSq(_crossword.bIsAcross);
                        break;
                    //If down arrow pressed get next sq
                    case Keys.Down when _crossword.bIsAcross:
                    {
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetNextSq(!_crossword.bIsAcross);
                        if (_crossword.sqCurrentSquare.clAcross == null)
                        {
                            _crossword.bIsAcross = !_crossword.bIsAcross;
                        }

                        break;
                    }
                    case Keys.Down:
                        _crossword.sqCurrentSquare = _crossword.sqCurrentSquare.GetNextSq(_crossword.bIsAcross);
                        break;
                }

                //Sets the highlighting of the square.
                _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross).HighlightSquares(_crossword.sqCurrentSquare, true);

                ///////////////////////////////////////
                //Listbox linkage stuff
                //
                //Find index to Clue Answer for highlighting in List boxes
                var tmp = _crossword.sqCurrentSquare.GetClueAnswerRef(_crossword.bIsAcross);
                var clueAnswerIdx = 0;
                for (var k = 0; k < _crossword.nNumQuestions; k++)
                {
                    if (tmp != _crossword.caPuzzleClueAnswers[k]) continue;
                    clueAnswerIdx = k;
                    break;
                }

                //Selects the item in the list box relative to the ClueAnswer
                //and the orientation.
                if (_crossword.bIsAcross)
                    _crossword.lstClueAcross.SelectedIndex = clueAnswerIdx;
                else
                    _crossword.lstClueDown.SelectedIndex = clueAnswerIdx - _crossword.lstClueAcross.Items.Count;
                ///////////////////////////////////////


            }
            catch (Exception e)
            { //Catch the exception
                Console.WriteLine("Exception " + e + " occurred in method NavigatePuzzle");
            }
        }

        /*---------------------------------------------------------------*/



    }
}

