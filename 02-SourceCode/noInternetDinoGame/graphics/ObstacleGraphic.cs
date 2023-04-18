using noInternetDinoGame.game.gameObjects.obstacles;
using noInternetDinoGame.singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.graphics
{
    public class ObstacleGraphic
    {
        #region Properties
        // Wall

        /// <summary>
        /// Design of the wall
        /// </summary>
        private string _wallDesign = "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|" +
                                     "|";
        private static int _wallHeight = 20;       // Wall height
        private static int _wallWidth = 1;         // Wall width

        // Bird

        /// <summary>
        /// Design of the bird
        /// </summary>
        private string _birdDesign = "╚╬";
        private static int _birdHeight = 1;        // Bird height
        private static int _birdWidth = 2;         // Bird width

        // Cactus

        /// <summary>
        /// Design of the cactus
        /// </summary>
        private string _cactusDesign = "╬;" +
                                       "║";
        private static int _cactusHeight = 2;      // Cactus height
        private static int _cactusWidth = 1;       // Cactus width
        #endregion

        #region Getter Setter
        // Wall

        /// <summary>
        /// Public wall height
        /// </summary>
        public static int WallHeight
        {
            get { return _wallHeight; }
        }

        /// <summary>
        /// Public wall width
        /// </summary>
        public static int WallWidth
        {
            get { return _wallWidth; }
        }

        // Bird

        /// <summary>
        /// Public bird height
        /// </summary>
        public static int BirdHeight
        {
            get { return _birdHeight; }
        }

        /// <summary>
        /// Public bird width
        /// </summary>
        public static int BirdWidth
        {
            get { return _birdWidth; }
        }

        // Cactus

        /// <summary>
        /// Public cactus height
        /// </summary>
        public static int CactusHeight
        {
            get { return _cactusHeight; }
        }

        /// <summary>
        /// Public cactus width
        /// </summary>
        public static int CactusWidth
        {
            get { return _cactusWidth; }
        }

        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public ObstacleGraphic()
        {

        }
        #endregion

        #region Methods
        /// /// <summary>
        /// Get an obstacle graphic
        /// </summary>
        /// <param name="obstacle">Obstacle received</param>
        /// <returns>Return the specified obstacle</returns>
        public string GetObstacle(Obstacle obstacle)
        {             
            // Get the obstacle
            if(obstacle is Wall)
            {
                return _wallDesign;
            }
            else if(obstacle is Bird)
            {
                return _birdDesign;
            }
            else if(obstacle is Cactus)
            {
                return _cactusDesign;
            }

            return null;
        }
        #endregion
    }
}