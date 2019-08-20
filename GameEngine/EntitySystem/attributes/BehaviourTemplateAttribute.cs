using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.EntitySystem
{
    /// <summary>
    /// Tells the entity system a behaviour is only a template and to ignore it for serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class BehaviourTemplateAttribute : Attribute
    {
    }
}
