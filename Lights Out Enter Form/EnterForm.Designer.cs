﻿namespace Lights_Out_Enter_Form
{
    partial class EnterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterForm));
            this.LightBoard = new System.Windows.Forms.TableLayoutPanel();
            this.EnterButton = new System.Windows.Forms.Button();
            this.WorldTB = new System.Windows.Forms.TextBox();
            this.LevelTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LightBoard
            // 
            this.LightBoard.ColumnCount = 5;
            this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LightBoard.Location = new System.Drawing.Point(21, 12);
            this.LightBoard.Name = "LightBoard";
            this.LightBoard.RowCount = 5;
            this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LightBoard.Size = new System.Drawing.Size(250, 250);
            this.LightBoard.TabIndex = 0;
            // 
            // EnterButton
            // 
            this.EnterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterButton.FlatAppearance.BorderSize = 0;
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EnterButton.Location = new System.Drawing.Point(12, 321);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(83, 26);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Save";
            this.EnterButton.UseVisualStyleBackColor = false;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // WorldTB
            // 
            this.WorldTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WorldTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WorldTB.Location = new System.Drawing.Point(74, 283);
            this.WorldTB.Name = "WorldTB";
            this.WorldTB.Size = new System.Drawing.Size(60, 20);
            this.WorldTB.TabIndex = 2;
            // 
            // LevelTB
            // 
            this.LevelTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LevelTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LevelTB.Location = new System.Drawing.Point(188, 283);
            this.LevelTB.Name = "LevelTB";
            this.LevelTB.Size = new System.Drawing.Size(60, 20);
            this.LevelTB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(20, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "World";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(140, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level";
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoadButton.FlatAppearance.BorderSize = 0;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LoadButton.Location = new System.Drawing.Point(101, 321);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(83, 26);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DeleteButton.Location = new System.Drawing.Point(190, 321);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(83, 26);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(292, 372);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelTB);
            this.Controls.Add(this.WorldTB);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.LightBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnterForm";
            this.Text = "Lights Out Level Form";
            this.Load += new System.EventHandler(this.EnterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LightBoard;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.TextBox WorldTB;
        private System.Windows.Forms.TextBox LevelTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}