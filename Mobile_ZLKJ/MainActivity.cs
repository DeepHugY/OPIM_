using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Mobile.Fragments;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Mobile
{
    [Activity(Label = "Mobile")]
    public class MainActivity : Activity
    {
        private TextView tab_recharge;
        private TextView tab_openccard;
        private TextView tab_personal;
        private FrameLayout ly_content;
        private MyFragment fg1;
        private OpenCardFragment fg2;
        private PersonalFragment personalFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            ////初始化fragment图标大小
            //Drawable drawableChat = GetDrawable(Resource.Drawable.tab_menu_icon);
            //drawableChat.SetBounds(5, 5, 40, 40);//图标距离左5，上5，宽40，高40
            //tab_recharge.SetCompoundDrawables(null, drawableChat, null, null);//图标放在上部


            //Drawable icon = GetDrawable(Resource.Drawable.tab_menu_user);
            ////setBounds(left,top,right,bottom)里的参数从左到右分别是
            ////drawable的左边到textview左边缘+padding的距离，drawable的上边离textview上边缘+padding的距离
            ////drawable的右边边离textview左边缘+padding的距离，drawable的下边离textview上边缘+padding的距离
            ////所以right-left = drawable的宽，top - bottom = drawable的高
            //icon.SetBounds(0, 0, 40, 44);
            //tab_recharge.SetCompoundDrawables(icon, null, null, null);





            //初始化fragment
            ly_content = (FrameLayout)FindViewById(Resource.Id.ly_content);
            MyFragment fg = new MyFragment("第一个fragment");
            tab_recharge = (TextView)FindViewById(Resource.Id.tab_recharge);
            tab_openccard = (TextView)FindViewById(Resource.Id.tab_openccard);
            
            tab_personal = (TextView)FindViewById(Resource.Id.tab_personal);
            bindViews();
            tab_recharge.PerformClick();
        }
        //ui组件初始化与事件绑定
        private void bindViews()
        {
            tab_recharge.Click += (s, e) => { onClick(tab_recharge); };
            tab_openccard.Click += delegate {onClick(tab_openccard); };
            tab_personal.Click += delegate {onClick(tab_personal); };
        }
        //隐藏所有Fragment
        private void hideAllFragment(FragmentTransaction fragmentTransaction)
        {
            if (fg1 != null) fragmentTransaction.Hide(fg1);
            if (fg2 != null) fragmentTransaction.Hide(fg2);
            if (personalFragment != null) fragmentTransaction.Hide(personalFragment);
            //if (openCardStep2Fragment != null) fragmentTransaction.Hide(openCardStep2Fragment);
        }
        //重置所有文本的选中状态
        private void setSelected()
        {
            tab_recharge.Selected = false;
            tab_openccard.Selected = false;
            tab_personal.Selected = false;
        }
        //单击事件
        public void onClick(View v)
        {
            FragmentTransaction fTransaction = FragmentManager.BeginTransaction();
            hideAllFragment(fTransaction);
            switch (v.Id)
            {
                case Resource.Id.tab_recharge:
                    setSelected();
                    tab_recharge.Selected = true;
                   
                    if (fg1 == null)
                    {
                        
                        fg1 = new MyFragment("开卡Fragment");
                        fTransaction.Add(Resource.Id.ly_content, fg1);
                    }
                    else { fTransaction.Show(fg1); }
                    break;
                case Resource.Id.tab_openccard:
                    setSelected();
                    tab_openccard.Selected = true;
                    
                    if (fg2 == null)
                    {
                        fg2 = new OpenCardFragment();
                        fTransaction.Add(Resource.Id.ly_content, fg2);
                    }
                    else { fTransaction.Show(fg2); }
                    break;
                case Resource.Id.tab_personal:
                    setSelected();
                    tab_personal.Selected = true;
                   
                    if (personalFragment == null)
                    { 
                        personalFragment = new PersonalFragment();
                        fTransaction.Add(Resource.Id.ly_content, personalFragment);
                    }
                    else { fTransaction.Show(personalFragment); }
                    break;
            }
            fTransaction.Commit();
        }

    }
}

