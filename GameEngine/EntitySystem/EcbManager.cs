using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameEngine.EntitySystem
{
    /// <summary>
    /// Manages the entity-component-behaviour system.
    /// </summary>
    public static class EntityManager
    {
        private static List<IBehaviour> _behaviours = new List<IBehaviour>();

        /// <summary>
        /// Loads all types from one assembly initializes all types decorated with <see cref="BehaviourAttribute"/>.
        /// </summary>
        /// <param name="assembly">The assembly to load types from.</param>
        public static void LoadBehaviours(Assembly assembly)
        {
            LoadBehaviours(assembly.GetTypes());
        }


        /// <summary>
        /// Load behaviours from an array of types.
        /// </summary>
        /// <param name="types">The types to load behaviours from.</param>
        public static void LoadBehaviours(params Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].IsAssignableFrom(typeof(IBehaviour)) && types[i].GetCustomAttribute<BehaviourTemplateAttribute>() == null)
                {
                    _behaviours.Add(Activator.CreateInstance(types[i]) as IBehaviour);
                }
            }
        }
    }
}
