using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using GameEngine.EntitySystem;

namespace GameEngine
{
    /// <summary>
    /// Manages the overall Gameengine
    /// </summary>
    public static class GameEngine
    {
        /// <summary>
        /// Initializes the game engine.
        /// </summary>
        public static void Init()
        {
            EntityManager.LoadBehaviours(Assembly.GetExecutingAssembly());
        }
    }
}