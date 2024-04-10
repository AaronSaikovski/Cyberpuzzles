using System;
using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Puzzle.Squares;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitClueAnswers

    /// <summary>
    /// Inits the ClueAnswerMap objects
    /// </summary>
    private void InitClueAnswers()
    {
        try
        {
            _logger.LogInformation("Start InitClueAnswers()");

            //loop over the questions
            for (var i = 0; i < _numQuestions; i++)
            {
                //Need to build a temp object of sqAnswerSquares[]
                if (_puzzleDataset != null)
                {
                    var sqAnswerSquares = new Square?[_puzzleDataset[i].Answer.Length];
                    for (var j = 0; j < _puzzleDataset[i].Answer.Length; j++)
                    {
                        //Need to work out number
                        //Build the Clue/Answer sets
                        if (_puzzleDataset[i].IsAcross)
                        {
                            if (_sqPuzzleSquares != null)
                                sqAnswerSquares[j] =
                                    _sqPuzzleSquares[_puzzleDataset[i].CoordDown + j, _puzzleDataset[i].CoordAcross];
                            if (j == 0)
                                if (_lstClueAcross != null)
                                    _lstClueAcross.Items.Add(new ListItem(
                                        _puzzleDataset[i].QuestionNum + ". " + _puzzleDataset[i].Clue,
                                        Color.White));
                        }
                        else
                        {
                            if (_sqPuzzleSquares != null)
                                sqAnswerSquares[j] =
                                    _sqPuzzleSquares[_puzzleDataset[i].CoordDown, _puzzleDataset[i].CoordAcross + j];
                            if (j == 0)
                                if (_lstClueDown != null)
                                    _lstClueDown.Items.Add(new ListItem(
                                        _puzzleDataset[i].QuestionNum + ". " + _puzzleDataset[i].Clue,
                                        Color.White));
                        }
                    }

                    //Build the Clue/Answer references
                    if (_caPuzzleClueAnswers != null)
                    {
                        _caPuzzleClueAnswers[i] = new ClueAnswer();
                        _caPuzzleClueAnswers[i].SetObjectRef(_puzzleDataset[i].Answer,
                            _puzzleDataset[i].Clue, _puzzleDataset[i].QuestionNum,
                            _puzzleDataset[i].IsAcross, sqAnswerSquares);
                    }
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