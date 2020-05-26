using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class MovieCreate : BaseLayout {

        private System.Windows.Forms.Label Create_a_movie_text;
        private System.Windows.Forms.Label Name_text;
        private System.Windows.Forms.Label Discription_text;
        private System.Windows.Forms.Label Playtime_text;
        private System.Windows.Forms.Label Movie_Picture_text;
        private System.Windows.Forms.Button Movie_create_button;
        private System.Windows.Forms.Button Search_picture_button;

        private TextBox NameMovie_input;
        private TextBox Discription_input;
        private TextBox Duration_input;
        private TextBox Genre_input;
        private Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;

        private string movieName;
        private string movieDiscription;
        private string movieGenre;
        private int movieDuration;
        private string movieDurationStr;
        private StorageFile image;

        public MovieCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieCreate";
        }

        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.Discription_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Movie_Picture_text = new System.Windows.Forms.Label();
            this.Movie_create_button = new System.Windows.Forms.Button();
            this.Search_picture_button = new System.Windows.Forms.Button();
            this.NameMovie_input = new System.Windows.Forms.TextBox();
            this.Discription_input = new System.Windows.Forms.TextBox();
            this.Duration_input = new System.Windows.Forms.TextBox();
            this.Genre_input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(759, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(58, 132);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(364, 58);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Create a movie";
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(65, 214);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(53, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Name";
            this.Name_text.Click += new System.EventHandler(this.label2_Click);
            // 
            // Discription_text
            // 
            this.Discription_text.AutoSize = true;
            this.Discription_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Discription_text.Location = new System.Drawing.Point(65, 263);
            this.Discription_text.Name = "Discription_text";
            this.Discription_text.Size = new System.Drawing.Size(90, 20);
            this.Discription_text.TabIndex = 5;
            this.Discription_text.Text = "Discription";
            // 
            // Playtime_text
            // 
            this.Playtime_text.AutoSize = true;
            this.Playtime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Playtime_text.Location = new System.Drawing.Point(64, 492);
            this.Playtime_text.Name = "Playtime_text";
            this.Playtime_text.Size = new System.Drawing.Size(73, 20);
            this.Playtime_text.TabIndex = 6;
            this.Playtime_text.Text = "Playtime";
            this.Playtime_text.Click += new System.EventHandler(this.label4_Click);
            // 
            // Movie_Picture_text
            // 
            this.Movie_Picture_text.AutoSize = true;
            this.Movie_Picture_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Movie_Picture_text.Location = new System.Drawing.Point(755, 214);
            this.Movie_Picture_text.Name = "Movie_Picture_text";
            this.Movie_Picture_text.Size = new System.Drawing.Size(111, 20);
            this.Movie_Picture_text.TabIndex = 11;
            this.Movie_Picture_text.Text = "Movie Picture";
            this.Movie_Picture_text.Click += new System.EventHandler(this.label5_Click);
            // 
            // Movie_create_button
            // 
            this.Movie_create_button.Location = new System.Drawing.Point(180, 604);
            this.Movie_create_button.Name = "Movie_create_button";
            this.Movie_create_button.Size = new System.Drawing.Size(133, 39);
            this.Movie_create_button.TabIndex = 12;
            this.Movie_create_button.Text = "Create Movie";
            this.Movie_create_button.UseVisualStyleBackColor = true;
            this.Movie_create_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Search_picture_button
            // 
            this.Search_picture_button.Location = new System.Drawing.Point(789, 518);
            this.Search_picture_button.Name = "Search_picture_button";
            this.Search_picture_button.Size = new System.Drawing.Size(133, 39);
            this.Search_picture_button.TabIndex = 13;
            this.Search_picture_button.Text = "Search Picture";
            this.Search_picture_button.UseVisualStyleBackColor = true;
            this.Search_picture_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameMovie_input
            // 
            this.NameMovie_input.Location = new System.Drawing.Point(180, 214);
            this.NameMovie_input.Name = "NameMovie_input";
            this.NameMovie_input.Size = new System.Drawing.Size(495, 22);
            this.NameMovie_input.TabIndex = 14;
            this.NameMovie_input.TextChanged += new System.EventHandler(this.Name_TextChanged);
            // 
            // Discription_input
            // 
            this.Discription_input.Location = new System.Drawing.Point(180, 263);
            this.Discription_input.Multiline = true;
            this.Discription_input.Name = "Discription_input";
            this.Discription_input.Size = new System.Drawing.Size(495, 206);
            this.Discription_input.TabIndex = 15;
            this.Discription_input.TextChanged += new System.EventHandler(this.Discription_input_TextChanged);
            // 
            // Duration_input
            // 
            this.Duration_input.Location = new System.Drawing.Point(180, 492);
            this.Duration_input.Name = "Duration_input";
            this.Duration_input.Size = new System.Drawing.Size(495, 22);
            this.Duration_input.TabIndex = 16;
            this.Duration_input.TextChanged += new System.EventHandler(this.Duration_TextChanged);
            // 
            // Genre_input
            // 
            this.Genre_input.Location = new System.Drawing.Point(180, 526);
            this.Genre_input.Name = "Genre_input";
            this.Genre_input.Size = new System.Drawing.Size(495, 22);
            this.Genre_input.TabIndex = 17;
            this.Genre_input.TextChanged += new System.EventHandler(this.Genre_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(65, 526);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Genre";
            // 
            // MovieCreate
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Genre_input);
            this.Controls.Add(this.Duration_input);
            this.Controls.Add(this.Discription_input);
            this.Controls.Add(this.NameMovie_input);
            this.Controls.Add(this.Search_picture_button);
            this.Controls.Add(this.Movie_create_button);
            this.Controls.Add(this.Movie_Picture_text);
            this.Controls.Add(this.Playtime_text);
            this.Controls.Add(this.Discription_text);
            this.Controls.Add(this.Name_text);
            this.Controls.Add(this.Create_a_movie_text);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MovieCreate";
            this.Load += new System.EventHandler(this.MovieCreate_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.Create_a_movie_text, 0);
            this.Controls.SetChildIndex(this.Name_text, 0);
            this.Controls.SetChildIndex(this.Discription_text, 0);
            this.Controls.SetChildIndex(this.Playtime_text, 0);
            this.Controls.SetChildIndex(this.Movie_Picture_text, 0);
            this.Controls.SetChildIndex(this.Movie_create_button, 0);
            this.Controls.SetChildIndex(this.Search_picture_button, 0);
            this.Controls.SetChildIndex(this.NameMovie_input, 0);
            this.Controls.SetChildIndex(this.Discription_input, 0);
            this.Controls.SetChildIndex(this.Duration_input, 0);
            this.Controls.SetChildIndex(this.Genre_input, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {

        }

        private void label2_Click(object sender, System.EventArgs e) {

        }

        private void MovieCreate_Load(object sender, System.EventArgs e) {

        }

        private void richTextBox3_TextChanged(object sender, System.EventArgs e) {

        }

        private void label5_Click(object sender, System.EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs args) {
            string imageLocation = "";

            try {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    image = StorageHelper.UploadImage(pictureBox1.ImageLocation);
                }
            } catch (Exception e) {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, System.EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            Movie movie = new Movie(movieName, movieDiscription, movieGenre, movieDuration, image);

            if (!movieManager.SaveMovie(movie)) {
                MessageBox.Show("Error: " + ValidationHelper.GetErrorList(movie), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Go back to list view
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void Duration_TextChanged(object sender, EventArgs e) {
            movieDurationStr = Duration_input.Text;
            try {
                movieDuration = int.Parse(movieDurationStr);

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Name_TextChanged(object sender, EventArgs e) {
            movieName = NameMovie_input.Text;
        }

        private void Genre_TextChanged(object sender, EventArgs e) {
            movieGenre = Genre_input.Text;
        }

        private void Discription_input_TextChanged(object sender, EventArgs e) {
            movieDiscription = Discription_input.Text;
        }

    }

}

