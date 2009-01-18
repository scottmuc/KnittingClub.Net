namespace KnittingClub.Utility
{
    public static class TypeExtensions 
    {
        public static T DownCastTo<T>(this object item) 
        {
            return (T)item;
        }
    }          
}