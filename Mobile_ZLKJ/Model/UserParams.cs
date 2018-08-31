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
using System.Security.Cryptography.X509Certificates;

namespace Mobile.Model
{
    public class UserParams
    {
        public string UserAccount { set; get; }
        public string UserPassword { set; get; }
        public string Type { set; get; }//1、白卡，2、成卡
        public string FirstMonthPayType { set; get; }//1、首月减半，2、首月按量，3、首月全价
        public bool IsAcitvity { set; get; }//是否参加活动，true，是
        public CustomInfo Custom { set; get; }
        public Depart Depart { set; get; }
        public ProductInfo Product { set; get; }
        public SystemInfo SystemInfo { set; get; }
        public string TradeBase { set; get; }
        public string TradeIdOfOpenCard { set; get; }//开卡订单tradeID
        public string TradeIdOfWriteCard { set; get; }//白卡写卡订单tradeID
        public X509Certificate2Collection X509 { set; get; }
        public UserParams()
        {
            this.Custom = new CustomInfo();
            this.Product = new ProductInfo();
            this.Depart = new Depart();
            this.SystemInfo = new SystemInfo();
        }
    }
}