﻿using System;
using System.Windows.Forms;
using Project.Base;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public class MovieCreate : BaseLayout {

        private Panel panel;
        private Label title;

        private Label nameLabel;
        private TextBox nameInput;

        private Label descriptionLabel;
        private TextBox descriptionInput;

        private Label durationLabel;
        private NumericUpDown durationInput;

        private Label genreLabel;
        private TextBox genreInput;

        private Label imageLabel;
        private Button imageInput;
        private PictureBox imagePreview;

        private Button saveButton;
        private Button cancelButton;

        public MovieCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieCreate";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void OnShow() {
            base.OnShow();

            // Clear inputs
            nameInput.Text = "";
            descriptionInput.Text = "";
            genreInput.Text = "";
            durationInput.Value = 0;
            imagePreview.Image = null;
        }

        private void InitializeComponent() {
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.imageInput = new System.Windows.Forms.Button();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.descriptionInput = new System.Windows.Forms.TextBox();
            this.genreInput = new System.Windows.Forms.TextBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.durationInput = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationInput)).BeginInit();
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
            this.title.Size = new System.Drawing.Size(291, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Film aanmaken";
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
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(125, 472);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // imageInput
            // 
            this.imageInput.Location = new System.Drawing.Point(734, 386);
            this.imageInput.Name = "imageInput";
            this.imageInput.Size = new System.Drawing.Size(140, 23);
            this.imageInput.TabIndex = 13;
            this.imageInput.Text = "Zoek afbeelding";
            this.imageInput.UseVisualStyleBackColor = true;
            this.imageInput.Click += new System.EventHandler(this.ImageInput_Click);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(125, 82);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(495, 20);
            this.nameInput.TabIndex = 14;
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(125, 131);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(495, 206);
            this.descriptionInput.TabIndex = 15;
            // 
            // genreInput
            // 
            this.genreInput.Location = new System.Drawing.Point(125, 394);
            this.genreInput.Name = "genreInput";
            this.genreInput.Size = new System.Drawing.Size(495, 20);
            this.genreInput.TabIndex = 17;
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
            this.panel.Controls.Add(this.durationInput);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.descriptionLabel);
            this.panel.Controls.Add(this.durationLabel);
            this.panel.Controls.Add(this.imageLabel);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.imageInput);
            this.panel.Controls.Add(this.nameInput);
            this.panel.Controls.Add(this.descriptionInput);
            this.panel.Controls.Add(this.genreInput);
            this.panel.Controls.Add(this.genreLabel);
            this.panel.Controls.Add(this.nameLabel);
            this.panel.Controls.Add(this.imagePreview);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 19;
            // 
            // durationInput
            // 
            this.durationInput.Location = new System.Drawing.Point(125, 357);
            this.durationInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.durationInput.Name = "durationInput";
            this.durationInput.Size = new System.Drawing.Size(495, 20);
            this.durationInput.TabIndex = 21;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(290, 472);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MovieCreate
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel);
            this.Name = "MovieCreate";
            this.Controls.SetChildIndex(this.panel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationInput)).EndInit();
            this.ResumeLayout(false);

        }

        private void ImageInput_Click(object sender, EventArgs args) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*,*)|*,*";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    imagePreview.ImageLocation = dialog.FileName;
                }
            } catch (Exception e) {
                GuiHelper.ShowError("Error: " + e.Message);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");

            // Upload image
            StorageFile image = StorageHelper.UploadImage(imagePreview.ImageLocation);

            // Create and save movie
            Movie movie = new Movie(nameInput.Text, descriptionInput.Text, genreInput.Text, (int) durationInput.Value, image);

            if (!movieManager.SaveMovie(movie)) {
                GuiHelper.ShowError(ValidationHelper.GetErrorList(movie));
                return;
            }

            // Redirect to screen
            MovieDetail movieDetail = app.GetScreen<MovieDetail>("movieDetail");

            movieDetail.SetMovie(movie);
            app.ShowScreen(movieDetail);
            GuiHelper.ShowInfo("Film succesvol aangemaakt");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

    }

}

