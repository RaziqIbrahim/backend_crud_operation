using backendTest.BOs;
using Npgsql;
using System.ComponentModel;

namespace backendTest.Helpers.DataStores
{
    public class UserSchema
    {
        public enum AppTable
        {
            [Description("app.user_data")]
            user_data,
        }

        public enum AppFunctions
        {
            [Description("SELECT app.insert_user_data(@_user_name,@_age)")]
            insert_user_data,
            [Description("SELECT (app.get_user_data(@_user_name)).*")]
            fetch_user_data,
            [Description("SELECT app.delete_user_data(@_user_name)")]
            delete_user_data,
            [Description("SELECT app.update_user_data(@_user_name,@_age)")]
            update_user_data
        }

        public static List<UserBo> get_all_users(string username)
        {
            List<UserBo> users = new List<UserBo>();
            using (NpgsqlConnection sqlCon = new NpgsqlConnection(ServerContants.DBConnectionString))
            {
                sqlCon.Open();

                using (NpgsqlCommand sqlCmd = new NpgsqlCommand(DBOperation.ResolveFunction(AppFunctions.fetch_user_data), sqlCon))
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    if(username != null)
                    {
                        sqlCmd.Parameters.AddWithValue("@_user_name", username);
                    }
                    else
                    {
                        sqlCmd.Parameters.AddWithValue("@_user_name", null);
                    }
                    
                    var reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {

                        users.Add(new UserBo()
                        {

                            user_name = reader.GetString(reader.GetOrdinal("user_name")),
                            age = reader.GetString(reader.GetOrdinal("age"))
                        });
                    }

                    sqlCon.Close();

                    return users;
                }
            }
        }

        public static int insertUserData(UserBo Userdetails)
        {
            using (NpgsqlConnection sqlCon = new NpgsqlConnection(ServerContants.DBConnectionString))
            {
                sqlCon.Open();

                using (NpgsqlCommand sqlCmd = new NpgsqlCommand(DBOperation.ResolveFunction(AppFunctions.insert_user_data), sqlCon))
                {
                   
                    sqlCmd.CommandType = System.Data.CommandType.Text;

                    sqlCmd.Parameters.AddWithValue("@_user_name", Userdetails.user_name);
                    sqlCmd.Parameters.AddWithValue("@_age", Userdetails.age);
                   
                   
                    var reader = sqlCmd.ExecuteReader();

                    return DBOperation.CheckNonQueryStatus(reader, sqlCon);
                }
            }
        }

        public static int deleteUserData(string user_name)
        {
            using (NpgsqlConnection sqlCon = new NpgsqlConnection(ServerContants.DBConnectionString))
            {
                sqlCon.Open();

                using (NpgsqlCommand sqlCmd = new NpgsqlCommand(DBOperation.ResolveFunction(AppFunctions.delete_user_data), sqlCon))
                {

                    sqlCmd.CommandType = System.Data.CommandType.Text;

                    sqlCmd.Parameters.AddWithValue("@_user_name", user_name);


                    var reader = sqlCmd.ExecuteReader();

                    return DBOperation.CheckNonQueryStatus(reader, sqlCon);
                }
            }
        }

        public static int updateUserData(UserBo userdeatils)
        {
            using (NpgsqlConnection sqlCon = new NpgsqlConnection(ServerContants.DBConnectionString))
            {
                sqlCon.Open();

                using (NpgsqlCommand sqlCmd = new NpgsqlCommand(DBOperation.ResolveFunction(AppFunctions.update_user_data), sqlCon))
                {

                    sqlCmd.CommandType = System.Data.CommandType.Text;

                    sqlCmd.Parameters.AddWithValue("@_user_name", userdeatils.user_name);
                    sqlCmd.Parameters.AddWithValue("@_age", userdeatils.age);


                    var reader = sqlCmd.ExecuteReader();

                    return DBOperation.CheckNonQueryStatus(reader, sqlCon);
                }
            }
        }


    }
    }
