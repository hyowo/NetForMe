namespace NetForMe
{
	partial class Main
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
			TopbarPanel = new Panel();
			MinimizeButton = new Button();
			ExitButton = new Button();
			MenuPanel = new Panel();
			ActivityPanel = new Panel();
			button1 = new Button();
			TopbarPanel.SuspendLayout();
			MenuPanel.SuspendLayout();
			SuspendLayout();
			// 
			// TopbarPanel
			// 
			TopbarPanel.Controls.Add(MinimizeButton);
			TopbarPanel.Controls.Add(ExitButton);
			TopbarPanel.Dock = DockStyle.Top;
			TopbarPanel.Location = new Point(0, 0);
			TopbarPanel.Name = "TopbarPanel";
			TopbarPanel.Size = new Size(900, 30);
			TopbarPanel.TabIndex = 1;
			// 
			// MinimizeButton
			// 
			MinimizeButton.BackColor = Color.FromArgb(180, 170, 30);
			MinimizeButton.Dock = DockStyle.Right;
			MinimizeButton.FlatAppearance.BorderSize = 0;
			MinimizeButton.FlatStyle = FlatStyle.Flat;
			MinimizeButton.Font = new Font("Poppins Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
			MinimizeButton.ForeColor = Color.FromArgb(16, 24, 32);
			MinimizeButton.Location = new Point(840, 0);
			MinimizeButton.Name = "MinimizeButton";
			MinimizeButton.Size = new Size(30, 30);
			MinimizeButton.TabIndex = 2;
			MinimizeButton.Text = "🗕";
			MinimizeButton.TextAlign = ContentAlignment.BottomCenter;
			MinimizeButton.UseVisualStyleBackColor = false;
			// 
			// ExitButton
			// 
			ExitButton.BackColor = Color.FromArgb(180, 170, 30);
			ExitButton.Dock = DockStyle.Right;
			ExitButton.FlatAppearance.BorderSize = 0;
			ExitButton.FlatStyle = FlatStyle.Flat;
			ExitButton.Font = new Font("Poppins Black", 7F, FontStyle.Bold, GraphicsUnit.Point);
			ExitButton.ForeColor = Color.FromArgb(16, 24, 32);
			ExitButton.Location = new Point(870, 0);
			ExitButton.Name = "ExitButton";
			ExitButton.Size = new Size(30, 30);
			ExitButton.TabIndex = 0;
			ExitButton.Text = "✖";
			ExitButton.TextAlign = ContentAlignment.BottomCenter;
			ExitButton.UseVisualStyleBackColor = false;
			// 
			// MenuPanel
			// 
			MenuPanel.Controls.Add(button1);
			MenuPanel.Dock = DockStyle.Left;
			MenuPanel.Location = new Point(0, 30);
			MenuPanel.Name = "MenuPanel";
			MenuPanel.Size = new Size(200, 470);
			MenuPanel.TabIndex = 2;
			// 
			// ActivityPanel
			// 
			ActivityPanel.Dock = DockStyle.Fill;
			ActivityPanel.Location = new Point(200, 30);
			ActivityPanel.Margin = new Padding(10);
			ActivityPanel.Name = "ActivityPanel";
			ActivityPanel.Padding = new Padding(10);
			ActivityPanel.Size = new Size(700, 470);
			ActivityPanel.TabIndex = 3;
			// 
			// button1
			// 
			button1.Location = new Point(46, 47);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(218, 201, 50);
			ClientSize = new Size(900, 500);
			Controls.Add(ActivityPanel);
			Controls.Add(MenuPanel);
			Controls.Add(TopbarPanel);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Main";
			Text = "Main";
			TopbarPanel.ResumeLayout(false);
			MenuPanel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel TopbarPanel;
		private Button MinimizeButton;
		private Button ExitButton;
		private Panel MenuPanel;
		private Panel ActivityPanel;
		private Button button1;
	}
}