using System;
using System.Collections.Generic;

namespace Assets.Scripts.Helpers
{
    public static class ListExtensions
    {
        private static Random random = new Random();

        public static T GetRandom<T>(this List<T> list)
        {
            int i = random.Next(list.Count);
            return list[i];
        }
    }
}
