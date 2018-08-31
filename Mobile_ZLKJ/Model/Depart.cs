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
    public class Depart
    {
        //渠道类
        private string StaffId { set; get; }//发展人编码
        public string DepartId { set; get; }//渠道编码
        public string DepartName { set; get; }//渠道名称
        public string StaffName { set; get; }//发展人名称
    }
}