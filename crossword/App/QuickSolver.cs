using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region QuickSolver

    public void QuickSolver()
    {
        try
        {
            if (BPuzzleFinished || BSetFinished) return;
            for (var p = 0; p < NNumQuestions; p++)
            {
                for (var j = 0; j < NNumQuestions; j++)
                {
                    if (_szTmpGetLetters.Length <= 0) continue;
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < NNumQuestions; i++)
                        CaPuzzleClueAnswers[i].CheckHint(chHintLetter);
                }
            }

            //Increment the score if the answer is correct
            UpdateCrosswordScore();

            for (var i = 0; i < NNumQuestions; i++)
                CaPuzzleClueAnswers[i].CheckWord();

            //If the crossword score == the number of questions, then it is the end of the game
            if (NScore == NNumQuestions)
            {
                //Flag that we have finished
                BPuzzleFinished = true;
            }
        }
        catch (Exception e)
        {
            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method quickSolver()");
        }
    }

    #endregion
}