using System;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordMain
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
            logger.LogInformation("Start GetHintLetters()");
            
            while (!hintSupplied && !allHintLettersChecked)
            {

                if (_szTmpGetLetters is { Length: > 0 })
                {
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    
                    //loop over hint letters
                    Parallel.For(0, NumQuestions, i =>
                    {
                        var bTmpResult = caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                        if (bTmpResult)
                        {
                            hintSupplied = true;
                        }
                    });
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
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

}