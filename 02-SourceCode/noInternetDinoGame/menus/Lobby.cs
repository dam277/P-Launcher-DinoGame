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
 *    - Classe          : inherits from Menu => manage the lobby menu of the game
 ************************************/
using noInternetDinoGame.game;
using noInternetDinoGame.game.events;
using noInternetDinoGame.template;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace noInternetDinoGame.menus
{
    public class Lobby : Menu
    {
        #region Variables
        #endregion

        #region Getter Setter
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="buttons">List of buttons</param>
        public Lobby(List<string> buttons) : base(buttons)
        {

        }

        #endregion

        #region Methods
        /// <summary>
        /// On the click of a button
        /// </summary>
        /// <param name="sender">Button clicked</param>
        public override void Button_onClick(object sender)
        {
            // Clear console
            Console.Clear();
            List<string> btnNames;

            // Search what button was clicked
            switch ((sender as Button).Name)
            {
                case "Jouer":
                    Console.Write("Donnez un nom à votre partie : ");
                    Game game = new Game(Console.ReadLine());
                    game.PlaceDino();
                    game.Play();
                    break;
                case "Scores":
                    // Set the list
                    btnNames = new List<string>();

                    // Set scores
                    List<string> saves = new SaveLogger().GetSaves();

                    // Set the buttons
                    foreach (string save in saves)
                    {
                        btnNames.Add(save);
                    }
                    btnNames.Add("Retour");

                    // Setup score menu
                    Menu scores = new Scores(btnNames);

                    // Display the menu
                    scores.DisplayMenu(0);
                    break;
                case "Quitter":
                    Environment.Exit(0);
                    break;
                default:
                    SimilarButtons_onClick(sender as Button);
                    break;
            }
        }

        /// <summary>
        /// On the click of a button to select a path
        /// </summary>
        /// <param name="sender">Button clicked</param>
        public override void Button_onSelect(object sender)
        {
        }
        #endregion
    }
}
