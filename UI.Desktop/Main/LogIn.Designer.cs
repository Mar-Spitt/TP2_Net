
namespace UI.Desktop
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.lblBienvenidos = new System.Windows.Forms.Label();
            this.lnkOlvidaPass = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.ckbSeePass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBienvenidos
            // 
            this.lblBienvenidos.AutoSize = true;
            this.lblBienvenidos.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenidos.Location = new System.Drawing.Point(25, 20);
            this.lblBienvenidos.Name = "lblBienvenidos";
            this.lblBienvenidos.Size = new System.Drawing.Size(262, 21);
            this.lblBienvenidos.TabIndex = 15;
            this.lblBienvenidos.Text = "Sistema de Gestión Académica";
            // 
            // lnkOlvidaPass
            // 
            this.lnkOlvidaPass.AutoSize = true;
            this.lnkOlvidaPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkOlvidaPass.Location = new System.Drawing.Point(18, 212);
            this.lnkOlvidaPass.Name = "lnkOlvidaPass";
            this.lnkOlvidaPass.Size = new System.Drawing.Size(106, 13);
            this.lnkOlvidaPass.TabIndex = 14;
            this.lnkOlvidaPass.TabStop = true;
            this.lnkOlvidaPass.Text = "Olvidé mi contraseña";
            this.lnkOlvidaPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvidaPass_LinkClicked);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.Location = new System.Drawing.Point(186, 185);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 13;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(136, 130);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(151, 20);
            this.txtPass.TabIndex = 12;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(136, 87);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(151, 20);
            this.txtUsuario.TabIndex = 11;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(60, 133);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 10;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(26, 90);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(104, 13);
            this.lblNombreUsuario.TabIndex = 9;
            this.lblNombreUsuario.Text = "Nombre de Usuario: ";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(60, 51);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(201, 13);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Por favor digite su información de ingreso";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbSeePass
            // 
            this.ckbSeePass.AutoSize = true;
            this.ckbSeePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbSeePass.Location = new System.Drawing.Point(170, 156);
            this.ckbSeePass.Name = "ckbSeePass";
            this.ckbSeePass.Size = new System.Drawing.Size(117, 17);
            this.ckbSeePass.TabIndex = 16;
            this.ckbSeePass.Text = "Mostrar contraseña";
            this.ckbSeePass.UseVisualStyleBackColor = true;
            this.ckbSeePass.CheckedChanged += new System.EventHandler(this.SeePass_CheckedChanged);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 240);
            this.Controls.Add(this.ckbSeePass);
            this.Controls.Add(this.lblBienvenidos);
            this.Controls.Add(this.lnkOlvidaPass);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenidos;
        private System.Windows.Forms.LinkLabel lnkOlvidaPass;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.CheckBox ckbSeePass;
    }
}