using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using MvvmCross.Forms.Platforms.Android.Views;
using TipCalc.Core;
using TipCalc.Form.UI;

namespace TipCalc.Form.Droid
{
    [Activity(Label = "Tip Calc", 
        Theme = "@style/AppTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<Setup,App,FormsApp>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
        }
    }
    
   
}