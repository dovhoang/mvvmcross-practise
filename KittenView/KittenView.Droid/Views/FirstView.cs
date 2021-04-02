using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Droid.Views;
using KittenView.Core.ViewModels;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid;

namespace KittenView.Droid.Views
{
    [Activity(Label = "Kitten Sqlite", MainLauncher = true)]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            Button btnAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            Button btnClear = FindViewById<Button>(Resource.Id.buttonClear);
            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(btnAdd)
                 .For(c => c.BindClick())
                 .To(vm => vm.ClickAddNewKitten)
                 .Apply();
            set.Bind(btnClear)
                .For(c => c.BindClick())
                .To(vm => vm.ClickClearAllKitten)
                .Apply();


        }
    }
}