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
    public class CustomInfo
    {
        public string Name { set; get; }//客户姓名
        public string IdNumber { set; get; }//证件号码
        public string CustId { set; get; }//客户ID
        public string PsptTypeCode { set; get; }//证件类型，1：身份证
        public string Address { set; get; }//证件地址
        public string Sex { set; get; }//性别
        public string PhotoUrl { set; get; }//照片路径:上传照片
        public string PhotoUrlBak { set; get; }//照片路径：比对照片
        public string PhotoName { set; get; }//照片名称:上传照片
        public string PhotoName2 { set; get; }//照片名称：对比照片
        public string Nation { set; get; }//民族
        public string PhoneNumber { set; get; }//联系人手机号码
        public string BirthDay { set; get; }//生日
        public string ActivityLFrom { set; get; }//身份证办证日期
        public string ActivityLTo { set; get; }//身份证办证过期时间
        public string PostCode { set; get; }//邮编 == $TextField$10
        public string PhotoSimilarity { set; get; }//照片相似度
    }
}