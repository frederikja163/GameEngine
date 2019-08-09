using System;

using GameEngine.EntitySystem;

namespace GameEngine.EventSystem
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

        /// <summary>
        /// Called once per frame before the update.
        /// </summary>
        public static event Action OnPreUpdate;

        /// <summary>
        /// Called once per frame.
        /// </summary>
        public static event Action OnUpdate;

        /// <summary>
        /// Called once per frame after the update.
        /// </summary>
        public static event Action OnPostUpdate;

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
        
        internal static void RaiseEntityCreated(Entity entity)
        {
            OnEntityCreated?.Invoke(entity);
        }

        internal static void RaisePreUpdate()
        {
            OnPreUpdate?.Invoke();
        }

        internal static void RaiseUpdate()
        {
            OnUpdate?.Invoke();
        }

        internal static void RaisePostUpdate()
        {
            OnPostUpdate?.Invoke();
        }
    }
}
