using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordMain
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
            _logger.LogInformation("Start UpdateCrosswordScore()");

            Parallel.For(0, NumQuestions, i =>
            {
                if (caPuzzleClueAnswers[i].IsCorrect())
                {
                    Interlocked.Increment(ref CrosswordScore);
                }

                caPuzzleClueAnswers[i].CheckWord();
            });


            if (CrosswordScore == NumQuestions)
            {
                IsFinished = true;
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