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
 *    - Classe          : inherits from Logger => manage the file logger to set error messages, etc...
 ************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace noInternetDinoGame.template
{
    public class FileLogger : Logger
    {
        private readonly string _path = "logs.txt";          // Path of the logs

        /// <summary>
        /// Save a log
        /// </summary>
        /// <param name="log">Log message</param>
        public override void DisplayLog(string log)
        {
            // Set stringbuilder
            _text = new StringBuilder();

            // Check if the file exists
            if(File.Exists(_path))
            {
                _streamReader = new StreamReader(_path);
                _text.AppendLine(_streamReader.ReadToEnd());
                _streamReader.Close();
            }

            // Write the log at the end
            _text.Append(log);

            // Write the text in a file
            _streamWriter = new StreamWriter(_path);
            _streamWriter.Write(_text);
            _streamWriter.Close();
        }

        /// <summary>
        /// Display the game save in a file
        /// </summary>
        /// <param name="save">Save message</param>
        public override void DisplaySave(string save, string savePath)
        {
            // NOTHING
        }
    }
}
