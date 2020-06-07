using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class ShowDelete : BaseLayout {
        private Panel panel1;
        private Button Delete_chair_button;

        private Label Chair_edit_text;
        private Label Row_text;
        private Label Colum_text;

        private Show show;
        private int row;
        private Label label1;
        private int colum;

        

        public ShowDelete() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "showDelete";
        }

        public void SetShow(Show show) {
            this.show = show;
        }

       

        public override void OnShow() {
            base.OnShow();
            this.label1.Text = "Show id = " + show.id;
        }
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Colum_text = new System.Windows.Forms.Label();
            this.Row_text = new System.Windows.Forms.Label();
            this.Delete_chair_button = new System.Windows.Forms.Button();
            this.Chair_edit_text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Colum_text);
            this.panel1.Controls.Add(this.Row_text);
            this.panel1.Controls.Add(this.Delete_chair_button);
            this.panel1.Controls.Add(this.Chair_edit_text);
            this.panel1.Location = new System.Drawing.Point(40, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            // 
            // Colum_text
            // 
            this.Colum_text.AutoSize = true;
            this.Colum_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Colum_text.Location = new System.Drawing.Point(9, 126);
            this.Colum_text.Name = "Colum_text";
            this.Colum_text.Size = new System.Drawing.Size(0, 20);
            this.Colum_text.TabIndex = 21;
            this.Colum_text.Click += new System.EventHandler(this.Colum_Click);
            // 
            // Row_text
            // 
            this.Row_text.AutoSize = true;
            this.Row_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Row_text.Location = new System.Drawing.Point(9, 94);
            this.Row_text.Name = "Row_text";
            this.Row_text.Size = new System.Drawing.Size(0, 20);
            this.Row_text.TabIndex = 20;
            this.Row_text.Click += new System.EventHandler(this.Row_Click);
            // 
            // Delete_chair_button
            // 
            this.Delete_chair_button.Location = new System.Drawing.Point(13, 135);
            this.Delete_chair_button.Name = "Delete_chair_button";
            this.Delete_chair_button.Size = new System.Drawing.Size(133, 39);
            this.Delete_chair_button.TabIndex = 19;
            this.Delete_chair_button.Text = "show verwijderen";
            this.Delete_chair_button.UseVisualStyleBackColor = true;
            this.Delete_chair_button.Click += new System.EventHandler(this.Chair_delete_button_Click);
            // 
            // Chair_edit_text
            // 
            this.Chair_edit_text.AutoEllipsis = true;
            this.Chair_edit_text.AutoSize = true;
            this.Chair_edit_text.BackColor = System.Drawing.SystemColors.Control;
            this.Chair_edit_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Chair_edit_text.Location = new System.Drawing.Point(3, 0);
            this.Chair_edit_text.Name = "Chair_edit_text";
            this.Chair_edit_text.Size = new System.Drawing.Size(420, 58);
            this.Chair_edit_text.TabIndex = 3;
            this.Chair_edit_text.Text = "Show verwijderen";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(15, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Show id =";
            // 
            // ShowDelete
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel1);
            this.Name = "ShowDelete";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

      


        private void Colum_Click(object sender, EventArgs e) {

        }

        private void Row_Click(object sender, EventArgs args) {

        }

        private void Chair_delete_button_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ShowService showManager = app.GetService<ShowService>("shows");
       
            try {
                showManager.DeleteShow(show);
            }
            catch {
                MessageBox.Show("Error: kon stoel niet verwijderen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            ShowList newScreen = app.GetScreen<ShowList>("showList");
            app.ShowScreen(newScreen);
        }
    }

}