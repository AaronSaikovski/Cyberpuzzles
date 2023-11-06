using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region QuickSolver

    public void QuickSolver()
    {
        try
        {
            if (bPuzzleFinished || bSetFinished) return;
            for (var p = 0; p < nNumQuestions; p++)
            {
                for (var j = 0; j < nNumQuestions; j++)
                {
                    if (_szTmpGetLetters.Length <= 0) continue;
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < nNumQuestions; i++)
                        caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                }
            }

            //Increment the score if the answer is correct
            //updateCrosswordScore();
            UpdateCrosswordScore();

            for (var i = 0; i < nNumQuestions; i++)
                caPuzzleClueAnswers[i].CheckWord();

            //If the crossword score == the number of questions, then it is the end of the game
            if (nScore == nNumQuestions)
            {
                //Flag that we have finished
                bPuzzleFinished = true;
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