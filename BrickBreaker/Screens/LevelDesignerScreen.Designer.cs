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
            this.instructionLabel = new System.Windows.Forms.Label();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.hpLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // powerUpLabel
            // 
            this.powerUpLabel.AutoSize = true;
            this.powerUpLabel.ForeColor = System.Drawing.Color.White;
            this.powerUpLabel.Location = new System.Drawing.Point(434, 492);
            this.powerUpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.powerUpLabel.Name = "powerUpLabel";
            this.powerUpLabel.Size = new System.Drawing.Size(33, 13);
            this.powerUpLabel.TabIndex = 0;
            this.powerUpLabel.Text = "None";
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.ForeColor = System.Drawing.Color.White;
            this.instructionLabel.Location = new System.Drawing.Point(11, 14);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(134, 26);
            this.instructionLabel.TabIndex = 1;
            this.instructionLabel.Text = "instructions";
            this.instructionLabel.Visible = false;
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaceLabel.ForeColor = System.Drawing.Color.White;
            this.replaceLabel.Location = new System.Drawing.Point(13, 492);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(112, 20);
            this.replaceLabel.TabIndex = 1;
            this.replaceLabel.Text = "replace:false";
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.ForeColor = System.Drawing.Color.White;
            this.deleteLabel.Location = new System.Drawing.Point(191, 492);
            this.deleteLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(33, 13);
            this.deleteLabel.TabIndex = 2;
            this.deleteLabel.Text = "None";
            // 
            // hpLabel
            // 
            this.hpLabel.AutoSize = true;
            this.hpLabel.ForeColor = System.Drawing.Color.White;
            this.hpLabel.Location = new System.Drawing.Point(338, 492);
            this.hpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(33, 13);
            this.hpLabel.TabIndex = 3;
            this.hpLabel.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(600, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // LevelDesignerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hpLabel);
            this.Controls.Add(this.deleteLabel);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.replaceLabel);
            this.Controls.Add(this.powerUpLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LevelDesignerScreen";
            this.Size = new System.Drawing.Size(853, 528);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelDesignerScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LevelDesignerScreen_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LevelDesignerScreen_MouseClick);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LevelDesignerScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label powerUpLabel;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.Label deleteLabel;
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.Label label1;
    }
}
