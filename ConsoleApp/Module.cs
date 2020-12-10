using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;

using DryIoc;

namespace ConsoleApp
{
    public abstract class Module : IModule
    {
        public virtual void Register(IContainer container)
        {
        }

        public virtual void Resolve(IContainer container)
        {
        }
    }
}