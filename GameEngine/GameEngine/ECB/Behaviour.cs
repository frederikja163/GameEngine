using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.ECB
{
    /// <summary>
    /// An attribute hinting at the entity-component-behaviour system a class is a behaviour.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BehaviourAttribute : Attribute
    {

    }

    /// <summary>
    /// A basic behaviour implementation for the entity-component-behaviour system.
    /// </summary>
    public abstract class Behaviour
    {
        private List<BehaviourEntity> _entities = new List<BehaviourEntity>(); //TODO: subscribe to addComponent and removeComponent events to add and remove entities.
        private Type[] _types;

        private struct BehaviourEntity
        {
            public Entity Entity { get; }
            public object[] Components { get; }

            public BehaviourEntity(Entity entity, object[] components)
            {
                Entity = entity;
                Components = components;
            }
        }

        /// <summary>
        /// Initializes a new behaviour.
        /// </summary>
        /// <param name="types">The types this behaviour will accept.</param>
        protected Behaviour(Type[] types) //TODO: Add ability to chose which event this behaviour should suscribe to.
        {
            _types = types;
        }

        /// <summary>
        /// Called ever iteration of the event this behaviour is subscribed to, for every entity.
        /// </summary>
        /// <param name="entity">The entity being processed.</param>
        /// <param name="components">The components of this entity of accepted types.</param>
        protected abstract void UpdateEntity(Entity entity, object[] components);

        /// <summary>
        /// Called when a new entity is accepted by this behaviour.
        /// </summary>
        /// <param name="entity">The entity accepted by this behaviour.</param>
        /// <param name="components">The components accepted by this behaviour.</param>
        /// <returns>Is this entity something to be added to the behaviour.</returns>
        protected virtual bool EntityAdded(Entity entity, object components)
        {
            return true;
        }

        /// <summary>
        /// Called when an entity is being removed from this behaviour.
        /// </summary>
        /// <param name="entity">The entity being removed by this behaviour.</param>
        protected virtual void EntityRemoved(Entity entity)
        {

        }

        internal void EntityCreated(Entity entity)
        {
            if (!entity.HasComponents(_types, out object[] comp))
            {
                return;
            }

            if (!EntityAdded(entity, comp))
            {
                return;
            }

            _entities.Add(new BehaviourEntity(entity, comp));
        }

        internal void ComponentAdded(Entity entity, object component)
        {
            if (_entities.Exists(x => x.Entity == entity))
            {
                return;
            }

            EntityCreated(entity);
        }

        internal void ComponentRemoved(Entity entity, object component)
        {
            //Is the removed component part of the accepted types.
            bool found = false;
            for (int i = 0; i < _types.Length; i++)
            {
                if (component.GetType() == _types[i])
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return;
            }

            EntityRemoved(entity);
            _entities.RemoveAt(_entities.FindIndex(x => x.Entity == entity));
        }

        internal void Update()
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                UpdateEntity(_entities[i].Entity, _entities[i].Components);
            }
        }
    }
}
