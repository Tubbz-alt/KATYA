using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KATYA
{
    public partial class KATYASqlServerDatabase : KATYADatabase
    {
        private string AuthenticationMode { get; set; }
        public KATYASqlServerDatabase(string Server, string Database, string UserID, string Password)
        {
            this.Server = Server;
            this.Database = Database;
            this.UserID = UserID;
            this.Password = Password;
            if(UserID == null || UserID.Length == 0 || Password == null || Password.Length == 0)
            {
                this.AuthenticationMode = "winauth";
            }
            else
            {
                this.AuthenticationMode = "sqlauth";
            }
        }
        public string GetConnectionString()
        {
            string ConnectionString = "";
            try
            {
                if(this.AuthenticationMode == "winauth")
                {
                    ConnectionString = String.Format("server={0};database={1};trusted_connection=true", this.Server, this.Database);
                }
                else if (this.AuthenticationMode == "sqlauth")
                {
                    ConnectionString = String.Format("server={0};database={1};user id={2};password={3}", this.Server, this.Database, this.UserID, this.Password);
                }
            }
            catch(Exception e)
            {
                ConnectionString = null;
            }
            return ConnectionString;
        }
        public SqlConnection GetSqlConnection()
        {
            SqlConnection NewConnection = new SqlConnection();
            try
            {
                NewConnection = new SqlConnection(GetConnectionString());
                NewConnection.Open();
                NewConnection.Dispose();
            }
            catch(Exception e)
            {
                NewConnection = null;
            }
            return NewConnection;
        }
        public StatusObject ExecuteNonReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXECUTENONREADERQUERY");
            }
            return SO;
        }
        public StatusObject ExecuteReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
