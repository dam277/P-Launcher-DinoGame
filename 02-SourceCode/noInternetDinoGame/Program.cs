/************************************
 * Lieu           : Lausanne         
 * Etablissement  : ETML             
 * Classe         : CID2             
 * Auteur         : Damien Loup      
 * Description                
 *    - Programme : P-SpicyInvader - Créer un Space invader en version console
 *    - Classe    : Partie principale du programme              
 ************************************/

using noInternetDinoGame.game.events;
using noInternetDinoGame.menus;
using System;
using System.Collections.Generic;

namespace noInternetDinoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MainMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void MainMenu()
        {
            // Set the list
            List<string> btnNames = new List<string>()
            {
            "Jouer", "Scores", "Quitter"
            };

            // Create the lobby
            Menu lobby = new Lobby(btnNames);
            lobby.DisplayMenu();
        }
    }
}


#region Variables
#endregion

#region Getter Setter
#endregion

#region Class constructor
#endregion

#region Methods
#endregion