using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using Serilog;
using TipCalc.Core;
using TipCalc.Form.UI;

namespace TipCalc.Form.Droid
{
    public class Setup : MvxFormsAndroidSetup<App,FormsApp>
    {
        public override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();
            return base.CreateLogProvider();
        }
    }
}