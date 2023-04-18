/************************************
 * Projet               : P_DinoGame
 * Lieu                 : Lausanne         
 * Etablissement        : ETML             
 * Classe               : CID3             
 * Auteur               : Damien Loup   
 * Date           
 *    - Création        : 07.09.2022
 *    - Modification    : 26.09.2022
 * Description                
 *    - Classe          : Abstract inheritance => manage the different menus of the game
 ************************************/

using noInternetDinoGame.game;
using noInternetDinoGame.game.events;
using noInternetDinoGame.utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace noInternetDinoGame.menus
{
    public abstract class Menu
    {
        #region Variables
        protected Dictionary<string ,Button> _buttons = new Dictionary<string, Button>();   // Buttons of the actual menu
        protected List<string> _btnNames;                                                   // List of the names of the buttons
        protected int _choice = 0;                                                          // Actual choice in the menu
        protected List<string> _similarButtons = new List<string>()                         // List of the similar buttons in different menus
        {
            "Retour"
        };
        #endregion

        #region Getter Setter
        /// <summary>
        /// Public dictionnary of buttons
        /// </summary>
        public Dictionary<string ,Button> Buttons
        {
            get { return _buttons; }
        }
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="buttons">List of buttons</param>
        /// <param name="select">Select event</param>
        public Menu(List<string> buttons, bool select = false)
        {
            // Set the list of buttons
            _btnNames = new List<string>();
            _btnNames = buttons;

            // Create the buttons
            for (int i = 0; i < buttons.Count; i++)
            {
                Button button = new Button(buttons[i]);

                // Set events
                button.onClick += Button_onClick;
                button.onSelect += Button_onSelect;
                
                _buttons.Add(button.Name, button);
            }
        }
        #endregion

        #region Methods
        #region Events
        /// <summary>
        /// On the click of a button
        /// </summary>
        /// <param name="sender">Button clicked</param>
        public abstract void Button_onClick(object sender);

        /// <summary>
        /// On the click of a button to select a path
        /// </summary>
        /// <param name="sender">Button clicked</param>
        public abstract void Button_onSelect(object sender);

        /// <summary>
        /// On the click of a smilare button in an other menu
        /// </summary>
        /// <param name="sender">Button clicked</param>
        protected void SimilarButtons_onClick(object sender)
        {
            Console.Clear();
            List<string> btnNames;

            switch ((sender as Button).Name)
            {
                case "Retour":
                    // Set the list
                    btnNames = new List<string>()
                    {
                    "Jouer", "Scores", "Quitter"
                    };

                    // Create the lobby
                    Menu lobby = new Lobby(btnNames);
                    lobby.DisplayMenu();
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Display the principal menu
        /// </summary>
        /// <param name="offset">Offset to the menu between the buttons</param>
        public void DisplayMenu(int offset = 5)
        {
            List<string> buttonsName = new List<string>();

            // Get the buttons names
            foreach (string btnName in _buttons.Keys)
            {
                buttonsName.Add(btnName);
            }

            // Select button
            do
            {
                // Set position
                Console.SetCursorPosition(0, 1);

                //Display menu buttons
                Print.MenuButtons(buttonsName, _buttons.Count, true, TextHeight.MIDDLE, TextWidth.CENTER, offset, _choice);

                //ConsoleKey which defines what button will be active 
                ConsoleKey consoleKey = Console.ReadKey().Key;
                if (consoleKey == ConsoleKey.DownArrow && _choice < _buttons.Count - 1)
                {
                    _choice++;
                }
                else if (consoleKey == ConsoleKey.UpArrow && _choice > 0)
                {
                    _choice--;
                }
                else if (consoleKey == ConsoleKey.Enter)
                {
                    // event of the button
                    _buttons[_btnNames[_choice]].ButtonClick();

                    _choice = 0;
                }
                else if(consoleKey == ConsoleKey.Spacebar)
                {
                    _buttons[_btnNames[_choice]].ButtonSelect();
                }
            }while(true);
        }
        #endregion
    }
}
