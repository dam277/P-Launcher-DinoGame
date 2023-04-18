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
 *    - Classe          : Singleton => manage the creation of a random number at every single time we need
 ************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.singleton
{
    public class RandSingleton
    {
        private static RandSingleton _instance;     // Instance of the singleton
        private Random _randomObject;               // Random object

        /// <summary>
        /// Public random
        /// </summary>
        public Random RandomObject
        {
            get
            {
                return _randomObject;
            }
            set
            {
                _randomObject = value;
            }
        }

        /// <summary>
        /// Singleton class constructor
        /// </summary>
        private RandSingleton()
        {
            RandomObject = new Random();
        }

        /// <summary>
        /// Get the instance of the singleton
        /// </summary>
        /// <returns>Return the instance of the singleton</returns>
        public static RandSingleton GetInstance()
        {
            // Define if the instance is null or not
            if (_instance == null)
            {
                _instance = new RandSingleton();
            }

            return _instance;
        }
    }
}
