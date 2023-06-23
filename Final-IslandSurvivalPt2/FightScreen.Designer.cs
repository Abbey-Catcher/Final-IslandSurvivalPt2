namespace Final_IslandSurvivalPt2
{
    partial class FightScreen
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
            this.attackBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attackBtn
            // 
            this.attackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.attackBtn.Location = new System.Drawing.Point(22, 383);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(165, 69);
            this.attackBtn.TabIndex = 0;
            this.attackBtn.Text = "Attack!";
            this.attackBtn.UseVisualStyleBackColor = true;
            this.attackBtn.Click += new System.EventHandler(this.attackBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.runBtn.Location = new System.Drawing.Point(248, 383);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(165, 69);
            this.runBtn.TabIndex = 1;
            this.runBtn.Text = "Run!";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // FightScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.attackBtn);
            this.Name = "FightScreen";
            this.Size = new System.Drawing.Size(449, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button attackBtn;
        private System.Windows.Forms.Button runBtn;
    }
}
