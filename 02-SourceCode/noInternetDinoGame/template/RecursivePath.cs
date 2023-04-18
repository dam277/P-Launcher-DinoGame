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
 *    - Classe          : Check recursivly in the searched path the folders to finally save a file, etc...
 ************************************/
using noInternetDinoGame.menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace noInternetDinoGame.template
{
    public class RecursivePath
    {
        private string _actualPath;             // Actual path
        private List<string> _repositorys;      // Possible repositorys can be opened

        /// <summary>
        /// Public path
        /// </summary>
        public string ActualPath
        {
            get { return _actualPath; }
            set { _actualPath = value; }
        }

        /// <summary>
        /// Public Repositorys
        /// </summary>
        public List<string> Repositorys
        {
            get { return _repositorys; }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public RecursivePath(Type type)
        {
            // Check the type of content
            switch(type)
            {
                case Type.SAVE:
                    // Set the lists
                    List<string> btnNames = new List<string>()
                    {
                    "Rechercher", "C:/", "Emplacement actuel", "Retour"
                    };

                    // Create the lobby
                    Menu save = new Save(btnNames, this);
                    save.DisplayMenu();
                    break;
            }
        }

        /// <summary>
        /// Save at actual place
        /// </summary>
        public void ActualPlace()
        {
            _actualPath = Path.GetFullPath("$/../");
        }

        /// <summary>
        /// Save and search from C:/
        /// </summary>
        /// <param name="path">Path of the folder</param>
        public void SearchFromC(string path = "C:/")
        {
            RecursiveSearch(path);
        }

        /// <summary>
        /// Save and search with text
        /// </summary>
        /// <param name="path">path of the folder</param>
        public void SearchFromDesktop(string path = "")
        {
            // Get the path of the desktop
            if (path == "")
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            RecursiveSearch(path);
        }

        /// <summary>
        /// Check all the folders to save
        /// </summary>
        /// <param name="newPath">New path used</param>
        private void RecursiveSearch(string newPath)
        {
            // Reset
            Console.Clear();
            _repositorys = new List<string>();

            // Check for exeption
            try
            {
                // Set dir infos
                DirectoryInfo dir = new DirectoryInfo(newPath);
                foreach (DirectoryInfo directory in dir.GetDirectories())
                {
                    _repositorys.Add(directory.FullName);
                }
                _repositorys.Add("/../");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Set logs
                new FileLogger().Log(ex.Message);
                Console.WriteLine("Ce répértoire n'est pas accessible");

                // Return to menu
                List<string> btnNames = new List<string>()
                {
                    "Retour"
                };

                // Display mainmenu
                Menu exit = new Save(btnNames, this);
                exit.DisplayMenu();
            }

            // Display the new folders
            Menu menu = new Save(_repositorys, this);
            menu.DisplayMenu(0);
        }

        /// <summary>
        /// Save the file in the selected emplacement
        /// </summary>
        public void Save()
        {
            new SaveLogger().Save(_actualPath);
        }
    }
}
