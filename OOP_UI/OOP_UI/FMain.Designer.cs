namespace OOP_UI
{
    partial class FMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBTypes = new System.Windows.Forms.ComboBox();
            this.BCreate = new System.Windows.Forms.Button();
            this.BDelete = new System.Windows.Forms.Button();
            this.BEdit = new System.Windows.Forms.Button();
            this.LVMain = new System.Windows.Forms.ListView();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBTypes
            // 
            this.CBTypes.FormattingEnabled = true;
            this.CBTypes.Location = new System.Drawing.Point(12, 319);
            this.CBTypes.Name = "CBTypes";
            this.CBTypes.Size = new System.Drawing.Size(190, 24);
            this.CBTypes.TabIndex = 0;
            // 
            // BCreate
            // 
            this.BCreate.Location = new System.Drawing.Point(233, 314);
            this.BCreate.Name = "BCreate";
            this.BCreate.Size = new System.Drawing.Size(110, 33);
            this.BCreate.TabIndex = 1;
            this.BCreate.Text = "Create";
            this.BCreate.UseVisualStyleBackColor = true;
            this.BCreate.Click += new System.EventHandler(this.BCreate_Click);
            // 
            // BDelete
            // 
            this.BDelete.Location = new System.Drawing.Point(377, 314);
            this.BDelete.Name = "BDelete";
            this.BDelete.Size = new System.Drawing.Size(110, 33);
            this.BDelete.TabIndex = 2;
            this.BDelete.Text = "Delete";
            this.BDelete.UseVisualStyleBackColor = true;
            this.BDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // BEdit
            // 
            this.BEdit.Location = new System.Drawing.Point(525, 314);
            this.BEdit.Name = "BEdit";
            this.BEdit.Size = new System.Drawing.Size(109, 33);
            this.BEdit.TabIndex = 3;
            this.BEdit.Text = "Edit";
            this.BEdit.UseVisualStyleBackColor = true;
            this.BEdit.Click += new System.EventHandler(this.BEdit_Click);
            // 
            // LVMain
            // 
            this.LVMain.Location = new System.Drawing.Point(12, 31);
            this.LVMain.Name = "LVMain";
            this.LVMain.Size = new System.Drawing.Size(622, 273);
            this.LVMain.TabIndex = 4;
            this.LVMain.UseCompatibleStateImageBehavior = false;
            this.LVMain.View = System.Windows.Forms.View.List;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(646, 28);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 355);
            this.Controls.Add(this.LVMain);
            this.Controls.Add(this.BEdit);
            this.Controls.Add(this.BDelete);
            this.Controls.Add(this.BCreate);
            this.Controls.Add(this.CBTypes);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBTypes;
        private System.Windows.Forms.Button BCreate;
        private System.Windows.Forms.Button BDelete;
        private System.Windows.Forms.Button BEdit;
        private System.Windows.Forms.ListView LVMain;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

