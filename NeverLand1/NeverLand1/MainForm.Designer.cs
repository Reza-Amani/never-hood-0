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
            this.button_new_single_cell = new System.Windows.Forms.Button();
            this.textBox_point = new System.Windows.Forms.TextBox();
            this.textBox_cell = new System.Windows.Forms.TextBox();
            this.textBox_world = new System.Windows.Forms.TextBox();
            this.button_graphic_onoff = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(19, 262);
            this.test.Margin = new System.Windows.Forms.Padding(4);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(100, 28);
            this.test.TabIndex = 0;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // step
            // 
            this.step.Location = new System.Drawing.Point(19, 298);
            this.step.Margin = new System.Windows.Forms.Padding(4);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(100, 28);
            this.step.TabIndex = 1;
            this.step.Text = "step";
            this.step.UseVisualStyleBackColor = true;
            this.step.Click += new System.EventHandler(this.step_Click);
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(15, 110);
            this.button_pause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(85, 39);
            this.button_pause.TabIndex = 2;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(15, 18);
            this.button_go.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(85, 38);
            this.button_go.TabIndex = 3;
            this.button_go.Text = "Go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_1day
            // 
            this.button_1day.Location = new System.Drawing.Point(15, 63);
            this.button_1day.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_1day.Name = "button_1day";
            this.button_1day.Size = new System.Drawing.Size(85, 41);
            this.button_1day.TabIndex = 4;
            this.button_1day.Text = "1 day";
            this.button_1day.UseVisualStyleBackColor = true;
            this.button_1day.Click += new System.EventHandler(this.button_1day_Click);
            // 
            // button_new_single_cell
            // 
            this.button_new_single_cell.Location = new System.Drawing.Point(19, 204);
            this.button_new_single_cell.Margin = new System.Windows.Forms.Padding(4);
            this.button_new_single_cell.Name = "button_new_single_cell";
            this.button_new_single_cell.Size = new System.Drawing.Size(81, 50);
            this.button_new_single_cell.TabIndex = 5;
            this.button_new_single_cell.Text = "new single cell";
            this.button_new_single_cell.UseVisualStyleBackColor = true;
            this.button_new_single_cell.Click += new System.EventHandler(this.button_new_single_cell_Click);
            // 
            // textBox_point
            // 
            this.textBox_point.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox_point.Location = new System.Drawing.Point(372, 18);
            this.textBox_point.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_point.Multiline = true;
            this.textBox_point.Name = "textBox_point";
            this.textBox_point.Size = new System.Drawing.Size(204, 171);
            this.textBox_point.TabIndex = 6;
            // 
            // textBox_cell
            // 
            this.textBox_cell.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_cell.Location = new System.Drawing.Point(585, 18);
            this.textBox_cell.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_cell.Multiline = true;
            this.textBox_cell.Name = "textBox_cell";
            this.textBox_cell.Size = new System.Drawing.Size(204, 171);
            this.textBox_cell.TabIndex = 7;
            // 
            // textBox_world
            // 
            this.textBox_world.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox_world.Location = new System.Drawing.Point(159, 18);
            this.textBox_world.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_world.Multiline = true;
            this.textBox_world.Name = "textBox_world";
            this.textBox_world.Size = new System.Drawing.Size(204, 171);
            this.textBox_world.TabIndex = 8;
            // 
            // button_graphic_onoff
            // 
            this.button_graphic_onoff.Location = new System.Drawing.Point(246, 278);
            this.button_graphic_onoff.Name = "button_graphic_onoff";
            this.button_graphic_onoff.Size = new System.Drawing.Size(103, 48);
            this.button_graphic_onoff.TabIndex = 9;
            this.button_graphic_onoff.Text = "graphics on/off";
            this.button_graphic_onoff.UseVisualStyleBackColor = true;
            this.button_graphic_onoff.Click += new System.EventHandler(this.button_graphic_onoff_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 48);
            this.button1.TabIndex = 10;
            this.button1.Text = "show cells on/off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 363);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_graphic_onoff);
            this.Controls.Add(this.textBox_world);
            this.Controls.Add(this.textBox_cell);
            this.Controls.Add(this.textBox_point);
            this.Controls.Add(this.button_new_single_cell);
            this.Controls.Add(this.button_1day);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.step);
            this.Controls.Add(this.test);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button step;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_1day;
        private System.Windows.Forms.Button button_new_single_cell;
        private System.Windows.Forms.TextBox textBox_point;
        private System.Windows.Forms.TextBox textBox_cell;
        private System.Windows.Forms.TextBox textBox_world;
        private System.Windows.Forms.Button button_graphic_onoff;
        private System.Windows.Forms.Button button1;
    }
}

