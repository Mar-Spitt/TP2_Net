
namespace UI.Desktop
{
    partial class frmReportePlanes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePlanes));
            this.rvwrPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvwrPlanes
            // 
            this.rvwrPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwrPlanes.Location = new System.Drawing.Point(0, 0);
            this.rvwrPlanes.Name = "rvwrPlanes";
            this.rvwrPlanes.ServerReport.BearerToken = null;
            this.rvwrPlanes.Size = new System.Drawing.Size(867, 450);
            this.rvwrPlanes.TabIndex = 0;
            // 
            // frmReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 450);
            this.Controls.Add(this.rvwrPlanes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportePlanes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.frmReportePlanes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwrPlanes;
    }
}