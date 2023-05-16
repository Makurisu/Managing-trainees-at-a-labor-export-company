namespace CK
{
    partial class UserControl2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eventLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "00";
            this.label1.Click += new System.EventHandler(this.UserControl2_Click);
            // 
            // eventLB
            // 
            this.eventLB.BackColor = System.Drawing.Color.White;
            this.eventLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventLB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventLB.Location = new System.Drawing.Point(0, 23);
            this.eventLB.Name = "eventLB";
            this.eventLB.Size = new System.Drawing.Size(129, 35);
            this.eventLB.TabIndex = 1;
            this.eventLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eventLB);
            this.Controls.Add(this.label1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(129, 58);
            this.Load += new System.EventHandler(this.UserControl2_Load);
            this.Click += new System.EventHandler(this.UserControl2_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label eventLB;
    }
}
