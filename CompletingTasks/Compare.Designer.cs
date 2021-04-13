﻿namespace EnglishTest.CompletingTasks
{
    partial class Compare
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textTask = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // textTask
            // 
            this.textTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTask.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.textTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTask.CausesValidation = false;
            this.textTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(23)))), ((int)(((byte)(5)))));
            this.textTask.Location = new System.Drawing.Point(10, 239);
            this.textTask.Margin = new System.Windows.Forms.Padding(1);
            this.textTask.Multiline = true;
            this.textTask.Name = "textTask";
            this.textTask.ReadOnly = true;
            this.textTask.ShortcutsEnabled = false;
            this.textTask.Size = new System.Drawing.Size(778, 243);
            this.textTask.TabIndex = 20;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimer.Location = new System.Drawing.Point(123, 492);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(76, 29);
            this.lblTimer.TabIndex = 19;
            this.lblTimer.Text = "00:00";
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::EnglishTest.Properties.Resources.Stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(67, 486);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 50);
            this.btnStop.TabIndex = 18;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.EnabledChanged += new System.EventHandler(this.RecordButtonEnabledChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::EnglishTest.Properties.Resources.Start;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Location = new System.Drawing.Point(12, 486);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(50, 50);
            this.btnStart.TabIndex = 17;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.EnabledChanged += new System.EventHandler(this.RecordButtonEnabledChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(404, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(384, 215);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textTask);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Compare";
            this.Text = "Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task_FormClosing);
            this.Load += new System.EventHandler(this.Compare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textTask;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}