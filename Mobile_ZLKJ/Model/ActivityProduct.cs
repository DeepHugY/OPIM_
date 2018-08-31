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
    public class ActivityProduct//开卡参加的活动产品
    {
        public string ActivityProductTypeCode { set; get; }//CFSF001
        public string ActivityProductName { set; get; }
        public string ProductId { set; get; }//活动ID
        public string ProductName { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string ProductMode { set; get; }
        public string ModifyTag { set; get; }
        public string UserIdA { set; get; }
        public string BrandCode { set; get; }
        public string ItemID { set; get; }
        public ActivityProduct(string productId)
        {
            this.ProductId = productId;
            this.ModifyTag = "0";
            this.UserIdA = "-1";
            this.BrandCode = "-1";
        }
    }
}