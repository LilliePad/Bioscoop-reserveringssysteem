using System;
using System.Windows.Forms;
using Project.Models;
using Project.Services;
using Project.Forms.Layouts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;
using System.Data.SqlTypes;
using Project.Helpers;

namespace Bioscoop_reserveringssysteem.forms {
    public partial class MovieEdit : BaseLayout {
        private Movie movie;
        public MovieEdit() {
            InitializeComponent();
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
            movie.name = NameMovie_input.Text;
        }

        private void Duration_input_TextChanged(object sender, EventArgs e) {
            movie.duration = ValidationHelper.ParseInt(Duration_input.Text);
        }

        private void Edit_panel_Paint(object sender, PaintEventArgs e) {

        }

        private void Genre_input_TextChanged(object sender, EventArgs e) {
            movie.genre = Genre_input.Text;
        }
    }
}
