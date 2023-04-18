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
 *    - Classe          : inherits from Menu => manage the save menu of the game
 ************************************/
using noInternetDinoGame.game.events;
using noInternetDinoGame.template;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.menus
{
    public class Save : Menu
    {
        #region Variables
        private RecursivePath _recursivePath;               // Recursive path object
        private bool _isPathSelected = false;               // Define if the path is selected
        #endregion

        #region Getter Setter
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="buttons">Buttons on the menu</param>
        /// <param name="recursivePath">Object of the recursive path</param>
        public Save(List<string> buttons, RecursivePath recursivePath) : base(buttons)
        {
            _isPathSelected = false;
            _recursivePath = recursivePath;
        }
        #endregion

        #region Methods
        /// <summary>
        /// On the click of a button
        /// </summary>
        /// <param name="sender">Button clicked</param>
        public override void Button_onClick(object sender)
        {
            Console.Clear();
            List<string> btnNames;

            // Search a place to save file
            switch ((sender as Button).Name)
            {
                case "Rechercher":
                    // Search from desktop
                    _recursivePath.SearchFromDesktop();
                    break;
                case "C:/":
                    // Search from C://
                    _recursivePath.SearchFromC();
                    break;
                case "Emplacement actuel":
                    // Save the actual place of the program
                    _recursivePath.ActualPlace();
                    break;
                default:
                    // Check if it has a similar button clicked
                    foreach(string buttonName in _similarButtons)
                    {
                        if((sender as Button).Name == buttonName)
                        {
                            SimilarButtons_onClick(sender as Button);
                            break;
                        }
                    }

                    _recursivePath.SearchFromC((sender as Button).Name);
                    break;
            }
        }

        /// <summary>
        /// Set the path
        /// </summary>
        /// <param name="sender">Button clicked</param>
        /// <returns>Boolean value</returns>
        public override void Button_onSelect(object sender)
        {
            // return and set the value
            _recursivePath.ActualPath = (sender as Button).Name;
            if(_recursivePath.ActualPath != null)
            {
                _recursivePath.Save();   
            }
        }
        #endregion
    }
}
