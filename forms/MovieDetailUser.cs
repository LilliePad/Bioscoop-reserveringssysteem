using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class MovieDetailUser : BaseLayout {

        private Panel panel;
        private Label title;

        private TableLayoutPanel container;

        private TextBox descriptionInput;
        private Label durationLabel;
        private Label genreLabel;
        private PictureBox imagePreview;

        private Movie movie;

        public MovieDetailUser() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieDetailUser";
        }

        public override bool RequireLogin() {
            return false;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");
            MovieService movieservice = app.GetService<MovieService>("movies");
            ShowService showService = app.GetService<ShowService>("shows");

            base.OnShow();

            title.Text = movie.name;
            descriptionInput.Text = movie.description;
            durationLabel.Text = "Speeltijd " + movie.duration + " Minuten";
            genreLabel.Text = "Genre " + movie.genre;
            imagePreview.Image = movie.GetImage();

            // Clear grid
            container.Controls.Clear();
            container.RowStyles.Clear();
            container.ColumnStyles.Clear();

            // Print shows
            List<Show> shows = showService.GetShowsByMovie(movie);
            int maximum = shows.Count;
            int rowCount = 5;
            int columnCount = 5;
            int showIndex = 0;

            container.ColumnCount = 5;
            container.RowCount = rowCount;

            for (int i = 0; i < columnCount; i++) {
                container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columnCount));
            }

            for (int i = 0; i < rowCount; i++) {
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount && showIndex < shows.Count; i++) {
                for (int j = 0; j < columnCount && showIndex < shows.Count; j++) {
                    Button button = new Button();
                    Show show = shows[showIndex];

                    button.Text = show.startTime.ToString(Program.DATETIME_FORMAT);
                    button.Name = "" + showIndex;
                    button.Dock = DockStyle.Fill;

                    button.Click += (sender, e) => {
                        ShowButton_Click(sender, e, button.Name);
                    };

                    container.Controls.Add(button, j, i);
                    showIndex += 1;
                }
            }
        }
            
        private void InitializeComponent() {
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.genreLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.descriptionInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePreview
            // 
            this.imagePreview.Location = new System.Drawing.Point(29, 39);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(200, 270);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePreview.TabIndex = 2;
            this.imagePreview.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(28, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(49, 46);
            this.title.TabIndex = 3;
            this.title.Text = "C";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.container);
            this.panel.Controls.Add(this.genreLabel);
            this.panel.Controls.Add(this.durationLabel);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.descriptionInput);
            this.panel.Controls.Add(this.imagePreview);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 700);
            this.panel.TabIndex = 19;
            // 
            // container
            // 
            this.container.ColumnCount = 2;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Location = new System.Drawing.Point(29, 302);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Size = new System.Drawing.Size(950, 395);
            this.container.TabIndex = 20;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genreLabel.Location = new System.Drawing.Point(660, 103);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(0, 17);
            this.genreLabel.TabIndex = 19;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.durationLabel.Location = new System.Drawing.Point(660, 55);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(0, 17);
            this.durationLabel.TabIndex = 17;
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(235, 48);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.ReadOnly = true;
            this.descriptionInput.Size = new System.Drawing.Size(400, 250);
            this.descriptionInput.TabIndex = 15;
            // 
            // MovieSelect
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel);
            this.Name = "MovieSelect";
            this.Controls.SetChildIndex(this.panel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }

        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

        void ShowButton_Click(object sender, EventArgs e, string showId) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            ReservationCreate reservationScreen = app.GetScreen<ReservationCreate>("reservationCreate");

            // Get show and redirect to screen
            List<Show> shows = showService.GetShowsByMovie(movie);
            Show show = shows[int.Parse(showId)];

            reservationScreen.SetShow(show);
            app.ShowScreen(reservationScreen);
        }

    }

}

