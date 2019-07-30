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
}
