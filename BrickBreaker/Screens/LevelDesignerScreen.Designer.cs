namespace BrickBreaker.Screens
{
    partial class LevelDesignerScreen
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
            this.powerUpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // powerUpLabel
            // 
            this.powerUpLabel.AutoSize = true;
            this.powerUpLabel.Location = new System.Drawing.Point(563, 41);
            this.powerUpLabel.Name = "powerUpLabel";
            this.powerUpLabel.Size = new System.Drawing.Size(47, 20);
            this.powerUpLabel.TabIndex = 0;
            this.powerUpLabel.Text = "None";
            // 
            // LevelDesignerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.powerUpLabel);
            this.Name = "LevelDesignerScreen";
            this.Size = new System.Drawing.Size(1280, 812);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelDesignerScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LevelDesignerScreen_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LevelDesignerScreen_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LevelDesignerScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label powerUpLabel;
    }
}
