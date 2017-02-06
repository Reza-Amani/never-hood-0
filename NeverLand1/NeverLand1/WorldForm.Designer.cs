namespace NeverLand1
{
    partial class WorldForm
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
            this.WorldPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WorldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WorldPictureBox
            // 
            this.WorldPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.WorldPictureBox.Location = new System.Drawing.Point(12, 12);
            this.WorldPictureBox.Name = "WorldPictureBox";
            this.WorldPictureBox.Size = new System.Drawing.Size(586, 460);
            this.WorldPictureBox.TabIndex = 0;
            this.WorldPictureBox.TabStop = false;
            // 
            // WorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 527);
            this.Controls.Add(this.WorldPictureBox);
            this.Name = "WorldForm";
            this.Text = "WorldForm";
            ((System.ComponentModel.ISupportInitialize)(this.WorldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WorldPictureBox;
    }
}