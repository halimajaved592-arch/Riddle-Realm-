namespace WindowsFormsApp1
{
    partial class LevelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelForm));
            this.btneasy = new System.Windows.Forms.Button();
            this.btnmedium = new System.Windows.Forms.Button();
            this.btnhard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btneasy
            // 
            this.btneasy.BackColor = System.Drawing.Color.Transparent;
            this.btneasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneasy.ForeColor = System.Drawing.Color.Black;
            this.btneasy.Image = global::WindowsFormsApp1.Properties.Resources.easy_buuton_new;
            this.btneasy.Location = new System.Drawing.Point(220, 159);
            this.btneasy.Name = "btneasy";
            this.btneasy.Size = new System.Drawing.Size(143, 97);
            this.btneasy.TabIndex = 0;
            this.btneasy.UseVisualStyleBackColor = false;
            this.btneasy.Click += new System.EventHandler(this.btneasy_Click);
            // 
            // btnmedium
            // 
            this.btnmedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmedium.Image = global::WindowsFormsApp1.Properties.Resources.new_medium_btn;
            this.btnmedium.Location = new System.Drawing.Point(220, 262);
            this.btnmedium.Name = "btnmedium";
            this.btnmedium.Size = new System.Drawing.Size(143, 99);
            this.btnmedium.TabIndex = 1;
            this.btnmedium.UseVisualStyleBackColor = true;
            this.btnmedium.Click += new System.EventHandler(this.btnmedium_Click);
            // 
            // btnhard
            // 
            this.btnhard.BackColor = System.Drawing.Color.Transparent;
            this.btnhard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhard.Image = global::WindowsFormsApp1.Properties.Resources.hard_btn_new;
            this.btnhard.Location = new System.Drawing.Point(220, 367);
            this.btnhard.Name = "btnhard";
            this.btnhard.Size = new System.Drawing.Size(143, 98);
            this.btnhard.TabIndex = 2;
            this.btnhard.UseVisualStyleBackColor = false;
            this.btnhard.Click += new System.EventHandler(this.btnhard_Click);
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.levels_img1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 529);
            this.Controls.Add(this.btnhard);
            this.Controls.Add(this.btnmedium);
            this.Controls.Add(this.btneasy);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LevelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LevelForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btneasy;
        private System.Windows.Forms.Button btnmedium;
        private System.Windows.Forms.Button btnhard;
    }
}