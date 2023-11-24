using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
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
            bool HintSupplied = false, AllHintLettersChecked = false;

            while (!HintSupplied && (!AllHintLettersChecked))
            {

                if (_szTmpGetLetters.Length > 0)
                {
                    var chHintLetter = _szTmpGetLetters[0];
                    _szTmpGetLetters = _szTmpGetLetters[1..];
                    for (var i = 0; i < NumQuestions; i++)
                    {
                        var bTmpResult = caPuzzleClueAnswers[i].CheckHint(chHintLetter);
                        if (bTmpResult)
                        {
                            HintSupplied = true;
                        }
                    }
                    count++;
                    if (count == _szGetLetters.Length)
                        AllHintLettersChecked = true;
                }
                else
                {
                    _szTmpGetLetters = _szGetLetters;
                    GetHintLetters(count);
                    HintSupplied = true;

                }
            }
        }
        catch (Exception e)
        { //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method GetHintLetters()");
        }

    }
    #endregion

}