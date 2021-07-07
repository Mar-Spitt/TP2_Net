
namespace UI.Desktop
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.1 - Usuarios");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1.2 - Alumnos");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("1.3 - Especialidades");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("1.4 - Profesores");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("1.5 - Planes y Materias");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("1.6 - Comisiones");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("1.7 - Cursos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("1 - Alta, Baja, Modificaciones y Consultas", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("2 - Inscripciones de Alumnos a Cursos");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("3 - Registro de notas");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("4.1 - Cursos");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("4.2 - Planes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("4 - Reportes", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.AcercaDe_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.trvABM = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mnsPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(847, 24);
            this.mnsPrincipal.TabIndex = 2;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AcercaDe_Click,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // AcercaDe_Click
            // 
            this.AcercaDe_Click.Image = global::UI.Desktop.Properties.Resources.university_cap_icon;
            this.AcercaDe_Click.Name = "AcercaDe_Click";
            this.AcercaDe_Click.Size = new System.Drawing.Size(182, 22);
            this.AcercaDe_Click.Text = "Acerca de Academia";
            this.AcercaDe_Click.Click += new System.EventHandler(this.AcercaDe_Click_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Image = ((System.Drawing.Image)(resources.GetObject("mnuSalir.Image")));
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(182, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // trvABM
            // 
            this.trvABM.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.trvABM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvABM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvABM.Location = new System.Drawing.Point(36, 52);
            this.trvABM.Name = "trvABM";
            treeNode1.Name = "nodoUsuario";
            treeNode1.Text = "1.1 - Usuarios";
            treeNode2.Name = "nodoAlumno";
            treeNode2.Text = "1.2 - Alumnos";
            treeNode3.Name = "nodoEspecialidad";
            treeNode3.Text = "1.3 - Especialidades";
            treeNode4.Name = "nodoProfesor";
            treeNode4.Text = "1.4 - Profesores";
            treeNode5.Name = "nodoPlanMateria";
            treeNode5.Text = "1.5 - Planes y Materias";
            treeNode6.Name = "nodoComision";
            treeNode6.Text = "1.6 - Comisiones";
            treeNode7.Name = "nodoCurso";
            treeNode7.Text = "1.7 - Cursos";
            treeNode8.Name = "nodoABM";
            treeNode8.Text = "1 - Alta, Baja, Modificaciones y Consultas";
            treeNode9.Name = "nodoInscripcion";
            treeNode9.Text = "2 - Inscripciones de Alumnos a Cursos";
            treeNode10.Name = "nodoRegistro";
            treeNode10.Text = "3 - Registro de notas";
            treeNode11.Name = "nodoCursoR";
            treeNode11.Text = "4.1 - Cursos";
            treeNode12.Name = "nodoPlanR";
            treeNode12.Text = "4.2 - Planes";
            treeNode13.Name = "nodoReporte";
            treeNode13.Text = "4 - Reportes";
            this.trvABM.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode13});
            this.trvABM.Size = new System.Drawing.Size(398, 288);
            this.trvABM.TabIndex = 17;
            this.trvABM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvABM_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.trvABM);
            this.groupBox1.Font = new System.Drawing.Font("Britannic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 385);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistema de Gestión Académica";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mnsPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "formMain";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academia";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Click += new System.EventHandler(this.mnuSalir_Click);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.TreeView trvABM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem AcercaDe_Click;
    }
}