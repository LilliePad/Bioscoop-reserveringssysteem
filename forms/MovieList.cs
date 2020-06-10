using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class MovieList : BaseLayout {

        // Frontend
        private ListView container;
        private Label title;

        private Button newButton;

        public MovieList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieList";
        }

        public override bool RequireAdmin() {
            return true;
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
            this.newButton = new System.Windows.Forms.Button();
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
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(40, 638);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(140, 23);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "Nieuw";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.NewButton_Click);
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
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.container);
            this.Controls.Add(this.title);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.newButton, 0);
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
                GuiHelper.ShowError("Geen item geselecteerd");
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Movie movie = movieService.GetMovieById(id);

            if (movie == null) {
                GuiHelper.ShowError("Kon geen film vinden voor dit item");
                return;
            }

            // Show screen
            MovieDetail movieDetail = app.GetScreen<MovieDetail>("movieDetail");

            movieDetail.SetMovie(movie);
            app.ShowScreen(movieDetail);
        }

        private void NewButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieCreate newScreen = app.GetScreen<MovieCreate>("movieCreate");

            app.ShowScreen(newScreen);
        }

    }

}
