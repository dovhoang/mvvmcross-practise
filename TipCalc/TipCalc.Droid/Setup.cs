using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using TipCalc.Core;

namespace TipCalc.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(MvxRecyclerView).Assembly
            };

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