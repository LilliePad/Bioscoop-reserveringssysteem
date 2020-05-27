using Project.Forms.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms {
    public partial class UserEditDesign : BaseLayout {
        private Panel panel2;
        private Label label1;
        private TextBox textBox1;
        private Button Confirm;
        private Label Old_password_label;
        private TextBox Old_password_input;

        public UserEditDesign() {
            InitializeComponent();
        }

        private void UserEditDesign_Load(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Old_password_label = new System.Windows.Forms.Label();
            this.Old_password_input = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.Confirm);
            this.panel2.Controls.Add(this.Old_password_label);
            this.panel2.Controls.Add(this.Old_password_input);
            this.panel2.Location = new System.Drawing.Point(254, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 443);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "change first and last name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 20);
            this.textBox1.TabIndex = 8;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(315, 292);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            // 
            // Old_password_label
            // 
            this.Old_password_label.AutoSize = true;
            this.Old_password_label.Location = new System.Drawing.Point(109, 123);
            this.Old_password_label.Name = "Old_password_label";
            this.Old_password_label.Size = new System.Drawing.Size(99, 13);
            this.Old_password_label.TabIndex = 1;
            this.Old_password_label.Text = "change User Name";
            // 
            // Old_password_input
            // 
            this.Old_password_input.Location = new System.Drawing.Point(258, 120);
            this.Old_password_input.Name = "Old_password_input";
            this.Old_password_input.Size = new System.Drawing.Size(272, 20);
            this.Old_password_input.TabIndex = 0;
            // 
            // UserEditDesign
            // 
            this.ClientSize = new System.Drawing.Size(1222, 606);
            this.Controls.Add(this.panel2);
            this.Name = "UserEditDesign";
            this.Load += new System.EventHandler(this.UserEditDesign_Load_1);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void UserEditDesign_Load_1(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
