namespace GeCord
{
    partial class GeCord
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
            this.gfnUpdate = new System.Windows.Forms.Timer(this.components);
            this.dcinfo = new System.Windows.Forms.StatusStrip();
            this.stGFN = new System.Windows.Forms.ToolStripStatusLabel();
            this.stGame = new System.Windows.Forms.ToolStripStatusLabel();
            this.stDiscord = new System.Windows.Forms.ToolStripStatusLabel();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.dcinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gfnUpdate
            // 
            this.gfnUpdate.Enabled = true;
            this.gfnUpdate.Interval = 1000;
            this.gfnUpdate.Tick += new System.EventHandler(this.gfnUpdate_Tick);
            // 
            // dcinfo
            // 
            this.dcinfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stGFN,
            this.stGame,
            this.stDiscord});
            this.dcinfo.Location = new System.Drawing.Point(0, 428);
            this.dcinfo.Name = "dcinfo";
            this.dcinfo.Size = new System.Drawing.Size(333, 22);
            this.dcinfo.TabIndex = 0;
            this.dcinfo.Text = "statusStrip1";
            // 
            // stGFN
            // 
            this.stGFN.Name = "stGFN";
            this.stGFN.Size = new System.Drawing.Size(94, 17);
            this.stGFN.Text = "GeForce Now: --";
            // 
            // stGame
            // 
            this.stGame.Name = "stGame";
            this.stGame.Size = new System.Drawing.Size(51, 17);
            this.stGame.Text = "Nothing";
            // 
            // stDiscord
            // 
            this.stDiscord.Name = "stDiscord";
            this.stDiscord.Size = new System.Drawing.Size(63, 17);
            this.stDiscord.Text = "Discord: --";
            // 
            // notify
            // 
            this.notify.Text = "notifyIcon1";
            this.notify.Visible = true;
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // GeCord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 450);
            this.Controls.Add(this.dcinfo);
            this.Name = "GeCord";
            this.ShowInTaskbar = false;
            this.Text = "GeForce NOW Helper";
            this.Load += new System.EventHandler(this.GeCord_Load);
            this.Resize += new System.EventHandler(this.GeCord_Resize);
            this.dcinfo.ResumeLayout(false);
            this.dcinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gfnUpdate;
        private System.Windows.Forms.StatusStrip dcinfo;
        private System.Windows.Forms.ToolStripStatusLabel stGFN;
        private System.Windows.Forms.ToolStripStatusLabel stDiscord;
        private System.Windows.Forms.ToolStripStatusLabel stGame;
        private System.Windows.Forms.NotifyIcon notify;
    }
}

