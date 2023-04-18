using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.game.score
{
    public class Label
    {
        private string _text;       //Text of the label
        private int _score;         //Score of the label

        /// <summary>
        /// Public text
        /// </summary>
        public string Text
        {
            get { return _text; }
        }

        /// <summary>
        /// Public score
        /// </summary>
        public int Score
        {
            get { return _score; }
        }

        /// <summary>
        /// Full label class constructor
        /// </summary>
        /// <param name="text">Text of the label</param>
        /// <param name="score">Score of the label</param>
        public Label(string text, string score)
        {
            _text = text;
            Int32.TryParse(score, out _score);
        }
    }
}
