using noInternetDinoGame.graphics;
using noInternetDinoGame.singleton;
using noInternetDinoGame.utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace noInternetDinoGame.game.gameObjects.obstacles
{
    public class Obstacle
    {
        #region Variables
        protected int _id;                           // Id of the obstacle
        protected int _y;                            // PosY of the obstacle
        protected int _x;                            // PosX of the obstacle
        protected string _model;                     // Design of the obtsacle
        private static List<object> _obstacles;      // List of the obstacles
        protected Game _game;
        #endregion

        #region Getter Setter
        /// <summary>
        /// Public game of the obstacles
        /// </summary>
        public Game Game
        {
            set { _game = value; }
        }

        /// <summary>
        /// Public PosY of the obstacle
        /// </summary>
        public int Y
        {
            get { return _y; }
            private set { _y = value; }
        }

        /// <summary>
        /// Public PosX of the obstacle
        /// </summary>
        public int X
        {
            get { return _x; }
            private set { _x = value; }
        }

        /// <summary>
        /// Public Design of the obstacle
        /// </summary>
        public string Model
        {
            get { return _model; }
            private set { _model = value; }
        }
        #endregion

        #region Class constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="posY">Pos Y of the obstacle</param>
        /// <param name="posX">Pos X of the obstacle</param>
        public Obstacle(int posY, int posX)
        {
            _y = posY - GetObstacleSpecification()["addY"];
            _x = posX - 3;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Move the obstacle
        /// </summary>
        /// <param name="speed">Speed of the game</param>
        public async Task Move(int speed)
        {
            await Task.Run(() =>
            {
                // Display the obstacle model
                Print.DisplayModels(this);

                // Move the obstacle to the left while he's not out of the console
                while (this._x > 0 && _game.Dino.IsAlive)
                {
                    this._x -= 1;
                    Console.MoveBufferArea(this._x + 1, this._y, GetObstacleSpecification()["width"], GetObstacleSpecification()["height"], this._x, this._y);
                    Thread.Sleep(speed);

                    // Check if an obstacle touch the dino
                    if ((_game.Dino.X == this._x || _game.Dino.X == this.X + GetObstacleSpecification()["width"]) && (this.Y - GetObstacleSpecification()["height"] >= _game.Dino.Y - DinoGraphic.DinoH && this.Y <= _game.Dino.Y))
                    {
                        _game.Dino.IsAlive = false;
                    }
                }

                // Delete de the obstacle model
                Print.DeleteModels(this);
            });
        }

        /// <summary>
        /// Get the specifications of a specific obstacle (width and height)
        /// </summary>
        /// <returns>Dictionary of string, int</returns>
        private Dictionary<string, int> GetObstacleSpecification()
        {
            Dictionary<string, int> obstacleSpecification = new Dictionary<string, int>();  
            if (this is Bird)
            {
                obstacleSpecification.Add("width", ObstacleGraphic.BirdWidth);
                obstacleSpecification.Add("height", ObstacleGraphic.BirdHeight);
                obstacleSpecification.Add("addY", 5);      // Number to add to Y on display
            }
            else if (this is Cactus)
            {
                obstacleSpecification.Add("width", ObstacleGraphic.CactusWidth);
                obstacleSpecification.Add("height", ObstacleGraphic.CactusHeight);
                obstacleSpecification.Add("addY", 0);      // Number to add to Y on display
            }
            else if (this is Wall)
            {
                obstacleSpecification.Add("width", ObstacleGraphic.WallWidth);
                obstacleSpecification.Add("height", ObstacleGraphic.WallHeight);
                obstacleSpecification.Add("addY", 0);      // Number to add to Y on display
            }

            return obstacleSpecification;
        }

        /// <summary>
        /// Get a random obstacle
        /// </summary>
        /// <param name="x">Position X of the obstacle</param>
        /// <param name="y">Position Y of the obstacle</param>
        /// <returns>Return an obstacle</returns>
        public static Obstacle GetObstacle(int x, int y)
        {
            // Set the list
            _obstacles = new List<object>();

            // Create objects of obstacles with the default constructor (id)
            Bird tempBird = new Bird(y, x);
            Cactus tempCactus = new Cactus(y, x);
            Wall tempWall = new Wall(y, x);
            
            // Add to the list
            _obstacles.Add(tempBird);
            _obstacles.Add(tempCactus);
            //_obstacles.Add(tempWall);

            // get a random
            int randObstacle = RandSingleton.GetInstance().RandomObject.Next(_obstacles.Count);
            return _obstacles[randObstacle] as Obstacle;
        }
        #endregion
    }
}
