using System.Collections;
using System.Collections.Generic;

namespace MvcMvvmArticle.DataLayer
{
    public static class DataFactory
    {
        public static IEnumerable<string> GetNames()
        {
            var names = new List<string>
            {
                "John",
                "Johnny",
                "Johnathan",
                "Jon",
                "Jonathan",
                "Jonathon"
            };

            return names;
        }
    }
}