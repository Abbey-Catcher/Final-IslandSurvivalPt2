namespace Final_IslandSurvivalPt2
{
    partial class GameScreen
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.inventoryRLabel = new System.Windows.Forms.Label();
            this.inventoryTLabel = new System.Windows.Forms.Label();
            this.inventoryImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // inventoryRLabel
            // 
            this.inventoryRLabel.BackColor = System.Drawing.Color.Transparent;
            this.inventoryRLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryRLabel.ForeColor = System.Drawing.Color.Black;
            this.inventoryRLabel.Location = new System.Drawing.Point(200, 487);
            this.inventoryRLabel.Name = "inventoryRLabel";
            this.inventoryRLabel.Size = new System.Drawing.Size(125, 50);
            this.inventoryRLabel.TabIndex = 7;
            this.inventoryRLabel.Text = "inventoryLabel";
            this.inventoryRLabel.Visible = false;
            // 
            // inventoryTLabel
            // 
            this.inventoryTLabel.BackColor = System.Drawing.Color.Transparent;
            this.inventoryTLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryTLabel.ForeColor = System.Drawing.Color.Black;
            this.inventoryTLabel.Location = new System.Drawing.Point(58, 487);
            this.inventoryTLabel.Name = "inventoryTLabel";
            this.inventoryTLabel.Size = new System.Drawing.Size(125, 50);
            this.inventoryTLabel.TabIndex = 6;
            this.inventoryTLabel.Text = "inventory label";
            this.inventoryTLabel.Visible = false;
            // 
            // inventoryImage
            // 
            this.inventoryImage.Image = global::Final_IslandSurvivalPt2.Properties.Resources.inventoryBag;
            this.inventoryImage.Location = new System.Drawing.Point(3, 495);
            this.inventoryImage.Name = "inventoryImage";
            this.inventoryImage.Size = new System.Drawing.Size(46, 41);
            this.inventoryImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inventoryImage.TabIndex = 8;
            this.inventoryImage.TabStop = false;
            this.inventoryImage.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_IslandSurvivalPt2.Properties.Resources.Background_Final;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.inventoryImage);
            this.Controls.Add(this.inventoryRLabel);
            this.Controls.Add(this.inventoryTLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(335, 550);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label inventoryRLabel;
        private System.Windows.Forms.Label inventoryTLabel;
        private System.Windows.Forms.PictureBox inventoryImage;
    }
}
