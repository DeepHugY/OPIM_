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
    public class OpenCardFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your fragment 

            //Button opencardButton = Activity.FindViewById<Button>(Resource.Id.opencard_btn);
            //TextView numberLabel = Activity.FindViewById<TextView>(Resource.Id.opencard_text_number);
            //opencardButton.Click += (sender, e) => {
            //    numberLabel.Text = "Hello";
            //    //Toast.MakeText(this, "OpenCard", ToastLength.Short);
            //};
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.fg_openCard, container, false);
            //Button opencardButton = view.FindViewById<Button>(Resource.Id.opencard_btn);
            //TextView numberLabel = view.FindViewById<TextView>(Resource.Id.opencard_text_number);

            //opencardButton.Click += delegate
            //{
            //    numberLabel.Text = "Hello";
            //    Console.WriteLine("Hello fox");
            //};


            TextView opencard_submit = (TextView)view.FindViewById<TextView>(Resource.Id.opencard_submit);
            opencard_submit.Click += delegate
            {
                FragmentTransaction fTransaction = FragmentManager.BeginTransaction();
                //FragmentManager mannger=fTransaction
                OpenCardStep2Fragment openCardStep2Fragment = new OpenCardStep2Fragment();

                fTransaction.Add(Resource.Id.ly_content, openCardStep2Fragment);
                fTransaction.Commit();
            };
            return view;
        }
    }
}