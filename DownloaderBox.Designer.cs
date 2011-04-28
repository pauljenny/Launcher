namespace LauncherShyax
{
    partial class DownloaderBox
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelDl = new System.Windows.Forms.Label();
            this.progressBarDl = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelMaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDesc
            // 
            this.labelDesc.Location = new System.Drawing.Point(13, 13);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(259, 48);
            this.labelDesc.TabIndex = 0;
            this.labelDesc.Text = "Une nouvelle mise à jour a été trouvée. Veuillez patienter durant le téléchargeme" +
                "nt et l\'installation de la mise à jour";
            // 
            // labelDl
            // 
            this.labelDl.AutoSize = true;
            this.labelDl.Location = new System.Drawing.Point(13, 61);
            this.labelDl.Name = "labelDl";
            this.labelDl.Size = new System.Drawing.Size(138, 13);
            this.labelDl.TabIndex = 1;
            this.labelDl.Text = "Téléchargement du patch : ";
            // 
            // progressBarDl
            // 
            this.progressBarDl.Location = new System.Drawing.Point(12, 230);
            this.progressBarDl.Name = "progressBarDl";
            this.progressBarDl.Size = new System.Drawing.Size(256, 20);
            this.progressBarDl.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarDl.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(97, 201);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Fermer";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelMaj
            // 
            this.labelMaj.AutoEllipsis = true;
            this.labelMaj.AutoSize = true;
            this.labelMaj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMaj.Location = new System.Drawing.Point(16, 78);
            this.labelMaj.Name = "labelMaj";
            this.labelMaj.Size = new System.Drawing.Size(2, 15);
            this.labelMaj.TabIndex = 4;
            // 
            // DownloaderBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelMaj);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.progressBarDl);
            this.Controls.Add(this.labelDl);
            this.Controls.Add(this.labelDesc);
            this.Name = "DownloaderBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Téléchargement des patchs";
            this.Load += new System.EventHandler(this.DownloaderBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelDl;
        private System.Windows.Forms.ProgressBar progressBarDl;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelMaj;
    }
}