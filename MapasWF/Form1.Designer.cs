namespace MapasWF
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Map1 = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.Tlatitud = new System.Windows.Forms.TextBox();
            this.Tlongitud = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Tdireccionbusqueda = new System.Windows.Forms.TextBox();
            this.ComboFflush = new System.Windows.Forms.ComboBox();
            this.Baddposittion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Bbruteforce = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Ttempototal = new System.Windows.Forms.TextBox();
            this.Tdistanciatotal = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Map1
            // 
            this.Map1.Bearing = 0F;
            this.Map1.CanDragMap = true;
            this.Map1.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map1.GrayScaleMode = false;
            this.Map1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map1.LevelsKeepInMemmory = 5;
            this.Map1.Location = new System.Drawing.Point(294, 12);
            this.Map1.MarkersEnabled = true;
            this.Map1.MaxZoom = 2;
            this.Map1.MinZoom = 2;
            this.Map1.MouseWheelZoomEnabled = true;
            this.Map1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map1.Name = "Map1";
            this.Map1.NegativeMode = false;
            this.Map1.PolygonsEnabled = true;
            this.Map1.RetryLoadTile = 0;
            this.Map1.RoutesEnabled = true;
            this.Map1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map1.ShowTileGridLines = false;
            this.Map1.Size = new System.Drawing.Size(746, 503);
            this.Map1.TabIndex = 0;
            this.Map1.Zoom = 0D;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar por texto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tlatitud
            // 
            this.Tlatitud.Enabled = false;
            this.Tlatitud.Location = new System.Drawing.Point(36, 54);
            this.Tlatitud.Name = "Tlatitud";
            this.Tlatitud.Size = new System.Drawing.Size(100, 20);
            this.Tlatitud.TabIndex = 2;
            // 
            // Tlongitud
            // 
            this.Tlongitud.Enabled = false;
            this.Tlongitud.Location = new System.Drawing.Point(142, 54);
            this.Tlongitud.Name = "Tlongitud";
            this.Tlongitud.Size = new System.Drawing.Size(100, 20);
            this.Tlongitud.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Latitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Longitud";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 46);
            this.button4.TabIndex = 8;
            this.button4.Text = "Ruta por calles";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 46);
            this.button5.TabIndex = 9;
            this.button5.Text = "Limpiar mapa";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Tdireccionbusqueda
            // 
            this.Tdireccionbusqueda.Location = new System.Drawing.Point(21, 19);
            this.Tdireccionbusqueda.Name = "Tdireccionbusqueda";
            this.Tdireccionbusqueda.Size = new System.Drawing.Size(206, 20);
            this.Tdireccionbusqueda.TabIndex = 11;
            // 
            // ComboFflush
            // 
            this.ComboFflush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFflush.FormattingEnabled = true;
            this.ComboFflush.Items.AddRange(new object[] {
            "Solo caminos",
            "Todo"});
            this.ComboFflush.Location = new System.Drawing.Point(127, 85);
            this.ComboFflush.Name = "ComboFflush";
            this.ComboFflush.Size = new System.Drawing.Size(121, 21);
            this.ComboFflush.TabIndex = 12;
            // 
            // Baddposittion
            // 
            this.Baddposittion.Location = new System.Drawing.Point(21, 97);
            this.Baddposittion.Name = "Baddposittion";
            this.Baddposittion.Size = new System.Drawing.Size(100, 46);
            this.Baddposittion.TabIndex = 13;
            this.Baddposittion.Text = "Añadir posicion ";
            this.Baddposittion.UseVisualStyleBackColor = true;
            this.Baddposittion.Click += new System.EventHandler(this.Baddposittion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Bbruteforce);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.ComboFflush);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 196);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eventos";
            // 
            // Bbruteforce
            // 
            this.Bbruteforce.Location = new System.Drawing.Point(21, 124);
            this.Bbruteforce.Name = "Bbruteforce";
            this.Bbruteforce.Size = new System.Drawing.Size(100, 46);
            this.Bbruteforce.TabIndex = 13;
            this.Bbruteforce.Text = "Centrar";
            this.Bbruteforce.UseVisualStyleBackColor = true;
            this.Bbruteforce.Click += new System.EventHandler(this.Bbruteforce_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Baddposittion);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.Tdireccionbusqueda);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 152);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrada";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Ttempototal);
            this.groupBox3.Controls.Add(this.Tdistanciatotal);
            this.groupBox3.Location = new System.Drawing.Point(12, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 75);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tiempo estimado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Distancia Total";
            // 
            // Ttempototal
            // 
            this.Ttempototal.Enabled = false;
            this.Ttempototal.Location = new System.Drawing.Point(134, 35);
            this.Ttempototal.Name = "Ttempototal";
            this.Ttempototal.Size = new System.Drawing.Size(118, 20);
            this.Ttempototal.TabIndex = 7;
            this.Ttempototal.Text = "0";
            // 
            // Tdistanciatotal
            // 
            this.Tdistanciatotal.Enabled = false;
            this.Tdistanciatotal.Location = new System.Drawing.Point(28, 35);
            this.Tdistanciatotal.Name = "Tdistanciatotal";
            this.Tdistanciatotal.Size = new System.Drawing.Size(100, 20);
            this.Tdistanciatotal.TabIndex = 6;
            this.Tdistanciatotal.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(970, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 46);
            this.button2.TabIndex = 17;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(970, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 46);
            this.button3.TabIndex = 18;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 537);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tlongitud);
            this.Controls.Add(this.Tlatitud);
            this.Controls.Add(this.Map1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl Map1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Tlatitud;
        private System.Windows.Forms.TextBox Tlongitud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox Tdireccionbusqueda;
        private System.Windows.Forms.ComboBox ComboFflush;
        private System.Windows.Forms.Button Baddposittion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Bbruteforce;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Ttempototal;
        private System.Windows.Forms.TextBox Tdistanciatotal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

