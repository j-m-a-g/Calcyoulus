using Xamarin.Forms;
using Xamanimation;
using System;
using Xamarin.Essentials;
using XF.Material.Forms.UI.Dialogs;

namespace Calcyoulus
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			if (Preferences.ContainsKey("imperial_system_preferred"))
			{
				PreferredUnitsOfMeasureSystemPicker.SelectedItem = "Imperial";
			}
			else if (Preferences.ContainsKey("metric_system_preferred"))
			{
				PreferredUnitsOfMeasureSystemPicker.SelectedItem = "Metric";
			}
		}

		// COLORS FROM CODE-BEHIND
		string greenAccent1 = "#61d800";
		string lightAccent2 = "#dedede";

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

		private void LengthUnitConversionsWholeReciprocal(string fromUnitItem, string toUnitItem, double unitFactor)
		{
			if (FromUnitConversionsPicker.SelectedItem == fromUnitItem && ToUnitConversionsPicker.SelectedItem == toUnitItem)
			{
				double parsedLengthValueMaterialTextField = double.Parse(LengthValueMaterialTextField.Text);
				CalculationAnswerEntry.Text = Convert.ToString(parsedLengthValueMaterialTextField / unitFactor);
			}
			else if (FromUnitConversionsPicker.SelectedItem == toUnitItem && ToUnitConversionsPicker.SelectedItem == fromUnitItem)
			{
				double parsedLengthValueMaterialTextField = double.Parse(LengthValueMaterialTextField.Text);
				CalculationAnswerEntry.Text = Convert.ToString(parsedLengthValueMaterialTextField * unitFactor);
			}
			else if (FromUnitConversionsPicker.SelectedItem == ToUnitConversionsPicker.SelectedItem)
			{
				ToUnitConversionsPicker.SelectedItem = null;
			}
		}

		private void AreaUnitConversionsWholeReciprocal(string fromUnitItem, string toUnitItem, double unitFactor)
		{
			if (FromAreaUnitConversionsPicker.SelectedItem == fromUnitItem && ToAreaUnitConversionsPicker.SelectedItem == toUnitItem)
			{
				double parsedAreaValueMaterialTextField = double.Parse(AreaValueMaterialTextField.Text);
				CalculationAnswerEntry.Text = Convert.ToString(parsedAreaValueMaterialTextField / unitFactor);
			}
			else if (FromAreaUnitConversionsPicker.SelectedItem == toUnitItem && ToAreaUnitConversionsPicker.SelectedItem == fromUnitItem)
			{
				double parsedAreaValueMaterialTextField = double.Parse(AreaValueMaterialTextField.Text);
				CalculationAnswerEntry.Text = Convert.ToString(parsedAreaValueMaterialTextField * unitFactor);
			}
			else if (FromAreaUnitConversionsPicker.SelectedItem == ToAreaUnitConversionsPicker.SelectedItem)
			{
				ToAreaUnitConversionsPicker.SelectedItem = null;
			}
		}

		// EVENT HANDLERS

		/* Bottom Page Navigation Bar Grid */
		private void HomeNavigationPageImageButton_Clicked(object sender, EventArgs e)
		{
			SwitchScrollViewPages(HomePageScrollView, HomeImageButtonRectangle, "Home", HomeNavigationPageImageButton);
			ClearCalculatedAnswerEntryImageButton.IsVisible = true;
			AnswerUnitPicker.IsVisible = false;
			ImperialAnswerUnitPicker.IsVisible = false;
		}

		private void GeometryCalculatorsNavigationImageButton_Clicked(object sender, EventArgs e)
		{
			SwitchScrollViewPages(GeometryCalculatorsPageScrollView, GeometryCalculatorsImageButtonRectangle, "Geometry", GeometryCalculatorsNavigationImageButton);
			ClearCalculatedAnswerEntryImageButton.IsVisible = false;
			if (Preferences.ContainsKey("imperial_system_preferred"))
			{
				AnswerUnitPicker.IsVisible = false;
				ImperialAnswerUnitPicker.IsVisible = true;
			}
			else if (Preferences.ContainsKey("metric_system_preferred"))
			{
				ImperialAnswerUnitPicker.IsVisible = false;
				AnswerUnitPicker.IsVisible = true;
			}
		}

		private void LinearCalculatorsNavigationImageButton_Clicked(object sender, EventArgs e)
		{
			SwitchScrollViewPages(LinearCalculatorsScrollView, LinearCalculatorsImageButtonRectangle, "Linear Relations", LinearCalculatorsNavigationImageButton);
			ClearCalculatedAnswerEntryImageButton.IsVisible = true;
			AnswerUnitPicker.IsVisible = false;
			ImperialAnswerUnitPicker.IsVisible = false;
		}

		private void SettingsNavigationImageButton_Clicked(object sender, EventArgs e)
		{
			SwitchScrollViewPages(SettingsPageScrollView, SettingsImageButtonRectangle, "Settings", SettingsNavigationImageButton);
			ClearCalculatedAnswerEntryImageButton.IsVisible = true;
			AnswerUnitPicker.IsVisible = false;
			ImperialAnswerUnitPicker.IsVisible = false;
		}

		private void AnswerUnitPicker_SelectedIndexChanged(object sender, EventArgs e)
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

		private void ImperialAnswerUnitPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Checks if a selected item from the ItemsSource
			// is not a valid unit to be displayed.
			switch (ImperialAnswerUnitPicker.SelectedIndex)
			{
				case 0:
					ImperialAnswerUnitPicker.SelectedItem = null;
					break;
				case 1:
					ImperialAnswerUnitPicker.SelectedIndex = 2;
					break;
				case 6:
					ImperialAnswerUnitPicker.SelectedIndex = 7;
					break;
				case 12:
					ImperialAnswerUnitPicker.SelectedIndex = 13;
					break;
				case 17:
					ImperialAnswerUnitPicker.SelectedIndex = 18;
					break;
			}
		}

		private void CalculationAnswerEntry_TextChanged(object sender, TextChangedEventArgs e)
		{
			// Checks to see if there is any numerical answer text
			// in the CalculatedAnswerEntry to make it worthwhile
			// allowing the user to copy their result.
			if (CalculationAnswerEntry.Text != null)
			{
				CopyCalculatedAnswerImageButton.BackgroundColor = Color.FromHex(greenAccent1);
				CopyCalculatedAnswerImageButton.IsEnabled = true;

				ClearCalculatedAnswerEntryImageButton.BackgroundColor = Color.FromHex(greenAccent1);
				ClearCalculatedAnswerEntryImageButton.IsEnabled = true;
			}
			else
			{
				CopyCalculatedAnswerImageButton.BackgroundColor = Color.FromHex(lightAccent2);
				CopyCalculatedAnswerImageButton.IsEnabled = false;

				ClearCalculatedAnswerEntryImageButton.BackgroundColor = Color.FromHex(lightAccent2);
				ClearCalculatedAnswerEntryImageButton.IsEnabled = false;
			}
		}

		private void ClearCalculatedAnswerEntryImageButton_Clicked(object sender, EventArgs e)
		{
			CalculationAnswerEntry.Text = null;
		}

		private void CopyCalculatedAnswerImageButton_Clicked(object sender, EventArgs e)
		{
			if (CalculationAnswerEntry.Text == null) 
			{
				MaterialDialog.Instance.SnackbarAsync("There is no answer to copy.", actionButtonText: "OK");
			} 
			else if (AnswerUnitPicker.IsVisible)
			{
				Clipboard.SetTextAsync($"{CalculationAnswerEntry.Text} {AnswerUnitPicker.SelectedItem}");
				MaterialDialog.Instance.SnackbarAsync("Copied to the clipboard", actionButtonText: "OK");
			}
			else if (ImperialAnswerUnitPicker.IsVisible)
			{
				Clipboard.SetTextAsync($"{CalculationAnswerEntry.Text} {ImperialAnswerUnitPicker.SelectedItem}");
				MaterialDialog.Instance.SnackbarAsync("Copied to the clipboard", actionButtonText: "OK");
			}
			else
			{
				Clipboard.SetTextAsync($"{CalculationAnswerEntry.Text}");
				MaterialDialog.Instance.SnackbarAsync("Copied to the clipboard", actionButtonText: "OK");
			}
		}

		/* Home Page ScrollView */
		private void QuickFormulasMaterialCard_Clicked(object sender, EventArgs e)
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

		private void UnitConversionsMaterialCard_Clicked(object sender, EventArgs e)
		{
			switch (UnitConversionsExpandedMaterialCard.IsVisible)
			{
				case true:
					UnitConversionsExpandedMaterialCard.IsVisible = false;
					AnimateExpandCollapseIcon(true, ExpandCollapseUnitConversionsMaterialIcon);
					break;
				case false:
					UnitConversionsExpandedMaterialCard.IsVisible = true;
					AnimateExpandCollapseIcon(false, ExpandCollapseUnitConversionsMaterialIcon);
					break;
			}
		}

		private void LengthValueMaterialTextField_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (LengthValueMaterialTextField.Text == null || LengthValueMaterialTextField.Text == "")
			{
				CalculationAnswerEntry.Text = null;
			}
			else
			{
				// METRIC TO METRIC

				// Millimetres to Centimetres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "cm (centimetres)", 10);
				// Millimetres to Decimetres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "dm (decimetres)", 100);
				// Millimetres to Metres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "m (metres)", 1000);
				// Millimetres to Decametres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "dam (decametres)", 10000);
				// Millimetres to Hectometres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "hm (hectometres)", 100000);
				// Millimetres to Kilometres
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "km (kilometres)", 1000000);
				// Centimetres to Decimetres
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "dm (decimetres)", 10);
				// Centimetres to Metres
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "m (metres)", 100);
				// Centimetres to Decametres
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "dam (decametres)", 1000);
				// Centimetres to Hectometres
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "hm (hectometres)", 10000);
				// Centimetres to Kilometres
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "km (kilometres)", 100000);
				// Decimetres to Metres
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "m (metres)", 10);
				// Decimetres to Decametres
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "dam (decametres)", 100);
				// Decimetres to Hectometres
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "hm (hectometres)", 1000);
				// Decimetres to Kilometres
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "km (kilometres)", 10000);
				// Metres to Decametres
				LengthUnitConversionsWholeReciprocal("m (metres)", "dam (decametres)", 10);
				// Metres to Hectometres
				LengthUnitConversionsWholeReciprocal("m (metres)", "hm (hectometres)", 100);
				// Metres to Kilometres
				LengthUnitConversionsWholeReciprocal("m (metres)", "km (kilometres)", 1000);


				// IMPERIAL TO IMPERIAL

				// Inches to Feet
				LengthUnitConversionsWholeReciprocal("in (inches)", "ft (feet)", 12);
				// Inches to Yards
				LengthUnitConversionsWholeReciprocal("in (inches)", "yd (yards)", 36);
				// Inches to Miles
				LengthUnitConversionsWholeReciprocal("in (inches)", "mi (miles)", 63360);
				// Feet to Yards
				LengthUnitConversionsWholeReciprocal("ft (feet)", "yd (yards)", 3);
				// Feet to Miles
				LengthUnitConversionsWholeReciprocal("ft (feet)", "mi (miles)", 5280);
				// Yards to Miles
				LengthUnitConversionsWholeReciprocal("yd (yards)", "mi (miles)", 1760);


				// METRIC TO IMPERIAL (IMPERIAL TO METRIC)

				// Millimetres to Inches
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "in (inches)", 25.4);
				// Millimetres to Feet
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "ft (feet)", 304.8);
				// Millimetres to Yards
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "yd (yards)", 914.4);
				// Millimetres to Miles
				LengthUnitConversionsWholeReciprocal("mm (millimetres)", "mi (miles)", 1609000);
				// Centimetres to Inches
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "in (inches)", 2.54);
				// Centimetres to Feet
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "ft (feet)", 30.48);
				// Centimetres to Yards
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "yd (yards)", 91.44);
				// Centimetres to Miles
				LengthUnitConversionsWholeReciprocal("cm (centimetres)", "mi (miles)", 160900);
				// Decimetres to Inches
				LengthUnitConversionsWholeReciprocal("in (inches)", "dm (decimetres)", 3.937);
				// Decimetres to Feet
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "ft (feet)", 3.048);
				// Decimetres to Yards
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "yd (yards)", 9.144);
				// Decimetres to Miles
				LengthUnitConversionsWholeReciprocal("dm (decimetres)", "mi (miles)", 16090);
				// Metres to Inches
				LengthUnitConversionsWholeReciprocal("in (inches)", "m (metres)", 39.37);
				// Metres to Feet
				LengthUnitConversionsWholeReciprocal("ft (feet)", "m (metres)", 3.281);
				// Metres to Yards
				LengthUnitConversionsWholeReciprocal("yd (yards)", "m (metres)", 1.094);
				// Metres to Miles
				LengthUnitConversionsWholeReciprocal("m (metres)", "mi (miles)", 1609);
				// Decametres to Inches
				LengthUnitConversionsWholeReciprocal("in (inches)", "dam (decametres)", 393.7);
				// Decametres to Feet
				LengthUnitConversionsWholeReciprocal("ft (feet)", "dam (decametres)", 32.808);
				// Decametres to Yards
				LengthUnitConversionsWholeReciprocal("yd (yards)", "dam (decametres)", 10.936);
				// Decametres to Miles
				LengthUnitConversionsWholeReciprocal("dam (decametres)", "mi (miles)", 160.9);
				// Hectometres to Inches
				LengthUnitConversionsWholeReciprocal("in (inches)", "hm (hectometres)", 3937);
				// Hectometres to Feet
				LengthUnitConversionsWholeReciprocal("ft (feet)", "hm (hectometres)", 328.1);
				// Hectometres to Yards
				LengthUnitConversionsWholeReciprocal("yd (yards)", "hm (hectometres)", 109.4);
				// Hectometres to Miles
				LengthUnitConversionsWholeReciprocal("hm (hectometres)", "mi (miles)", 16.093);
				// Kilometres to Inches
				LengthUnitConversionsWholeReciprocal("in (inches)", "km (kilometres)", 39370);
				// Kilometres to Feet
				LengthUnitConversionsWholeReciprocal("ft (feet)", "km (kilometres)", 3281);
				// Kilometres to Yards
				LengthUnitConversionsWholeReciprocal("yd (yards)", "km (kilometres)", 1094);
				// Kilometres to Miles
				LengthUnitConversionsWholeReciprocal("km (kilometres)", "mi (miles)", 1.609);
			}
		}

		private void AreaValueMaterialTextField_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (AreaValueMaterialTextField.Text == null || AreaValueMaterialTextField.Text == "")
			{
				CalculationAnswerEntry.Text = null;
			}
			else
			{
				// METRIC TO METRIC

				// Square Millimetres to Square Centimetres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "cm² (square centimetres)", 100);
				// Square Millimetres to Square Decimetres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "dm² (square decimetres)", 10000);
				// Square Millimetres to Square Metres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "m² (square metres)", 1000000);
				// Square Millimetres to Square Decametres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "dam² (square decametres)", 100000000);
				// Square Millimetres to Square Hectometres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "hm² (square hecometres)", 10000000000);
				// Square Millimetres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "km² (square kilometres)", 1000000000000);

				// Square Centimetres to Square Decimetres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "dm² (square decimetres)", 100);
				// Square Centimetres to Square Metres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "m² (square metres)", 10000);
				// Square Centimetres to Square Decametres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "dam² (square decametres)", 1000000);
				// Square Centimetres to Square Hectometres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "hm² (square hecometres)", 100000000);
				// Square Centimetres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "km² (square kilometres)", 10000000000);
			}
		}

		/* Settings Page ScrollView */
		private void XFMaterialLibraryCreditMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Checks user's internet connection to prevent an error being thrown
			// when trying to navigate to the specified webpage.
			if (Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				Launcher.OpenAsync("https://github.com/Baseflow/XF-Material-Library");
			}
			else
			{
				MaterialDialog.Instance.SnackbarAsync(message: "It seems that you are not connected to the internet", actionButtonText: "OK", MaterialSnackbar.DurationLong);
			}
		}

		private void XamanimationCreditMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Checks user's internet connection to prevent an error being thrown
			// when trying to navigate to the specified webpage.
			if (Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				Launcher.OpenAsync("https://github.com/jsuarezruiz/Xamanimation");
			}
			else
			{
				MaterialDialog.Instance.SnackbarAsync(message: "It seems that you are not connected to the internet", actionButtonText: "OK", MaterialSnackbar.DurationLong);
			}
		}

		private void PreferredUnitsOfMeasureSystemPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Sets saved preference to be checked in the Geometry Calculators
			// page to be applied to the AnswerUnitPicker
			switch (PreferredUnitsOfMeasureSystemPicker.SelectedItem) 
			{ 
				case "Imperial":
					Preferences.Remove("metric_system_preferred");
					Preferences.Set("imperial_system_preferred", true);
					break;
				case "Metric":
					Preferences.Remove("imperial_system_preferred");
					Preferences.Set("metric_system_preferred", true);
					break;
			}
		}

		private void ResetAppPreferencesMaterialCard_Clicked(object sender, EventArgs e)
		{
			ResetAppPreferencesMaterialCard.IsVisible = false;
			ResetAppPreferencesWarningMaterialCard.IsVisible = true;
		}

		private void ResetAppPreferencesCancelMaterialCard_Clicked(object sender, EventArgs e)
		{
			ResetAppPreferencesWarningMaterialCard.IsVisible = false;
			ResetAppPreferencesMaterialCard.IsVisible = true;
		}

		private void ResetAppPreferencesProceedMaterialCard_Clicked(object sender, EventArgs e)
		{
			ResetAppPreferencesWarningMaterialCard.IsVisible = false;

			// Shows and disables the ResetAppPreferencesMaterialCard to disallow constant preference clearing
			ResetAppPreferencesMaterialCard.IsVisible = true;
			ResetAppPreferencesMaterialCard.IsClickable = false;
			ResetAppPreferencesMaterialCard.BackgroundColor = Color.FromHex(lightAccent2);

			PreferredUnitsOfMeasureSystemPicker.SelectedItem = null;
			Preferences.Clear();
		}
	}
}
