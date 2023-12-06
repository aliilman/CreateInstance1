using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInstance.Factory
{
    public interface IDependencyReflectorFactory
    {
       // T GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class;
        T Getinstance<T>(Type typeToReflect, object[] constructorRequiredParamerters)where T : class;
    }
}