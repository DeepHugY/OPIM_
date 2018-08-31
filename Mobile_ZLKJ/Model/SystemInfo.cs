using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mobile.Model
{
    public class SystemInfo
    {
        public string CheckCode { set; get; }
        public string RandomCode { set; get; }
        public string StaffName { set; get; }//工号名:"李守宾"
        public string DeptId { set; get; }//'76b4k0h' 
        public string DeptCode { set; get; }//'76b4k0h' 
        public string DeptName { set; get; }//'纵联南阳工业路港达店' 
        public string CityId { set; get; }//城市ID:'766487' 
        public string CityName { set; get; }//城市名称:'南阳市区' 
        public string AreaCode { set; get; }//区号:'76b3ph' 
        public string AreaName { set; get; }//区名:'南阳市城区' 
        public string EpachyId { set; get; }//'0377' 
        public string EpachyName { set; get; }//'南阳' 
        public string LoginEpachyId { set; get; }//'0377' 
        public string Version { set; get; }//'BSS2PLUS' 
        public string ProvinceId { set; get; }//所属省编号：'76' 
        public string SubSysCode { set; get; }//'custserv'
        public string ContextName { set; get; }//'custserv' 
        public string LoginProvinceId { set; get; }//'76'  
    }
}