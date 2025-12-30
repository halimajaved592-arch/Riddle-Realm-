using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.Button btnLogout;

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
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.cmbLevels = new System.Windows.Forms.ComboBox();
            this.dgvRiddles = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.btntestConcetion = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabLevels = new System.Windows.Forms.TabPage();
            this.btnDellevels = new System.Windows.Forms.Button();
            this.btnEditlevels = new System.Windows.Forms.Button();
            this.btnAddlevels = new System.Windows.Forms.Button();
            this.dgvLevels = new System.Windows.Forms.DataGridView();
            this.tabRiddles = new System.Windows.Forms.TabPage();
            this.btnDelriddles = new System.Windows.Forms.Button();
            this.btnEditriddles = new System.Windows.Forms.Button();
            this.btnAddriddles = new System.Windows.Forms.Button();
            this.dgvriddle = new System.Windows.Forms.DataGridView();
            this.tabProgress = new System.Windows.Forms.TabPage();
            this.btnBackToLogin = new System.Windows.Forms.Button();
            this.btnResetProgress = new System.Windows.Forms.Button();
            this.btnRefreshProgress = new System.Windows.Forms.Button();
            this.dgvProgress = new System.Windows.Forms.DataGridView();
            this.dgvRiddles.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabLevels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevels)).BeginInit();
            this.tabRiddles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvriddle)).BeginInit();
            this.tabProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(700, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdminWelcome.Location = new System.Drawing.Point(6, 207);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(129, 19);
            this.lblAdminWelcome.TabIndex = 1;
            this.lblAdminWelcome.Text = "Welcome, Admin!";
            // 
            // cmbLevels
            // 
            this.cmbLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevels.Location = new System.Drawing.Point(585, 17);
            this.cmbLevels.Name = "cmbLevels";
            this.cmbLevels.Size = new System.Drawing.Size(150, 21);
            this.cmbLevels.TabIndex = 2;
            // 
            // dgvRiddles
            // 
            this.dgvRiddles.Controls.Add(this.tabUsers);
            this.dgvRiddles.Controls.Add(this.tabLevels);
            this.dgvRiddles.Controls.Add(this.tabRiddles);
            this.dgvRiddles.Controls.Add(this.tabProgress);
            this.dgvRiddles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRiddles.Location = new System.Drawing.Point(0, 0);
            this.dgvRiddles.Name = "dgvRiddles";
            this.dgvRiddles.SelectedIndex = 0;
            this.dgvRiddles.Size = new System.Drawing.Size(702, 450);
            this.dgvRiddles.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.btntestConcetion);
            this.tabUsers.Controls.Add(this.cmbLevels);
            this.tabUsers.Controls.Add(this.lblAdminWelcome);
            this.tabUsers.Controls.Add(this.btnDelete);
            this.tabUsers.Controls.Add(this.btnEdit);
            this.tabUsers.Controls.Add(this.btnAdd);
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(694, 424);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // btntestConcetion
            // 
            this.btntestConcetion.Location = new System.Drawing.Point(629, 385);
            this.btntestConcetion.Name = "btntestConcetion";
            this.btntestConcetion.Size = new System.Drawing.Size(57, 22);
            this.btntestConcetion.TabIndex = 4;
            this.btntestConcetion.Text = "test conection";
            this.btntestConcetion.UseVisualStyleBackColor = true;
            this.btntestConcetion.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(27, 335);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(27, 294);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(27, 252);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(3, 3);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(688, 418);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // tabLevels
            // 
            this.tabLevels.Controls.Add(this.btnDellevels);
            this.tabLevels.Controls.Add(this.btnEditlevels);
            this.tabLevels.Controls.Add(this.btnAddlevels);
            this.tabLevels.Controls.Add(this.dgvLevels);
            this.tabLevels.Location = new System.Drawing.Point(4, 22);
            this.tabLevels.Name = "tabLevels";
            this.tabLevels.Padding = new System.Windows.Forms.Padding(3);
            this.tabLevels.Size = new System.Drawing.Size(694, 424);
            this.tabLevels.TabIndex = 1;
            this.tabLevels.Text = "Levels";
            this.tabLevels.UseVisualStyleBackColor = true;
            // 
            // btnDellevels
            // 
            this.btnDellevels.Location = new System.Drawing.Point(24, 332);
            this.btnDellevels.Name = "btnDellevels";
            this.btnDellevels.Size = new System.Drawing.Size(103, 23);
            this.btnDellevels.TabIndex = 3;
            this.btnDellevels.Text = "Delete";
            this.btnDellevels.UseVisualStyleBackColor = true;
            this.btnDellevels.Click += new System.EventHandler(this.btlDellevels_Click);
            // 
            // btnEditlevels
            // 
            this.btnEditlevels.Location = new System.Drawing.Point(24, 284);
            this.btnEditlevels.Name = "btnEditlevels";
            this.btnEditlevels.Size = new System.Drawing.Size(103, 23);
            this.btnEditlevels.TabIndex = 2;
            this.btnEditlevels.Text = "Edit";
            this.btnEditlevels.UseVisualStyleBackColor = true;
            this.btnEditlevels.Click += new System.EventHandler(this.btnEditlevels_Click);
            // 
            // btnAddlevels
            // 
            this.btnAddlevels.Location = new System.Drawing.Point(24, 234);
            this.btnAddlevels.Name = "btnAddlevels";
            this.btnAddlevels.Size = new System.Drawing.Size(103, 23);
            this.btnAddlevels.TabIndex = 1;
            this.btnAddlevels.Text = "Add";
            this.btnAddlevels.UseVisualStyleBackColor = true;
            this.btnAddlevels.Click += new System.EventHandler(this.btnAddlevels_Click);
            // 
            // dgvLevels
            // 
            this.dgvLevels.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLevels.Location = new System.Drawing.Point(3, 3);
            this.dgvLevels.Name = "dgvLevels";
            this.dgvLevels.Size = new System.Drawing.Size(688, 418);
            this.dgvLevels.TabIndex = 0;
            // 
            // tabRiddles
            // 
            this.tabRiddles.Controls.Add(this.btnDelriddles);
            this.tabRiddles.Controls.Add(this.btnEditriddles);
            this.tabRiddles.Controls.Add(this.btnAddriddles);
            this.tabRiddles.Controls.Add(this.dgvriddle);
            this.tabRiddles.Location = new System.Drawing.Point(4, 22);
            this.tabRiddles.Name = "tabRiddles";
            this.tabRiddles.Size = new System.Drawing.Size(694, 424);
            this.tabRiddles.TabIndex = 2;
            this.tabRiddles.Text = "Riddles";
            this.tabRiddles.UseVisualStyleBackColor = true;
            // 
            // btnDelriddles
            // 
            this.btnDelriddles.Location = new System.Drawing.Point(18, 346);
            this.btnDelriddles.Name = "btnDelriddles";
            this.btnDelriddles.Size = new System.Drawing.Size(111, 23);
            this.btnDelriddles.TabIndex = 3;
            this.btnDelriddles.Text = "Delete";
            this.btnDelriddles.UseVisualStyleBackColor = true;
            this.btnDelriddles.Click += new System.EventHandler(this.btnDelriddles_Click);
            // 
            // btnEditriddles
            // 
            this.btnEditriddles.Location = new System.Drawing.Point(18, 297);
            this.btnEditriddles.Name = "btnEditriddles";
            this.btnEditriddles.Size = new System.Drawing.Size(111, 23);
            this.btnEditriddles.TabIndex = 2;
            this.btnEditriddles.Text = "Edit";
            this.btnEditriddles.UseVisualStyleBackColor = true;
            this.btnEditriddles.Click += new System.EventHandler(this.btnEditriddles_Click);
            // 
            // btnAddriddles
            // 
            this.btnAddriddles.Location = new System.Drawing.Point(18, 248);
            this.btnAddriddles.Name = "btnAddriddles";
            this.btnAddriddles.Size = new System.Drawing.Size(111, 23);
            this.btnAddriddles.TabIndex = 1;
            this.btnAddriddles.Text = "Add";
            this.btnAddriddles.UseVisualStyleBackColor = true;
            this.btnAddriddles.Click += new System.EventHandler(this.btnAddriddles_Click);
            // 
            // dgvriddle
            // 
            this.dgvriddle.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvriddle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvriddle.Location = new System.Drawing.Point(-4, -9);
            this.dgvriddle.Name = "dgvriddle";
            this.dgvriddle.Size = new System.Drawing.Size(700, 444);
            this.dgvriddle.TabIndex = 0;
            // 
            // tabProgress
            // 
            this.tabProgress.Controls.Add(this.btnBackToLogin);
            this.tabProgress.Controls.Add(this.btnResetProgress);
            this.tabProgress.Controls.Add(this.btnRefreshProgress);
            this.tabProgress.Controls.Add(this.dgvProgress);
            this.tabProgress.Location = new System.Drawing.Point(4, 22);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.Size = new System.Drawing.Size(694, 424);
            this.tabProgress.TabIndex = 3;
            this.tabProgress.Text = "Progress";
            this.tabProgress.UseVisualStyleBackColor = true;
            // 
            // btnBackToLogin
            // 
            this.btnBackToLogin.Location = new System.Drawing.Point(544, 393);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(137, 23);
            this.btnBackToLogin.TabIndex = 4;
            this.btnBackToLogin.Text = "Back to Login";
            this.btnBackToLogin.UseVisualStyleBackColor = true;
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // btnResetProgress
            // 
            this.btnResetProgress.Location = new System.Drawing.Point(19, 302);
            this.btnResetProgress.Name = "btnResetProgress";
            this.btnResetProgress.Size = new System.Drawing.Size(133, 23);
            this.btnResetProgress.TabIndex = 3;
            this.btnResetProgress.Text = "Reset";
            this.btnResetProgress.UseVisualStyleBackColor = true;
            this.btnResetProgress.Click += new System.EventHandler(this.btnResetProgress_Click);
            // 
            // btnRefreshProgress
            // 
            this.btnRefreshProgress.Location = new System.Drawing.Point(19, 259);
            this.btnRefreshProgress.Name = "btnRefreshProgress";
            this.btnRefreshProgress.Size = new System.Drawing.Size(133, 23);
            this.btnRefreshProgress.TabIndex = 2;
            this.btnRefreshProgress.Text = "Refresh";
            this.btnRefreshProgress.UseVisualStyleBackColor = true;
            this.btnRefreshProgress.Click += new System.EventHandler(this.btnRefreashProgress_Click);
            // 
            // dgvProgress
            // 
            this.dgvProgress.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProgress.Location = new System.Drawing.Point(0, 0);
            this.dgvProgress.Name = "dgvProgress";
            this.dgvProgress.Size = new System.Drawing.Size(694, 424);
            this.dgvProgress.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dgvRiddles);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.dgvRiddles.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabLevels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevels)).EndInit();
            this.tabRiddles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvriddle)).EndInit();
            this.tabProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl dgvRiddles;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabLevels;
        private System.Windows.Forms.TabPage tabRiddles;
        private System.Windows.Forms.TabPage tabProgress;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvLevels;
        private System.Windows.Forms.DataGridView dgvriddle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProgress;
        private System.Windows.Forms.Button btnDellevels;
        private System.Windows.Forms.Button btnEditlevels;
        private System.Windows.Forms.Button btnAddlevels;
        private System.Windows.Forms.Button btnDelriddles;
        private System.Windows.Forms.Button btnEditriddles;
        private System.Windows.Forms.Button btnAddriddles;
        private System.Windows.Forms.Button btnResetProgress;
        private System.Windows.Forms.Button btnRefreshProgress;
        private System.Windows.Forms.Button btntestConcetion;
        private System.Windows.Forms.ComboBox cmbLevels;
        private Button btnBackToLogin;
    }
}