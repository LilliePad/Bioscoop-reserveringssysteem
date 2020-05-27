using System;
using System.Windows.Forms;
using Project.Models;
using Project.Forms.Layouts;
using Project.Helpers;

namespace Project.Forms {

    public class MovieEdit : BaseLayout {

        private Movie movie;

        public MovieEdit() {
            
        }

        public override string GetHandle() {
            return "movieEdit";
        }

        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

        public override void OnShow() {
            MessageBox.Show("Movie: " + movie.name, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e) {
         
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void Discription_input_TextChanged(object sender, EventArgs e) {

        }

        private void Edit_movie_text_Click(object sender, EventArgs e) {

        }


        private void NameMovie_input_TextChanged(object sender, EventArgs e) {

        }

        private void Duration_input_TextChanged(object sender, EventArgs e) {

        }

        private void Edit_panel_Paint(object sender, PaintEventArgs e) {

        }

        private void Genre_input_TextChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MovieEdit
            // 
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Name = "MovieEdit";
            this.Load += new System.EventHandler(this.MovieEdit_Load);
            this.ResumeLayout(false);

        }

        private void MovieEdit_Load(object sender, EventArgs e) {

        }
    }
    
}