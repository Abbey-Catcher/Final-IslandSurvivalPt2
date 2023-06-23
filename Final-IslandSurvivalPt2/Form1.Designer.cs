namespace Final_IslandSurvivalPt2
{
    partial class Form1
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.inventoryTLabel = new System.Windows.Forms.Label();
            this.inventoryImage = new System.Windows.Forms.PictureBox();
            this.inventoryRLabel = new System.Windows.Forms.Label();
            this.enemyLivesLabel = new System.Windows.Forms.Label();
            this.heroLivesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.titleLabel.Location = new System.Drawing.Point(42, 74);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(376, 151);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "title label";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.subtitleLabel.Location = new System.Drawing.Point(42, 264);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(376, 108);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "subtitle label";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inventoryTLabel
            // 
            this.inventoryTLabel.BackColor = System.Drawing.Color.Transparent;
            this.inventoryTLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryTLabel.ForeColor = System.Drawing.Color.Black;
            this.inventoryTLabel.Location = new System.Drawing.Point(56, 580);
            this.inventoryTLabel.Name = "inventoryTLabel";
            this.inventoryTLabel.Size = new System.Drawing.Size(195, 50);
            this.inventoryTLabel.TabIndex = 3;
            this.inventoryTLabel.Text = "inventory label";
            this.inventoryTLabel.Visible = false;
            // 
            // inventoryImage
            // 
            this.inventoryImage.Image = global::Final_IslandSurvivalPt2.Properties.Resources.inventoryBag;
            this.inventoryImage.Location = new System.Drawing.Point(4, 583);
            this.inventoryImage.Name = "inventoryImage";
            this.inventoryImage.Size = new System.Drawing.Size(46, 41);
            this.inventoryImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inventoryImage.TabIndex = 4;
            this.inventoryImage.TabStop = false;
            this.inventoryImage.Visible = false;
            // 
            // inventoryRLabel
            // 
            this.inventoryRLabel.BackColor = System.Drawing.Color.Transparent;
            this.inventoryRLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryRLabel.ForeColor = System.Drawing.Color.Black;
            this.inventoryRLabel.Location = new System.Drawing.Point(273, 580);
            this.inventoryRLabel.Name = "inventoryRLabel";
            this.inventoryRLabel.Size = new System.Drawing.Size(195, 50);
            this.inventoryRLabel.TabIndex = 5;
            this.inventoryRLabel.Text = "inventory label";
            this.inventoryRLabel.Visible = false;
            // 
            // enemyLivesLabel
            // 
            this.enemyLivesLabel.AutoSize = true;
            this.enemyLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.enemyLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.enemyLivesLabel.ForeColor = System.Drawing.Color.White;
            this.enemyLivesLabel.Location = new System.Drawing.Point(12, 319);
            this.enemyLivesLabel.Name = "enemyLivesLabel";
            this.enemyLivesLabel.Size = new System.Drawing.Size(0, 17);
            this.enemyLivesLabel.TabIndex = 6;
            this.enemyLivesLabel.Visible = false;
            // 
            // heroLivesLabel
            // 
            this.heroLivesLabel.AutoSize = true;
            this.heroLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.heroLivesLabel.ForeColor = System.Drawing.Color.White;
            this.heroLivesLabel.Location = new System.Drawing.Point(286, 319);
            this.heroLivesLabel.Name = "heroLivesLabel";
            this.heroLivesLabel.Size = new System.Drawing.Size(0, 17);
            this.heroLivesLabel.TabIndex = 7;
            this.heroLivesLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(480, 648);
            this.Controls.Add(this.heroLivesLabel);
            this.Controls.Add(this.enemyLivesLabel);
            this.Controls.Add(this.inventoryRLabel);
            this.Controls.Add(this.inventoryImage);
            this.Controls.Add(this.inventoryTLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "islandSurvival";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label inventoryTLabel;
        private System.Windows.Forms.PictureBox inventoryImage;
        private System.Windows.Forms.Label inventoryRLabel;
        private System.Windows.Forms.Label enemyLivesLabel;
        private System.Windows.Forms.Label heroLivesLabel;
    }
}

