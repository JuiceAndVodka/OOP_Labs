namespace OOP_UI
{
    partial class TypeOfFile
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
            this.CBType = new System.Windows.Forms.ComboBox();
            this.LabelMain = new System.Windows.Forms.Label();
            this.BAccept = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.LabelChoise = new System.Windows.Forms.Label();
            this.CheckChoise = new System.Windows.Forms.CheckBox();
            this.LabelPlugins = new System.Windows.Forms.Label();
            this.CBPlugins = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CBType
            // 
            this.CBType.FormattingEnabled = true;
            this.CBType.Location = new System.Drawing.Point(32, 75);
            this.CBType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(180, 21);
            this.CBType.TabIndex = 0;
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMain.Location = new System.Drawing.Point(8, 40);
            this.LabelMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(230, 20);
            this.LabelMain.TabIndex = 1;
            this.LabelMain.Text = "Choose a type of serialization";
            // 
            // BAccept
            // 
            this.BAccept.Location = new System.Drawing.Point(93, 252);
            this.BAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BAccept.Name = "BAccept";
            this.BAccept.Size = new System.Drawing.Size(67, 28);
            this.BAccept.TabIndex = 2;
            this.BAccept.Text = "Accept";
            this.BAccept.UseVisualStyleBackColor = true;
            this.BAccept.Click += new System.EventHandler(this.BAccept_Click);
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(176, 252);
            this.BCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(67, 28);
            this.BCancel.TabIndex = 3;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // LabelChoise
            // 
            this.LabelChoise.AutoSize = true;
            this.LabelChoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelChoise.Location = new System.Drawing.Point(44, 119);
            this.LabelChoise.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelChoise.Name = "LabelChoise";
            this.LabelChoise.Size = new System.Drawing.Size(151, 20);
            this.LabelChoise.TabIndex = 4;
            this.LabelChoise.Text = "Wanna use plugin?";
            // 
            // CheckChoise
            // 
            this.CheckChoise.AutoSize = true;
            this.CheckChoise.Location = new System.Drawing.Point(84, 151);
            this.CheckChoise.Name = "CheckChoise";
            this.CheckChoise.Size = new System.Drawing.Size(64, 17);
            this.CheckChoise.TabIndex = 5;
            this.CheckChoise.Text = "Want to";
            this.CheckChoise.UseVisualStyleBackColor = true;
            // 
            // LabelPlugins
            // 
            this.LabelPlugins.AutoSize = true;
            this.LabelPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPlugins.Location = new System.Drawing.Point(54, 171);
            this.LabelPlugins.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPlugins.Name = "LabelPlugins";
            this.LabelPlugins.Size = new System.Drawing.Size(129, 20);
            this.LabelPlugins.TabIndex = 6;
            this.LabelPlugins.Text = "Choose a plugin";
            // 
            // CBPlugins
            // 
            this.CBPlugins.FormattingEnabled = true;
            this.CBPlugins.Location = new System.Drawing.Point(32, 202);
            this.CBPlugins.Margin = new System.Windows.Forms.Padding(2);
            this.CBPlugins.Name = "CBPlugins";
            this.CBPlugins.Size = new System.Drawing.Size(180, 21);
            this.CBPlugins.TabIndex = 7;
            // 
            // TypeOfFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 278);
            this.Controls.Add(this.CBPlugins);
            this.Controls.Add(this.LabelPlugins);
            this.Controls.Add(this.CheckChoise);
            this.Controls.Add(this.LabelChoise);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BAccept);
            this.Controls.Add(this.LabelMain);
            this.Controls.Add(this.CBType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "TypeOfFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TypeOfFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Button BAccept;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.Label LabelChoise;
        private System.Windows.Forms.CheckBox CheckChoise;
        private System.Windows.Forms.Label LabelPlugins;
        private System.Windows.Forms.ComboBox CBPlugins;
    }
}