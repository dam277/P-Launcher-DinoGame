namespace Jump
{
    public class Game
    {
        private Ball _ball;         // Ball object

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game()
        {
            _ball = new Ball();
        }

        /// <summary>
        /// Place the ball on the console
        /// </summary>
        public void PlaceBall()
        {
            Console.SetCursorPosition(_ball.X, _ball.Y);
            Console.WriteLine(_ball.Model);
        }

        /// <summary>
        /// Play the game
        /// </summary>
        public void Play()
        {
            _ball.JumpMovement();

            while(_ball.IsAlive)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar && _ball.IsJumping == false)
                {
                    _ball.SetJump(_ball.Strenght);
                }
            }
        }
    }
}
