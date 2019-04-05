namespace TrainsProject
{
    partial class HomePage
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
            this.buyStationButton = new System.Windows.Forms.Button();
            this.buyTrainsButton = new System.Windows.Forms.Button();
            this.CurrentMoneyTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.namingTextBox = new System.Windows.Forms.TextBox();
            this.namingSubmit = new System.Windows.Forms.Button();
            this.stationMapGrid = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stationMapGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buyStationButton
            // 
            this.buyStationButton.ForeColor = System.Drawing.Color.Purple;
            this.buyStationButton.Location = new System.Drawing.Point(12, 449);
            this.buyStationButton.Name = "buyStationButton";
            this.buyStationButton.Size = new System.Drawing.Size(137, 51);
            this.buyStationButton.TabIndex = 1;
            this.buyStationButton.Text = "Buy Stations";
            this.buyStationButton.UseVisualStyleBackColor = true;
            this.buyStationButton.Click += new System.EventHandler(this.buyStationButton_Click);
            // 
            // buyTrainsButton
            // 
            this.buyTrainsButton.ForeColor = System.Drawing.Color.Purple;
            this.buyTrainsButton.Location = new System.Drawing.Point(12, 506);
            this.buyTrainsButton.Name = "buyTrainsButton";
            this.buyTrainsButton.Size = new System.Drawing.Size(137, 51);
            this.buyTrainsButton.TabIndex = 2;
            this.buyTrainsButton.Text = "Buy Trains";
            this.buyTrainsButton.UseVisualStyleBackColor = true;
            this.buyTrainsButton.Click += new System.EventHandler(this.buyTrainsButton_Click);
            // 
            // CurrentMoneyTextBox
            // 
            this.CurrentMoneyTextBox.BackColor = System.Drawing.Color.Purple;
            this.CurrentMoneyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMoneyTextBox.ForeColor = System.Drawing.Color.White;
            this.CurrentMoneyTextBox.Location = new System.Drawing.Point(155, 449);
            this.CurrentMoneyTextBox.Multiline = true;
            this.CurrentMoneyTextBox.Name = "CurrentMoneyTextBox";
            this.CurrentMoneyTextBox.Size = new System.Drawing.Size(258, 53);
            this.CurrentMoneyTextBox.TabIndex = 3;
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.ForeColor = System.Drawing.Color.Purple;
            this.ConsoleTextBox.Location = new System.Drawing.Point(435, 454);
            this.ConsoleTextBox.Multiline = true;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.Size = new System.Drawing.Size(924, 162);
            this.ConsoleTextBox.TabIndex = 4;
            // 
            // YesButton
            // 
            this.YesButton.ForeColor = System.Drawing.Color.Purple;
            this.YesButton.Location = new System.Drawing.Point(155, 506);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(137, 51);
            this.YesButton.TabIndex = 7;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.ForeColor = System.Drawing.Color.Purple;
            this.NoButton.Location = new System.Drawing.Point(298, 506);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(115, 51);
            this.NoButton.TabIndex = 8;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // namingTextBox
            // 
            this.namingTextBox.BackColor = System.Drawing.Color.Purple;
            this.namingTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namingTextBox.ForeColor = System.Drawing.Color.White;
            this.namingTextBox.Location = new System.Drawing.Point(12, 563);
            this.namingTextBox.Multiline = true;
            this.namingTextBox.Name = "namingTextBox";
            this.namingTextBox.Size = new System.Drawing.Size(280, 53);
            this.namingTextBox.TabIndex = 9;
            // 
            // namingSubmit
            // 
            this.namingSubmit.ForeColor = System.Drawing.Color.Purple;
            this.namingSubmit.Location = new System.Drawing.Point(298, 563);
            this.namingSubmit.Name = "namingSubmit";
            this.namingSubmit.Size = new System.Drawing.Size(115, 51);
            this.namingSubmit.TabIndex = 10;
            this.namingSubmit.Text = "Submit";
            this.namingSubmit.UseVisualStyleBackColor = true;
            this.namingSubmit.Click += new System.EventHandler(this.namingSubmit_Click);
            // 
            // stationMapGrid
            // 
            this.stationMapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stationMapGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G,
            this.H,
            this.I,
            this.J});
            this.stationMapGrid.Location = new System.Drawing.Point(12, 12);
            this.stationMapGrid.Name = "stationMapGrid";
            this.stationMapGrid.RowTemplate.Height = 24;
            this.stationMapGrid.Size = new System.Drawing.Size(1343, 431);
            this.stationMapGrid.TabIndex = 11;
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.Name = "A";
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.Name = "E";
            // 
            // F
            // 
            this.F.HeaderText = "F";
            this.F.Name = "F";
            // 
            // G
            // 
            this.G.HeaderText = "G";
            this.G.Name = "G";
            // 
            // H
            // 
            this.H.HeaderText = "H";
            this.H.Name = "H";
            // 
            // I
            // 
            this.I.HeaderText = "I";
            this.I.Name = "I";
            // 
            // J
            // 
            this.J.HeaderText = "J";
            this.J.Name = "J";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 630);
            this.Controls.Add(this.stationMapGrid);
            this.Controls.Add(this.namingSubmit);
            this.Controls.Add(this.namingTextBox);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.ConsoleTextBox);
            this.Controls.Add(this.CurrentMoneyTextBox);
            this.Controls.Add(this.buyTrainsButton);
            this.Controls.Add(this.buyStationButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "HomePage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stationMapGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buyStationButton;
        private System.Windows.Forms.Button buyTrainsButton;
        private System.Windows.Forms.TextBox CurrentMoneyTextBox;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox namingTextBox;
        private System.Windows.Forms.Button namingSubmit;
        private System.Windows.Forms.DataGridView stationMapGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn G;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
    }
}

