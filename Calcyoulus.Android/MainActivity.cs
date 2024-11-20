using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace Calcyoulus.Droid
{
	[Activity(
		Label = "Calcyoulus",
		Icon = "@mipmap/icon",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle? savedInstanceState)
		{
			// Force app to appear in light theme
			AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

			// XF.Material Library
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			Xamarin.Forms.Forms.Init(this, savedInstanceState);

			// XF.Material Library
			XF.Material.Droid.Material.Init(this, savedInstanceState);

			LoadApplication(new App());
		}
		public override void OnRequestPermissionsResult(
			int requestCode,
			string[] permissions,
			[GeneratedEnum] Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		[System.Obsolete]
		public override void OnBackPressed()
		{
			XF.Material.Droid.Material.HandleBackButton(base.OnBackPressed);
		}
	}
}
