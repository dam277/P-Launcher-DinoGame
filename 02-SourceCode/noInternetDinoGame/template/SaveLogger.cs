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
 *    - Classe          : inherits from Logger => manage the save logger to save the games scores
 ************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace noInternetDinoGame.template
{
    public class SaveLogger : Logger
    {
        private string _savePath;       // Path of the save file

        /// <summary>
        /// Display the log in a file
        /// </summary>
        /// <param name="log">Message</param>
        public override void DisplayLog(string log)
        {
            // NOTHING
        }

        /// <summary>
        /// Display the game save in a file
        /// </summary>
        /// <param name="save">Save message</param>
        public override void DisplaySave(string save, string savePath)
        {
            // Set path
            _savePath = savePath;

            // Set stringbuilder
            _text = new StringBuilder();

            // Check if the file saving the saves file exists
            if(!File.Exists("Path.txt"))
            {
                _streamWriter = new StreamWriter("Path.txt");
                _streamWriter.Write($@"{_savePath}\save.txt");
                _streamWriter.Close();
            }

            // get the save path
            _savePath = ReadFile("Path.txt");

            // Check if the saves file exists
            if (File.Exists(_savePath))
            {
                _text.AppendLine(ReadFile(_savePath));
            }

            // Write the log to the end
            _text.Append(save);

            // Write the saved game
            _streamWriter = new StreamWriter(_savePath);
            _streamWriter.WriteLine(_text);
            _streamWriter.Close();

        }

        /// <summary>
        /// Get the save file in an array
        /// </summary>
        /// <returns>Return the list of string of the save file</returns>
        public List<string> GetSaves()
        {
            // Results
            string[] result;
            string path;

            // Get save path
            if (File.Exists("Path.txt"))
            {
                // Get the path of the save file
                path = ReadFile("Path.txt");

                // Check if save file exists
                if(File.Exists(path))
                {
                    // Get the text and the lengh of the futur array
                    _text = new StringBuilder();
                    _text.Append(ReadFile(path));
                    result = _text.ToString().Split(";");

                    // Set the return list
                    List<string> saves = new List<string>();
                    foreach(string save in result)
                    {
                        if (save != "")
                        {
                            saves.Add(save);
                        }
                    }

                    return saves;
                }
            }

            return null;
        }
    }
}
