namespace Servicios_de_Salud
{
    partial class Form1
    {
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.TextBox txtConsultaIA;
        private System.Windows.Forms.Button btnConsultaIA;
        private System.Windows.Forms.TextBox txtRespuestaIA;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnExportarHistorial;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblConsulta = new System.Windows.Forms.Label();
            this.txtConsultaIA = new System.Windows.Forms.TextBox();
            this.btnConsultaIA = new System.Windows.Forms.Button();
            this.txtRespuestaIA = new System.Windows.Forms.TextBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(4F, 8F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.Name = "Form1";
            this.Text = "Servicios de Salud - Consulta IA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // lblConsulta
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblConsulta.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblConsulta.Location = new System.Drawing.Point(25, 18);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(105, 15);
            this.lblConsulta.Text = "Consulta a la IA:";
            this.Controls.Add(this.lblConsulta);

            // txtConsultaIA
            this.txtConsultaIA.Location = new System.Drawing.Point(25, 40);
            this.txtConsultaIA.Name = "txtConsultaIA";
            this.txtConsultaIA.Size = new System.Drawing.Size(475, 17);
            this.txtConsultaIA.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.txtConsultaIA.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.txtConsultaIA.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtConsultaIA);

            // btnConsultaIA
            this.btnConsultaIA.Location = new System.Drawing.Point(510, 39);
            this.btnConsultaIA.Name = "btnConsultaIA";
            this.btnConsultaIA.Size = new System.Drawing.Size(90, 19);
            this.btnConsultaIA.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.btnConsultaIA.Text = "Consultar IA";
            this.btnConsultaIA.UseVisualStyleBackColor = false;
            this.btnConsultaIA.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnConsultaIA.ForeColor = System.Drawing.Color.White;
            this.btnConsultaIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaIA.FlatAppearance.BorderSize = 0;
            this.btnConsultaIA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultaIA.Click += new System.EventHandler(this.btnConsultaIA_Click);
            this.Controls.Add(this.btnConsultaIA);

            // txtRespuestaIA (más pequeño)
            this.txtRespuestaIA.Location = new System.Drawing.Point(25, 68);
            this.txtRespuestaIA.Name = "txtRespuestaIA";
            this.txtRespuestaIA.Size = new System.Drawing.Size(575, 90);
            this.txtRespuestaIA.Multiline = true;
            this.txtRespuestaIA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRespuestaIA.ReadOnly = true;
            this.txtRespuestaIA.Font = new System.Drawing.Font("Segoe UI", 6.5F);
            this.txtRespuestaIA.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            this.txtRespuestaIA.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.Controls.Add(this.txtRespuestaIA);

            // dgvResultados (más pequeño)
            this.dgvResultados.Location = new System.Drawing.Point(25, 170);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(575, 175);
            this.dgvResultados.AutoGenerateColumns = true;
            this.dgvResultados.Font = new System.Drawing.Font("Segoe UI", 6.5F);
            this.dgvResultados.RowTemplate.Height = 18;
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultados.GridColor = System.Drawing.Color.FromArgb(200, 200, 200);
            // btnExportarHistorial
            this.btnExportarHistorial = new System.Windows.Forms.Button();
            this.btnExportarHistorial.Location = new System.Drawing.Point(510, 65);
            this.btnExportarHistorial.Name = "btnExportarHistorial";
            this.btnExportarHistorial.Size = new System.Drawing.Size(90, 19);
            this.btnExportarHistorial.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.btnExportarHistorial.Text = "Exportar historial";
            this.btnExportarHistorial.UseVisualStyleBackColor = false;
            this.btnExportarHistorial.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExportarHistorial.ForeColor = System.Drawing.Color.White;
            this.btnExportarHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarHistorial.FlatAppearance.BorderSize = 0;
            this.btnExportarHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarHistorial.Click += new System.EventHandler(this.btnExportarHistorial_Click);
            this.Controls.Add(this.btnExportarHistorial);


            // Estilos de encabezado y filas alternas
            headerStyle.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvResultados.ColumnHeadersDefaultCellStyle = headerStyle;

            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvResultados.DefaultCellStyle = rowStyle;

            altRowStyle.BackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            altRowStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvResultados.AlternatingRowsDefaultCellStyle = altRowStyle;

            this.Controls.Add(this.dgvResultados);

        }
    }
}




