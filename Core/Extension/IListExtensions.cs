using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// method for compare two lists
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool Compare<T>(this IList<T> list1, IList<T> list2)
        {
            List<T> firstNotSecond = list1.Except(list2).ToList();
            List<T> secondNotFirst = list2.Except(list1).ToList();
            return firstNotSecond.Count == 0 && secondNotFirst.Count == 0;
        }
    }
}
