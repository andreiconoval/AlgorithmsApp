
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
    }
}