namespace NeverLand1
{
    partial class MainForm
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
            this.test = new System.Windows.Forms.Button();
            this.step = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_go = new System.Windows.Forms.Button();
            this.button_1day = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(16, 15);
            this.test.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(100, 28);
            this.test.TabIndex = 0;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // step
            // 
            this.step.Location = new System.Drawing.Point(16, 50);
            this.step.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(100, 28);
            this.step.TabIndex = 1;
            this.step.Text = "step";
            this.step.UseVisualStyleBackColor = true;
            this.step.Click += new System.EventHandler(this.step_Click);
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(16, 218);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(86, 40);
            this.button_pause.TabIndex = 2;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(16, 127);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(86, 38);
            this.button_go.TabIndex = 3;
            this.button_go.Text = "Go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_1day
            // 
            this.button_1day.Location = new System.Drawing.Point(16, 171);
            this.button_1day.Name = "button_1day";
            this.button_1day.Size = new System.Drawing.Size(86, 41);
            this.button_1day.TabIndex = 4;
            this.button_1day.Text = "1 day";
            this.button_1day.UseVisualStyleBackColor = true;
            this.button_1day.Click += new System.EventHandler(this.button_1day_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 270);
            this.Controls.Add(this.button_1day);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.step);
            this.Controls.Add(this.test);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button step;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_1day;
    }
}

