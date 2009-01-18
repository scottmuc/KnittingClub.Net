using System.Collections.Generic;

namespace KnittingClub.Utility
{
    public static class CollectionExtensions
    {
        public static int GetCount<T>(this IEnumerable<T> collection)
        {
            return new List<T>(collection).Count;
        }
    }
}