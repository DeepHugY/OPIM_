using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OPIM_Common
{
   public class StringHelper
    {
        public static bool IsNullOrEmptyOrWhiteSpace(string value)
        {
            return (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value));
        }
        public static bool IsNullOrEmptyOrWhiteSpace(params string[] value)
        {
            bool r = false;
            foreach (string v in value)
            {
                if (StringHelper.IsNullOrEmptyOrWhiteSpace(v))
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public static string DateTimeConver(string data)
        {
            string[] arr = data.Split('/');
            string month = int.Parse(arr[1]) < 10 ? "0" + arr[1].ToString() : arr[1].ToString();
            string day= int.Parse(arr[2]) < 10 ? "0" + arr[2].ToString() : arr[2].ToString();
            string newData =arr[0].ToString()+"/"+month+"/"+day;
            return newData;
        }

        /// <summary>
        /// 过滤不安全的字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FilteSQLStr(string Str)
        {
            Str = Str.Replace("'", "");
            Str = Str.Replace("\"", "");
            Str = Str.Replace("&", "&");
            Str = Str.Replace("<", "<");
            Str = Str.Replace(">", ">");
            Str = Str.Replace("delete", "");
            Str = Str.Replace("update", "");
            Str = Str.Replace("insert", "");
            return Str;
        }
        #region 过滤 Sql 语句字符串中的注入脚本
        /// <summary>
        /// 过滤 Sql 语句字符串中的注入脚本
        /// </summary>
        /// <param name="source">传入的字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string SqlFilter(string source)
        {
            //单引号替换成两个单引号
            source = source.Replace("'", "''");
            //半角封号替换为全角封号，防止多语句执行
            source = source.Replace(";", "；");
            //半角括号替换为全角括号
            source = source.Replace("(", "（");
            source = source.Replace(")", "）");
            ///////////////要用正则表达式替换，防止字母大小写得情况////////////////////
            //去除执行存储过程的命令关键字
            source = source.Replace("Exec", "");
            source = source.Replace("Execute", "");
            //去除系统存储过程或扩展存储过程关键字
            source = source.Replace("xp_", "x p_");
            source = source.Replace("sp_", "s p_");
            //防止16进制注入
            source = source.Replace("0x", "0 x");
            return source;
        }
        #endregion
        /// 过滤SQL字符。
        /// </summary>
        /// <param name="str">要过滤SQL字符的字符串。</param>
        /// <returns>已过滤掉SQL字符的字符串。</returns>
        public static string ReplaceSQLChar(string str)
        {
            if (str == String.Empty)
                return String.Empty; str = str.Replace("'", "‘");
            str = str.Replace(";", "；");
            str = str.Replace(",", ",");
            str = str.Replace("?", "?");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            str = str.Replace("+", "＋");
            str = str.Replace("*", "＊");
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            str = str.Replace("%", "％");
            str = str.Replace("$", "￥");
            return str;
        }
        /// <summary>
        /// 过滤标记
        /// </summary>
        /// <param name="NoHTML">包括HTML，脚本，数据库关键字，特殊字符的源码 </param>
        /// <returns>已经去除标记后的文字</returns>
        public string NoHtml(string Htmlstring)
        {
            if (Htmlstring == null)
            {
                return "";
            }
            else
            {
                //删除脚本
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                //删除与数据库相关的词
                Htmlstring = Regex.Replace(Htmlstring, "select", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net user", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "or", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net", "", RegexOptions.IgnoreCase);
                //Htmlstring = Regex.Replace(Htmlstring, "*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "-", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "script", "", RegexOptions.IgnoreCase);
                //特殊的字符
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("*", "");
                Htmlstring = Htmlstring.Replace("-", "");
                Htmlstring = Htmlstring.Replace("?", "");
                Htmlstring = Htmlstring.Replace("'", "''");
                Htmlstring = Htmlstring.Replace(",", "");
                Htmlstring = Htmlstring.Replace("/", "");
                Htmlstring = Htmlstring.Replace(";", "");
                Htmlstring = Htmlstring.Replace("*/", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                return Htmlstring;
            }
        }
        public static bool CheckWord(string str)
        {
            if (StringHelper.IsNullOrEmptyOrWhiteSpace(str))
                return false;
            string pattern = @"select|insert|delete|from|count\(|drop table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec master|netlocalgroup administrators|net user|or|and";
            if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
                return true;
            return false;
        }
        public static bool CheckWord(params string[] value)
        {
            bool r = true;
            foreach (string v in value)
            {
                if (!StringHelper.CheckWord(v))
                {
                    r = false;
                    break;
                }
            }
            return r;
        }
        public static string Filter(string str)
        {
            string[] pattern = { "select", "insert", "delete", "from", "count\\(", "drop table", "update", "truncate", "asc\\(", "mid\\(", "char\\(", "xp_cmdshell", "exec master", "netlocalgroup administrators", "net user", "or", "and" };
            for (int i = 0; i < pattern.Length; i++)
            {
                str = str.Replace(pattern[i].ToString(), "");
            }
            return str;
        }
        public static int Base64Length(string base64)
        {
            string b = base64.Split(',')[1];
            var equalIndex = b.IndexOf('=');
            if (equalIndex > 0)
                b = b.Substring(0, equalIndex);
            int l = b.Length;
            l = l - (l / 8) * 2;
            return l / 1024;
        }
        public static string GetId(string Id, char symbol)
        {
            var result = Id.Split(symbol);
            return result[1];
        }
        public static string MD5Encryption(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            StringBuilder sb = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < output.Length; i++)
            {
                sb.Append(output[i].ToString("x2"));
            }
            return sb.ToString().ToLower();
        }
        public static string GetVcode(int codeLength)
        {
            string VCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                VCode += random.Next(0, 9);
            }
            return VCode;
        }
    }
}
