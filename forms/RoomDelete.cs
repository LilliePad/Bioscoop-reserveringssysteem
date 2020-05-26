using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Forms.Layouts;


namespace Project.forms {
    public partial class RoomDelete : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private Label Discription_text;
        private Label Playtime_text;
        private Button Movie_create_button;
        private TextBox NameMovie_input;
        private TextBox Discription_input;
        private TextBox Duration_input;
        private TextBox Genre_input;
        private Label label6;
        private Panel panel2;
        private Label Old_password_label;
        private Button Confirm;
        private Label roomIDlabel;
        private ListBox Chair_list;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label Name_text;

        public RoomDelete() {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.Confirm = new System.Windows.Forms.Button();
            this.Old_password_label = new System.Windows.Forms.Label();
            this.Chair_list = new System.Windows.Forms.ListBox();
            this.roomIDlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.roomIDlabel);
            this.panel2.Controls.Add(this.Chair_list);
            this.panel2.Controls.Add(this.Confirm);
            this.panel2.Controls.Add(this.Old_password_label);
            this.panel2.Location = new System.Drawing.Point(180, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 443);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(420, 164);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Delete chair";
            this.Confirm.UseVisualStyleBackColor = true;
            // 
            // Old_password_label
            // 
            this.Old_password_label.AutoSize = true;
            this.Old_password_label.Location = new System.Drawing.Point(19, 58);
            this.Old_password_label.Name = "Old_password_label";
            this.Old_password_label.Size = new System.Drawing.Size(46, 13);
            this.Old_password_label.TabIndex = 1;
            this.Old_password_label.Text = "RoomID";
            this.Old_password_label.Click += new System.EventHandler(this.Old_password_label_Click);
            // 
            // Chair_list
            // 
            this.Chair_list.FormattingEnabled = true;
            this.Chair_list.Location = new System.Drawing.Point(140, 135);
            this.Chair_list.Name = "Chair_list";
            this.Chair_list.Size = new System.Drawing.Size(250, 160);
            this.Chair_list.TabIndex = 7;
            // 
            // roomIDlabel
            // 
            this.roomIDlabel.AutoSize = true;
            this.roomIDlabel.Location = new System.Drawing.Point(137, 58);
            this.roomIDlabel.Name = "roomIDlabel";
            this.roomIDlabel.Size = new System.Drawing.Size(63, 13);
            this.roomIDlabel.TabIndex = 8;
            this.roomIDlabel.Text = "roomIDlabel";
            this.roomIDlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "roomnumberlabel";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Room number";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "chairs";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Add chair";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Delete room";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RoomDelete
            // 
            this.ClientSize = new System.Drawing.Size(1217, 599);
            this.Controls.Add(this.panel2);
            this.Name = "RoomDelete";
            this.Load += new System.EventHandler(this.UserChangePassword_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void UserChangePassword_Load(object sender, EventArgs e) {

        }

        private void Create_a_movie_text_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void Old_password_label_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click_1(object sender, EventArgs e) {

        }

        private void label1_Click_1(object sender, EventArgs e) {

        }
    }
}
