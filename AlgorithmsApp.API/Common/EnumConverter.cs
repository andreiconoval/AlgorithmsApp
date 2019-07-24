
using System;
using System.Collections;
using System.Linq;

namespace AlgorithmsApp.API.Common
{
    public  class EnumConverter
    {
        public object List { get; set ; }
        public static IList EnumToList<T>()
        { 
            var list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return  list;
        }
        public static bool EnumIsString<T>(string name)
        { 
            var list = Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(e => e.ToString() == name);
            return  true;
        }
    }
}