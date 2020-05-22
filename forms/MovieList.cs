using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public partial class MovieList : BaseLayout {

        private System.Windows.Forms.ListView container;

        public MovieList() {
            InitializeComponent();
            this.Populate();
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.SuspendLayout();

            // 
            // Container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.container.Size = new System.Drawing.Size(670, 499);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;

            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Name = "MovieList";
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);
        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Films", 250);
        }

        private void Populate() {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            ImageList imgs = new ImageList();
            List<Movie> movies = movieService.GetMovies();

            imgs.ImageSize = new Size(50, 50);

            for (int i = 0; i < movies.Count; i++) {
                Movie movie = movies[i];

                imgs.Images.Add(movie.GetImage());
                container.Items.Add(movie.name, i);
            }

            //BIND IMGS TO LISTVIEW
            container.SmallImageList = imgs;
        }

    }
}
