using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class MovieEdit : BaseLayout {
        private Panel panel1;
        private Label Create_a_movie_text;
        private Label Discription_text;
        private Label Playtime_text;
        private Label Movie_Picture_text;
        private Button Movie_edit_button;
        private Button Search_picture_button;
        private TextBox NameMovie_input;
        private TextBox Discription_input;
        private TextBox Duration_input;
        private TextBox Genre_input;
        private Label label6;
        private Label Name_text;
        private PictureBox pictureBox1;
        private Button Delete_movie_button;
        private TextBox Movie_ID_input;
        private Label label1;
        private Movie movie;
        private StorageFile image;

        public MovieEdit() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieEdit";
        }

        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

      

        private void label3_Click(object sender, EventArgs e) {

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Movie_ID_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Delete_movie_button = new System.Windows.Forms.Button();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Discription_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Movie_Picture_text = new System.Windows.Forms.Label();
            this.Movie_edit_button = new System.Windows.Forms.Button();
            this.Search_picture_button = new System.Windows.Forms.Button();
            this.NameMovie_input = new System.Windows.Forms.TextBox();
            this.Discription_input = new System.Windows.Forms.TextBox();
            this.Duration_input = new System.Windows.Forms.TextBox();
            this.Genre_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Movie_ID_input);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Delete_movie_button);
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Discription_text);
            this.panel1.Controls.Add(this.Playtime_text);
            this.panel1.Controls.Add(this.Movie_Picture_text);
            this.panel1.Controls.Add(this.Movie_edit_button);
            this.panel1.Controls.Add(this.Search_picture_button);
            this.panel1.Controls.Add(this.NameMovie_input);
            this.panel1.Controls.Add(this.Discription_input);
            this.panel1.Controls.Add(this.Duration_input);
            this.panel1.Controls.Add(this.Genre_input);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Name_text);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(40, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 20;
            // 
            // Movie_ID_input
            // 
            this.Movie_ID_input.Location = new System.Drawing.Point(125, 62);
            this.Movie_ID_input.Name = "Movie_ID_input";
            this.Movie_ID_input.Size = new System.Drawing.Size(495, 20);
            this.Movie_ID_input.TabIndex = 21;
            this.Movie_ID_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Movie ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Delete_movie_button
            // 
            this.Delete_movie_button.Location = new System.Drawing.Point(487, 472);
            this.Delete_movie_button.Name = "Delete_movie_button";
            this.Delete_movie_button.Size = new System.Drawing.Size(133, 39);
            this.Delete_movie_button.TabIndex = 19;
            this.Delete_movie_button.Text = "Delete Movie";
            this.Delete_movie_button.UseVisualStyleBackColor = true;
            this.Delete_movie_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoEllipsis = true;
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.BackColor = System.Drawing.SystemColors.Control;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(239, 46);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Edit a movie";
            // 
            // Discription_text
            // 
            this.Discription_text.AutoSize = true;
            this.Discription_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Discription_text.Location = new System.Drawing.Point(10, 131);
            this.Discription_text.Name = "Discription_text";
            this.Discription_text.Size = new System.Drawing.Size(74, 17);
            this.Discription_text.TabIndex = 5;
            this.Discription_text.Text = "Discription";
            // 
            // Playtime_text
            // 
            this.Playtime_text.AutoSize = true;
            this.Playtime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Playtime_text.Location = new System.Drawing.Point(9, 360);
            this.Playtime_text.Name = "Playtime_text";
            this.Playtime_text.Size = new System.Drawing.Size(61, 17);
            this.Playtime_text.TabIndex = 6;
            this.Playtime_text.Text = "Playtime";
            // 
            // Movie_Picture_text
            // 
            this.Movie_Picture_text.AutoSize = true;
            this.Movie_Picture_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Movie_Picture_text.Location = new System.Drawing.Point(700, 82);
            this.Movie_Picture_text.Name = "Movie_Picture_text";
            this.Movie_Picture_text.Size = new System.Drawing.Size(93, 17);
            this.Movie_Picture_text.TabIndex = 11;
            this.Movie_Picture_text.Text = "Movie Picture";
            // 
            // Movie_edit_button
            // 
            this.Movie_edit_button.Location = new System.Drawing.Point(125, 472);
            this.Movie_edit_button.Name = "Movie_edit_button";
            this.Movie_edit_button.Size = new System.Drawing.Size(133, 39);
            this.Movie_edit_button.TabIndex = 12;
            this.Movie_edit_button.Text = "Edit Movie";
            this.Movie_edit_button.UseVisualStyleBackColor = true;
            this.Movie_edit_button.Click += new System.EventHandler(this.Movie_create_button_Click_1);
            // 
            // Search_picture_button
            // 
            this.Search_picture_button.Location = new System.Drawing.Point(734, 386);
            this.Search_picture_button.Name = "Search_picture_button";
            this.Search_picture_button.Size = new System.Drawing.Size(133, 39);
            this.Search_picture_button.TabIndex = 13;
            this.Search_picture_button.Text = "Search Picture";
            this.Search_picture_button.UseVisualStyleBackColor = true;
            this.Search_picture_button.Click += new System.EventHandler(this.Search_picture_button_Click);
            // 
            // NameMovie_input
            // 
            this.NameMovie_input.Location = new System.Drawing.Point(125, 95);
            this.NameMovie_input.Name = "NameMovie_input";
            this.NameMovie_input.Size = new System.Drawing.Size(495, 20);
            this.NameMovie_input.TabIndex = 14;
            this.NameMovie_input.TextChanged += new System.EventHandler(this.NameMovie_input_TextChanged_1);
            // 
            // Discription_input
            // 
            this.Discription_input.Location = new System.Drawing.Point(125, 131);
            this.Discription_input.Multiline = true;
            this.Discription_input.Name = "Discription_input";
            this.Discription_input.Size = new System.Drawing.Size(495, 206);
            this.Discription_input.TabIndex = 15;
            this.Discription_input.TextChanged += new System.EventHandler(this.Discription_input_TextChanged);
            // 
            // Duration_input
            // 
            this.Duration_input.Location = new System.Drawing.Point(125, 360);
            this.Duration_input.Name = "Duration_input";
            this.Duration_input.Size = new System.Drawing.Size(495, 20);
            this.Duration_input.TabIndex = 16;
            this.Duration_input.TextChanged += new System.EventHandler(this.Duration_input_TextChanged_1);
            // 
            // Genre_input
            // 
            this.Genre_input.Location = new System.Drawing.Point(125, 394);
            this.Genre_input.Name = "Genre_input";
            this.Genre_input.Size = new System.Drawing.Size(495, 20);
            this.Genre_input.TabIndex = 17;
            this.Genre_input.TextChanged += new System.EventHandler(this.Genre_input_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(10, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Genre";
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 95);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(45, 17);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Name";
            this.Name_text.Click += new System.EventHandler(this.Name_text_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(704, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MovieEdit
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel1);
            this.Name = "MovieEdit";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");
            if (movieManager.DeleteMovie(movie)) {
                MessageBox.Show("film succesvol verwijderd");
                MovieList newScreen = app.GetScreen<MovieList>("movieList");
                app.ShowScreen(newScreen);
            }
            else {
                MessageBox.Show("Kon de film niet verwijderen");
            }
        }

        private void Movie_create_button_Click(object sender, EventArgs args) {
       
        }
        private void label1_Click(object sender, EventArgs args) {

        }

        private void NameMovie_input_TextChanged_1(object sender, EventArgs args) {
            movie.name = NameMovie_input.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs args) {

        }

        private void Name_text_Click(object sender, EventArgs args) {

        }

        private void Movie_create_button_Click_1(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");
            movieManager.SaveMovie(movie);
            MovieList newScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(newScreen);
        }

        private void Discription_input_TextChanged(object sender, EventArgs args) {

        }

        private void Duration_input_TextChanged_1(object sender, EventArgs args) {
            movie.duration = ValidationHelper.ParseInt(Duration_input.Text);
        }

        private void Genre_input_TextChanged_1(object sender, EventArgs args) {
            movie.genre = Genre_input.Text;
        }

        private void Search_picture_button_Click(object sender, EventArgs args) {
            string imageLocation = "";

            try {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    image = StorageHelper.UploadImage(pictureBox1.ImageLocation);
                    movie.image = image;
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}