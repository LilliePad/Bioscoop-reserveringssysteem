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
        public UserEditDesign() {
            InitializeComponent();
        }

        private void UserEditDesign_Load(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // UserEditDesign
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "UserEditDesign";
            this.Load += new System.EventHandler(this.UserEditDesign_Load_1);
            this.ResumeLayout(false);

        }

        private void UserEditDesign_Load_1(object sender, EventArgs e) {

        }
    }
}
