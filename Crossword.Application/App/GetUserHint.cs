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
        bool hintSupplied = false;
        bool allHintLettersChecked = false;
        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion

}