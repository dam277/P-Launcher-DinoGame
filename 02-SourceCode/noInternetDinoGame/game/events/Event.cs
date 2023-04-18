using noInternetDinoGame.game.events.delegates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace noInternetDinoGame.game.events
{
    /// <summary>
    /// Movements events class
    /// </summary>
    public class Movement
    {
        // Events
        private event Jump _jump;            // Jump event
        private event Crouch _crouch;        // Crouch event
        private Game _game;

        public Game Game
        {
            set { _game = value; }
        }

        /// <summary>
        /// Public jump event
        /// </summary>
        public event Jump Jump
        {
            add { _jump = value; }
            remove { _jump = value; }
        }

        /// <summary>
        /// Public crouch event
        /// </summary>
        public event Crouch Crouch
        {
            add { _crouch = value; }
            remove { _crouch = value; }
        }

        /// <summary>
        /// Invoke the move from the event
        /// </summary>
        /// <returns>Task</returns>
        public async Task GetMove()
        {
            await Task.Run(() =>
            {
                while (_game.Dino.IsAlive)
                {
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    if (consoleKey == ConsoleKey.UpArrow)
                    {
                        _jump.Invoke();
                    }
                    else if (consoleKey == ConsoleKey.DownArrow)
                    {
                        _crouch.Invoke();
                    }
                }
            });
        }
    }

    /// <summary>
    /// Button events class
    /// </summary>
    public class Button
    {
        // Variables
        private string _name;           // Name of the button

        // Events
        public event Click onClick;     // On the click of a button
        public event Select onSelect;   // On a selection of a button

        /// <summary>
        /// Public button name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name of the button</param>
        public Button(string name)
        {
            _name = name;
        } 

        /// <summary>
        /// Invoke the click event
        /// </summary>
        public virtual void ButtonClick()
        {
            this.onClick?.Invoke(this);
        }

        /// <summary>
        /// Invoke the select event
        /// </summary>
        public virtual void ButtonSelect()
        {
            this.onSelect?.Invoke(this);
        }
    }
}
