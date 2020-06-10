using System.Windows.Forms;
using System;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class MovieDetail : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private Label nameLabel;
        private Label nameValue;

        private Label descriptionLabel;
        private Label descriptionValue;

        private Label durationLabel;
        private Label durationValue;

        private Label genreLabel;
        private Label genreValue;

        private Label imageLabel;
        private PictureBox imagePreview;
        private Button cancelButton;
        private Button deleteButton;

        // Backend
        private Movie movie;

        public MovieDetail() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieDetail";
        }

        public override void OnShow() {
            base.OnShow();

            nameValue.Text = movie.name;
            descriptionValue.Text = movie.description;
            durationValue.Text = "" + movie.duration;
            genreValue.Text = movie.genre;
            imagePreview.ImageLocation = movie.image.location;
        }

        private void InitializeComponent() {
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.genreValue = new System.Windows.Forms.Label();
            this.durationValue = new System.Windows.Forms.Label();
            this.descriptionValue = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePreview
            // 
            this.imagePreview.Location = new System.Drawing.Point(704, 112);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(204, 268);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePreview.TabIndex = 2;
            this.imagePreview.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(221, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Film details";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameLabel.Location = new System.Drawing.Point(10, 82);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 17);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Film naam";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.descriptionLabel.Location = new System.Drawing.Point(10, 131);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(84, 17);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "Beschrijving";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.durationLabel.Location = new System.Drawing.Point(9, 360);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(62, 17);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "Speeltijd";
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.imageLabel.Location = new System.Drawing.Point(700, 82);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(75, 17);
            this.imageLabel.TabIndex = 11;
            this.imageLabel.Text = "Afbeelding";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genreLabel.Location = new System.Drawing.Point(10, 394);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(48, 17);
            this.genreLabel.TabIndex = 18;
            this.genreLabel.Text = "Genre";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.genreValue);
            this.panel.Controls.Add(this.durationValue);
            this.panel.Controls.Add(this.descriptionValue);
            this.panel.Controls.Add(this.nameValue);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.descriptionLabel);
            this.panel.Controls.Add(this.durationLabel);
            this.panel.Controls.Add(this.imageLabel);
            this.panel.Controls.Add(this.genreLabel);
            this.panel.Controls.Add(this.nameLabel);
            this.panel.Controls.Add(this.imagePreview);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 19;
            // 
            // genreValue
            // 
            this.genreValue.AutoSize = true;
            this.genreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genreValue.Location = new System.Drawing.Point(122, 394);
            this.genreValue.Name = "genreValue";
            this.genreValue.Size = new System.Drawing.Size(61, 17);
            this.genreValue.TabIndex = 24;
            this.genreValue.Text = "<genre>";
            // 
            // durationValue
            // 
            this.durationValue.AutoSize = true;
            this.durationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.durationValue.Location = new System.Drawing.Point(122, 360);
            this.durationValue.Name = "durationValue";
            this.durationValue.Size = new System.Drawing.Size(76, 17);
            this.durationValue.TabIndex = 23;
            this.durationValue.Text = "<duration>";
            // 
            // descriptionValue
            // 
            this.descriptionValue.AutoSize = true;
            this.descriptionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.descriptionValue.Location = new System.Drawing.Point(122, 131);
            this.descriptionValue.Name = "descriptionValue";
            this.descriptionValue.Size = new System.Drawing.Size(93, 17);
            this.descriptionValue.TabIndex = 22;
            this.descriptionValue.Text = "<description>";
            // 
            // nameValue
            // 
            this.nameValue.AutoSize = true;
            this.nameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameValue.Location = new System.Drawing.Point(122, 82);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(59, 17);
            this.nameValue.TabIndex = 21;
            this.nameValue.Text = "<name>";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(177, 449);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(13, 449);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 23);
            this.deleteButton.TabIndex = 25;
            this.deleteButton.Text = "Verwijderen";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MovieEdit
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel);
            this.Name = "MovieEdit";
            this.Controls.SetChildIndex(this.panel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");

            // Ask for confirmation
            if (!GuiHelper.ShowConfirm("Weet je zeker dat je deze film wilt verwijderen?")) {
                return;
            }

            // Delete room
            if (!movieService.DeleteMovie(movie)) {
                GuiHelper.ShowError("Kon film niet verwijderen");
                return;
            }

            // Redirect to screen
            MovieList movieList = app.GetScreen<MovieList>("movieList");

            app.ShowScreen(movieList);
            GuiHelper.ShowInfo("Film succesvol verwijderd");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

    }

}

