namespace NetForMe
{
	public partial class Startup : Form
	{
		private System.Windows.Forms.Timer timer = new() { Interval = 400 };
		private int iteration = 0;
		public Startup()
		{
			InitializeComponent();
			timer.Tick += LoadingText;
			timer.Start();
			new Main().Show();
		}

		private void LoadingText(object? sender, EventArgs e)
		{
			if (iteration > 3)
				iteration = 0;
			iteration++;
			if (iteration == 1)
				label1.Text = "Loading";
			else
				label1.Text += ".";
		}

		public void ShowLoadingScreen()
		{
			
		}
	}
}