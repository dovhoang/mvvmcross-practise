using MvvmCross;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TipCalc.Core.Services;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ICalculationService, CalculationService>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<TipViewModel>());
        }
    }
}