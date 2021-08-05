using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Library
{
    public static class Utils
    {
        /// <summary>
        /// It will return number of random boats
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <returns></returns>
       public static List<T> GetSelectedRandom<T>(List<T> list, int count)
        {
            var r = new Random();
            var rList = new List<T>();
            while (count > 0 && list.Count > 0)
            {
                var n = r.Next(0, list.Count);
                var e = list[n];
                rList.Add(e);
                count--;
            }

            return rList;
        }
    }
}
