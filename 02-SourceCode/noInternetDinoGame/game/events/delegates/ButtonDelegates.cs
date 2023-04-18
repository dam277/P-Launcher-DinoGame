using System;
using System.Collections.Generic;
using System.Text;

namespace noInternetDinoGame.game.events.delegates
{
    /// <summary>
    /// Click event of a button
    /// </summary>
    /// <param name="sender">This button clicked</param>
    public delegate void Click(object sender);

    /// <summary>
    /// Select event of a button
    /// </summary>
    /// <param name="sender">This button selected</param>
    public delegate void Select(object sender);
}
