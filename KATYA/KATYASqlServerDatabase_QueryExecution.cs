using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public partial class KATYASqlServerDatabase
    {
        public StatusObject ExecuteNonReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
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
        public StatusObject ExtractStoredProcedure(string StoredProcedureName)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {

            }
            return SO;
        }
    }
}
