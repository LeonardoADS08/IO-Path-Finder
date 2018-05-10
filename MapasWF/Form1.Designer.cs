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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.Map1.Location = new System.Drawing.Point(374, 12);
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
            this.Map1.Size = new System.Drawing.Size(414, 426);
            this.Map1.TabIndex = 0;
            this.Map1.Zoom = 0D;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar por texto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tlatitud
            // 
            this.Tlatitud.Location = new System.Drawing.Point(36, 54);
            this.Tlatitud.Name = "Tlatitud";
            this.Tlatitud.Size = new System.Drawing.Size(100, 20);
            this.Tlatitud.TabIndex = 2;
            // 
            // Tlongitud
            // 
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "posicion actual";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Poligono lineal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(36, 209);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 46);
            this.button4.TabIndex = 8;
            this.button4.Text = "Ruta por calles";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(142, 145);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 46);
            this.button5.TabIndex = 9;
            this.button5.Text = "Flush";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(143, 209);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 46);
            this.button6.TabIndex = 10;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tlongitud);
            this.Controls.Add(this.Tlatitud);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Map1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

