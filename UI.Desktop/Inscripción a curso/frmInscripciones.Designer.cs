
namespace UI.Desktop
{
    partial class frmInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInscripciones));
            this.tlInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMateria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAnioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionComisión = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnElegir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tlInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tlInscripciones
            // 
            this.tlInscripciones.ColumnCount = 3;
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.Controls.Add(this.dgvInscripciones, 0, 0);
            this.tlInscripciones.Controls.Add(this.btnElegir, 0, 1);
            this.tlInscripciones.Controls.Add(this.btnActualizar, 1, 1);
            this.tlInscripciones.Controls.Add(this.btnSalir, 2, 1);
            this.tlInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlInscripciones.Name = "tlInscripciones";
            this.tlInscripciones.RowCount = 2;
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripciones.Size = new System.Drawing.Size(737, 450);
            this.tlInscripciones.TabIndex = 0;
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvInscripciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInscripciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.colDescCurso,
            this.colMateria,
            this.colAnioCalendario,
            this.colDescripcionComisión});
            this.tlInscripciones.SetColumnSpan(this.dgvInscripciones, 3);
            this.dgvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvInscripciones.MultiSelect = false;
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(731, 415);
            this.dgvInscripciones.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // colDescCurso
            // 
            this.colDescCurso.DataPropertyName = "Descripcion";
            this.colDescCurso.HeaderText = "Curso";
            this.colDescCurso.Name = "colDescCurso";
            this.colDescCurso.ReadOnly = true;
            this.colDescCurso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescCurso.Width = 120;
            // 
            // colMateria
            // 
            this.colMateria.DataPropertyName = "IDMateria";
            this.colMateria.HeaderText = "Materia";
            this.colMateria.Name = "colMateria";
            this.colMateria.ReadOnly = true;
            this.colMateria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMateria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMateria.Width = 250;
            // 
            // colAnioCalendario
            // 
            this.colAnioCalendario.DataPropertyName = "AnioCalendario";
            this.colAnioCalendario.HeaderText = "Año Calendario";
            this.colAnioCalendario.Name = "colAnioCalendario";
            this.colAnioCalendario.ReadOnly = true;
            // 
            // colDescripcionComisión
            // 
            this.colDescripcionComisión.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcionComisión.DataPropertyName = "IDComision";
            this.colDescripcionComisión.HeaderText = "Comisión";
            this.colDescripcionComisión.Name = "colDescripcionComisión";
            this.colDescripcionComisión.ReadOnly = true;
            this.colDescripcionComisión.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescripcionComisión.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnElegir
            // 
            this.btnElegir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElegir.Location = new System.Drawing.Point(497, 424);
            this.btnElegir.Name = "btnElegir";
            this.btnElegir.Size = new System.Drawing.Size(75, 23);
            this.btnElegir.TabIndex = 1;
            this.btnElegir.Text = "Elegir curso";
            this.btnElegir.UseVisualStyleBackColor = true;
            this.btnElegir.Click += new System.EventHandler(this.btnElegir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(578, 424);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(659, 424);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 450);
            this.Controls.Add(this.tlInscripciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInscripciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripciones a cursos";
            this.Load += new System.EventHandler(this.frmInscripciones_Load);
            this.tlInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlInscripciones;
        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescCurso;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnioCalendario;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDescripcionComisión;
    }
}