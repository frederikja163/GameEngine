using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameEngine.ECB
{
    /// <summary>
    /// Manages the entity-component-behaviour system.
    /// </summary>
    public static class EcbManager
    {
        private static bool _initialized = false;
        private static List<object> _behaviours = new List<object>();

        internal static bool Initialized { get => _initialized; }

        /// <summary>
        /// Initializes the entity-component-behaviour system
        /// </summary>
        public static void Init()
        {
            _initialized = true;

            LoadBehavioursFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Loads all types from one assembly initializes all types decorated with <see cref="BehaviourAttribute"/>.
        /// </summary>
        /// <param name="assembly">The assembly to load types from.</param>
        public static void LoadBehavioursFromAssembly(Assembly assembly)
        {
            LoadBehavioursFromAssembly(assembly.GetTypes());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="types"></param>
        public static void LoadBehavioursFromAssembly(Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetCustomAttribute<BehaviourAttribute>() == null)
                {
                    continue;
                }
                _behaviours.Add(Activator.CreateInstance(types[i]));
            }
        }
    }
}
