namespace RocketLeagueReplaysToDataSet
{
    partial class frmLaunch
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
            this.LblReplayFolder = new System.Windows.Forms.Label();
            this.TxtReplayFolder = new System.Windows.Forms.TextBox();
            this.BtnReplayFolder = new System.Windows.Forms.Button();
            this.btnDataSetFolder = new System.Windows.Forms.Button();
            this.TxtDataSetFolder = new System.Windows.Forms.TextBox();
            this.LblDataSetFolder = new System.Windows.Forms.Label();
            this.btnRattletrapPath = new System.Windows.Forms.Button();
            this.txtRattletrapPath = new System.Windows.Forms.TextBox();
            this.LblRattletrapPath = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblReplayFolder
            // 
            this.LblReplayFolder.AutoSize = true;
            this.LblReplayFolder.Location = new System.Drawing.Point(9, 9);
            this.LblReplayFolder.Name = "LblReplayFolder";
            this.LblReplayFolder.Size = new System.Drawing.Size(72, 13);
            this.LblReplayFolder.TabIndex = 0;
            this.LblReplayFolder.Text = "Replay Folder";
            // 
            // TxtReplayFolder
            // 
            this.TxtReplayFolder.Location = new System.Drawing.Point(87, 6);
            this.TxtReplayFolder.Name = "TxtReplayFolder";
            this.TxtReplayFolder.Size = new System.Drawing.Size(373, 20);
            this.TxtReplayFolder.TabIndex = 1;
            // 
            // BtnReplayFolder
            // 
            this.BtnReplayFolder.Location = new System.Drawing.Point(466, 6);
            this.BtnReplayFolder.Name = "BtnReplayFolder";
            this.BtnReplayFolder.Size = new System.Drawing.Size(70, 20);
            this.BtnReplayFolder.TabIndex = 2;
            this.BtnReplayFolder.Text = "Find folder";
            this.BtnReplayFolder.UseVisualStyleBackColor = true;
            this.BtnReplayFolder.Click += new System.EventHandler(this.BtnReplayFolder_Click);
            // 
            // btnDataSetFolder
            // 
            this.btnDataSetFolder.Location = new System.Drawing.Point(466, 32);
            this.btnDataSetFolder.Name = "btnDataSetFolder";
            this.btnDataSetFolder.Size = new System.Drawing.Size(70, 20);
            this.btnDataSetFolder.TabIndex = 5;
            this.btnDataSetFolder.Text = "Find folder";
            this.btnDataSetFolder.UseVisualStyleBackColor = true;
            this.btnDataSetFolder.Click += new System.EventHandler(this.btnDataSetFolder_Click);
            // 
            // TxtDataSetFolder
            // 
            this.TxtDataSetFolder.Location = new System.Drawing.Point(87, 32);
            this.TxtDataSetFolder.Name = "TxtDataSetFolder";
            this.TxtDataSetFolder.Size = new System.Drawing.Size(373, 20);
            this.TxtDataSetFolder.TabIndex = 4;
            // 
            // LblDataSetFolder
            // 
            this.LblDataSetFolder.AutoSize = true;
            this.LblDataSetFolder.Location = new System.Drawing.Point(3, 35);
            this.LblDataSetFolder.Name = "LblDataSetFolder";
            this.LblDataSetFolder.Size = new System.Drawing.Size(78, 13);
            this.LblDataSetFolder.TabIndex = 3;
            this.LblDataSetFolder.Text = "DataSet Folder";
            // 
            // btnRattletrapPath
            // 
            this.btnRattletrapPath.Location = new System.Drawing.Point(466, 58);
            this.btnRattletrapPath.Name = "btnRattletrapPath";
            this.btnRattletrapPath.Size = new System.Drawing.Size(70, 20);
            this.btnRattletrapPath.TabIndex = 8;
            this.btnRattletrapPath.Text = "Find file";
            this.btnRattletrapPath.UseVisualStyleBackColor = true;
            this.btnRattletrapPath.Click += new System.EventHandler(this.btnRattletrapPath_Click);
            // 
            // txtRattletrapPath
            // 
            this.txtRattletrapPath.Location = new System.Drawing.Point(87, 58);
            this.txtRattletrapPath.Name = "txtRattletrapPath";
            this.txtRattletrapPath.Size = new System.Drawing.Size(373, 20);
            this.txtRattletrapPath.TabIndex = 7;
            // 
            // LblRattletrapPath
            // 
            this.LblRattletrapPath.AutoSize = true;
            this.LblRattletrapPath.Location = new System.Drawing.Point(20, 61);
            this.LblRattletrapPath.Name = "LblRattletrapPath";
            this.LblRattletrapPath.Size = new System.Drawing.Size(61, 13);
            this.LblRattletrapPath.TabIndex = 6;
            this.LblRattletrapPath.Text = "Parser path";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(389, 86);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(149, 23);
            this.btnConvert.TabIndex = 9;
            this.btnConvert.Text = "Convert replays to dataset";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Convert replays for visualisation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLaunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 121);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnRattletrapPath);
            this.Controls.Add(this.txtRattletrapPath);
            this.Controls.Add(this.LblRattletrapPath);
            this.Controls.Add(this.btnDataSetFolder);
            this.Controls.Add(this.TxtDataSetFolder);
            this.Controls.Add(this.LblDataSetFolder);
            this.Controls.Add(this.BtnReplayFolder);
            this.Controls.Add(this.TxtReplayFolder);
            this.Controls.Add(this.LblReplayFolder);
            this.Name = "frmLaunch";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblReplayFolder;
        private System.Windows.Forms.TextBox TxtReplayFolder;
        private System.Windows.Forms.Button BtnReplayFolder;
        private System.Windows.Forms.Button btnDataSetFolder;
        private System.Windows.Forms.TextBox TxtDataSetFolder;
        private System.Windows.Forms.Label LblDataSetFolder;
        private System.Windows.Forms.Button btnRattletrapPath;
        private System.Windows.Forms.TextBox txtRattletrapPath;
        private System.Windows.Forms.Label LblRattletrapPath;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button button1;
    }
}

