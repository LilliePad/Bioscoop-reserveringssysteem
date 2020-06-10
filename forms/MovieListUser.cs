using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class MovieListUser : BaseLayout {

        // Frontend
        private ListView container;
        private Label title;

        public MovieListUser() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieListUser";
        }

        public override bool IsDefault() {
            return true;
        }

        public override bool RequireLogin() {
            return false;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            ImageList imgs = new ImageList();
            List<Movie> movies = movieService.GetMovies();

            base.OnShow();

            container.Items.Clear();
            imgs.ImageSize = new Size(100, 100);

            for (int i = 0; i < movies.Count; i++) {
                Movie movie = movies[i];
                ListViewItem item = new ListViewItem(movie.name + " - " + movie.genre + " - " + movie.duration, i);

                item.Tag = movie.id;

                imgs.Images.Add(movie.GetImage());
                container.Items.Add(item);
            }

            //BIND IMGS TO LISTVIEW
            container.SmallImageList = imgs;
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 174);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 430);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(32, 114);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(165, 46);
            this.title.TabIndex = 4;
            this.title.Text = "Film lijst";
            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Controls.Add(this.title);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Films (naam - genre - speelduur)", 600);
        }

        private void ListItem_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if (item == null) {
                MessageBox.Show("Error: Geen item geselecteerd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Movie movie = movieService.GetMovieById(id);

            if (movie == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show screen
            MovieDetailUser movieDetailUser = app.GetScreen<MovieDetailUser>("movieDetailUser");

            movieDetailUser.SetMovie(movie);
            app.ShowScreen(movieDetailUser);
        }

    }

}
