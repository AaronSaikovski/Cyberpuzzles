using System;

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

            // Use regular loop instead of Parallel.For (_numQuestions is typically small)
            if (_caPuzzleClueAnswers != null)
            {
                for (var i = 0; i < _numQuestions; i++)
                {
                    if (_caPuzzleClueAnswers[i].IsCorrect())
                    {
                        _crosswordScore++;
                    }

                    _caPuzzleClueAnswers[i].CheckWord();
                }
            }

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