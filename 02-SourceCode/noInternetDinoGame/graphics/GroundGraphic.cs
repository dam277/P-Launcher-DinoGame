using noInternetDinoGame.singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.graphics
{
    public class GroundGraphic
    {
        #region Properties
        private string _flatGround = "_";   //
        private string _grass = "/";        //
        private int _y;                     //

        private Queue<string> _ground;      // Queue which contains the ground
        #endregion

        #region Getters Setters
        /// <summary>
        /// 
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Queue<string> Ground
        {
            get { return _ground; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Basic class constructor
        /// </summary>
        public GroundGraphic(int y)
        {
            // Set variables
            _ground = new Queue<string>();
            _y = y;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get random ground
        /// </summary>
        /// <returns>Return a random ground in a string</returns>
        public string GetRandomGround()
        {
            // Get a random number
            int randNumber = RandSingleton.GetInstance().RandomObject.Next(101);
            
            // Get the ground random
            if(randNumber < 50)
            {
                return _flatGround;
            }
            else
            {
                return _grass;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSet"></param>
        public void SetGround(bool isSet)
        {
            // Check if the queue is set or not
            if(isSet == false)
            {
                // Get the ground
                _ground.Enqueue(this.GetRandomGround());
            }
            else
            {
                // delete the last element and add a new
                _ground.Dequeue();
                _ground.Enqueue(this.GetRandomGround());
            }
        }
        #endregion
    }
}
