namespace PM03
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стедентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предметToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеЗанятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оценкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.документыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стедентToolStripMenuItem,
            this.предметToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расписаниеЗанятийToolStripMenuItem,
            this.оценкаToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // стедентToolStripMenuItem
            // 
            this.стедентToolStripMenuItem.Name = "стедентToolStripMenuItem";
            this.стедентToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стедентToolStripMenuItem.Text = "Стедент";
            this.стедентToolStripMenuItem.Click += new System.EventHandler(this.стедентToolStripMenuItem_Click);
            // 
            // предметToolStripMenuItem
            // 
            this.предметToolStripMenuItem.Name = "предметToolStripMenuItem";
            this.предметToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.предметToolStripMenuItem.Text = "Предмет";
            this.предметToolStripMenuItem.Click += new System.EventHandler(this.предметToolStripMenuItem_Click);
            // 
            // расписаниеЗанятийToolStripMenuItem
            // 
            this.расписаниеЗанятийToolStripMenuItem.Name = "расписаниеЗанятийToolStripMenuItem";
            this.расписаниеЗанятийToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.расписаниеЗанятийToolStripMenuItem.Text = "Расписание занятий";
            this.расписаниеЗанятийToolStripMenuItem.Click += new System.EventHandler(this.расписаниеЗанятийToolStripMenuItem_Click);
            // 
            // оценкаToolStripMenuItem
            // 
            this.оценкаToolStripMenuItem.Name = "оценкаToolStripMenuItem";
            this.оценкаToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.оценкаToolStripMenuItem.Text = "Оценка";
            this.оценкаToolStripMenuItem.Click += new System.EventHandler(this.оценкаToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стедентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предметToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеЗанятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оценкаToolStripMenuItem;
    }
}