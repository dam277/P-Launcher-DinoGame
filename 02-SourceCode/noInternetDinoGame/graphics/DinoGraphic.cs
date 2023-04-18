using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.graphics
{
    public class DinoGraphic
    {
        #region Properties
        private static int _dinoH = 3;      // Height of dino
        private static int _dinoW = 1;      // Width of dino

        /// <summary>
        /// Model of the bunker full life
        /// </summary>
        private string _dino = "▄;" +
                               "╠;" +
                               "╩";
        #endregion

        #region Getters Setters
        /// <summary>
        /// Public height of Dino
        /// </summary>
        public static int DinoH
        {
            get { return _dinoH; }
        }

        /// <summary>
        /// Public width of Dino
        /// </summary>
        public static int DinoW
        {
            get { return _dinoW; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Basic class constructor
        /// </summary>
        public DinoGraphic()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the dino
        /// </summary>
        /// <returns>Return the model of the dino</returns>
        public string GetDino()
        {
            return _dino;
        }
        #endregion
    }
}
