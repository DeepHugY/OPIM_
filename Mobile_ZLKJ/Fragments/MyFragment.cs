using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Mobile.Fragments
{
    public class MyFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        private string content { get; set; }
        public MyFragment(string content)
        {
            this.content = content;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fg_recharge, container, false);
            //TextView txt_content = (TextView)view.FindViewById(Resource.Id.txt_content);
            Button btn10 = (Button)view.FindViewById<Button>(Resource.Id.btn10);
            Button btn20 = (Button)view.FindViewById<Button>(Resource.Id.btn20);
            Button btn30 = (Button)view.FindViewById<Button>(Resource.Id.btn30);
            Button btn50 = (Button)view.FindViewById<Button>(Resource.Id.btn50);
            Button btn100 = (Button)view.FindViewById<Button>(Resource.Id.btn100);
            Button btn200 = (Button)view.FindViewById<Button>(Resource.Id.btn200);
            Button btn500 = (Button)view.FindViewById<Button>(Resource.Id.btn500);
            Button btn1000 = (Button)view.FindViewById<Button>(Resource.Id.btn1000);
            Button btn2000 = (Button)view.FindViewById<Button>(Resource.Id.btn2000);
            TextView payamount = (TextView)view.FindViewById<TextView>(Resource.Id.payamount);
           
            btn10.Click += delegate
            {
                string txt = btn10.Text;
                payamount.Text = txt;
            };
            btn20.Click += delegate
            {
                string txt = btn20.Text;
                payamount.Text = txt;
            };
            btn30.Click += delegate
            {
                string txt = btn30.Text;
                payamount.Text = txt;
            };
            btn50.Click += delegate
            {
                string txt = btn50.Text;
                payamount.Text = txt;
            };
            btn100.Click += delegate
            {
                string txt = btn100.Text;
                payamount.Text = txt;
            };
            btn200.Click += delegate
            {
                string txt = btn200.Text;
                payamount.Text = txt;
            };
            btn500.Click += delegate
            {
                string txt = btn500.Text;
                payamount.Text = txt;
            };
            btn1000.Click += delegate
            {
                string txt = btn1000.Text;
                payamount.Text = txt;
            };
            btn2000.Click += delegate
            {
                string txt = btn2000.Text;
                payamount.Text = txt;
            };
            return view;

           
        }
    }
}