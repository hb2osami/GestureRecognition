using System;

namespace ProjetImage
{
     partial  class Form1
        {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LRX = new System.Windows.Forms.Label();
            this.LRZ = new System.Windows.Forms.Label();
            this.LRY = new System.Windows.Forms.Label();
            this.pbKinectVideo = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LYL = new System.Windows.Forms.Label();
            this.LZL = new System.Windows.Forms.Label();
            this.LXL = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbKinectVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // LRX
            // 
            this.LRX.AutoSize = true;
            this.LRX.Location = new System.Drawing.Point(38, 47);
            this.LRX.Name = "LRX";
            this.LRX.Size = new System.Drawing.Size(23, 13);
            this.LRX.TabIndex = 0;
            this.LRX.Text = "X : ";
            // 
            // LRZ
            // 
            this.LRZ.AutoSize = true;
            this.LRZ.Location = new System.Drawing.Point(38, 100);
            this.LRZ.Name = "LRZ";
            this.LRZ.Size = new System.Drawing.Size(23, 13);
            this.LRZ.TabIndex = 1;
            this.LRZ.Text = "Z : ";
            // 
            // LRY
            // 
            this.LRY.AutoSize = true;
            this.LRY.Location = new System.Drawing.Point(38, 71);
            this.LRY.Name = "LRY";
            this.LRY.Size = new System.Drawing.Size(23, 13);
            this.LRY.TabIndex = 2;
            this.LRY.Text = "Y : ";
            // 
            // pbKinectVideo
            // 
            this.pbKinectVideo.Location = new System.Drawing.Point(170, 12);
            this.pbKinectVideo.Name = "pbKinectVideo";
            this.pbKinectVideo.Size = new System.Drawing.Size(709, 532);
            this.pbKinectVideo.TabIndex = 3;
            this.pbKinectVideo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "right hand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "right hand";
            // 
            // LYL
            // 
            this.LYL.AutoSize = true;
            this.LYL.Location = new System.Drawing.Point(38, 215);
            this.LYL.Name = "LYL";
            this.LYL.Size = new System.Drawing.Size(23, 13);
            this.LYL.TabIndex = 8;
            this.LYL.Text = "Y : ";
            // 
            // LZL
            // 
            this.LZL.AutoSize = true;
            this.LZL.Location = new System.Drawing.Point(38, 244);
            this.LZL.Name = "LZL";
            this.LZL.Size = new System.Drawing.Size(17, 13);
            this.LZL.TabIndex = 7;
            this.LZL.Text = "Z:";
            this.LZL.Click += new System.EventHandler(this.label3_Click);
            // 
            // LXL
            // 
            this.LXL.AutoSize = true;
            this.LXL.Location = new System.Drawing.Point(38, 191);
            this.LXL.Name = "LXL";
            this.LXL.Size = new System.Drawing.Size(23, 13);
            this.LXL.TabIndex = 6;
            this.LXL.Text = "X : ";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(29, 283);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 9;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(29, 355);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 10;
            this.stop.Text = "STOP";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.LYL);
            this.Controls.Add(this.LZL);
            this.Controls.Add(this.LXL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbKinectVideo);
            this.Controls.Add(this.LRY);
            this.Controls.Add(this.LRZ);
            this.Controls.Add(this.LRX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbKinectVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label LRX;
        private System.Windows.Forms.Label LRZ;
        private System.Windows.Forms.Label LRY;
        private System.Windows.Forms.PictureBox pbKinectVideo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LYL;
        private System.Windows.Forms.Label LZL;
        private System.Windows.Forms.Label LXL;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
    }
}

