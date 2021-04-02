using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        TextView translatedPhoneWord;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneText);
            translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button startActivityButton = FindViewById<Button>(Resource.Id.StartActivityButton);
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                string translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    Toast.MakeText(Application.Context, "phone number is required!", ToastLength.Short).Show();
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    phoneNumberText.Text = "";
                }
            };
            Toast.MakeText(Application.Context, "data change", ToastLength.Short).Show();
            startActivityButton.Click += StartActivityClick;

            
        }
        public void StartActivityClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
            StartActivity(intent);
        }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}