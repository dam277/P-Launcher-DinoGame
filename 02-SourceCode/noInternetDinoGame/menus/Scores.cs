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
 *    - Classe          : inherits from Menu => manage the scores menu of the game
 ************************************/
using noInternetDinoGame.game.events;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.menus
{
    public class Scores : Menu
    {
        #region Variables
        #endregion

        #region Getter Setter
        #endregion

        #region Class constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="buttons">Buttons name</param>
        public Scores(List<string> buttons) : base(buttons)
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
            // Search what button was clicked
            switch ((sender as Button).Name)
            {
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
