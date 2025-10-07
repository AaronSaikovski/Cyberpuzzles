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
            _logger.LogInformation("Start QuickSolver()");

            if (_puzzleFinished || _setFinished) return;
            for (var p = 0; p < _numQuestions; p++)
            {
                for (var j = 0; j < _numQuestions; j++)
                {
                    switch (_szTmpGetLetters)
                    {
                        case { Length: <= 0 }:
                        case null:
                            continue;
                    }

                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < _numQuestions; i++)
                        if (_caPuzzleClueAnswers != null)
                            _caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                }
            }

            //Increment the score if the answer is correct
            UpdateCrosswordScore();

            // Use regular loop instead of Parallel.For (_numQuestions is typically small)
            if (_caPuzzleClueAnswers != null)
            {
                for (var i = 0; i < _numQuestions; i++)
                {
                    _caPuzzleClueAnswers[i].CheckWord();
                }
            }

            //If the crossword score == the number of questions, then it is the end of the game
            if (_crosswordScore == _numQuestions)
            {
                //Flag that we have finished
                _puzzleFinished = true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}