using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
namespace KATYA
{
    public partial class KATYASqlServerDatabase
    {
        /// <summary>
        /// Default Stored Procedure Extraction
        /// </summary>
        /// <returns></returns>
        public StatusObject ExtractStoredProcedures()
        {
            StatusObject SO = new StatusObject();
            try
            {
                string ExtractPath = String.Format(@"Databases\SQLServer\{0}\StoredProcedures", this.Database);
                Directory.CreateDirectory(ExtractPath);
                SqlConnection TargetDatabase = GetSqlConnection();
                TargetDatabase.Open();
                SqlCommand StoredProcedureNamesCommand = new SqlCommand(
                    @"select 
	                    ROUTINE_NAME
                    from 
	                    INFORMATION_SCHEMA.ROUTINES 
                    where 
	                    ROUTINE_TYPE='PROCEDURE' 
	                    and left(Routine_name,3) not in ('sp_','xp_','ms_','dt_') 
                    order by 
	                    ROUTINE_NAME", TargetDatabase);
                SqlDataReader StoredProcedureNamesReader = StoredProcedureNamesCommand.ExecuteReader();
                List<string> StoredProcedureNames = new List<string>();
                while (StoredProcedureNamesReader.Read())
                {
                    StoredProcedureNames.Add(StoredProcedureNamesReader[0].ToString());
                }
                TargetDatabase.Close();
                foreach (string StoredProcedureName in StoredProcedureNames)
                {
                    TargetDatabase.Open();
                    SqlCommand StoredProcedureContentCommand = new SqlCommand(
                        String.Format("select OBJECT_DEFINITION (OBJECT_ID('{0}'))", StoredProcedureName),
                        TargetDatabase);
                    SqlDataReader StoredProcedureContentReader = StoredProcedureContentCommand.ExecuteReader();
                    StreamWriter StoredProcedureTextFile = new StreamWriter(String.Format(@"{0}\{1}.txt", ExtractPath, StoredProcedureName));
                    while (StoredProcedureContentReader.Read())
                    {
                        Console.WriteLine(StoredProcedureName);
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        StoredProcedureTextFile.Write(StoredProcedureContentReader[0]);
                    }
                    StoredProcedureTextFile.Close();
                    TargetDatabase.Close();
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXTRACTSTOREDPROCEDURES");
            }
            return SO;
        }
        public StatusObject ExtractStoredProcedures(params string[] StoredProcedureNames)
        {
            StatusObject SO = new StatusObject();
            try
            {
                string ExtractPath = String.Format(@"Databases\SQLServer\{0}\StoredProcedures", this.Database);
                SqlConnection TargetDatabase = GetSqlConnection();
                foreach (string StoredProcedureName in StoredProcedureNames)
                {
                    TargetDatabase.Open();
                    SqlCommand StoredProcedureContentCommand = new SqlCommand(
                        String.Format("select OBJECT_DEFINITION (OBJECT_ID('{0}'))", StoredProcedureName),
                        TargetDatabase);
                    SqlDataReader StoredProcedureContentReader = StoredProcedureContentCommand.ExecuteReader();
                    StreamWriter StoredProcedureTextFile = new StreamWriter(String.Format(@"{0}\{1}.txt", ExtractPath, StoredProcedureName));
                    while (StoredProcedureContentReader.Read())
                    {
                        Console.WriteLine(StoredProcedureName);
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        StoredProcedureTextFile.Write(StoredProcedureContentReader[0]);
                    }
                    StoredProcedureTextFile.Close();
                    TargetDatabase.Close();
                }
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "SQLSERVERDATABASE_EXTRACTSTOREDPROCEDURES");
            }
            return SO;
        }
    }
}
