namespace Lights_Out_Enter_Form
{
    partial class LevelSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelSelection));
            this.LevelPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LevelPanel
            // 
            this.LevelPanel.AutoScroll = true;
            this.LevelPanel.Location = new System.Drawing.Point(8, 8);
            this.LevelPanel.Name = "LevelPanel";
            this.LevelPanel.Size = new System.Drawing.Size(331, 363);
            this.LevelPanel.TabIndex = 0;
            // 
            // LevelSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(343, 371);
            this.Controls.Add(this.LevelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LevelSelection";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeftLayout = true;
            this.Text = "Level Selection";
            this.Load += new System.EventHandler(this.LevelSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LevelPanel;
    }
}