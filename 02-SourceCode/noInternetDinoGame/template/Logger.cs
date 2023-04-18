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
 *    - Classe          : Abstract inheritance => manage the different types of loggers
 ************************************/
using noInternetDinoGame.game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace noInternetDinoGame.template
{
    public abstract class Logger
    {
        protected StringBuilder _text;              // Text of the files
        protected StreamReader _streamReader;       // Stream reader to read files
        protected StreamWriter _streamWriter;       // Stream writer to write in files
        protected static Game _game;                // game object

        /// <summary>
        /// Public game object
        /// </summary>
        public static Game Game
        {
            set { _game = value; }
        }

        /// <summary>
        /// Display the log in a file
        /// </summary>
        /// <param name="log">Message</param>
        public abstract void DisplayLog(string log);

        /// <summary>
        /// Display the game save in a file
        /// </summary>
        /// <param name="save">Save message</param>
        public abstract void DisplaySave(string save, string savePath);

        /// <summary>
        /// Set log message
        /// </summary>
        /// <param name="message">Message</param>
        public void Log(string message)
        {
            DisplayLog($"[{DateTime.Now}] : {message}");
        }

        /// <summary>
        /// Set save message
        /// </summary>
        public void Save(string path)
        {
            DisplaySave($"name:{_game.Name},distance:{_game.Distance},died:{!_game.Dino.IsAlive};", path);
        }

        /// <summary>
        /// Get the path of a file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>String of the path</returns>
        protected string ReadFile(string path)
        {
            // Open the streamReader and return the text in
            _streamReader = new StreamReader(path);
            string savePath = _streamReader.ReadToEnd();
            _streamReader.Close();

            return savePath;
        }
    }
}
