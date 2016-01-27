namespace MultipleJoysticks
{
    partial class SortDataDisplay
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.lblData);
            this.dataPanel.Enabled = false;
            this.dataPanel.Location = new System.Drawing.Point(73, 12);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(424, 293);
            this.dataPanel.TabIndex = 1;
            this.dataPanel.Visible = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(29, 33);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(40, 13);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "lblData";
            // 
            // SortDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 382);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.button1);
            this.Name = "SortDataDisplay";
            this.Text = "SortDataDisplay";
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Label lblData;
    }
}