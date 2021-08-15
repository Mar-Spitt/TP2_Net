
namespace UI.Desktop
{
    partial class frmComisionesDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComisionesDesktop));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIdComision = new System.Windows.Forms.Label();
            this.lblAnioEspecialidad = new System.Windows.Forms.Label();
            this.lblDescripcionPlan = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtAnioEspecialidad = new System.Windows.Forms.TextBox();
            this.txtDescipcion = new System.Windows.Forms.TextBox();
            this.cmbDescipcionPlan = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.69811F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.30189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Controls.Add(this.txtID, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIdComision, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioEspecialidad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcionPlan, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioEspecialidad, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescipcion, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDescipcionPlan, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 5, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.16883F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.83117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 151);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(113, 23);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(53, 20);
            this.txtID.TabIndex = 0;
            // 
            // lblIdComision
            // 
            this.lblIdComision.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIdComision.AutoSize = true;
            this.lblIdComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdComision.Location = new System.Drawing.Point(57, 20);
            this.lblIdComision.Name = "lblIdComision";
            this.lblIdComision.Size = new System.Drawing.Size(20, 13);
            this.lblIdComision.TabIndex = 1;
            this.lblIdComision.Text = "ID";
            // 
            // lblAnioEspecialidad
            // 
            this.lblAnioEspecialidad.AutoSize = true;
            this.lblAnioEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnioEspecialidad.Location = new System.Drawing.Point(182, 20);
            this.lblAnioEspecialidad.Name = "lblAnioEspecialidad";
            this.lblAnioEspecialidad.Size = new System.Drawing.Size(105, 13);
            this.lblAnioEspecialidad.TabIndex = 2;
            this.lblAnioEspecialidad.Text = "Año Especialidad";
            // 
            // lblDescripcionPlan
            // 
            this.lblDescripcionPlan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescripcionPlan.AutoSize = true;
            this.lblDescripcionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionPlan.Location = new System.Drawing.Point(439, 20);
            this.lblDescripcionPlan.Name = "lblDescripcionPlan";
            this.lblDescripcionPlan.Size = new System.Drawing.Size(32, 13);
            this.lblDescripcionPlan.TabIndex = 3;
            this.lblDescripcionPlan.Text = "Plan";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(30, 65);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtAnioEspecialidad
            // 
            this.txtAnioEspecialidad.Location = new System.Drawing.Point(293, 23);
            this.txtAnioEspecialidad.Name = "txtAnioEspecialidad";
            this.txtAnioEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtAnioEspecialidad.TabIndex = 5;
            // 
            // txtDescipcion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescipcion, 5);
            this.txtDescipcion.Location = new System.Drawing.Point(113, 68);
            this.txtDescipcion.Name = "txtDescipcion";
            this.txtDescipcion.Size = new System.Drawing.Size(295, 20);
            this.txtDescipcion.TabIndex = 6;
            // 
            // cmbDescipcionPlan
            // 
            this.cmbDescipcionPlan.FormattingEnabled = true;
            this.cmbDescipcionPlan.Location = new System.Drawing.Point(504, 23);
            this.cmbDescipcionPlan.Name = "cmbDescipcionPlan";
            this.cmbDescipcionPlan.Size = new System.Drawing.Size(121, 21);
            this.cmbDescipcionPlan.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(504, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(413, 104);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmComisionesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 151);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComisionesDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComisionesDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIdComision;
        private System.Windows.Forms.Label lblAnioEspecialidad;
        private System.Windows.Forms.Label lblDescripcionPlan;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtAnioEspecialidad;
        private System.Windows.Forms.TextBox txtDescipcion;
        private System.Windows.Forms.ComboBox cmbDescipcionPlan;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}