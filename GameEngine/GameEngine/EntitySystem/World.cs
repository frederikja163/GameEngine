using System.Collections.Generic;

namespace GameEngine.EntitySystem
{
    /// <summary>
    /// A world containing entities in the Entity-Component-Behaviour system
    /// </summary>
    public class World
    {
        private List<Entity> _entities;

        private static World _current;

        /// <summary>
        /// Initializes a new world.
        /// </summary>
        /// <param name="makeCurrent">Should this world be the new current world.</param>
        public World(bool makeCurrent = false)
        {
            if (makeCurrent)
            {
                MakeCurrent();
            }
        }

        /// <summary>
        /// Gets the currently active and rendering world.
        /// </summary>
        public static World Current { get => _current; }

        /// <summary>
        /// Gets an array of entities belonging to this world.
        /// </summary>
        public Entity[] Entities { get => _entities.ToArray(); }

        /// <summary>
        /// Make this world the currently active and rendering world.
        /// </summary>
        public void MakeCurrent()
        {
            _current = this;
        }

        /// <summary>
        /// Add an entity to this world.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <remarks>Cannot add entities to serveral worlds.</remarks>
        public void AddEntity(Entity entity)
        {
            if (_entities.Contains(entity))
            {
                return;
            }

            int id = _entities.IndexOf(null);
            if (id == -1)
            {
                _entities.Add(entity);
                id = _entities.Count;
            }
            else
            {
                _entities[id] = entity;
            }
            entity.SetWorld(this, id);
        }

        /// <summary>
        /// Add several entities to this world.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        /// <remarks>Cannot add entities to several worlds.</remarks>
        public void AddEntities(params Entity[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                AddEntity(entities[i]);
            }
        }

        /// <summary>
        /// Remove an entity from this world.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <remarks>This will make the Id of the entity invalid.</remarks>
        public void RemoveEntity(Entity entity)
        {
            if (!_entities.Contains(entity))
            {
                return;
            }
            _entities[entity.Id] = null;
            entity.RemoveWorld();
        }

        /// <summary>
        /// Remove serveral entities from this world.
        /// </summary>
        /// <param name="entity">The entities to remove.</param>
        /// <remarks>This will make the Ids of the entities invalid</remarks>
        public void RemoveEntities(params Entity[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                RemoveEntity(entities[i]);
            }
        }
    }
}
