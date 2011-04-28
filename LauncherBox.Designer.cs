namespace LauncherShyax
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.checkBoxCache = new System.Windows.Forms.CheckBox();
            this.labelStatut = new System.Windows.Forms.Label();
            this.pictureBoxLancer = new System.Windows.Forms.PictureBox();
            this.pictureBox3Close = new System.Windows.Forms.PictureBox();
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxRealm = new System.Windows.Forms.PictureBox();
            this.pictureBoxWorld = new System.Windows.Forms.PictureBox();
            this.linkLabelSite = new System.Windows.Forms.LinkLabel();
            this.linkLabelForum = new System.Windows.Forms.LinkLabel();
            this.linkLabelBugTracker = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLancer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRealm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxCache
            // 
            this.checkBoxCache.AutoSize = true;
            this.checkBoxCache.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxCache.Checked = true;
            this.checkBoxCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCache.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBoxCache.Location = new System.Drawing.Point(12, 331);
            this.checkBoxCache.Name = "checkBoxCache";
            this.checkBoxCache.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxCache.Size = new System.Drawing.Size(95, 18);
            this.checkBoxCache.TabIndex = 1;
            this.checkBoxCache.Text = "Vider le cache";
            this.checkBoxCache.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBoxCache.UseCompatibleTextRendering = true;
            this.checkBoxCache.UseVisualStyleBackColor = false;
            // 
            // labelStatut
            // 
            this.labelStatut.AutoEllipsis = true;
            this.labelStatut.AutoSize = true;
            this.labelStatut.BackColor = System.Drawing.Color.Transparent;
            this.labelStatut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelStatut.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelStatut.Location = new System.Drawing.Point(541, 333);
            this.labelStatut.Name = "labelStatut";
            this.labelStatut.Size = new System.Drawing.Size(0, 12);
            this.labelStatut.TabIndex = 3;
            // 
            // pictureBoxLancer
            // 
            this.pictureBoxLancer.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLancer.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLancer.Image")));
            this.pictureBoxLancer.Location = new System.Drawing.Point(12, 290);
            this.pictureBoxLancer.Name = "pictureBoxLancer";
            this.pictureBoxLancer.Size = new System.Drawing.Size(156, 35);
            this.pictureBoxLancer.TabIndex = 4;
            this.pictureBoxLancer.TabStop = false;
            this.pictureBoxLancer.Click += new System.EventHandler(this.pictureBoxLancer_Click);
            // 
            // pictureBox3Close
            // 
            this.pictureBox3Close.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3Close.Image = global::LauncherShyax.Properties.Resources.Close;
            this.pictureBox3Close.Location = new System.Drawing.Point(628, 6);
            this.pictureBox3Close.Name = "pictureBox3Close";
            this.pictureBox3Close.Size = new System.Drawing.Size(23, 21);
            this.pictureBox3Close.TabIndex = 6;
            this.pictureBox3Close.TabStop = false;
            this.pictureBox3Close.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHelp.Image = global::LauncherShyax.Properties.Resources.Help;
            this.pictureBoxHelp.Location = new System.Drawing.Point(610, 6);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(12, 21);
            this.pictureBoxHelp.TabIndex = 7;
            this.pictureBoxHelp.TabStop = false;
            this.pictureBoxHelp.Click += new System.EventHandler(this.pictureBoxHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(36, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Serveur de connexion";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(36, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Serveur de jeu";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // pictureBoxRealm
            // 
            this.pictureBoxRealm.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRealm.Image = global::LauncherShyax.Properties.Resources.up;
            this.pictureBoxRealm.Location = new System.Drawing.Point(173, 5);
            this.pictureBoxRealm.Name = "pictureBoxRealm";
            this.pictureBoxRealm.Size = new System.Drawing.Size(10, 14);
            this.pictureBoxRealm.TabIndex = 10;
            this.pictureBoxRealm.TabStop = false;
            this.pictureBoxRealm.Visible = false;
            // 
            // pictureBoxWorld
            // 
            this.pictureBoxWorld.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxWorld.Image = global::LauncherShyax.Properties.Resources.down;
            this.pictureBoxWorld.Location = new System.Drawing.Point(173, 18);
            this.pictureBoxWorld.Name = "pictureBoxWorld";
            this.pictureBoxWorld.Size = new System.Drawing.Size(10, 14);
            this.pictureBoxWorld.TabIndex = 11;
            this.pictureBoxWorld.TabStop = false;
            this.pictureBoxWorld.Visible = false;
            // 
            // linkLabelSite
            // 
            this.linkLabelSite.AutoSize = true;
            this.linkLabelSite.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSite.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabelSite.Location = new System.Drawing.Point(494, 244);
            this.linkLabelSite.Name = "linkLabelSite";
            this.linkLabelSite.Size = new System.Drawing.Size(80, 13);
            this.linkLabelSite.TabIndex = 12;
            this.linkLabelSite.TabStop = true;
            this.linkLabelSite.Text = "Lien vers le site";
            this.linkLabelSite.VisitedLinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkLabelSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSite_LinkClicked);
            // 
            // linkLabelForum
            // 
            this.linkLabelForum.AutoSize = true;
            this.linkLabelForum.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelForum.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabelForum.Location = new System.Drawing.Point(494, 266);
            this.linkLabelForum.Name = "linkLabelForum";
            this.linkLabelForum.Size = new System.Drawing.Size(90, 13);
            this.linkLabelForum.TabIndex = 13;
            this.linkLabelForum.TabStop = true;
            this.linkLabelForum.Text = "Lien vers le forum";
            this.linkLabelForum.VisitedLinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkLabelForum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForum_LinkClicked);
            // 
            // linkLabelBugTracker
            // 
            this.linkLabelBugTracker.AutoSize = true;
            this.linkLabelBugTracker.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelBugTracker.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabelBugTracker.Location = new System.Drawing.Point(494, 290);
            this.linkLabelBugTracker.Name = "linkLabelBugTracker";
            this.linkLabelBugTracker.Size = new System.Drawing.Size(118, 13);
            this.linkLabelBugTracker.TabIndex = 14;
            this.linkLabelBugTracker.TabStop = true;
            this.linkLabelBugTracker.Text = "Lien vers le bug tracker";
            this.linkLabelBugTracker.VisitedLinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkLabelBugTracker.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBugTracker_LinkClicked);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LauncherShyax.Properties.Resources.Sans_titre_18;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(650, 347);
            this.Controls.Add(this.linkLabelBugTracker);
            this.Controls.Add(this.linkLabelForum);
            this.Controls.Add(this.linkLabelSite);
            this.Controls.Add(this.pictureBoxWorld);
            this.Controls.Add(this.pictureBoxRealm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxHelp);
            this.Controls.Add(this.pictureBox3Close);
            this.Controls.Add(this.pictureBoxLancer);
            this.Controls.Add(this.labelStatut);
            this.Controls.Add(this.checkBoxCache);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher WoW";
            this.Load += new System.EventHandler(this.LauncherBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLancer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRealm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCache;
        private System.Windows.Forms.Label labelStatut;
        private System.Windows.Forms.PictureBox pictureBoxLancer;
        private System.Windows.Forms.PictureBox pictureBox3Close;
        private System.Windows.Forms.PictureBox pictureBoxHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxRealm;
        private System.Windows.Forms.PictureBox pictureBoxWorld;
        private System.Windows.Forms.LinkLabel linkLabelSite;
        private System.Windows.Forms.LinkLabel linkLabelForum;
        private System.Windows.Forms.LinkLabel linkLabelBugTracker;
    }
}

