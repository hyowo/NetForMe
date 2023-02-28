namespace NetForMe
{
	partial class Startup
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
			label1 = new Label();
			pictureBox1 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Font = new Font("Poppins Black", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
			label1.ForeColor = Color.FromArgb(16, 24, 32);
			label1.Location = new Point(100, 194);
			label1.Name = "label1";
			label1.Size = new Size(288, 51);
			label1.TabIndex = 0;
			label1.Text = "Loading...";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(12, 11);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(376, 180);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// Startup
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(218, 201, 50);
			ClientSize = new Size(400, 250);
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			ForeColor = Color.White;
			FormBorderStyle = FormBorderStyle.None;
			Name = "Startup";
			Text = "Startup";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private PictureBox pictureBox1;
	}
}