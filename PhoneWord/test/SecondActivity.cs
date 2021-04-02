using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
namespace test
{
    [Activity(Label = "Translation History")]
    public class SecondActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your application here
            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);
        }
    }
}