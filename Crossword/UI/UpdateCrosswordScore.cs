using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region UpdateCrosswordScore

    /// <summary>
    /// Updates the crossword score
    /// </summary>
    private void UpdateCrosswordScore()
    {
        CrosswordScore = 0;
        try
        {
            logger.LogInformation("Start UpdateCrosswordScore()");

            Parallel.For(0, _numQuestions, i =>
            {
                if (_caPuzzleClueAnswers[i].IsCorrect())
                {
                    Interlocked.Increment(ref CrosswordScore);
                }

                _caPuzzleClueAnswers[i].CheckWord();
            });


            if (CrosswordScore == _numQuestions)
            {
                IsFinished = true;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}