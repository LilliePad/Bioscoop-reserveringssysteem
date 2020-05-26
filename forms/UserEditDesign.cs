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
        private Button Confirm;
        private Label New_password_label;
        private TextBox New_password_input;
        private Label New_password_again_label;
        private Label Old_password_label;
        private ListBox Ticket_list;
        private Button Delete_user_button;
        private TextBox Old_password_input;

        public UserEditDesign() {
            InitializeComponent();
        }

        private void UserEditDesign_Load(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.Confirm = new System.Windows.Forms.Button();
            this.New_password_label = new System.Windows.Forms.Label();
            this.New_password_input = new System.Windows.Forms.TextBox();
            this.New_password_again_label = new System.Windows.Forms.Label();
            this.Old_password_label = new System.Windows.Forms.Label();
            this.Old_password_input = new System.Windows.Forms.TextBox();
            this.Ticket_list = new System.Windows.Forms.ListBox();
            this.Delete_user_button = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Delete_user_button);
            this.panel2.Controls.Add(this.Ticket_list);
            this.panel2.Controls.Add(this.Confirm);
            this.panel2.Controls.Add(this.New_password_label);
            this.panel2.Controls.Add(this.New_password_input);
            this.panel2.Controls.Add(this.New_password_again_label);
            this.panel2.Controls.Add(this.Old_password_label);
            this.panel2.Controls.Add(this.Old_password_input);
            this.panel2.Location = new System.Drawing.Point(180, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 500);
            this.panel2.TabIndex = 3;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(258, 363);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            // 
            // New_password_label
            // 
            this.New_password_label.AutoSize = true;
            this.New_password_label.Location = new System.Drawing.Point(137, 65);
            this.New_password_label.Name = "New_password_label";
            this.New_password_label.Size = new System.Drawing.Size(35, 13);
            this.New_password_label.TabIndex = 5;
            this.New_password_label.Text = "Name";
            this.New_password_label.Click += new System.EventHandler(this.New_password_label_Click);
            // 
            // New_password_input
            // 
            this.New_password_input.Location = new System.Drawing.Point(258, 62);
            this.New_password_input.Name = "New_password_input";
            this.New_password_input.Size = new System.Drawing.Size(272, 20);
            this.New_password_input.TabIndex = 4;
            // 
            // New_password_again_label
            // 
            this.New_password_again_label.AutoSize = true;
            this.New_password_again_label.Location = new System.Drawing.Point(137, 140);
            this.New_password_again_label.Name = "New_password_again_label";
            this.New_password_again_label.Size = new System.Drawing.Size(42, 13);
            this.New_password_again_label.TabIndex = 3;
            this.New_password_again_label.Text = "Tickets";
            // 
            // Old_password_label
            // 
            this.Old_password_label.AutoSize = true;
            this.Old_password_label.Location = new System.Drawing.Point(137, 101);
            this.Old_password_label.Name = "Old_password_label";
            this.Old_password_label.Size = new System.Drawing.Size(58, 13);
            this.Old_password_label.TabIndex = 1;
            this.Old_password_label.Text = "User name";
            this.Old_password_label.Click += new System.EventHandler(this.Old_password_label_Click);
            // 
            // Old_password_input
            // 
            this.Old_password_input.Location = new System.Drawing.Point(258, 98);
            this.Old_password_input.Name = "Old_password_input";
            this.Old_password_input.Size = new System.Drawing.Size(272, 20);
            this.Old_password_input.TabIndex = 0;
            // 
            // Ticket_list
            // 
            this.Ticket_list.FormattingEnabled = true;
            this.Ticket_list.Location = new System.Drawing.Point(258, 140);
            this.Ticket_list.Name = "Ticket_list";
            this.Ticket_list.Size = new System.Drawing.Size(272, 95);
            this.Ticket_list.TabIndex = 7;
            this.Ticket_list.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Delete_user_button
            // 
            this.Delete_user_button.Location = new System.Drawing.Point(455, 363);
            this.Delete_user_button.Name = "Delete_user_button";
            this.Delete_user_button.Size = new System.Drawing.Size(75, 23);
            this.Delete_user_button.TabIndex = 8;
            this.Delete_user_button.Text = "Delete user";
            this.Delete_user_button.UseVisualStyleBackColor = true;
            // 
            // UserEditDesign
            // 
            this.ClientSize = new System.Drawing.Size(1221, 618);
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

        private void Old_password_label_Click(object sender, EventArgs e) {

        }

        private void New_password_label_Click(object sender, EventArgs e) {

        }

        private void New_password_again_input_TextChanged(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
