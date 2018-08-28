using OPIM_Common;
using System.Data;
using System.Data.SqlClient;

namespace OPIM_Dapper
{
    public class DbConnectionSetting
    {
        protected IDbConnection GetConnection()
        {
            DataBaseConfigSetting.Initialize();
            return new SqlConnection(DataBaseConfigSetting.OPIMConnectionString);
        }


    }
}
