
namespace Final___OOP
{
    partial class Fforgotpass
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.tbconfirm = new System.Windows.Forms.TextBox();
            this.btnotp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbemail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(261, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nhập mã xác minh vào đây";
            // 
            // btnconfirm
            // 
            this.btnconfirm.Location = new System.Drawing.Point(261, 311);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(81, 26);
            this.btnconfirm.TabIndex = 16;
            this.btnconfirm.Text = "Xác nhận";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // tbconfirm
            // 
            this.tbconfirm.Location = new System.Drawing.Point(261, 281);
            this.tbconfirm.Multiline = true;
            this.tbconfirm.Name = "tbconfirm";
            this.tbconfirm.Size = new System.Drawing.Size(218, 24);
            this.tbconfirm.TabIndex = 15;
            // 
            // btnotp
            // 
            this.btnotp.Location = new System.Drawing.Point(261, 189);
            this.btnotp.Name = "btnotp";
            this.btnotp.Size = new System.Drawing.Size(81, 26);
            this.btnotp.TabIndex = 14;
            this.btnotp.Text = "lấy mã";
            this.btnotp.UseVisualStyleBackColor = true;
            this.btnotp.Click += new System.EventHandler(this.btnotp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 37);
            this.label3.TabIndex = 13;
            this.label3.Text = "mật khẩu";
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(261, 159);
            this.tbemail.Multiline = true;
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(218, 24);
            this.tbemail.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(265, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vui lòng nhập email của bạn để tiếp tục";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Đặt lại";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Final___OOP.Properties.Resources.forgot;
            this.pictureBox1.Location = new System.Drawing.Point(1, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Fforgotpass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 380);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.tbconfirm);
            this.Controls.Add(this.btnotp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbemail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Fforgotpass";
            this.Text = "Quên mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.TextBox tbconfirm;
        private System.Windows.Forms.Button btnotp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbemail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}