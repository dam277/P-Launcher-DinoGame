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
 *    - Classe          : Custom printer which write text with custom positions
 ************************************/
using noInternetDinoGame.game;
using noInternetDinoGame.game.gameObjects;
using noInternetDinoGame.game.gameObjects.obstacles;
using System;
using System.Collections.Generic;
using System.Text;
using noInternetDinoGame.game.score;

namespace noInternetDinoGame.utils
{
    public static class Print
    {
        /// <summary>
        /// Write text
        /// </summary>
        /// <param name="text">Text which will be display</param>
        public static void OneLine(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Display simple text in a any position
        /// </summary>
        /// <param name="x">Position X of the text</param>
        /// <param name="y">Position Y of the text</param>
        /// <param name="text">Text which will be write</param>
        public static void PrintLn(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Display the scoreBoard
        /// </summary>
        /// <param name="scoreBoard">Scoreboard object</param>
        public static void DisplayScoreBoard(ScoreBoard scoreBoard)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Display line
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                PrintLn("_", i, Console.WindowHeight - 20);
            }

            //Display informations
            //LoopList(scoreBoard.Labels, scoreBoard.Labels.Count, true, game.Border + 9, 5, 1);
        }

        /// <summary>
        /// Display a menu
        /// </summary>
        /// <param name="text">Text which will be display</param>
        /// <param name="forNumber">number of turns the loop will perform</param>
        /// <param name="line">Define if the text will display line per line or not</param>
        /// <param name="currentChoice">Current choice of the menu</param>
        /// <param name="textHeight">height of the text</param>
        /// <param name="textWidth">Width of the text</param>
        /// <param name="setOffset">Offset of the text</param>
        public static void MenuButtons(List<string> text, int forNumber, bool line, TextHeight textHeight, TextWidth textWidth, int setOffset, int currentChoice)
        {
            // Reset variables
            int counter = 0;
            int posY = 0;
            int posX = 0;
            int offset = (setOffset == 0) ? 1 : setOffset;

            for (int i = 0; i < forNumber; i++)
            {
                // Set the positions 
                // Height
                switch(textHeight)
                {
                    case TextHeight.TOP:
                        posY = 0;
                        break;
                    case TextHeight.MIDDLE:
                        posY = Console.WindowHeight / 2 - (text.Count * offset) / 2;
                        break;
                    case TextHeight.BOTTOM:
                        posY = Console.WindowHeight;
                        break;
                }

                // Width
                switch(textWidth)
                {
                    case TextWidth.LEFT:
                        posX = 0;
                        break;
                    case TextWidth.CENTER:
                        posX = Console.WindowWidth / 2 - text[i].Length / 2;
                        break;
                    case TextWidth.RIGHT:
                        posX = Console.WindowWidth;
                        break;
                }

                // Set the cursor position
                if(posY < 0)
                {
                    posY = 0;
                }
                Console.SetCursorPosition(posX, posY + counter);

                // Chose the color of the current button
                if (currentChoice == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Write the text from the current choice
                if (line == true)
                {
                    Console.WriteLine(text[i]);
                }
                else
                {
                    Console.Write(text[i] + " ");
                }

                counter += (1 + setOffset);
            }
        }


        /// <summary>
        /// Display a model of any character
        /// </summary>
        /// <param name="sender">Object of any character</param>
        public static void DisplayModels(object sender)
        {

            //Put the ligns of the model into six lines of a table and check what is the object
            string[] pixels = new string[0];
            if (sender is Dino)
            {
                pixels = (sender as Dino).Model.Split(';');
            }
            else if (sender is Obstacle)
            {
                pixels = (sender as Obstacle).Model.Split(';');
            }

            //Display line per line the object and put him some colors sometimes
            for (int i = 0; i < pixels.Length; i++)
            {
                if (sender is Dino && i == pixels.Length - 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (sender is Obstacle)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (sender is Dino)
                {
                    PrintLn(pixels[i], (sender as Dino).X, (sender as Dino).Y + i);
                }
                else if (sender is Obstacle)
                {
                    PrintLn(pixels[i], (sender as Obstacle).X, (sender as Obstacle).Y + i);
                }
            }

        }

        /// <summary>
        /// Delete a model of any character
        /// </summary>
        /// <param name="sender">Object of any character</param>
        public static void DeleteModels(object sender)
        {
            //Put the ligns of the model into six lines of a table and check what is the object
            string[] pixels = new string[0];
            if (sender is Dino)
            {
                pixels = (sender as Dino).Model.Split(';');
            }
            else if (sender is Obstacle)
            {
                pixels = (sender as Obstacle).Model.Split(';');
            }

            //Delete line per line the object
            for (int i = 0; i < pixels.Length; i++)
            {
                if (sender is Dino)
                {
                    PrintLn(" ", (sender as Dino).X, (sender as Dino).Y + i);
                }
                else if (sender is Obstacle)
                {
                    PrintLn(" ", (sender as Obstacle).X, (sender as Obstacle).Y + i);
                }
            }
        }
    }
}
