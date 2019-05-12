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
            this.SuspendLayout();
            // 
            // CBType
            // 
            this.CBType.FormattingEnabled = true;
            this.CBType.Location = new System.Drawing.Point(43, 92);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(239, 24);
            this.CBType.TabIndex = 0;
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMain.Location = new System.Drawing.Point(38, 32);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(244, 29);
            this.LabelMain.TabIndex = 1;
            this.LabelMain.Text = "Choose a type of file";
            // 
            // BAccept
            // 
            this.BAccept.Location = new System.Drawing.Point(123, 173);
            this.BAccept.Name = "BAccept";
            this.BAccept.Size = new System.Drawing.Size(89, 34);
            this.BAccept.TabIndex = 2;
            this.BAccept.Text = "Accept";
            this.BAccept.UseVisualStyleBackColor = true;
            this.BAccept.Click += new System.EventHandler(this.BAccept_Click);
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(234, 173);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(89, 34);
            this.BCancel.TabIndex = 3;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "openFileDialog1";
            // 
            // TypeOfFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 205);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BAccept);
            this.Controls.Add(this.LabelMain);
            this.Controls.Add(this.CBType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}