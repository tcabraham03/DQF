namespace DQF_30_01_15
{
    partial class Register
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.UIDlabel = new System.Windows.Forms.Label();
            this.Unamelabel = new System.Windows.Forms.Label();
            this.UIDtextBox = new System.Windows.Forms.TextBox();
            this.UnametextBox = new System.Windows.Forms.TextBox();
            this.DatetextBox4 = new System.Windows.Forms.TextBox();
            this.Datelabel = new System.Windows.Forms.Label();
            this.PswdtextBox = new System.Windows.Forms.TextBox();
            this.Pswdlabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CClosebutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // UIDlabel
            // 
            this.UIDlabel.AutoSize = true;
            this.UIDlabel.BackColor = System.Drawing.Color.Transparent;
            this.UIDlabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIDlabel.Location = new System.Drawing.Point(181, 184);
            this.UIDlabel.Name = "UIDlabel";
            this.UIDlabel.Size = new System.Drawing.Size(30, 17);
            this.UIDlabel.TabIndex = 0;
            this.UIDlabel.Text = "UID";
            // 
            // Unamelabel
            // 
            this.Unamelabel.AutoSize = true;
            this.Unamelabel.BackColor = System.Drawing.Color.Transparent;
            this.Unamelabel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unamelabel.Location = new System.Drawing.Point(138, 226);
            this.Unamelabel.Name = "Unamelabel";
            this.Unamelabel.Size = new System.Drawing.Size(75, 16);
            this.Unamelabel.TabIndex = 1;
            this.Unamelabel.Text = "User Name";
            // 
            // UIDtextBox
            // 
            this.UIDtextBox.Location = new System.Drawing.Point(221, 184);
            this.UIDtextBox.Name = "UIDtextBox";
            this.UIDtextBox.Size = new System.Drawing.Size(121, 20);
            this.UIDtextBox.TabIndex = 2;
            // 
            // UnametextBox
            // 
            this.UnametextBox.Location = new System.Drawing.Point(221, 226);
            this.UnametextBox.Name = "UnametextBox";
            this.UnametextBox.Size = new System.Drawing.Size(121, 20);
            this.UnametextBox.TabIndex = 3;
            // 
            // DatetextBox4
            // 
            this.DatetextBox4.Enabled = false;
            this.DatetextBox4.Location = new System.Drawing.Point(221, 268);
            this.DatetextBox4.Name = "DatetextBox4";
            this.DatetextBox4.Size = new System.Drawing.Size(121, 20);
            this.DatetextBox4.TabIndex = 7;
            // 
            // Datelabel
            // 
            this.Datelabel.AutoSize = true;
            this.Datelabel.BackColor = System.Drawing.Color.Transparent;
            this.Datelabel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelabel.Location = new System.Drawing.Point(176, 268);
            this.Datelabel.Name = "Datelabel";
            this.Datelabel.Size = new System.Drawing.Size(37, 16);
            this.Datelabel.TabIndex = 6;
            this.Datelabel.Text = "Date";
            // 
            // PswdtextBox
            // 
            this.PswdtextBox.Location = new System.Drawing.Point(221, 313);
            this.PswdtextBox.Name = "PswdtextBox";
            this.PswdtextBox.Size = new System.Drawing.Size(121, 20);
            this.PswdtextBox.TabIndex = 9;
            this.PswdtextBox.UseSystemPasswordChar = true;
            // 
            // Pswdlabel
            // 
            this.Pswdlabel.AutoSize = true;
            this.Pswdlabel.BackColor = System.Drawing.Color.Transparent;
            this.Pswdlabel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pswdlabel.Location = new System.Drawing.Point(144, 313);
            this.Pswdlabel.Name = "Pswdlabel";
            this.Pswdlabel.Size = new System.Drawing.Size(69, 16);
            this.Pswdlabel.TabIndex = 8;
            this.Pswdlabel.Text = "Password";
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.Transparent;
            this.SubmitButton.Location = new System.Drawing.Point(184, 365);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 11;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CClosebutton
            // 
            this.CClosebutton.BackColor = System.Drawing.Color.Transparent;
            this.CClosebutton.Location = new System.Drawing.Point(267, 365);
            this.CClosebutton.Name = "CClosebutton";
            this.CClosebutton.Size = new System.Drawing.Size(75, 23);
            this.CClosebutton.TabIndex = 12;
            this.CClosebutton.Text = "Cancel";
            this.CClosebutton.UseVisualStyleBackColor = false;
            this.CClosebutton.Click += new System.EventHandler(this.CClosebutton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 41);
            this.label6.TabIndex = 13;
            this.label6.Text = "Registration";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(524, 500);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CClosebutton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.PswdtextBox);
            this.Controls.Add(this.Pswdlabel);
            this.Controls.Add(this.DatetextBox4);
            this.Controls.Add(this.Datelabel);
            this.Controls.Add(this.UnametextBox);
            this.Controls.Add(this.UIDtextBox);
            this.Controls.Add(this.Unamelabel);
            this.Controls.Add(this.UIDlabel);
            this.Name = "Register";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UIDlabel;
        private System.Windows.Forms.Label Unamelabel;
        private System.Windows.Forms.TextBox UIDtextBox;
        private System.Windows.Forms.TextBox UnametextBox;
        private System.Windows.Forms.TextBox DatetextBox4;
        private System.Windows.Forms.Label Datelabel;
        private System.Windows.Forms.TextBox PswdtextBox;
        private System.Windows.Forms.Label Pswdlabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CClosebutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}