using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class MovieList : BaseLayout {

        private ListView container;
        private Button movieCreateButton;

        public MovieList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieList";
        }

        public override bool IsDefault() {
            return true;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            ImageList imgs = new ImageList();
            List<Movie> movies = movieService.GetMovies();

            container.Items.Clear();
            imgs.ImageSize = new Size(50, 50);

            for (int i = 0; i < movies.Count; i++) {
                Movie movie = movies[i];

                imgs.Images.Add(movie.GetImage());
                container.Items.Add(movie.name, i);
            }

            //BIND IMGS TO LISTVIEW
            container.SmallImageList = imgs;
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.movieCreateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 452);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            // 
            // movieCreateButton
            // 
            this.movieCreateButton.Location = new System.Drawing.Point(40, 601);
            this.movieCreateButton.Name = "movieCreateButton";
            this.movieCreateButton.Size = new System.Drawing.Size(110, 51);
            this.movieCreateButton.TabIndex = 3;
            this.movieCreateButton.Text = "Nieuw";
            this.movieCreateButton.UseVisualStyleBackColor = true;
            this.movieCreateButton.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.movieCreateButton);
            this.Controls.Add(this.container);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.movieCreateButton, 0);
            this.ResumeLayout(false);

        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Films", 250);
        }

        private void ButtonNew_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieCreate editScreen = app.GetScreen<MovieCreate>("movieCreate");

            app.ShowScreen(editScreen);
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieEdit editScreen = app.GetScreen<MovieEdit>("movieEdit");

            app.ShowScreen(editScreen);
        }

    }

}
