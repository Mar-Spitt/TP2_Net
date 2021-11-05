
namespace UI.Desktop
{
    partial class frmRegistroNotas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroNotas));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRegistroNotas = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCargarNota = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.id_inscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_calendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvRegistroNotas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCargarNota, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvRegistroNotas
            // 
            this.dgvRegistroNotas.AllowUserToAddRows = false;
            this.dgvRegistroNotas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvRegistroNotas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegistroNotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegistroNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_inscripcion,
            this.id_alumno,
            this.id_curso,
            this.id_materia,
            this.anio_calendario,
            this.id_comision,
            this.nota,
            this.condicion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvRegistroNotas, 3);
            this.dgvRegistroNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistroNotas.Location = new System.Drawing.Point(3, 3);
            this.dgvRegistroNotas.MultiSelect = false;
            this.dgvRegistroNotas.Name = "dgvRegistroNotas";
            this.dgvRegistroNotas.ReadOnly = true;
            this.dgvRegistroNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistroNotas.Size = new System.Drawing.Size(954, 415);
            this.dgvRegistroNotas.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(882, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCargarNota
            // 
            this.btnCargarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarNota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarNota.Location = new System.Drawing.Point(800, 424);
            this.btnCargarNota.Name = "btnCargarNota";
            this.btnCargarNota.Size = new System.Drawing.Size(76, 23);
            this.btnCargarNota.TabIndex = 1;
            this.btnCargarNota.Text = "Cargar Nota";
            this.btnCargarNota.UseVisualStyleBackColor = true;
            this.btnCargarNota.Click += new System.EventHandler(this.btnCargarNota_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Location = new System.Drawing.Point(719, 424);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // id_inscripcion
            // 
            this.id_inscripcion.DataPropertyName = "ID";
            this.id_inscripcion.HeaderText = "ID";
            this.id_inscripcion.Name = "id_inscripcion";
            this.id_inscripcion.ReadOnly = true;
            this.id_inscripcion.Width = 30;
            // 
            // id_alumno
            // 
            this.id_alumno.DataPropertyName = "NombreApellidoAlu";
            this.id_alumno.HeaderText = "Alumnos";
            this.id_alumno.Name = "id_alumno";
            this.id_alumno.ReadOnly = true;
            this.id_alumno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_alumno.Width = 120;
            // 
            // id_curso
            // 
            this.id_curso.DataPropertyName = "DescripcionCurso";
            this.id_curso.HeaderText = "Cursos";
            this.id_curso.Name = "id_curso";
            this.id_curso.ReadOnly = true;
            this.id_curso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_curso.Width = 120;
            // 
            // id_materia
            // 
            this.id_materia.DataPropertyName = "DescripcionMateria";
            this.id_materia.HeaderText = "Materia";
            this.id_materia.Name = "id_materia";
            this.id_materia.ReadOnly = true;
            this.id_materia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_materia.Width = 250;
            // 
            // anio_calendario
            // 
            this.anio_calendario.DataPropertyName = "AnioCalendario";
            this.anio_calendario.HeaderText = "Año Calendario";
            this.anio_calendario.Name = "anio_calendario";
            this.anio_calendario.ReadOnly = true;
            // 
            // id_comision
            // 
            this.id_comision.DataPropertyName = "DescripcionComision";
            this.id_comision.HeaderText = "Comisión";
            this.id_comision.Name = "id_comision";
            this.id_comision.ReadOnly = true;
            this.id_comision.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_comision.Width = 80;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Notas";
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            this.nota.Width = 80;
            // 
            // condicion
            // 
            this.condicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condición";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            // 
            // frmRegistroNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistroNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Notas";
            this.Load += new System.EventHandler(this.frmRegistroNotas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroNotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvRegistroNotas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCargarNota;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_inscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_calendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
    }
}