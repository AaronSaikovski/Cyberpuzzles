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
        _crosswordScore = 0;
        try
        {
            _logger.LogInformation("Start UpdateCrosswordScore()");

            Parallel.For(0, _numQuestions, i =>
            {
                if (_caPuzzleClueAnswers[i] == null) return;
                if (_caPuzzleClueAnswers[i].IsCorrect())
                {
                    Interlocked.Increment(ref _crosswordScore);
                }

                _caPuzzleClueAnswers[i].CheckWord();
            });


            if (_crosswordScore == _numQuestions)
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