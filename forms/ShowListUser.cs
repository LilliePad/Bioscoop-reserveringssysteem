using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ShowListUser : BaseLayout {
        private ListView container;

        public ShowListUser() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "showListUser";
        }

        public override bool IsDefault() {
            return true;
        }

        public override bool RequireLogin() {
            return false;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            List<Show> shows = showService.GetShows();

            base.OnShow();
            container.Items.Clear();
            
            for (int i = 0; i < shows.Count; i++) {
                Show show = shows[i];
                ListViewItem item = new ListViewItem("Show id = " + show.id, i);
                item.Tag = show.id;
                container.Items.Add(item);
            }
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
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
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            this.container.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ShowListUser
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Name = "ShowListUser";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);

        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Shows", 500);
        }

        private void ButtonNew_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowCreate newScreen = app.GetScreen<ShowCreate>("showCreate");

            app.ShowScreen(newScreen);
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            MovieSelect movieSelect = app.GetScreen<MovieSelect>("movieSelect");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if(item == null) {
                MessageBox.Show("Error: Geen item geselecteerd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find the show
            int id = (int) item.Tag;
            Show show = showService.GetShowById(id);

            if(show == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            movieSelect.SetMovie(show.GetMovie());
            app.ShowScreen(movieSelect);
        }

        private void container_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }

}
