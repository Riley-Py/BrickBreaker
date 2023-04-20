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
            this.generateLevelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateLevelButton
            // 
            this.generateLevelButton.Location = new System.Drawing.Point(497, 741);
            this.generateLevelButton.Name = "generateLevelButton";
            this.generateLevelButton.Size = new System.Drawing.Size(217, 54);
            this.generateLevelButton.TabIndex = 0;
            this.generateLevelButton.Text = "Generate XML";
            this.generateLevelButton.UseVisualStyleBackColor = true;
            this.generateLevelButton.Click += new System.EventHandler(this.generateLevelButton_Click);
            // 
            // LevelDesignerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.generateLevelButton);
            this.Name = "LevelDesignerScreen";
            this.Size = new System.Drawing.Size(1280, 812);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelDesignerScreen_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LevelDesignerScreen_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateLevelButton;
    }
}
