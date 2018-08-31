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
    public class ElementInfo
    {
        public string ElementId { set; get; }
        public string ElementName { set; get; }
        public string DefaultTag { set; get; }
        public string StartOffset { set; get; }
        public string EndOffset { set; get; }
        public string ModifyTag { set; get; }
        public string ItemIndex { set; get; }
        public string ForceTag { set; get; }
        public string ElementTypeCode { set; get; }
        public string Score { set; get; }
        public string ParamValue { set; get; }
        public string SpId { set; get; }
        public string SpProductId { set; get; }
        public string RewardLimit { set; get; }
        public string HasAttr { set; get; }
        public string PartyId { set; get; }
        public string StartAbsoluteDate { set; get; }
        public string EndAbsoluteDate { set; get; }
    }
}