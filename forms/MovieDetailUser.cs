using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using System.Linq;

namespace Project.Forms {

    public class MovieDetailUser : BaseLayout {

        private Panel panel;
        private Label title;

        private TableLayoutPanel container;
        internal TextBox descriptionInput;
        private Label durationLabel;
        private Label genreLabel;
        private PictureBox imagePreview;
        private Label voorstellingen;
        private Button cancelButton;
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
            durationLabel.Text = "Speeltijd     " + movie.duration + " Minuten";
            genreLabel.Text = "Genre         " + movie.genre;
            imagePreview.Image = movie.GetImage();

            // Clear grid
            container.Controls.Clear();
            container.RowStyles.Clear();
            container.ColumnStyles.Clear();

            // Prepare list
            int rowCount = 15;
            int columnCount = 5;

            container.ColumnCount = columnCount;
            container.RowCount = rowCount;

            for (int i = 0; i < columnCount; i++) {
                container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columnCount));
            }

            for (int i = 0; i < rowCount; i++) {
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rowCount));
            }

            // Build list
            List<Show> shows = showService.GetShowsByMovie(movie);
            List<Show> list = shows.Where(i => i.startTime > DateTime.Now).OrderBy(i => i.startTime).Take(rowCount * columnCount).ToList();

            int rowIndex = 0;
            int columnIndex = 0;

            foreach(Show show in list) {
                Button button = new Button();

                button.Text = show.startTime.ToString(Program.DATETIME_FORMAT);
                button.Name = "show" + show.id;
                button.BackColor = Color.FromArgb(193, 193, 193);
                button.Dock = DockStyle.Fill;

                button.Click += (sender, e) => {
                    ShowButton_Click(sender, e, button.Name);
                };

                container.Controls.Add(button, rowIndex, columnIndex);

                columnIndex += 1;

                if(columnIndex >= columnCount) {
                    columnIndex = 0;
                    rowIndex += 1;
                }
            }
        }
            
        private void InitializeComponent() {
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.voorstellingen = new System.Windows.Forms.Label();
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
            this.imagePreview.Location = new System.Drawing.Point(29, 47);
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
            this.title.Size = new System.Drawing.Size(61, 58);
            this.title.TabIndex = 3;
            this.title.Text = "C";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.voorstellingen);
            this.panel.Controls.Add(this.container);
            this.panel.Controls.Add(this.genreLabel);
            this.panel.Controls.Add(this.durationLabel);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.descriptionInput);
            this.panel.Controls.Add(this.imagePreview);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1600, 700);
            this.panel.TabIndex = 19;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(29, 419);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // voorstellingen
            // 
            this.voorstellingen.AutoSize = true;
            this.voorstellingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.voorstellingen.Location = new System.Drawing.Point(650, 0);
            this.voorstellingen.Name = "voorstellingen";
            this.voorstellingen.Size = new System.Drawing.Size(343, 58);
            this.voorstellingen.TabIndex = 21;
            this.voorstellingen.Text = "Voorstellingen";
            // 
            // container
            // 
            this.container.ColumnCount = 2;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Location = new System.Drawing.Point(660, 60);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Size = new System.Drawing.Size(800, 600);
            this.container.TabIndex = 20;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genreLabel.Location = new System.Drawing.Point(30, 320);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(0, 20);
            this.genreLabel.TabIndex = 19;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.durationLabel.Location = new System.Drawing.Point(30, 350);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(0, 20);
            this.durationLabel.TabIndex = 17;
            // 
            // descriptionInput
            // 
            this.descriptionInput.AcceptsReturn = true;
            this.descriptionInput.AcceptsTab = true;
            this.descriptionInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.descriptionInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionInput.ImeMode = System.Windows.Forms.ImeMode.On;
            this.descriptionInput.Location = new System.Drawing.Point(235, 67);
            this.descriptionInput.MaximumSize = new System.Drawing.Size(400, 250);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.ReadOnly = true;
            this.descriptionInput.Size = new System.Drawing.Size(400, 250);
            this.descriptionInput.TabIndex = 15;
            // 
            // MovieDetailUser
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel);
            this.Name = "MovieDetailUser";
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
            List<Show> list = shows.Where(i => i.startTime > DateTime.Now).OrderBy(i => i.startTime).ToList();
            Show show = list[int.Parse(showId)];
            reservationScreen.SetShow(show);
            app.ShowScreen(reservationScreen);
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieListUser movieListUser = app.GetScreen<MovieListUser>("movieListUser");
            app.ShowScreen(movieListUser);
        }

    }

}

