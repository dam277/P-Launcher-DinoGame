using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jump
{
    public class Vector2D
    {
        private Point _start;       // Start point
        private Point _end;         // End point
        private int _intensity;     // Strenght (intensity of the vector)

        /// <summary>
        /// Public start point
        /// </summary>
        public Point Start
        {
            get { return _start; }
        }

        /// <summary>
        /// Public end point
        /// </summary>
        public Point End
        {
            get { return _end; }
        }

        /// <summary>
        /// Public intensity
        /// </summary>
        public int Intensity
        {
            get { return _intensity; }
        }

        /// <summary>
        /// Struct constructor
        /// </summary>
        public Vector2D(Point start, Point end, int intensity = 1)
        {
            _end = end;
            _start = start;
            _intensity = intensity;
        }

        /// <summary>
        /// Get a vector 2D
        /// </summary>
        /// <param name="intensity">Intensity of the vector</param>
        /// <param name="x">Position X of the ball</param>
        /// <param name="y">Position Y of the ball</param>
        /// <returns>Returns vector2D</returns>
        public static Vector2D GetVector(int intensity, int x, int y)
        {
            // Set a counter and the intensity
            int counter = 0;
            int intensityTemp = intensity;

            // Up the counter while the intensity is not to 0
            while (intensity != 0)
            {
                for (int i = 0; i < intensity; i++)
                {
                    counter++;
                }
                intensity--;
            }

            // Return the vector
            return new Vector2D(new Point(x, y), new Point(x, y - counter), intensityTemp);
        }
    }
}
