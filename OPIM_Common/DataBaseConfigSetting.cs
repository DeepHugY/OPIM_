using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common
{
   public class DataBaseConfigSetting
    {
        public static string OPIMConnectionString { get; set; }

        /// <summary>
        /// 获得连接字符串
        /// </summary>
        public static void Initialize()
        {
            OPIMConnectionString = ConfigurationManager.ConnectionStrings["OPIM"].ConnectionString;
        }
    }
}
