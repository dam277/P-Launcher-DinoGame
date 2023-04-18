using noInternetDinoGame.game.score;
using noInternetDinoGame.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.game
{
    public class ScoreBoard
    {
        #region Variables
        private int _score;     // Score of the game
        private int _time;      // Time of the game
        private int _speed;     // Speed of the game
        private Game _game;
        private List<Label> _labels;
        #endregion

        #region Getter Setter
        public Game Game
        {
            set { _game = value; }
        }
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public ScoreBoard()
        {
            _labels = new List<Label>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a label to the scoreboard which display a specific score or text
        /// </summary>
        /// <param name="score">Score for the label</param>
        /// <param name="text">text of the label</param>
        public void AddLabel(string text = "", string score = "")
        {
            _labels.Add(new Label(text, score));
        }

        /// <summary>
        /// Display the scoreboard
        /// </summary>
        private void Display()
        {
            Print.DisplayScoreBoard(this);
        }
        #endregion

    }
}
