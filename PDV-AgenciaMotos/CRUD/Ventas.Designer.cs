namespace CRUD
{
    partial class Ventas
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
            this.button1 = new System.Windows.Forms.Button();
            this.dGventadetalle = new System.Windows.Forms.DataGridView();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha1 = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dGfecha = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGventadetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGfecha)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.BackgroundImage = global::CRUD.Properties.Resources.qqqqq;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(525, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dGventadetalle
            // 
            this.dGventadetalle.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dGventadetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGventadetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenta,
            this.Column1,
            this.Column2});
            this.dGventadetalle.Location = new System.Drawing.Point(226, 78);
            this.dGventadetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dGventadetalle.Name = "dGventadetalle";
            this.dGventadetalle.RowHeadersWidth = 62;
            this.dGventadetalle.RowTemplate.Height = 28;
            this.dGventadetalle.Size = new System.Drawing.Size(412, 101);
            this.dGventadetalle.TabIndex = 3;
            this.dGventadetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IdVenta
            // 
            this.IdVenta.HeaderText = "IdVenta";
            this.IdVenta.MinimumWidth = 8;
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ProductoId";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Monto";
            this.Column2.Name = "Column2";
            // 
            // fecha1
            // 
            this.fecha1.CalendarForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.fecha1.CalendarMonthBackground = System.Drawing.SystemColors.MenuText;
            this.fecha1.CalendarTitleBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.fecha1.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.fecha1.CustomFormat = "yyyy-MM-dd";
            this.fecha1.Location = new System.Drawing.Point(11, 361);
            this.fecha1.Margin = new System.Windows.Forms.Padding(2);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(135, 20);
            this.fecha1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button3.BackgroundImage = global::CRUD.Properties.Resources.qqqqq;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(586, 368);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 47);
            this.button3.TabIndex = 30;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 31;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblIdVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIdVenta.Location = new System.Drawing.Point(36, 108);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(79, 13);
            this.lblIdVenta.TabIndex = 32;
            this.lblIdVenta.Text = "Id De La Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 238);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(109, 20);
            this.dateTimePicker1.TabIndex = 33;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 34;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::CRUD.Properties.Resources.qqqqq;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(101, 386);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(460, 29);
            this.button4.TabIndex = 35;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.BackgroundImage = global::CRUD.Properties.Resources.qqqqq;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(22, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(601, 28);
            this.button5.TabIndex = 36;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::CRUD.Properties.Resources.qqqqq;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(532, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 42);
            this.button2.TabIndex = 37;
            this.button2.Text = "Cargar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dGfecha
            // 
            this.dGfecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGfecha.Location = new System.Drawing.Point(226, 238);
            this.dGfecha.Name = "dGfecha";
            this.dGfecha.Size = new System.Drawing.Size(412, 114);
            this.dGfecha.TabIndex = 38;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(679, 416);
            this.Controls.Add(this.dGfecha);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblIdVenta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fecha1);
            this.Controls.Add(this.dGventadetalle);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGventadetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGfecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dGventadetalle;
        private System.Windows.Forms.DateTimePicker fecha1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblIdVenta;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dGfecha;
    }
}