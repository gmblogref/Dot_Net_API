
namespace GMB.Repository
{
    public class GMBDataConnection
    {
        public T GetAs<T>() where T : class
        {
            return DBConnectionSettings.GetConnectionAs<T>("GMBDataConnection");
        }

        public T GetParallelAs<T>() where T : class
        {
            return DBConnectionSettings.GetParallelConnectionAs<T>("GMBDataConnection");
        }
    }

    public class GMBUtilitiesConnection
    {
        public T GetAs<T>() where T : class
        {
            return DBConnectionSettings.GetConnectionAs<T>("GMBUtilitiesConnection");
        }

        public T GetParallelAs<T>() where T : class
        {
            return DBConnectionSettings.GetParallelConnectionAs<T>("GMBUtilitiesConnection");
        }
    }
}
