using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;


namespace Project.Forms {

    public class ShowCreate : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private Label movieLabel;
        private ComboBox movieInput;

        private Label roomLabel;
        private ComboBox roomInput;

        private Label datetimeLabel;
        private DateTimePicker datetimeInput;

        private Button saveButton;
        private Button cancelButton;

        public ShowCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "showCreate";
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            RoomService roomService = app.GetService<RoomService>("rooms");
            List<Movie> movies = movieService.GetMovies();
            List<Room> rooms = roomService.GetRooms();

            base.OnShow();

            movieInput.Items.Clear();
            roomInput.Items.Clear();

            movieInput.Items.AddRange(movies.ToArray());
            roomInput.Items.AddRange(rooms.ToArray());
        }
        private void InitializeComponent() {
            this.title = new System.Windows.Forms.Label();
            this.movieLabel = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.movieInput = new System.Windows.Forms.ComboBox();
            this.roomInput = new System.Windows.Forms.ComboBox();
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.datetimeInput = new System.Windows.Forms.DateTimePicker();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(426, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Voorstelling aanmaken";
            // 
            // movieLabel
            // 
            this.movieLabel.AutoSize = true;
            this.movieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.movieLabel.Location = new System.Drawing.Point(10, 82);
            this.movieLabel.Name = "movieLabel";
            this.movieLabel.Size = new System.Drawing.Size(33, 17);
            this.movieLabel.TabIndex = 4;
            this.movieLabel.Text = "Film";
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.roomLabel.Location = new System.Drawing.Point(10, 131);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(36, 17);
            this.roomLabel.TabIndex = 5;
            this.roomLabel.Text = "Zaal";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(125, 230);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(170, 39);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.movieInput);
            this.panel.Controls.Add(this.roomInput);
            this.panel.Controls.Add(this.datetimeLabel);
            this.panel.Controls.Add(this.datetimeInput);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.roomLabel);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.movieLabel);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 19;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(308, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(170, 39);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // movieInput
            // 
            this.movieInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.movieInput.FormattingEnabled = true;
            this.movieInput.Location = new System.Drawing.Point(125, 82);
            this.movieInput.Name = "movieInput";
            this.movieInput.Size = new System.Drawing.Size(495, 21);
            this.movieInput.TabIndex = 21;
            // 
            // roomInput
            // 
            this.roomInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomInput.FormattingEnabled = true;
            this.roomInput.Location = new System.Drawing.Point(125, 131);
            this.roomInput.Name = "roomInput";
            this.roomInput.Size = new System.Drawing.Size(495, 21);
            this.roomInput.TabIndex = 20;
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.datetimeLabel.Location = new System.Drawing.Point(11, 175);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(91, 17);
            this.datetimeLabel.TabIndex = 16;
            this.datetimeLabel.Text = "Datum en tijd";
            // 
            // datetimeInput
            // 
            this.datetimeInput.CustomFormat = Program.DATETIME_FORMAT;
            this.datetimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeInput.Location = new System.Drawing.Point(125, 173);
            this.datetimeInput.MinDate = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
            this.datetimeInput.Name = "datetimeInput";
            this.datetimeInput.Size = new System.Drawing.Size(400, 20);
            this.datetimeInput.TabIndex = 15;
            this.datetimeInput.Value = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
            // 
            // ShowCreate
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel);
            this.Name = "ShowCreate";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void SaveButton_Click(object sender, System.EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            RoomService roomService = app.GetService<RoomService>("rooms");
            ShowService showService = app.GetService<ShowService>("shows");

            // Parse values
            Movie movie = (Movie) movieInput.SelectedItem;
            Room room = (Room) roomInput.SelectedItem;

            if(movie == null) {
                GuiHelper.ShowError("Je moet een film kiezen");
                return;
            }

            if (room == null) {
                GuiHelper.ShowError("Je moet een zaal kiezen");
                return;
            }

            // Create and save show
            Show show = new Show(movie.id, room.id, datetimeInput.Value);

            if (!showService.SaveShow(show)) {
                GuiHelper.ShowError(ValidationHelper.GetErrorList(show));
                return;
            }

            // Redirect to screen
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowList editScreen = app.GetScreen<ShowList>("showList");
            app.ShowScreen(editScreen);
        }

    }

}

