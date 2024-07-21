using System;
using Xamanimation;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI;
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

			if (Preferences.ContainsKey("always_show_clear_button"))
			{
				AlwaysShowClearButtonMaterialSwitch.IsActivated = true;
			}
		}

		// COLORS FROM CODE-BEHIND
		string greenAccent1 = "#61d800";
		string lightAccent2 = "#dedede";

		// GLOBAL VARIABLES
		string calculationAnswerEntryError = "Not all required values have been inputted";

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

		private void EnableOrDisableMaterialCardButton(MaterialCard correspondingButton, bool enabledOrDisabledBool, Color enabledColor)
		{
			switch (enabledOrDisabledBool)
			{
				case true:
					correspondingButton.IsEnabled = true;
					correspondingButton.BackgroundColor = enabledColor;
					break;
				case false:
					correspondingButton.IsEnabled = false;
					correspondingButton.BackgroundColor = Color.FromHex(lightAccent2);
					break;
			}
		}

		private void XOrYInterceptChange(MaterialSwitch activeSwitch, MaterialTextField interceptChanged, MaterialCard enabledOrDisabledInterceptButton)
		{
			switch (activeSwitch.IsActivated)
			{
				case true:
					EnableOrDisableMaterialCardButton(enabledOrDisabledInterceptButton, false, Color.White);
					interceptChanged.Text = "0";
					break;
				case false:
					EnableOrDisableMaterialCardButton(enabledOrDisabledInterceptButton, true, Color.White);
					interceptChanged.Text = "";
					break;
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

			if (Preferences.ContainsKey("always_show_clear_button"))
			{
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
			else
			{
				ClearCalculatedAnswerEntryImageButton.IsVisible = true;
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
			if (CalculationAnswerEntry.Text == null || CalculationAnswerEntry.Text == "")
			{
				CopyCalculatedAnswerImageButton.BackgroundColor = Color.FromHex(lightAccent2);
				CopyCalculatedAnswerImageButton.IsEnabled = false;

				ClearCalculatedAnswerEntryImageButton.BackgroundColor = Color.FromHex(lightAccent2);
				ClearCalculatedAnswerEntryImageButton.IsEnabled = false;
			}
			else if (CalculationAnswerEntry.Text == calculationAnswerEntryError ||
					 CalculationAnswerEntry.Text == "No date difference" ||
					 CalculationAnswerEntry.Text == "No date and time difference")
			{
				CopyCalculatedAnswerImageButton.BackgroundColor = Color.FromHex(lightAccent2);
				CopyCalculatedAnswerImageButton.IsEnabled = false;

				ClearCalculatedAnswerEntryImageButton.BackgroundColor = Color.FromHex(greenAccent1);
				ClearCalculatedAnswerEntryImageButton.IsEnabled = true;
			}
			else
			{
				CopyCalculatedAnswerImageButton.BackgroundColor = Color.FromHex(greenAccent1);
				CopyCalculatedAnswerImageButton.IsEnabled = true;

				ClearCalculatedAnswerEntryImageButton.BackgroundColor = Color.FromHex(greenAccent1);
				ClearCalculatedAnswerEntryImageButton.IsEnabled = true;
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

		private void DateDifferenceMaterialCard_Clicked(object sender, EventArgs e)
		{
			switch (DateDifferenceExpandedMaterialCard.IsVisible)
			{
				case true:
					DateDifferenceExpandedMaterialCard.IsVisible = false;
					AnimateExpandCollapseIcon(true, ExpandCollapseDateDifferenceMaterialIcon);
					break;
				case false:
					DateDifferenceExpandedMaterialCard.IsVisible = true;
					AnimateExpandCollapseIcon(false, ExpandCollapseDateDifferenceMaterialIcon);
					break;
			}
		}

		private void IncludeSpecificTimeForDateMaterialSwitch_Activated(object sender, XF.Material.Forms.UI.ActivatedEventArgs e)
		{
			switch (IncludeSpecificTimeForDateMaterialSwitch.IsActivated)
			{
				case true:
					FirstDatePairMaterialTimePicker.IsEnabled = true;
					SecondDatePairMaterialTimePicker.IsEnabled = true;
					break;
				case false:
					FirstDatePairMaterialTimePicker.IsEnabled = false;
					SecondDatePairMaterialTimePicker.IsEnabled = false;
					break;
			}
		}

		private void FindDateDifferenceMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Specifies characters to trim when only date values are inputted
			char[] dateOnlyTrim = { ':', '0' };

			switch (FirstDatePairMaterialTimePicker.IsEnabled && SecondDatePairMaterialTimePicker.IsEnabled)
			{
				case true:
					// Defined variables that represent each pair of DatePickers and TimePickers
					DateTime firstDateTimePairSum = FirstMaterialDatePicker.Date + FirstDatePairMaterialTimePicker.Time;
					DateTime secondDateTimePairSum = SecondMaterialDatePicker.Date + SecondDatePairMaterialTimePicker.Time;

					if (firstDateTimePairSum > secondDateTimePairSum)
					{
						TimeSpan firstGreaterDifference = firstDateTimePairSum - secondDateTimePairSum;
						CalculationAnswerEntry.Text = $"{firstGreaterDifference.ToString()} days:hours:minutes:seconds";
					}
					else if (firstDateTimePairSum < secondDateTimePairSum)
					{
						TimeSpan secondGreaterDifference = secondDateTimePairSum - firstDateTimePairSum;
						CalculationAnswerEntry.Text = $"{secondGreaterDifference.ToString()} days:hours:minutes:seconds";
					}
					else if (firstDateTimePairSum == secondDateTimePairSum)
					{
						CalculationAnswerEntry.Text = "No date and time difference";
					}
					break;
				case false:
					if (FirstMaterialDatePicker.Date > SecondMaterialDatePicker.Date)
					{
						TimeSpan firstDatePickerGreaterDifference = FirstMaterialDatePicker.Date - SecondMaterialDatePicker.Date;
						CalculationAnswerEntry.Text = $"{firstDatePickerGreaterDifference.ToString().Trim(dateOnlyTrim)} days";
					}
					else if (FirstMaterialDatePicker.Date < SecondMaterialDatePicker.Date)
					{
						TimeSpan secondDatePickerGreaterDifference = SecondMaterialDatePicker.Date - FirstMaterialDatePicker.Date;
						CalculationAnswerEntry.Text = $"{secondDatePickerGreaterDifference.ToString().Trim(dateOnlyTrim)} days";
					}
					else if (FirstMaterialDatePicker.Date == SecondMaterialDatePicker.Date)
					{
						CalculationAnswerEntry.Text = "No date difference";
					}
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
				// Square Millimetres to Hectares
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "ha (hectares)", 10000000000);

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
				// Square Centimetres to Hectares
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "ha (hectares)", 100000000);

				// Square Decimetres to Square Metres
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "m² (square metres)", 100);
				// Square Decimetres to Square Decametres
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "dam² (square decametres)", 10000);
				// Square Decimetres to Square Hectometres
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "hm² (square hectometres)", 1000000);
				// Square Decimetres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "km² (square kilometres)", 100000000);
				// Square Decimetres to Hectares
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "ha (hectares)", 1000000);

				// Square Metres to Square Decametres
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "dam² (square decametres)", 100);
				// Square Metres to Square Hectometres
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "hm² (square hectometres)", 10000);
				// Square Metres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "km² (square kilometres)", 1000000);
				// Square Metres to Hectares
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "ha (hectares)", 10000);

				// Square Decametres to Square Hectometres
				AreaUnitConversionsWholeReciprocal("dam² (square decametres)", "hm² (square hectometres)", 100);
				// Square Decametres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("dam² (square decametres)", "km² (square kilometres)", 10000);
				// Square Decametres to Hectares
				AreaUnitConversionsWholeReciprocal("dam² (square decametres)", "ha (hectares)", 100);

				// Square Hectometres to Square Kilometres
				AreaUnitConversionsWholeReciprocal("hm² (square hectometres)", "km² (square kilometres)", 100);
				// Square Hectometres to Hectares
				AreaUnitConversionsWholeReciprocal("hm² (square hectometres)", "ha (hectares)", 1);

				// Square Kilometres to Hectares
				AreaUnitConversionsWholeReciprocal("ha (hectares)", "km² (square kilometres)", 100);


				// IMPERIAL TO IMPERIAL

				// Square Inches to Square Feet
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "ft² (square feet)", 144);
				// Square Inches to Square Yards
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "yd² (square yards)", 1296);
				// Square Inches to Square Miles
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "mi² (square miles)", 4014000000);
				// Square Inches to Acres
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "ac (acres)", 6273000);

				// Square Feet to Square Yards
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "yd² (square yards)", 9);
				// Square Feet to Square Miles
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "mi² (square miles)", 27880000);
				// Square Feet to Acres
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "ac (acres)", 43560);

				// Square Yards to Square Miles
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "mi² (square miles)", 3098000);
				// Square Yards to Acres
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "ac (acres)", 4840);

				// Square Miles to Acres
				AreaUnitConversionsWholeReciprocal("ac (acres)", "mi² (square miles)", 640);


				// METRIC TO IMPERIAL (IMPERIAL TO METRIC)

				// Square Millimetres to Square Inches
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "in² (square inches)", 645.2);
				// Square Millimetres to Square Feet
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "ft² (square feet)", 92900);
				// Square Millimetres to Square Yards
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "yd² (square yards)", 836100);
				// Square Millimetres to Square Miles
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "mi² (square miles)", 2590000000000);
				// Square Millimetres to Acres
				AreaUnitConversionsWholeReciprocal("mm² (square millimetres)", "ac (acres)", 4047000000);

				// Square Centimetres to Square Inches
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "in² (square inches)", 6.452);
				// Square Centimetres to Square Feet
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "ft² (square feet)", 929);
				// Square Centimetres to Square Yards
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "yd² (square yards)", 8361);
				// Square Centimetres to Square Miles
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "mi² (square miles)", 25900000000);
				// Square Centimetres to Acres
				AreaUnitConversionsWholeReciprocal("cm² (square centimetres)", "ac (acres)", 40470000);

				// Square Decimetres to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "dm² (square decimetres)", 15.5);
				// Square Decimetres to Square Feet
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "ft² (square feet)", 9.29);
				// Square Decimetres to Square Yards
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "yd² (square yards)", 83.613);
				// Square Decimetres to Square Miles
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "mi² (square miles)", 259000000);
				// Square Decimetres to Acres
				AreaUnitConversionsWholeReciprocal("dm² (square decimetres)", "ac (acres)", 404700);

				// Square Metres to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "m² (square metres)", 1550);
				// Square Metres to Square Feet
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "m² (square metres)", 10.764);
				// Square Metres to Square Yards
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "m² (square metres)", 1.196);
				// Square Metres to Square Miles
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "mi² (square miles)", 2590000);
				// Square Metres to Acres
				AreaUnitConversionsWholeReciprocal("m² (square metres)", "ac (acres)", 4047);

				// Square Decametres to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "dam² (square decametres)", 155000);
				// Square Decametres to Square Feet
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "dam² (square decametres)", 1076);
				// Square Decametres to Square Yards
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "dam² (square decametres)", 119.6);
				// Square Decametres to Square Miles
				AreaUnitConversionsWholeReciprocal("dam² (square decametres)", "mi² (square miles)", 25900);
				// Square Decametres to Acres
				AreaUnitConversionsWholeReciprocal("dam² (square decametres)", "ac (acres)", 40.469);

				// Square Hectometres to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "hm² (square hectometres)", 15500000);
				// Square Hectometres to Square Feet
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "hm² (square hectometres)", 107600);
				// Square Hectometres to Square Yards
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "hm² (square hectometres)", 11960);
				// Square Hectometres to Square Miles
				AreaUnitConversionsWholeReciprocal("hm² (square hectometres)", "mi² (square miles)", 259);
				// Square Hectometres to Acres
				AreaUnitConversionsWholeReciprocal("ac (acres)", "hm² (square hectometres)", 2.471);

				// Square Kilometres to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "km² (square kilometres)", 1550000000);
				// Square Kilometres to Square Feet
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "km² (square kilometres)", 10760000);
				// Square Kilometres to Square Yards
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "km² (square kilometres)", 1196000);
				// Square Kilometres to Square Miles
				AreaUnitConversionsWholeReciprocal("km² (square kilometres)", "mi² (square miles)", 2.59);
				// Square Kilometres to Acres
				AreaUnitConversionsWholeReciprocal("ac (acres)", "km² (square kilometres)", 247.1);

				// Hectares to Square Inches
				AreaUnitConversionsWholeReciprocal("in² (square inches)", "ha (hectares)", 15500000);
				// Hectares to Square Feet
				AreaUnitConversionsWholeReciprocal("ft² (square feet)", "ha (hectares)", 107600);
				// Hectares to Square Yards
				AreaUnitConversionsWholeReciprocal("yd² (square yards)", "ha (hectares)", 11960);
				// Hectares to Square Miles
				AreaUnitConversionsWholeReciprocal("ha (hectares)", "mi² (square miles)", 259);
				// Hectares to Acres
				AreaUnitConversionsWholeReciprocal("ac (acres)", "ha (hectares)", 2.471);
			}
		}

		/* Linear Calculators ScrollView */
		private void SolveSystemMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Checks if user has inputted any value in the first
			// place to prevent throwing an exception and crashing
			if (FirstLinearSystemsEquationMValueMaterialTextField.Text == null ||
				FirstLinearSystemsEquationMValueMaterialTextField.Text == "" ||
				FirstLinearSystemsEquationBValueMaterialTextField.Text == null ||
				FirstLinearSystemsEquationBValueMaterialTextField.Text == "" ||
				SecondLinearSystemsEquationMValueMaterialTextField.Text == null ||
				SecondLinearSystemsEquationMValueMaterialTextField.Text == "" ||
				SecondLinearSystemsEquationBValueMaterialTextField.Text == null ||
				SecondLinearSystemsEquationBValueMaterialTextField.Text == "")
			{
				CalculationAnswerEntry.Text = calculationAnswerEntryError;
			}
			else
			{
				double firstLinearSystemsEquationMDouble = int.Parse(FirstLinearSystemsEquationMValueMaterialTextField.Text);
				double firstLinearSystemsEquationBDouble = int.Parse(FirstLinearSystemsEquationBValueMaterialTextField.Text);

				double secondLinearSystemsEquationMDouble = int.Parse(SecondLinearSystemsEquationMValueMaterialTextField.Text);
				double secondLinearSystemsEquationBDouble = int.Parse(SecondLinearSystemsEquationBValueMaterialTextField.Text);

				// STEP 1: Cancel out and subtract the second linear equation's 'b' value from the first
				double solveSystemFirstStep = secondLinearSystemsEquationBDouble - firstLinearSystemsEquationBDouble;

				// STEP 2: Subtract first linear equation's 'm' value from the second (acts as coefficient for variable)
				double solveSystemSecondStep = firstLinearSystemsEquationMDouble - secondLinearSystemsEquationMDouble;

				// STEP 3: Divide the integer, "on the left side of the equation," by the, "coefficient"
				// Point of Intersection X
				double pointOfIntersectionXVal = solveSystemFirstStep / solveSystemSecondStep;

				// Point of Intersection Y
				double pointOfIntersectionYVal = firstLinearSystemsEquationMDouble * pointOfIntersectionXVal + firstLinearSystemsEquationBDouble;

				// Output Answer
				CalculationAnswerEntry.Text = $"P.O.I. = ({pointOfIntersectionXVal}, {pointOfIntersectionYVal})";
			}
		}

		private void TwoPointsModeMaterialRadioButton_SelectedChanged(object sender, XF.Material.Forms.UI.SelectedChangedEventArgs e)
		{
			switch (TwoPointsModeMaterialRadioButton.IsSelected)
			{
				case true:
					PointAndEquationModeMaterialRadioButton.IsSelected = false;
					TwoPointsModeStackLayout.IsVisible = true;
					break;
				case false:
					TwoPointsModeStackLayout.IsVisible = false;
					break;
			}
		}

		private void TwoPointsModeFindSlopeMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Checks if user has inputted any value in the first
			// place to prevent throwing an exception and crashing
			if (XFirstPointTwoPointsModeMaterialTextField.Text == null ||
				XFirstPointTwoPointsModeMaterialTextField.Text == "" ||
				YFirstPointTwoPointsModeMaterialTextField.Text == null ||
				YFirstPointTwoPointsModeMaterialTextField.Text == "" ||
				XSecondPointTwoPointsModeMaterialTextField.Text == null ||
				XSecondPointTwoPointsModeMaterialTextField.Text == "" ||
				YSecondPointTwoPointsModeMaterialTextField.Text == null ||
				YSecondPointTwoPointsModeMaterialTextField.Text == "")
			{
				CalculationAnswerEntry.Text = calculationAnswerEntryError;
			}
			else
			{
				// First Point's Parsed Variables
				double xFirstPointTwoPointsMode = int.Parse(XFirstPointTwoPointsModeMaterialTextField.Text);
				double yFirstPointTwoPointsMode = int.Parse(YFirstPointTwoPointsModeMaterialTextField.Text);

				// Second Point's Parsed Variables
				double xSecondPointTwoPointsMode = int.Parse(XSecondPointTwoPointsModeMaterialTextField.Text);
				double ySecondPointTwoPointsMode = int.Parse(YSecondPointTwoPointsModeMaterialTextField.Text);

				// STEP 1: Subtract second point's 'y' value by the first point's 'y' value
				double twoPointsModeFindSlopeFirstStep = ySecondPointTwoPointsMode - yFirstPointTwoPointsMode;

				// STEP 2: Subtract second point's 'x' value by the first point's 'x' value
				double twoPointsModeFindSlopeSecondStep = xSecondPointTwoPointsMode - xFirstPointTwoPointsMode;

				// STEP 3: Divide the result of the first step by the second step
				double twoPointsModeFindSlopeThirdStep = twoPointsModeFindSlopeFirstStep / twoPointsModeFindSlopeSecondStep;

				// Output Answer
				CalculationAnswerEntry.Text = $"m = {twoPointsModeFindSlopeThirdStep}";

				if (CalculationAnswerEntry.Text == "m = NaN" || CalculationAnswerEntry.Text == "m = Infinity")
				{
					CalculationAnswerEntry.Text = "m = Undefined";
				}
			}
		}

		private void TwoPointsModeFindEquationMaterialCard_Clicked(object sender, EventArgs e)
		{
			// Checks if user has inputted any value in the first
			// place to prevent throwing an exception and crashing
			if (XFirstPointTwoPointsModeMaterialTextField.Text == null ||
				XFirstPointTwoPointsModeMaterialTextField.Text == "" ||
				YFirstPointTwoPointsModeMaterialTextField.Text == null ||
				YFirstPointTwoPointsModeMaterialTextField.Text == "" ||
				XSecondPointTwoPointsModeMaterialTextField.Text == null ||
				XSecondPointTwoPointsModeMaterialTextField.Text == "" ||
				YSecondPointTwoPointsModeMaterialTextField.Text == null ||
				YSecondPointTwoPointsModeMaterialTextField.Text == "")
			{
				CalculationAnswerEntry.Text = calculationAnswerEntryError;
			}
			else if (XFirstPointTwoPointsModeMaterialTextField.Text == XSecondPointTwoPointsModeMaterialTextField.Text)
			{
				CalculationAnswerEntry.Text = $"x = {XFirstPointTwoPointsModeMaterialTextField.Text}";
			}
			else
			{
				// First Point's Parsed Variables
				double xFirstPointTwoPointsMode = int.Parse(XFirstPointTwoPointsModeMaterialTextField.Text);
				double yFirstPointTwoPointsMode = int.Parse(YFirstPointTwoPointsModeMaterialTextField.Text);

				// Second Point's Parsed Variables
				double xSecondPointTwoPointsMode = int.Parse(XSecondPointTwoPointsModeMaterialTextField.Text);
				double ySecondPointTwoPointsMode = int.Parse(YSecondPointTwoPointsModeMaterialTextField.Text);

				// STEP 1: Subtract second point's 'y' value by the first point's 'y' value
				double twoPointsModeFindEquationFirstStep = ySecondPointTwoPointsMode - yFirstPointTwoPointsMode;

				// STEP 2: Subtract second point's 'x' value by the first point's 'x' value
				double twoPointsModeFindEquationSecondStep = xSecondPointTwoPointsMode - xFirstPointTwoPointsMode;

				// STEP 3: Divide the result of the first step by the second step to get the slope
				double twoPointsModeFindEquationThirdStep = twoPointsModeFindEquationFirstStep / twoPointsModeFindEquationSecondStep;

				// STEP 4: Multiply the first point's 'x' value by the slope
				double twoPointsModeFindEquationFourthStep = xFirstPointTwoPointsMode * twoPointsModeFindEquationThirdStep;

				// STEP 5: Subtract the first point's 'y' value by result in Step 4 
				double twoPointsModeFindEquationFifthStep = yFirstPointTwoPointsMode - twoPointsModeFindEquationFourthStep;

				// Output Answer
				string twoPointsModeFindEquationAnswer = $"y = {twoPointsModeFindEquationThirdStep}x + {twoPointsModeFindEquationFifthStep}";
				CalculationAnswerEntry.Text = twoPointsModeFindEquationAnswer;

				// Simplifies calculated equation if an unnecessary coefficient of '0' is
				// applied to 'x'
				if (CalculationAnswerEntry.Text.Contains("0x"))
				{
					string simplifiedEquation = twoPointsModeFindEquationAnswer.Remove(4, 5);
					CalculationAnswerEntry.Text = simplifiedEquation;
				}
			}
		}

		private void TwoPointsModeXInterceptMaterialSwitch_Activated(object sender, ActivatedEventArgs e)
		{
			XOrYInterceptChange(TwoPointsModeXInterceptMaterialSwitch, YFirstPointTwoPointsModeMaterialTextField, TwoPointsModeFindXInterceptMaterialCard);
		}

		private void TwoPointsModeYInterceptMaterialSwitch_Activated(object sender, ActivatedEventArgs e)
		{
			XOrYInterceptChange(TwoPointsModeYInterceptMaterialSwitch, XSecondPointTwoPointsModeMaterialTextField, TwoPointsModeFindYInterceptMaterialCard);
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

		private void AlwaysShowClearButtonMaterialSwitch_Activated(object sender, XF.Material.Forms.UI.ActivatedEventArgs e)
		{
			switch (AlwaysShowClearButtonMaterialSwitch.IsActivated)
			{
				case true:
					Preferences.Remove("always_show_clear_button");
					break;
				case false:
					Preferences.Set("always_show_clear_button", true);
					break;
			}
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
