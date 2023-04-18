using noInternetDinoGame.game.events;
using noInternetDinoGame.game.gameObjects;
using noInternetDinoGame.game.gameObjects.obstacles;
using noInternetDinoGame.game.score;
using noInternetDinoGame.graphics;
using noInternetDinoGame.singleton;
using noInternetDinoGame.template;
using noInternetDinoGame.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading;

namespace noInternetDinoGame.game
{
    public class Game
    {
        #region Variables
        // Console
        private int _consoleWidth;      // Console width
        private int _consoleHeight;     // Console height

        // Game progress
        private int _speed;             // Game speed
        private int _time;              // Game time
        private int _distance;          // Game distance
        private string _name;           // Game name

        // Objects
        GroundGraphic _groundGraphics;  // Ground
        private Dino _dino;             // Dinosaure
        private ScoreBoard _board;      // Scoreboard
        #endregion

        #region Getter Setter
        /// <summary>
        /// Public game Speed
        /// </summary>
        public int Speed
        {
            get { return _speed; }
        }

        /// <summary>
        /// Public game Time
        /// </summary>
        public int Time
        {
            get { return _time; }
        }

        /// <summary>
        /// Public game Distance
        /// </summary>
        public int Distance
        {
            get { return _distance; }
        }

        /// <summary>
        /// Public game Name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Public dino object
        /// </summary>
        public Dino Dino
        {
            get { return _dino; }
        }
        #endregion

        #region Class constructor
        /// <summary>
        /// Game constructor
        /// </summary>
        /// <param name="name">Name of the game</param>
        public Game(string name = "New game")
        {
            // Set variables
            _name = name;
            _speed = 25;
            _time = 0;
            _consoleWidth = Console.LargestWindowWidth;
            _consoleHeight = Console.LargestWindowHeight;
            SetupGame();
            _dino = new Dino();
            _board = new ScoreBoard();
            _board.Game = this;
            Logger.Game = this;
            GameEvents();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Setup the game
        /// </summary>
        private void SetupGame()
        {
            // Setup the console
            Console.CursorVisible = false;
            Console.SetWindowSize(_consoleWidth, _consoleHeight);
            Console.SetWindowPosition(0, 0);
        }

        /// <summary>
        /// Set the event of the game
        /// </summary>
        private void GameEvents()
        {
            // Set the events of the dino
            Movement movements = new Movement();
            movements.Jump += Movements_Jump;
            movements.Crouch += Movements_Crouch;
            movements.Game = this;
            movements.GetMove();

            //RecursivePath recursivePath = new RecursivePath(template.Type.SAVE);
        }
        
        /// <summary>
        /// Place de dino on the console
        /// </summary>
        public void PlaceDino()
        {
            Console.SetCursorPosition(_dino.X, _dino.Y);
            Print.DisplayModels(_dino);
        }

        /// <summary>
        /// Play the game
        /// </summary>
        public void Play()
        {
            // New graphics
            _groundGraphics = new GroundGraphic(_dino.Y);

            // Get the dino first Y pos
            int posy = _dino.Y;

            // Get groud for the whole width
            for (int i = 0; i < _consoleWidth - 1; i++)
            {
                // Set the entire ground
                _groundGraphics.SetGround(false);
            }

            // Use an async method to get the jumps of the dino while playing
            _dino.JumpMovement();


            // Game
            int spawnCounter = 0;
            while (_dino.IsAlive)
            {
                // Ground
                int groundCounter = 0;
                foreach (string groundPart in _groundGraphics.Ground)
                {
                    Console.SetCursorPosition(groundCounter, _groundGraphics.Y + DinoGraphic.DinoH);
                    Console.Write(groundPart);
                    groundCounter++;
                }
                _groundGraphics.SetGround(true);

                // Get an obstacle
                if (RandSingleton.GetInstance().RandomObject.Next(10, 200) < spawnCounter)
                {
                    // Reset counter
                    spawnCounter = 0;
                    Obstacle obstacle = Obstacle.GetObstacle(_consoleWidth, posy);
                    obstacle.Game = this;
                    obstacle.Move(_speed);
                }
                // Increment counter
                spawnCounter++;

                // Speed
                Thread.Sleep(_speed);
            }
        }

        /// <summary>
        /// Make crouch the dino
        /// </summary>
        private void Movements_Crouch()
        {
            // TODO
        }

        /// <summary>
        /// Make jump the dino
        /// </summary>
        private void Movements_Jump()
        {
            // Check if the dino is jumping or not
            if (!_dino.IsJumping)
            {
                _dino.SetJump();
            }
        }

        #endregion
    }
}
