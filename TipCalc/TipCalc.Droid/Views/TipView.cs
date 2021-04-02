using Android.App;
using Android.OS;
using Android.Widget;
using TipCalc.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.Droid;

namespace TipCalc.Droid.Views
{
    [Activity(Label = "Tip Calculator", MainLauncher = true)]
    public class TipView : MvxActivity<TipViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TipView);
            Button button = FindViewById<Button>(Resource.Id.button);
            var set = this.CreateBindingSet<TipView, TipViewModel>();
            set.Bind(button)
                .For(c => c.BindClick())
                .To(vm => vm.NavigateCommand)
                .Apply();
        }
    }


}