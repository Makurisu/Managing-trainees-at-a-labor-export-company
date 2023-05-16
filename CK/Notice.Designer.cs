namespace CK
{
    partial class Notice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noticeLB = new System.Windows.Forms.Label();
            this.datepostLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noticeLB
            // 
            this.noticeLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.noticeLB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noticeLB.Location = new System.Drawing.Point(0, 0);
            this.noticeLB.Name = "noticeLB";
            this.noticeLB.Padding = new System.Windows.Forms.Padding(10);
            this.noticeLB.Size = new System.Drawing.Size(354, 73);
            this.noticeLB.TabIndex = 0;
            this.noticeLB.Text = "label1";
            // 
            // datepostLB
            // 
            this.datepostLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datepostLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datepostLB.Location = new System.Drawing.Point(0, 73);
            this.datepostLB.Name = "datepostLB";
            this.datepostLB.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.datepostLB.Size = new System.Drawing.Size(354, 26);
            this.datepostLB.TabIndex = 1;
            this.datepostLB.Text = "label2";
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.datepostLB);
            this.Controls.Add(this.noticeLB);
            this.Name = "Notice";
            this.Size = new System.Drawing.Size(354, 99);
            this.Load += new System.EventHandler(this.Notice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Label noticeLB;
        private Label datepostLB;
    }
}
