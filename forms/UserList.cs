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
    public partial class UserList : BaseLayout {
        private ListView container;
        private Panel panel2;

        public UserList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "userList";
        }

        private void UserEditDesign_Load(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.panel2 = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.ListView();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.container);
            this.panel2.Location = new System.Drawing.Point(40, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 800);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(3, 3);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(500, 500);
            this.container.TabIndex = 4;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            // 
            // UserList
            // 
            this.ClientSize = new System.Drawing.Size(1222, 606);
            this.Controls.Add(this.panel2);
            this.Name = "UserList";
            this.Load += new System.EventHandler(this.UserEditDesign_Load_1);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void UserEditDesign_Load_1(object sender, EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Users", 250);
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void container_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
