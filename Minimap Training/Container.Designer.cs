namespace Minimap_Training
{
    partial class Container
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
            this.components = new System.ComponentModel.Container();
            this.DotAppearTimer = new System.Windows.Forms.Timer(this.components);
            this.DotGrowTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DotAppearTimer
            // 
            this.DotAppearTimer.Tick += new System.EventHandler(this.DotAppearTimer_Tick);
            // 
            // DotGrowTimer
            // 
            this.DotGrowTimer.Interval = 7000;
            this.DotGrowTimer.Tick += new System.EventHandler(this.DotGrowTimer_Tick);
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(30, 30);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(30, 30);
            this.MinimumSize = new System.Drawing.Size(30, 30);
            this.Name = "Container";
            this.Opacity = 0.01D;
            this.ShowInTaskbar = false;
            this.Text = "Container";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Container_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Container_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer DotAppearTimer;
        private System.Windows.Forms.Timer DotGrowTimer;
    }
}

