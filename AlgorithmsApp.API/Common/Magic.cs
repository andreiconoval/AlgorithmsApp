using System;
using System.Linq;
using System.Reflection;

namespace AlgorithmsApp.API.Common
{
    public static class Magic
    {
        private static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }

        
    }
}