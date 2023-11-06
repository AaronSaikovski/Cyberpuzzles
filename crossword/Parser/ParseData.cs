namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    //Main - used to parse QuickCrossword data set from string
    //Pre  : szParseData is NOT null
    //Post : Returns true if data has been succesfully parsed from String and false otherwise
    public bool ParseData(string szParseData)
    {
        //local vars
        var strData = szParseData.Split("*");

        //Loop over for each of the tokens
        for (var tokenIdx = 0; tokenIdx < strData.Length; tokenIdx++)
        {
            switch (tokenIdx)
            {
                //Eat the first String - number of bytes in data set - eg. "1075"
                case 0:
                    GetNumBytes(strData);
                    break;

                //Puzzle ID  - eg. "QXW000000"
                case 1:
                    GetPuzzleIdAndType(strData);
                    break;

                //Number of Columns and Rows - eg. "0909"
                case 2:
                    GetColsAndRows(strData);
                    break;

                //Grid positions and Data for across and down numbers - eg. "0 0 1 1#6 0 1 4#3 2 1 6#0 3 1 8#3 5 1 11#0 6 1 13#0 8 1 15#4 8 1 16#1 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 6#5 2 2 7#7 4 2 9#0 5 2 10#4 5 2 12#2 6 2 14"
                case 3:
                    GetGridPositions(strData);
                    break;

                //Clues - eg. "Bread maker#Skill#Receive#Calm#Real#Taunts#Apple _ _ _#Midday meal#Irritate#Wealthy#Queen,King,__ __ __#Ballet skirt#Book of maps#100 make a dollar#Conjuring#Cease#Prison room#Length of life"
                case 4:
                    GetClues(strData);
                    break;

                //Answers - eg BAKER#ART#ACCEPT#SOOTHE#ACTUAL#TEASES#PIE#LUNCH#ANNOY#RICH#ACE#TUTU#ATLAS#CENTS#MAGIC#STOP#CELL#AGE
                case 5:
                    GetAnswers(strData);
                    break;

                //Hint letters - eg "ABCEGHIKLMNOPRSTUY"
                case 6:
                    GetHintLetters(strData);
                    break;

                //CyberSilver level costs & bonuses - eg. "30 1 1 0 1 5"
                case 7:
                    GetCybersilver(strData);
                    break;

                //Jim's crappy blurb - eg. "Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"
                case 8:
                    GetBlurb(strData);
                    break;
            }
        }

        return true;
    }
}