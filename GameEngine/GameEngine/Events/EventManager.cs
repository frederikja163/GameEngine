using System;

using GameEngine.ECB;

namespace GameEngine.Events
{
    /// <summary>
    /// Manages the event system.
    /// </summary>
    public static class EventManager
    {
        /// <summary>
        /// Called when a component is added to an entity.
        /// </summary>
        public static event Action<Entity, object[]> OnComponentsAdded;

        /// <summary>
        /// Called when a component is removed from an entity.
        /// </summary>
        public static event Action<Entity, object[]> OnComponentsRemoved;

        /// <summary>
        /// Called when an entity is added to a world.
        /// </summary>
        public static event Action<Entity> OnEntityAdded;

        /// <summary>
        /// Called when an entity is removed from a world.
        /// </summary>
        public static event Action<Entity> OnEntityRemoved;

        /// <summary>
        /// Called when an entity is created.
        /// </summary>
        public static event Action<Entity> OnEntityCreated;

        internal static void RaiseComponentsAdded(Entity entity, object[] components)
        {
            OnComponentsAdded?.Invoke(entity, components);
        }

        internal static void RaiseComponentsRemoved(Entity entity, object[] components)
        {
            OnComponentsRemoved?.Invoke(entity, components);
        }

        internal static void RaiseEntityAdded(Entity entity)
        {
            OnEntityAdded?.Invoke(entity);
        }

        internal static void RaiseEntityRemoved(Entity entity)
        {
            OnEntityRemoved?.Invoke(entity);
        }
    }
}
