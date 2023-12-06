using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CreateInstance.Factory
{
    public class DependencyReflectorFactory : IDependencyReflectorFactory
    {
        private readonly IServiceProvider serviceProvider;
        public DependencyReflectorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public T Getinstance<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class
        {
            ConstructorInfo[] constructors = typeToReflect.GetConstructors();
            PropertyInfo[] properties = typeToReflect.GetProperties();

            if (constructors.Length == 0)
            {
                throw new ArgumentNullException("Constructors Tanımlı Değil");
            }
            return (T)ActivatorUtilities.CreateInstance(serviceProvider, typeToReflect, constructorRequiredParamerters);
        }

        //Arşiv
        // https://stackoverflow.com/questions/52644507/using-activatorutilities-createinstance-to-create-instance-from-type
        //KAYNAK
        //https://dev.to/nikcio/how-to-use-asp-net-core-di-reflection-1fi1
        //https://github.com/nikcio/Nikcio.UHeadless/blob/b978a4539ae2d1d20f252fbe4a78d3ac93dccaf6/src/Nikcio.UHeadless/Reflection/Factories/DependencyReflectorFactory.cs
        //
        /*    

            public T GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class
            {
                var propertyTypeAssemblyQualifiedName = typeToReflect.AssemblyQualifiedName;
                var constructors = typeToReflect.GetConstructors();
                if (constructors.Length == 0)
                {
                    // LogConstructorError(typeToReflect, constructorRequiredParamerters);
                    return null;
                }
                var parameters = GetConstructor(constructors, constructorRequiredParamerters)?.GetParameters();
                if (parameters == null)
                {
                    // LogConstructorError(typeToReflect, constructorRequiredParamerters);
                    return null;
                    //return (T)ActivatorUtilities.CreateInstance(serviceProvider, typeToReflect, constructorRequiredParamerters);
                }
                object[] injectedParamerters = null;
                if (constructorRequiredParamerters == null)
                {
                    injectedParamerters = parameters.Select(parameter => serviceProvider.GetService(parameter.ParameterType)).ToArray();
                }
                else
                {
                    injectedParamerters = constructorRequiredParamerters
                    .Concat(parameters.Skip(constructorRequiredParamerters.Length)
                    .Select(parameter => serviceProvider.GetService(parameter.ParameterType)))
                    .ToArray();
                }
                return (T)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), injectedParamerters);
            }




            /// <summary>
            /// Takes the required paramters from a constructor
            /// </summary>
            /// <param name="constructor"></param>
            /// <param name="constructorRequiredParamertersLength"></param>
            /// <returns></returns>
            private ParameterInfo[] TakeConstructorRequiredParamters(ConstructorInfo constructor, int constructorRequiredParamertersLength)
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length < constructorRequiredParamertersLength)
                {
                    return parameters;
                }
                return parameters?.Take(constructorRequiredParamertersLength).ToArray();
            }

            /// <summary>
            /// Validates the required parameters from a constructor
            /// </summary>
            /// <param name="constructor"></param>
            /// <param name="constructorRequiredParameters"></param>
            /// <returns></returns>
            private bool ValidateConstructorRequiredParameters(ConstructorInfo constructor, object[] constructorRequiredParameters)
            {
                if (constructorRequiredParameters == null)
                {
                    return true;
                }
                var parameters = TakeConstructorRequiredParamters(constructor, constructorRequiredParameters.Length);
                for (int i = 0; i < parameters.Length; i++)
                {
                    var requiredParameter = constructorRequiredParameters[i].GetType();
                    if (parameters[i].ParameterType != requiredParameter)
                    {
                        return false;
                    }
                }
                return true;
            }

            /// <summary>
            /// Gets a constructor
            /// </summary>
            /// <param name="constructors"></param>
            /// <param name="constructorRequiredParameters"></param>
            /// <returns></returns>
            private ConstructorInfo GetConstructor(ConstructorInfo[] constructors, object[] constructorRequiredParameters)
            {
                return constructors?.FirstOrDefault(constructor => ValidateConstructorRequiredParameters(constructor, constructorRequiredParameters));
            }
        */  
            // foreach (var item in properties)
                // {
                //     Type propertyType = item.PropertyType;

                //     Console.WriteLine("Type " + propertyType);
                //     Console.WriteLine("Name " + item.Name);
                //     Console.WriteLine("");
                // }
            /// <inheritdoc/>
    }
}