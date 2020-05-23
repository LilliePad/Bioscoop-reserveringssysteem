using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.Base;
using Project.Data;
using Project.Models;
using Project.Records;
using Project.Services;

namespace Project.Forms {

    public partial class MovieCreate : BaseLayout {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        private TextBox NameMovie;
        private TextBox Discription;
        private TextBox Duration;
        private TextBox Genre;
        private Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;

        private string movieName;
        private string movieGenre;
        private int movieDuration;
        private string movieDurationStr;
        private string Image;

        public MovieCreate() {
            InitializeComponent();
            
        }

        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NameMovie = new System.Windows.Forms.TextBox();
            this.Discription = new System.Windows.Forms.TextBox();
            this.Duration = new System.Windows.Forms.TextBox();
            this.Genre = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(58, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create a Movie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(65, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(65, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Discription";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(64, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Playtime";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(755, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Movie Pictue";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "Create Movie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(789, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 39);
            this.button2.TabIndex = 13;
            this.button2.Text = "Search Picture";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameMovie
            // 
            this.NameMovie.Location = new System.Drawing.Point(180, 214);
            this.NameMovie.Name = "NameMovie";
            this.NameMovie.Size = new System.Drawing.Size(495, 22);
            this.NameMovie.TabIndex = 14;
            this.NameMovie.TextChanged += new System.EventHandler(this.Name_TextChanged);
            // 
            // Discription
            // 
            this.Discription.Location = new System.Drawing.Point(180, 263);
            this.Discription.Multiline = true;
            this.Discription.Name = "Discription";
            this.Discription.Size = new System.Drawing.Size(495, 206);
            this.Discription.TabIndex = 15;
            // 
            // Duration
            // 
            this.Duration.Location = new System.Drawing.Point(180, 492);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(495, 22);
            this.Duration.TabIndex = 16;
            this.Duration.TextChanged += new System.EventHandler(this.Duration_TextChanged);
            // 
            // Genre
            // 
            this.Genre.Location = new System.Drawing.Point(180, 526);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(495, 22);
            this.Genre.TabIndex = 17;
            this.Genre.TextChanged += new System.EventHandler(this.Genre_TextChanged);
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
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.Discription);
            this.Controls.Add(this.NameMovie);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MovieCreate";
            this.Load += new System.EventHandler(this.MovieCreate_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.NameMovie, 0);
            this.Controls.SetChildIndex(this.Discription, 0);
            this.Controls.SetChildIndex(this.Duration, 0);
            this.Controls.SetChildIndex(this.Genre, 0);
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

        private void button2_Click(object sender, System.EventArgs e) {
            System.String imageLocation = "";
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    Image = pictureBox1.ImageLocation;
                }
            }
            catch (System.Exception) {
                MessageBox.Show("an Error Ocured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void TextChanged_Tostring(object sender, EventArgs e) {
              
        }

        private void TextChanged_ToString(object sender, EventArgs e) {
         
        }



        private void button1_Click(object sender, System.EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            Movie movie = new Movie(movieName, movieGenre, movieDuration, Image);
            if (movieManager.SaveMovie(movie)) {
                MessageBox.Show("Movie Created", "noError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("an Error Ocured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void label4_Click(object sender, EventArgs e) {

        }

        private void Duration_TextChanged(object sender, EventArgs e) {
            movieDurationStr = Duration.Text;
            try {
                movieDuration = int.Parse(movieDurationStr);

            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Name_TextChanged(object sender, EventArgs e) {
            movieName = NameMovie.Text;
        }

        private void Genre_TextChanged(object sender, EventArgs e) {
            movieGenre = Genre.Text;
        }
    }
}

