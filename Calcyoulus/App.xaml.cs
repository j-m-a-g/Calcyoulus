namespace Calcyoulus
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();
			XF.Material.Forms.Material.Init(this);
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
