namespace MultipleJoysticks
{
    partial class MatchDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchDisplay));
            this.btnSkip = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SaveDataBtn = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblmatch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gamePad4 = new MultipleJoysticks.GamePadControl();
            this.gamePad3 = new MultipleJoysticks.GamePadControl();
            this.gamePad2 = new MultipleJoysticks.GamePadControl();
            this.gamePad1 = new MultipleJoysticks.GamePadControl();
            this.gamePad5 = new MultipleJoysticks.GamePadControl();
            this.gamePad6 = new MultipleJoysticks.GamePadControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.btnSkip.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.btnSkip.Location = new System.Drawing.Point(740, 2);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(50, 44);
            this.btnSkip.TabIndex = 229;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.textBox1.Location = new System.Drawing.Point(679, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 20);
            this.textBox1.TabIndex = 228;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.button3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.button3.Location = new System.Drawing.Point(796, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 33);
            this.button3.TabIndex = 226;
            this.button3.Text = "Set Up Teams and ";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // SaveDataBtn
            // 
            this.SaveDataBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.SaveDataBtn.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDataBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.SaveDataBtn.Location = new System.Drawing.Point(1159, 2);
            this.SaveDataBtn.Name = "SaveDataBtn";
            this.SaveDataBtn.Size = new System.Drawing.Size(110, 44);
            this.SaveDataBtn.TabIndex = 227;
            this.SaveDataBtn.Text = "Save Data";
            this.SaveDataBtn.UseVisualStyleBackColor = false;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label63.Location = new System.Drawing.Point(4, 3);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(128, 43);
            this.label63.TabIndex = 225;
            this.label63.Text = "Match: ";
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.lblEvent.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEvent.Location = new System.Drawing.Point(349, 4);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(450, 40);
            this.lblEvent.TabIndex = 224;
            this.lblEvent.Text = "Event";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.lblTime.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTime.Location = new System.Drawing.Point(168, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(188, 42);
            this.lblTime.TabIndex = 223;
            this.lblTime.Text = "Time";
            // 
            // lblmatch
            // 
            this.lblmatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.lblmatch.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblmatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblmatch.Location = new System.Drawing.Point(125, 4);
            this.lblmatch.Name = "lblmatch";
            this.lblmatch.Size = new System.Drawing.Size(47, 34);
            this.lblmatch.TabIndex = 222;
            this.lblmatch.Text = "1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.button1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.button1.Location = new System.Drawing.Point(956, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 44);
            this.button1.TabIndex = 221;
            this.button1.Text = "Save Data First Time";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // gamePad4
            // 
            this.gamePad4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(143)))));
            this.gamePad4.Location = new System.Drawing.Point(12, 390);
            this.gamePad4.Name = "gamePad4";
            this.gamePad4.Size = new System.Drawing.Size(444, 346);
            this.gamePad4.TabIndex = 233;
            // 
            // gamePad3
            // 
            this.gamePad3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.gamePad3.Location = new System.Drawing.Point(899, 47);
            this.gamePad3.Name = "gamePad3";
            this.gamePad3.Size = new System.Drawing.Size(444, 346);
            this.gamePad3.TabIndex = 232;
            // 
            // gamePad2
            // 
            this.gamePad2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.gamePad2.Location = new System.Drawing.Point(455, 47);
            this.gamePad2.Name = "gamePad2";
            this.gamePad2.Size = new System.Drawing.Size(444, 346);
            this.gamePad2.TabIndex = 231;
            // 
            // gamePad1
            // 
            this.gamePad1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.gamePad1.Location = new System.Drawing.Point(12, 47);
            this.gamePad1.Name = "gamePad1";
            this.gamePad1.Size = new System.Drawing.Size(444, 346);
            this.gamePad1.TabIndex = 230;
            // 
            // gamePad5
            // 
            this.gamePad5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(143)))));
            this.gamePad5.Location = new System.Drawing.Point(455, 390);
            this.gamePad5.Name = "gamePad5";
            this.gamePad5.Size = new System.Drawing.Size(444, 346);
            this.gamePad5.TabIndex = 234;
            // 
            // gamePad6
            // 
            this.gamePad6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(143)))));
            this.gamePad6.Location = new System.Drawing.Point(899, 390);
            this.gamePad6.Name = "gamePad6";
            this.gamePad6.Size = new System.Drawing.Size(444, 346);
            this.gamePad6.TabIndex = 235;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.button4.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.button4.Location = new System.Drawing.Point(740, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 44);
            this.button4.TabIndex = 236;
            this.button4.Text = "Event";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // MatchDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1343, 737);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.gamePad6);
            this.Controls.Add(this.gamePad5);
            this.Controls.Add(this.gamePad4);
            this.Controls.Add(this.gamePad3);
            this.Controls.Add(this.gamePad2);
            this.Controls.Add(this.gamePad1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SaveDataBtn);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblmatch);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatchDisplay";
            this.Text = "MatchDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button SaveDataBtn;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblmatch;
        private System.Windows.Forms.Button button1;
        private GamePadControl gamePad1;
        private GamePadControl gamePad2;
        private GamePadControl gamePad3;
        private GamePadControl gamePad4;
        private GamePadControl gamePad5;
        private GamePadControl gamePad6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
    }
}