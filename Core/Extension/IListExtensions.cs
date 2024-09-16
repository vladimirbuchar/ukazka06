using System;
using System.Collections.Generic;

namespace Core.Extension
{
    /// <summary>
    /// Extension for IList
    /// </summary>
    public static class IListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            Random rng = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }

        /// <summary>
        /// method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static IList<T> Limit<T>(this IList<T> list, int limit)
        {
            if (list.Count <= limit || limit == 0)
            {
                return list;
            }
            List<T> newList = [];
            foreach (T item in list)
            {
                newList.Add(item);
                if (newList.Count >= limit)
                {
                    break;
                }
            }
            return newList;
        }
    }
}
