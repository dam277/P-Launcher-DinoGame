using noInternetDinoGame.game.physic;
using noInternetDinoGame.graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace noInternetDinoGame.game.gameObjects
{
    public class Dino
    {
        #region Variables
        // Int
        private int _x;                             // Position X of the dino
        private int _y;                             // Position Y of the dino

        // String
        private string _model;                      // Model of the dino

        // Objects
        private Vector2D _gravity;                  // Gravity of the dino
        private Vector2D _jump;                     // Jump vector of the dino

        // Boolean
        private bool _isAlive = true;               // Check if the dino is alive       
        private bool _isJumping = false;            // Check if the dino is jumping

        // Const
        private const int STRENGHT = 4;             // Strengh of the dino for the jump
        #endregion

        #region Getter Setter
        /// <summary>
        /// Public position X of the dino
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Public position Y of the dino
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Public model of dino
        /// </summary>
        public string Model
        {
            get { return _model; }
        }

        /// <summary>
        /// Public is dino alive
        /// </summary>
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        /// <summary>
        /// Public is dino jumping 
        /// </summary>
        public bool IsJumping
        {
            get { return _isJumping; }
        }

        /// <summary>
        /// Public strenght of the jump
        /// </summary>
        public int Strenght
        {
            get { return STRENGHT; }
        }
        #endregion

        #region Class constructor
        /// <summary>
        /// Dino class constructor
        /// </summary>
        public Dino()
        {
            _x = Console.WindowWidth / 2;
            _y = Console.WindowHeight / 3;
            _gravity = new Vector2D(new Point(this._x, this._y), new Point(this._x, this._y + 1));
            _model = new DinoGraphic().GetDino();
        }
        #endregion

        #region Methods
        // <summary>
        /// Get the jump vector
        /// </summary>
        /// <param name="intensity">Intensity of the jump</param>
        public void SetJump()
        {
            _jump = Vector2D.GetVector(STRENGHT, this._x, this._y);
            _isJumping = true;
        }
        #region Events

        /// <summary>
        /// make jump the dino
        /// </summary>
        public async Task JumpMovement()
        {
            // Run new task
            await Task.Run(() =>
            {
                // Move the dino while she's not dead
                while (_isAlive)
                {
                    // Check if the object of the jump is null
                    if (_jump != null && _isJumping)
                    {
                        // Make jump the dino
                        int jumpIntensity = _jump.Intensity;
                        int counter = 1;
                        bool goUp = true;

                        // Move while the dino is jumping
                        do
                        {
                            _y -= jumpIntensity;    // Intensity of the dino

                            // Move the dino
                            Console.MoveBufferArea(this._x, this._y + jumpIntensity, DinoGraphic.DinoW, DinoGraphic.DinoH, this._x, this._y);
                            Thread.Sleep(counter * 50);

                            // Set time between each place
                            if (goUp)
                            {
                                counter++;
                            }
                            else
                            {
                                counter--;
                            }

                            // Set the goUp variable if the dino is at the end of the vector
                            if (_y == _jump.End.Y)
                            {
                                goUp = false;
                            }

                            // lower the intensity
                            jumpIntensity--;
                        } while (_y != _jump.Start.Y);

                        // Set the jump to null
                        _isJumping = false;
                        _jump = null;
                    }
                }
            });
        }
        #endregion

        #endregion
    }
}
