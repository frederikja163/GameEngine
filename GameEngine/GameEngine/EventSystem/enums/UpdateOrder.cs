using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.EventSystem
{
    /// <summary>
    /// Different times/priorities of updates.
    /// </summary>
    public enum UpdateOrder
    {
        /// <summary>
        /// Pre update is called as the first update.
        /// </summary>
        PreUpdate = 1,

        /// <summary>
        /// The main update.
        /// </summary>
        Update,

        /// <summary>
        /// Post update is called as the last update.
        /// </summary>
        PostUpdate
    }
}
