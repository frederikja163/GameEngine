using System;
using System.Collections.Generic;

using GameEngine.EventSystem;

namespace GameEngine.EntitySystem
{
    /// <summary>
    /// A single entity inside the Entity-Component-Behaviour system.
    /// </summary>
    public class Entity //struct? also make something like an entity-prefab
    {
        private int _id = -1;
        private List<IComponent> _components = new List<IComponent>();
        private World _world;

        /// <summary>
        /// Initializes a new entity.
        /// </summary>
        /// <param name="components">Components to initialize the entity with.</param>
        public Entity(params IComponent[] components)
        {
            _components.AddRange(components);
            EventManager.RaiseEntityCreated(this);
        }

        /// <summary>
        /// Get the Id of the entity.
        /// </summary>
        /// <remarks>If the Id is 0, it hasn't been added to a world yet <see cref="World.AddEntity(Entity)"/></remarks>
        public int Id { get => _id; }

        /// <summary>
        /// Gets the world this entity belongs to.
        /// </summary>
        public World World { get => _world; }

        /// <summary>
        /// Gets or sets a component based a given index.
        /// </summary>
        /// <param name="i">The index of the component to get or set.</param>
        /// <returns>The component with given index.</returns>
        public IComponent this[int i] { get { return _components[i]; } set { _components[i] = value; } }

        /// <summary>
        /// Finds and returns the index of the first component inside this entity matching the given type.
        /// </summary>
        /// <typeparam name="tComponentType">The type of the component.</typeparam>
        /// <returns>The index of the first component with given type, or -1 if none found.</returns>
        public int GetComponentIndex<tComponentType>()
        {
            return GetComponentIndex(x => x.GetType() == typeof(tComponentType));
        }

        /// <summary>
        /// Finds and returns the index of the first component inside this entity matching the predicate conditions.
        /// </summary>
        /// <param name="match">A predicate used to search for the component.</param>
        /// <returns>The index of the first component matching the predicate, or -1 if none found.</returns>
        public int GetComponentIndex(Predicate<IComponent> match)
        {
            return _components.FindIndex(match);
        }

        /// <summary>
        /// Checks wether or not this entity has components of the types provided.
        /// </summary>
        /// <param name="types">The types to check for.</param>
        /// <param name="components">An array containing all the components the entity has.</param>
        /// <returns>Does this entity have all the components.</returns>
        public bool HasComponents(Type[] types, out IComponent[] components)
        {
            //Setup.
            object[] comp = new object[types.Length];
            int index = 0;

            //Loop through all the components and types to see if any are a match.
            for (int i = 0; i < _components.Count; i++)
            {
                for (int j = 0; j < types.Length; j++)
                {
                    if (_components[i].GetType() == types[j])//If they are a match put them into the components array.
                    {
                        comp[index++] = _components[i];
                        break;
                    }
                }
            }

            components = new IComponent[index];
            comp.CopyTo(components, 0);

            //Returns, based on wether or not all components where found.
            if (index == types.Length)
            {
                return false;
            }
            return true;
        }
          
        /// <summary>
        /// Find and returns the indices of all components inside this entity matching the given type.
        /// </summary>
        /// <typeparam name="tComponentType">The type of the component.</typeparam>
        /// <returns>The indices of all components with a given type, or null if none found.</returns>
        public int[] GetComponentsIndices<tComponentType>()
        {
            return GetComponentsIndices(x => x.GetType() == typeof(tComponentType));
        }

        /// <summary>
        /// Find and returns the indices of all components inside this entity matching the predicate conditions.
        /// </summary>
        /// <param name="match">A predicate used to search for the component.</param>
        /// <returns>The indices of all components matching the predicate, or null if none found.</returns>
        public int[] GetComponentsIndices(Predicate<object> match)
        {
            int size = GetComponents(match).Length;
            int[] returnVal = new int[size];
            int returnIndex = 0;

            for (int i = 0; i < _components.Count; i++)
            {
                if (match.Invoke(_components[i]))
                {
                    returnVal[returnIndex++] = i;
                }
            }

            return returnVal;
        }

        /// <summary>
        /// Finds and returns the first component inside this entity matching the given type.
        /// </summary>
        /// <typeparam name="tComponentType">The type of the component.</typeparam>
        /// <returns>The first component with given type, or null if none found.</returns>
        public tComponentType GetComponent<tComponentType>()
        {
            return (tComponentType)GetComponent(x => x.GetType() == typeof(tComponentType));
        }

        /// <summary>
        /// Finds and returns the first component inside this entity matching the predicate conditions.
        /// </summary>
        /// <param name="match">A predicate used to search for the component.</param>
        /// <returns>The first component matching the predicate, or null if none found.</returns>
        public object GetComponent(Predicate<object> match)
        {
            return _components.Find(match);
        }

        /// <summary>
        /// Finds and returns all components inside this entity matching the predicate conditions.
        /// </summary>
        /// <param name="match">A predicate used to search for the component.</param>
        /// <returns>All components matching the predicate or null if none found.</returns>
        public object[] GetComponents(Predicate<object> match)
        {
            return _components.FindAll(match).ToArray();
        }

        /// <summary>
        /// Adds components to this entity.
        /// </summary>
        /// <param name="components">An array containing components to be added.</param>
        public void AddComponents(params IComponent[] components)
        {
            _components.AddRange(components);

            EventManager.RaiseComponentsAdded(this, components);
        }

        /// <summary>
        /// Removes components from an entity if they match the given predicate.
        /// </summary>
        /// <param name="match">Predicate to check all components for.</param>
        public void RemoveComponents(Predicate<IComponent> match)
        {
            IComponent[] components = new IComponent[_components.Count];
            int index = 0;

            for (int i = 0; i < _components.Count; i++)
            {
                if (match.Invoke(_components[i]))
                {
                    components[index++] = _components[i];
                    _components.RemoveAt(i--);
                }
            }

            IComponent[] comp = new IComponent[index];
            components.CopyTo(comp, 0);

            EventManager.RaiseComponentsRemoved(this, comp);
        }

        internal void SetWorld(World world, int id)
        {
            _world = world;
            _id = id;


            EventManager.RaiseEntityAdded(this);
        }

        internal void RemoveWorld()
        {
            _world = null;
            _id = -1;

            EventManager.RaiseEntityRemoved(this);
        }

    }
}