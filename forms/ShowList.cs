using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ShowList : BaseLayout {

        private ListView container;
        private Button movieCreateButton;

        public ShowList() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "showList";
        }

  

        public override void OnShow() {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            RoomService roomService = app.GetService<RoomService>("rooms");
            MovieService movieService = app.GetService<MovieService>("movies");
            List<Show> shows = showService.GetShows();

            base.OnShow();
            container.Items.Clear();
            
            for (int i = 0; i < shows.Count; i++) {
                Show show = shows[i];
                ListViewItem item = new ListViewItem("voorstelling id = " + show.id + ", zaal nummer = " + roomService.GetRoomById(show.roomId).number , i);
                item.Tag = show.id;
                container.Items.Add(item);
            }
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
            this.container.SelectedIndexChanged += new System.EventHandler(this.container_SelectedIndexChanged);
            this.container.Click += new System.EventHandler(this.ButtonEdit_Click);
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
            // RoomList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.movieCreateButton);
            this.Controls.Add(this.container);
            this.Name = "RoomList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.container, 0);
            this.Controls.SetChildIndex(this.movieCreateButton, 0);
            this.ResumeLayout(false);

        }

        private void MovieList_Load(object sender, System.EventArgs e) {
            container.View = View.Details;
            container.Columns.Add("Shows", 100);
        }

        private void ButtonNew_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowCreate newScreen = app.GetScreen<ShowCreate>("showCreate");

            app.ShowScreen(newScreen);
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            ShowDelete editScreen = app.GetScreen<ShowDelete>("showDelete");

            // Get the clicked item
            ListViewItem item = container.SelectedItems[0];

            if(item == null) {
                MessageBox.Show("Error: Geen item geselecteerd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find the movie
            int id = (int) item.Tag;
            Show show = showService.GetShowById(id);

            if(show == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            editScreen.SetShow(show);
            app.ShowScreen(editScreen);
        }

        private void container_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }

}
