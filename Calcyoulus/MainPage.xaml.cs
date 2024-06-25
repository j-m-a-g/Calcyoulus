﻿using Xamarin.Forms;
using Xamanimation;
using XF.Material.Forms.UI;

namespace Calcyoulus
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		// METHODS

		private void SwitchScrollViewPages(ScrollView currentPageScrollView, Xamarin.Forms.Shapes.Rectangle currentIndicatorRectangle, string currentTopAppBarPageLabelText, ImageButton currentDisabledImageButton)
		{
			// Check to see if the ScrollView page is visible
			// in the first place.
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

			// Check to see if the Rectangle indicator below the ImageButton
			// is visible in the first place.
			switch (HomeImageButtonRectangle.IsVisible)
			{
				case true:
					HomeImageButtonRectangle.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (GeometryCalculatorsImageButtonRectangle.IsVisible)
			{
				case true:
					GeometryCalculatorsImageButtonRectangle.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (LinearCalculatorsImageButtonRectangle.IsVisible)
			{
				case true:
					LinearCalculatorsImageButtonRectangle.IsVisible = false;
					break;
				case false:
					break;
			}
			switch (SettingsImageButtonRectangle.IsVisible)
			{
				case true:
					SettingsImageButtonRectangle.IsVisible = false;
					break;
				case false:
					break;
			}

			// Check to see if the ImageButton of each page
			// is disabled in the first place.
			switch (HomeNavigationPageImageButton.IsEnabled)
			{
				case true:
					break;
				case false:
					HomeNavigationPageImageButton.IsEnabled = true;
					break;
			}
			switch (GeometryCalculatorsNavigationImageButton.IsEnabled)
			{
				case true:
					break;
				case false:
					GeometryCalculatorsNavigationImageButton.IsEnabled = true;
					break;
			}
			switch (LinearCalculatorsNavigationImageButton.IsEnabled)
			{
				case true:
					break;
				case false:
					LinearCalculatorsNavigationImageButton.IsEnabled = true;
					break;
			}
			switch (SettingsNavigationImageButton.IsEnabled)
			{
				case true:
					break;
				case false:
					SettingsNavigationImageButton.IsEnabled = true;
					break;
			}

			currentPageScrollView.IsVisible = true;
			currentPageScrollView.Animate(new FadeInAnimation());

			currentDisabledImageButton.IsEnabled = false;
			currentIndicatorRectangle.IsVisible = true;
			CurrentPageNameLabel.Text = currentTopAppBarPageLabelText;
		}

		private void AnimateExpandCollapseIcon(bool isExpand, Image currentAnimating)
		{
			switch (isExpand)
			{
				case true:
					currentAnimating.Animate(new FadeInAnimation());
					currentAnimating.Source = "expand_96.png";
					break;
				case false:
					currentAnimating.Animate(new FadeInAnimation());
					currentAnimating.Source = "collapse_96.png";
					break;
			}
		}

		private void ShowQuickFormulas(bool hideState)
		{
			// Hides or displays each MaterialCard based on
			// "hideState" parameter.
			AreaFormulasMaterialCard.IsVisible = hideState;
			VolumeFormulasMaterialCard.IsVisible = hideState;
			SurfaceAreaFormulasMaterialCard.IsVisible = hideState;
			PerimeterFormulasMaterialCard.IsVisible = hideState;
		}

		// EVENT HANDLERS

		/* Bottom Page Navigation Bar Grid */
		private void HomeNavigationPageImageButton_Clicked(object sender, System.EventArgs e)
		{
			SwitchScrollViewPages(HomePageScrollView, HomeImageButtonRectangle, "Home", HomeNavigationPageImageButton);
        }

		private void GeometryCalculatorsNavigationImageButton_Clicked(object sender, System.EventArgs e)
		{
			SwitchScrollViewPages(GeometryCalculatorsPageScrollView, GeometryCalculatorsImageButtonRectangle, "Geometry", GeometryCalculatorsNavigationImageButton);
		}

		private void LinearCalculatorsNavigationImageButton_Clicked(object sender, System.EventArgs e)
		{
			SwitchScrollViewPages(LinearCalculatorsScrollView, LinearCalculatorsImageButtonRectangle, "Linear Relations", LinearCalculatorsNavigationImageButton);
		}

		private void SettingsNavigationImageButton_Clicked(object sender, System.EventArgs e)
		{
			SwitchScrollViewPages(SettingsPageScrollView, SettingsImageButtonRectangle, "Settings", SettingsNavigationImageButton);
		}

		private void AnswerUnitPicker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Checks if a selected item from the ItemsSource
			// is not a valid unit to be displayed.
			switch (AnswerUnitPicker.SelectedIndex)
			{
				case 0:
					AnswerUnitPicker.SelectedItem = null;
					break;
				case 1:
					AnswerUnitPicker.SelectedIndex = 2;
					break;
				case 9:
					AnswerUnitPicker.SelectedIndex = 10;
					break;
				case 17:
					AnswerUnitPicker.SelectedIndex = 18;
					break;
			}
		}

		/* Home Page ScrollView */
		private void QuickFormulasMaterialCard_Clicked(object sender, System.EventArgs e)
		{
			switch (AreaFormulasMaterialCard.IsVisible && VolumeFormulasMaterialCard.IsVisible && SurfaceAreaFormulasMaterialCard.IsVisible && PerimeterFormulasMaterialCard.IsVisible)
			{
				case true:
					ShowQuickFormulas(false);
					AnimateExpandCollapseIcon(true, ExpandCollapseQuickFormulasMaterialIcon);
					break;
				case false:
					ShowQuickFormulas(true);
					AnimateExpandCollapseIcon(false, ExpandCollapseQuickFormulasMaterialIcon);
					break;
			}
		}
	}
}
