using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class MovieList : BaseLayout {

        private Panel panel1;
        private Button Edit_list;
        private Button Add_to_list;
        private ListView container;

        public MovieList() {
            InitializeComponent();
            this.Populate();
        }

        public override string GetHandle() {
            return "movieList";
        }

        public override bool IsDefault() {
            return true;
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Add_to_list = new System.Windows.Forms.Button();
            this.Edit_list = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1182, 437);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Edit_list);
            this.panel1.Controls.Add(this.Add_to_list);
            this.panel1.Location = new System.Drawing.Point(40, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 100);
            this.panel1.TabIndex = 3;
            // 
            // Add_to_list
            // 
            this.Add_to_list.Location = new System.Drawing.Point(16, 27);
            this.Add_to_list.Name = "Add_to_list";
            this.Add_to_list.Size = new System.Drawing.Size(133, 39);
            this.Add_to_list.TabIndex = 26;
            this.Add_to_list.Text = "Add to list";
            this.Add_to_list.UseVisualStyleBackColor = true;
            this.Add_to_list.Click += new System.EventHandler(this.Add_to_list_Click);
            // 
            // Edit_list
            // 
            this.Edit_list.Location = new System.Drawing.Point(186, 27);
            this.Edit_list.Name = "Edit_list";
            this.Edit_list.Size = new System.Drawing.Size(133, 39);
            this.Edit_list.TabIndex = 27;
            this.Edit_list.Text = "Edit list";
            this.Edit_list.UseVisualStyleBackColor = true;
            this.Edit_list.Click += new System.EventHandler(this.Edit_list_Click);
            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.container);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
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

        private void Add_to_list_Click(object sender, EventArgs e) {
            MovieCreate Movie_create = new MovieCreate();
            Movie_create.Show();
            this.Hide();
        }

        private void Edit_list_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieEdit editScreen = app.GetScreen<MovieEdit>("movieEdit");

            app.ShowScreen(editScreen);
        }

    }

}
