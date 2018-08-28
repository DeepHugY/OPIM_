using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common
{
   public class PathHelper
    {
        public static string GetRelativePath(string path)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            if (path == null)
                return null;
            else
                return path.Replace(basePath, @"\");
        }
        public static string GetAbsolutePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
