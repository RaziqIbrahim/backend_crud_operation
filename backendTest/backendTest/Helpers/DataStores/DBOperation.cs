using Npgsql;

namespace backendTest.Helpers.DataStores
{
    public class DBOperation
    {
        public static string ResolveFunction(Enum function)
        {
            return Utilites.ToStringEnums(function);
        }

        public static int CheckNonQueryStatus(NpgsqlDataReader reader, NpgsqlConnection sqlCon, bool closeConnection = true)
        {
            try
            {
                if (reader != null && reader.HasRows && reader.Read())
                {
                    var affectedRowCount = Convert.ToInt32(reader[0]);
                    if (affectedRowCount > 0)
                    {
                        if (closeConnection)
                            sqlCon.Close();
                        return affectedRowCount;
                    }
                    else
                    {
                        if (closeConnection)
                            sqlCon.Close();
                        return affectedRowCount;
                    }
                }
                else
                {
                    if (closeConnection)
                        sqlCon.Close();
                    return -1;
                }
            }
            catch (Exception ex)
            {
               

                if (closeConnection)
                    sqlCon.Close();
                return -1;
            }
        }
    }
}
