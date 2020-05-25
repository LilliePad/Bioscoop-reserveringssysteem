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
    public partial class MovieEdit : BaseLayout {
        public MovieEdit() {
            InitializeComponent();
        }
        private void InitializeComponent() {
            this.Genre_text = new System.Windows.Forms.Label();
            this.Genre_input = new System.Windows.Forms.TextBox();
            this.Duration_input = new System.Windows.Forms.TextBox();
            this.Discription_input = new System.Windows.Forms.TextBox();
            this.NameMovie_input = new System.Windows.Forms.TextBox();
            this.Search_Picture = new System.Windows.Forms.Button();
            this.Create_Movie = new System.Windows.Forms.Button();
            this.Movie_Picture_text = new System.Windows.Forms.Label();
            this.Playtime_text = new System.Windows.Forms.Label();
            this.Discription_text = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.Edit_movie_text = new System.Windows.Forms.Label();
            this.Movie_Picture = new System.Windows.Forms.PictureBox();
            this.Delete_movie = new System.Windows.Forms.Button();
            this.Edit_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Picture)).BeginInit();
            this.Edit_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Genre_text
            // 
            this.Genre_text.AutoSize = true;
            this.Genre_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Genre_text.Location = new System.Drawing.Point(31, 409);
            this.Genre_text.Name = "Genre_text";
            this.Genre_text.Size = new System.Drawing.Size(48, 17);
            this.Genre_text.TabIndex = 31;
            this.Genre_text.Text = "Genre";
            // 
            // Genre_input
            // 
            this.Genre_input.Location = new System.Drawing.Point(146, 409);
            this.Genre_input.Name = "Genre_input";
            this.Genre_input.Size = new System.Drawing.Size(495, 20);
            this.Genre_input.TabIndex = 30;
            // 
            // Duration_input
            // 
            this.Duration_input.Location = new System.Drawing.Point(146, 375);
            this.Duration_input.Name = "Duration_input";
            this.Duration_input.Size = new System.Drawing.Size(495, 20);
            this.Duration_input.TabIndex = 29;
            // 
            // Discription_input
            // 
            this.Discription_input.Location = new System.Drawing.Point(146, 146);
            this.Discription_input.Multiline = true;
            this.Discription_input.Name = "Discription_input";
            this.Discription_input.Size = new System.Drawing.Size(495, 206);
            this.Discription_input.TabIndex = 28;
            this.Discription_input.TextChanged += new System.EventHandler(this.Discription_input_TextChanged);
            // 
            // NameMovie_input
            // 
            this.NameMovie_input.Location = new System.Drawing.Point(146, 97);
            this.NameMovie_input.Name = "NameMovie_input";
            this.NameMovie_input.Size = new System.Drawing.Size(495, 20);
            this.NameMovie_input.TabIndex = 27;
            // 
            // Search_Picture
            // 
            this.Search_Picture.Location = new System.Drawing.Point(755, 401);
            this.Search_Picture.Name = "Search_Picture";
            this.Search_Picture.Size = new System.Drawing.Size(133, 39);
            this.Search_Picture.TabIndex = 26;
            this.Search_Picture.Text = "Search Picture";
            this.Search_Picture.UseVisualStyleBackColor = true;
            // 
            // Create_Movie
            // 
            this.Create_Movie.Location = new System.Drawing.Point(146, 487);
            this.Create_Movie.Name = "Create_Movie";
            this.Create_Movie.Size = new System.Drawing.Size(133, 39);
            this.Create_Movie.TabIndex = 25;
            this.Create_Movie.Text = "Create Movie";
            this.Create_Movie.UseVisualStyleBackColor = true;
            this.Create_Movie.Click += new System.EventHandler(this.button1_Click);
            // 
            // Movie_Picture_text
            // 
            this.Movie_Picture_text.AutoSize = true;
            this.Movie_Picture_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Movie_Picture_text.Location = new System.Drawing.Point(722, 97);
            this.Movie_Picture_text.Name = "Movie_Picture_text";
            this.Movie_Picture_text.Size = new System.Drawing.Size(93, 17);
            this.Movie_Picture_text.TabIndex = 24;
            this.Movie_Picture_text.Text = "Movie Picture";
            this.Movie_Picture_text.Click += new System.EventHandler(this.label5_Click);
            // 
            // Playtime_text
            // 
            this.Playtime_text.AutoSize = true;
            this.Playtime_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Playtime_text.Location = new System.Drawing.Point(30, 375);
            this.Playtime_text.Name = "Playtime_text";
            this.Playtime_text.Size = new System.Drawing.Size(61, 17);
            this.Playtime_text.TabIndex = 23;
            this.Playtime_text.Text = "Playtime";
            // 
            // Discription_text
            // 
            this.Discription_text.AutoSize = true;
            this.Discription_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Discription_text.Location = new System.Drawing.Point(31, 146);
            this.Discription_text.Name = "Discription_text";
            this.Discription_text.Size = new System.Drawing.Size(74, 17);
            this.Discription_text.TabIndex = 22;
            this.Discription_text.Text = "Discription";
            this.Discription_text.Click += new System.EventHandler(this.label3_Click);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(31, 97);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(45, 17);
            this.Name_text.TabIndex = 21;
            this.Name_text.Text = "Name";
            // 
            // Edit_movie_text
            // 
            this.Edit_movie_text.AutoSize = true;
            this.Edit_movie_text.Font = new System.Drawing.Font("Modum", 39.25F);
            this.Edit_movie_text.Location = new System.Drawing.Point(24, 15);
            this.Edit_movie_text.Name = "Edit_movie_text";
            this.Edit_movie_text.Size = new System.Drawing.Size(228, 64);
            this.Edit_movie_text.TabIndex = 20;
            this.Edit_movie_text.Text = "Edit movie";
            this.Edit_movie_text.Click += new System.EventHandler(this.Edit_movie_text_Click);
            // 
            // Movie_Picture
            // 
            this.Movie_Picture.Location = new System.Drawing.Point(725, 127);
            this.Movie_Picture.Name = "Movie_Picture";
            this.Movie_Picture.Size = new System.Drawing.Size(204, 268);
            this.Movie_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Movie_Picture.TabIndex = 19;
            this.Movie_Picture.TabStop = false;
            // 
            // Delete_movie
            // 
            this.Delete_movie.Location = new System.Drawing.Point(508, 487);
            this.Delete_movie.Name = "Delete_movie";
            this.Delete_movie.Size = new System.Drawing.Size(133, 39);
            this.Delete_movie.TabIndex = 32;
            this.Delete_movie.Text = "Delete Movie";
            this.Delete_movie.UseVisualStyleBackColor = true;
            this.Delete_movie.Click += new System.EventHandler(this.Delete_movie_Click);
            // 
            // Edit_panel
            // 
            this.Edit_panel.Controls.Add(this.Delete_movie);
            this.Edit_panel.Controls.Add(this.Genre_text);
            this.Edit_panel.Controls.Add(this.Genre_input);
            this.Edit_panel.Controls.Add(this.Duration_input);
            this.Edit_panel.Controls.Add(this.Discription_input);
            this.Edit_panel.Controls.Add(this.NameMovie_input);
            this.Edit_panel.Controls.Add(this.Search_Picture);
            this.Edit_panel.Controls.Add(this.Create_Movie);
            this.Edit_panel.Controls.Add(this.Movie_Picture_text);
            this.Edit_panel.Controls.Add(this.Playtime_text);
            this.Edit_panel.Controls.Add(this.Discription_text);
            this.Edit_panel.Controls.Add(this.Name_text);
            this.Edit_panel.Controls.Add(this.Edit_movie_text);
            this.Edit_panel.Controls.Add(this.Movie_Picture);
            this.Edit_panel.Location = new System.Drawing.Point(40, 122);
            this.Edit_panel.Name = "Edit_panel";
            this.Edit_panel.Size = new System.Drawing.Size(966, 528);
            this.Edit_panel.TabIndex = 33;
            // 
            // MovieEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Edit_panel);
            this.Name = "MovieEdit";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.Edit_panel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Picture)).EndInit();
            this.Edit_panel.ResumeLayout(false);
            this.Edit_panel.PerformLayout();
            this.ResumeLayout(false);

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

        private void Delete_movie_Click(object sender, EventArgs e) {

        }
    }
}
