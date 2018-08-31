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
    public class PackeageInfo
    {
        public string PackageId { set; get; }
        public string PackageName { set; get; }
        public string PackageDesc { set; get; }
        public string DefaultTag { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string MinNumber { set; get; }
        public string MaxNumber { set; get; }
        public string NeedExp { set; get; }
        public string ModifyTag { set; get; }
        public string ItemIndex { set; get; }
        public string PackageTypeCode { set; get; }
        public string ProductId { set; get; }

        public List<ElementInfo> Elements { set; get; }

        public PackeageInfo()
        {
            this.Elements = new List<ElementInfo>();
        }
    }
}