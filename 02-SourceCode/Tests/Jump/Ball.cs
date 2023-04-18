using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jump
{
    public class Ball
    {
        private readonly string _model = "O";       // Model of the ball
        private int _x;                             // Position X of the ball
        private int _y;                             // Position Y of the ball
                                                
        private Vector2D _gravity;                  // Gravity of the ball
        private Vector2D _jump;                     // Jump vector of the ball

        private bool _isAlive = true;               // Check if the ball is alive       
        private bool _isJumping = false;            // Check if the ball is jumping

        private const int STRENGHT = 5;             // Strengh of the ball for the jump
        
        /// <summary>
        /// Public strenght of the ball
        /// </summary>
        public int Strenght
        {
            get { return STRENGHT; }
        }

        /// <summary>
        /// Public isJumping 
        /// </summary>
        public bool IsJumping
        {
            get { return _isJumping; }
        }

        /// <summary>
        /// Public isJumping 
        /// </summary>
        public bool IsAlive
        {
            get { return _isAlive; }
        }

        /// <summary>
        /// Public gravity
        /// </summary>
        public Vector2D Gravity
        {
            get { return _gravity; }
        }

        /// <summary>
        /// Public jump
        /// </summary>
        public Vector2D Jump
        {
            get { return _jump; }
        }

        /// <summary>
        /// Public positon X of the ball
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Public positon Y of the ball
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Public model of the ball
        /// </summary>
        public string Model
        {
            get { return _model; }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public Ball()
        {
            _x = 50;
            _y = 25;
            _gravity = new Vector2D(new Point(this._x, this._y), new Point(this._x, this._y + 1));
        }

        /// <summary>
        /// Get the jump vector
        /// </summary>
        /// <param name="intensity">Intensity of the jump</param>
        public void SetJump(int intensity)
        {
            _jump = Vector2D.GetVector(intensity, this._x, this._y);
            _isJumping = true;
        }

        /// <summary>
        /// Move
        /// </summary>
        public async Task JumpMovement()
        {
            // Run new task
            await Task.Run(() =>
            {
                // Move the ball while she's not dead
                while (_isAlive)
                {
                    // Check if the object of the jump is null
                    if (_jump != null)
                    {
                        // Make jump the ball
                        int jumpIntensity = _jump.Intensity;
                        int counter = 1;
                        bool goUp = true;

                        // Move while the ball is jumping
                        do
                        {
                            _y -= jumpIntensity;    // Intensity of the ball

                            // Move the ball
                            Console.MoveBufferArea(this.X, this.Y + jumpIntensity, 1, 1, this.X, this.Y);
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

                            // Set the goUp variable if the ball is at the end of the vector
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
    }
}
