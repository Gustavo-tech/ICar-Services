namespace ICar.Data
{
    internal static class DatabaseConnectionFactory
    {
        internal static string GetICarConnection()
        {
            return "DataSource=DESKTOP-PR1204Q;Initial Catalog=icar;Integrated Security=True";
        }
    }
}
