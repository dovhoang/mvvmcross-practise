

using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Droid.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.Droid.Views
{
    [Activity(Label = "SecondView")]
    public class SecondView : MvxActivity<SecondViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondView);
        }
    }
}
