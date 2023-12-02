using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region GetHintLetters
    /// <summary>
    /// Hint implementation
    /// </summary>
    /// <param name="count"></param>
    private void GetHintLetters(int count)
    {
        try
        {

            //local vars
            bool hintSupplied = false, allHintLettersChecked = false;

            while (!hintSupplied && !allHintLettersChecked)
            {

                if (_szTmpGetLetters is { Length: > 0 })
                {
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < NumQuestions; i++)
                    {
                        var bTmpResult = caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                        if (bTmpResult)
                        {
                            hintSupplied = true;
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
        catch (Exception e)
        { 
            Console.WriteLine("Exception " + e + " occurred in method GetHintLetters()");
        }

    }
    #endregion

}