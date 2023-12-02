using System;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region QuickSolver

    /// <summary>
    /// QuickSolver
    /// </summary>
    public void QuickSolver()
    {
        try
        {
            if (PuzzleFinished || SetFinished) return;
            for (var p = 0; p < NumQuestions; p++)
            {
                for (var j = 0; j < NumQuestions; j++)
                {
                    switch (_szTmpGetLetters)
                    {
                        case { Length: <= 0 }:
                        case null:
                            continue;
                    }

                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < NumQuestions; i++)
                        caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                }
            }

            //Increment the score if the answer is correct
            UpdateCrosswordScore();

            // for (var i = 0; i < NumQuestions; i++)
            //     caPuzzleClueAnswers[i].CheckWord();
            Parallel.For(0, NumQuestions, i =>
            {
                caPuzzleClueAnswers[i].CheckWord();
            });

            //If the crossword score == the number of questions, then it is the end of the game
            if (CrosswordScore == NumQuestions)
            {
                //Flag that we have finished
                PuzzleFinished = true;
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