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
    public class ProductInfo
    {
        public string PhoneNumber { set; get; }//电话号码
        public string SimCardNo { set; get; } //SIM卡号
        public string BaiCardNo { set; get; } //白卡SIM卡号
        public string ProductID { set; get; }//主套餐Id
        public string ProductName { set; get; }//主套餐名称
        public List<ActivityProduct> ExtraProduct { set; get; }//附属套餐信息
        public ActivityProduct ActivityProduct { set; get; }//所参加活动product
        public Dictionary<string, string> ExtraPackageIDsDefaultElements { set; get; }//额外Package及其的默认值 key:packageID,value:elementID
        public List<PackeageInfo> Packages { set; get; }//套餐全部功能包（包含主套餐、附属套餐、及主套餐额外的package信息）

        public string AcceptDate { set; get; }//开卡时间
        public string NewCardData { set; get; }//开成卡时所需
        public string ResCenter { set; get; }//开成卡时所需
        public string Imsi { set; get; }//开成卡时所需
        public string ResultCode { set; get; }//开成卡时所需
        public string CardType { set; get; }//开成卡时所需
        public string RespCode { set; get; }//开成卡时所需
        public string CapacityTypeCode { set; get; }//开白卡时所需
        public string Procid { set; get; }//开白卡时所需
        public string ResKindCode { set; get; }//开白卡时所需

        public ProductInfo()
        {
            this.Packages = new List<PackeageInfo>();
        }
    }
}