using Project.Forms.Layouts;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Project.Models;
using Project.Services;
using System.Linq;

namespace Project.Forms {

    public class MovieSelect : BaseLayout {

        private Panel panel;
        private Label title;

        private TableLayoutPanel container;

        private TextBox descriptionInput;
        private Label durationLabel;
        private Label genreLabel;
        private PictureBox imagePreview;
        private Label label1;
        private Movie movie;

        public MovieSelect() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieSelect";
        }

        public override bool RequireLogin() {
            return false;
        }

        public override void OnShow() {
            base.OnShow();
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");
            MovieService movieservice = app.GetService<MovieService>("movies");
            ShowService showService = app.GetService<ShowService>("shows");

            title.Text = movie.name;
            descriptionInput.Text = movie.description;
            durationLabel.Text = "Speeltijd =" + movie.duration + " Minuten";
            genreLabel.Text = "Genre = " + movie.genre;
            imagePreview.Image = movie.GetImage();

            // Clear grid
            container.Controls.Clear();
            container.RowStyles.Clear();
            container.ColumnStyles.Clear();

            // Print shows
            List<Show> shows = showService.GetShowsByMovie(movie);
            List<Show> list = shows.Where(i => i.startTime > DateTime.Now).OrderBy(i => i.startTime).ToList();
            int maximum = list.Count;
            int rowCount = 15;
            int columnCount = 5;
            int showIndex = 0;

            container.ColumnCount = columnCount;
            container.RowCount = rowCount;

            for (int i = 0; i < columnCount; i++) {
                container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columnCount));
            }

            for (int i = 0; i < rowCount; i++) {
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount && showIndex < list.Count; i++) {
                for (int j = 0; j < columnCount && showIndex < list.Count; j++) {
                    Button button = new Button();
                    Show show = list[showIndex];

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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePreview
            // 
            this.imagePreview.Location = new System.Drawing.Point(13, 48);
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
            this.title.Location = new System.Drawing.Point(3, -3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(61, 58);
            this.title.TabIndex = 3;
            this.title.Text = "C";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label1);
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
            // container
            // 
            this.container.ColumnCount = 2;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Location = new System.Drawing.Point(650, 60);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Size = new System.Drawing.Size(825, 600);
            this.container.TabIndex = 20;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genreLabel.Location = new System.Drawing.Point(17, 345);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(0, 20);
            this.genreLabel.TabIndex = 19;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.durationLabel.Location = new System.Drawing.Point(17, 325);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(0, 20);
            this.durationLabel.TabIndex = 17;
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(232, 60);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.ReadOnly = true;
            this.descriptionInput.Size = new System.Drawing.Size(400, 250);
            this.descriptionInput.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(630, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 58);
            this.label1.TabIndex = 21;
            this.label1.Text = "Voorstellingen";
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
            List<Show> list = shows.Where(i => i.startTime > DateTime.Now).OrderBy(i => i.startTime).ToList();
            Show show = list[int.Parse(showId)];

            reservationScreen.SetShow(show);
            app.ShowScreen(reservationScreen);
        }


    }
}

