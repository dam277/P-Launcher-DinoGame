using noInternetDinoGame.graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.game.gameObjects.obstacles
{
    public class Wall : Obstacle
    {
        #region Variables
        #endregion

        #region Getter Setter
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="posY">Pos Y of the obstacle</param>
        /// <param name="posX">Pos X of the obstacle</param>
        public Wall(int posY, int posX) : base(posY, posX)
        {
            _model = new ObstacleGraphic().GetObstacle(this);
            _id = 2;
        }
        #endregion

        #region Methods
        #endregion
    }
}
