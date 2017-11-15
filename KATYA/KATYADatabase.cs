using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public partial class KATYADatabase
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        private string AuthenticationMode { get; set; }
        public KATYADatabase(string Server, string Database, string UserID, string Password)
        {
            this.Server = Server;
            this.Database = Database;
            this.UserID = UserID;
            this.Password = Password;
        }
        public string GetSQLServerConnectionString()
        {
            string ConnectionString = "";
            try
            {
                if(UserID == null || UserID.Length == 0 || Password == null || Password.Length == 0)
                {
                    this.AuthenticationMode = "winauth";
                }
                else
                {
                    this.AuthenticationMode = "sqlauth";
                }
                if(this.AuthenticationMode == "winauth")
                {
                    ConnectionString = String.Format(
                        "server={0};database={1};trusted_connection=true",
                        this.Server,
                        this.Database);
                }
                else if(this.AuthenticationMode == "sqlauth")
                {
                    ConnectionString = String.Format(
                        "server={0};database={1};user id={2};password={3}",
                        this.Server,
                        this.Database,
                        this.UserID,
                        this.Password);
                }
            }
            catch(Exception e)
            {

            }
            return ConnectionString;
        }
        public SqlConnection GetSQLServerConnection()
        {
            SqlConnection NewConnection = new SqlConnection(GetSQLServerConnectionString());
            try
            {
                NewConnection.Open();
                NewConnection.Close();
            }
            catch(Exception e)
            {
                NewConnection = null;
            }
            return NewConnection;
        }
    }
}
