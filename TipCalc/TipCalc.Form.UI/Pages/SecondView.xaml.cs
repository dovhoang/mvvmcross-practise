

using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.Form.UI.Pages
{
    public partial class SecondView : MvxContentPage<SecondViewModel>
    {
        public SecondView()
        {
            InitializeComponent();
            //TODO: Not Working
            // var set = this.CreateBindingSet<SecondView, SecondViewModel>();
            // set.Bind(Subtotal).For(v => v.Text).To(vm => vm.Subtotal);
            // set.Bind(Tip).For(v => v.Text).To(vm => vm.Tip);
            // set.Bind(CloseButton).For(x => x.Command).To(vm => vm.CloseCommand);
            // set.Apply();
        }
    }
}