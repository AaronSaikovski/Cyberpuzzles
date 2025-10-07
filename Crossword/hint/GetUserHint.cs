using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region GetHintLetters
    /// <summary>
    /// Get Hint letters from the Hintletter array
    /// </summary>
    /// <param name="count"></param>
    private void GetHintLetters(int count)
    {
        var hintSupplied = false;
        var allHintLettersChecked = false;
        try
        {
            _logger.LogInformation("Start GetHintLetters()");

            while (!hintSupplied && !allHintLettersChecked)
            {

                if (_szTmpGetLetters is { Length: > 0 })
                {
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];

                    // Use regular loop instead of Parallel.For to avoid race condition
                    // and because _numQuestions is typically small (< 100)
                    if (_caPuzzleClueAnswers != null)
                    {
                        for (var i = 0; i < _numQuestions; i++)
                        {
                            if (_caPuzzleClueAnswers[i].CheckHint(chHintLetter))
                            {
                                hintSupplied = true;
                                break; // Can exit early when hint is found
                            }
                        }
                    }

                    count++;
                    if (_szGetLetters is not null && count == _szGetLetters.Length)
                        allHintLettersChecked = true;
                }
                else
                {
                    _szTmpGetLetters = _szGetLetters;
                    GetHintLetters(count);
                    hintSupplied = true;

                }
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