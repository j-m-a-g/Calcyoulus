using Xamarin.Forms;

namespace Calcyoulus
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		// METHODS

		private void SwitchScrollViewPages(ScrollView currentScrollView)
		{
			// Check to see if the ScrollView page is visible in the first place.
			switch (HomePageScrollView.IsVisible)
			{
				case true:
					HomePageScrollView.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (GeometryCalculatorsPageScrollView.IsVisible)
			{
				case true:
					GeometryCalculatorsPageScrollView.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (LinearCalculatorsScrollView.IsVisible)
			{
				case true:
					LinearCalculatorsScrollView.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (SettingsPageScrollView.IsVisible)
			{
				case true:
					SettingsPageScrollView.IsVisible = false;
					break;
				case false:
					break;
			}

			currentScrollView.IsVisible = true;
		}

		// EVENT HANDLERS

		private void HomeNavigationPageImageButton_Clicked(object sender, System.EventArgs e)
		{
			SwitchScrollViewPages(HomePageScrollView);
        }
    }
}
