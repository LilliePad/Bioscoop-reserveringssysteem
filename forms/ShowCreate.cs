using Project.Forms.Layouts;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using Project.Helpers;
using System.Collections.Generic;


namespace Project.Forms {

    public class ShowCreate : BaseLayout {

        private System.Windows.Forms.Label Create_a_show_text;
        private System.Windows.Forms.Label Name_text;
        private System.Windows.Forms.Label Room_text;
        private System.Windows.Forms.Button Show_create_button;

        
        
        private int movieId;
        private int roomNumber;
        private double hours;
        private DateTime date;
        private Panel panel1;
        private Label Datum_text;
        private DateTimePicker dateTimePicker1;
        private ComboBox MovieComboBox2;
        private ComboBox RoomComboBox;
        private List<Room> rooms;
        private List<Movie> movies;


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

            for (int i = 0; i < movies.Count; i++) {
                this.MovieComboBox2.Items.AddRange(new object[]{movies[i].name});
            }
            
            for (int i = 0; i < rooms.Count; i++) {
                this.RoomComboBox.Items.AddRange(new object[] { rooms[i].number });
            }
        }
        private void InitializeComponent() {
            this.Create_a_show_text = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.Room_text = new System.Windows.Forms.Label();
            this.Show_create_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MovieComboBox2 = new System.Windows.Forms.ComboBox();
            this.RoomComboBox = new System.Windows.Forms.ComboBox();
            this.Datum_text = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Create_a_show_text
            // 
            this.Create_a_show_text.AutoSize = true;
            this.Create_a_show_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_show_text.Location = new System.Drawing.Point(3, 0);
            this.Create_a_show_text.Name = "Create_a_show_text";
            this.Create_a_show_text.Size = new System.Drawing.Size(355, 58);
            this.Create_a_show_text.TabIndex = 3;
            this.Create_a_show_text.Text = "Create a Show";
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(41, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Film";
            this.Name_text.Click += new System.EventHandler(this.label2_Click);
            // 
            // Room_text
            // 
            this.Room_text.AutoSize = true;
            this.Room_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Room_text.Location = new System.Drawing.Point(10, 131);
            this.Room_text.Name = "Room_text";
            this.Room_text.Size = new System.Drawing.Size(40, 20);
            this.Room_text.TabIndex = 5;
            this.Room_text.Text = "Zaal";
            // 
            // Show_create_button
            // 
            this.Show_create_button.Location = new System.Drawing.Point(125, 230);
            this.Show_create_button.Name = "Show_create_button";
            this.Show_create_button.Size = new System.Drawing.Size(133, 39);
            this.Show_create_button.TabIndex = 12;
            this.Show_create_button.Text = "Create Show";
            this.Show_create_button.UseVisualStyleBackColor = true;
            this.Show_create_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MovieComboBox2);
            this.panel1.Controls.Add(this.RoomComboBox);
            this.panel1.Controls.Add(this.Datum_text);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.Create_a_show_text);
            this.panel1.Controls.Add(this.Room_text);
            this.panel1.Controls.Add(this.Show_create_button);
            this.panel1.Controls.Add(this.Name_text);
            this.panel1.Location = new System.Drawing.Point(40, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 534);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MovieComboBox2
            // 
            this.MovieComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MovieComboBox2.FormattingEnabled = true;
            this.MovieComboBox2.Location = new System.Drawing.Point(125, 82);
            this.MovieComboBox2.Name = "MovieComboBox2";
            this.MovieComboBox2.Size = new System.Drawing.Size(495, 24);
            this.MovieComboBox2.TabIndex = 21;
            this.MovieComboBox2.SelectedIndexChanged += new System.EventHandler(this.MovieComboBox2_SelectedIndexChanged);
            // 
            // RoomComboBox
            // 
            this.RoomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoomComboBox.FormattingEnabled = true;
            this.RoomComboBox.Location = new System.Drawing.Point(125, 131);
            this.RoomComboBox.Name = "RoomComboBox";
            this.RoomComboBox.Size = new System.Drawing.Size(495, 24);
            this.RoomComboBox.TabIndex = 20;
            this.RoomComboBox.SelectedIndexChanged += new System.EventHandler(this.RoomComboBox_SelectedIndexChanged);
            // 
            // Datum_text
            // 
            this.Datum_text.AutoSize = true;
            this.Datum_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Datum_text.Location = new System.Drawing.Point(11, 175);
            this.Datum_text.Name = "Datum_text";
            this.Datum_text.Size = new System.Drawing.Size(109, 20);
            this.Datum_text.TabIndex = 16;
            this.Datum_text.Text = "Datum en tijd";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(125, 173);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(400, 22);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.Value = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ShowCreate
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel1);
            this.Name = "ShowCreate";
            this.Load += new System.EventHandler(this.MovieCreate_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {

        }

        private void label2_Click(object sender, System.EventArgs e) {

        }

        private void MovieCreate_Load(object sender, System.EventArgs e) {

        }

        private void richTextBox3_TextChanged(object sender, System.EventArgs e) {

        }

        private void label5_Click(object sender, System.EventArgs e) {

        }


        private void button1_Click(object sender, System.EventArgs e) {

            Program app = Program.GetInstance();
            MovieService movieService = app.GetService<MovieService>("movies");
            RoomService roomService = app.GetService<RoomService>("rooms");
            ShowService showService = app.GetService<ShowService>("shows");
          

            List<Movie> movies = movieService.GetMovies();
            List<Room> rooms = roomService.GetRooms();
            date = date.AddHours(hours);
            Show show = new Show(movies[movieId].id , rooms[roomNumber].id, date);

            if (!showService.SaveShow(show)) {
                MessageBox.Show("Error: " + ValidationHelper.GetErrorList(show), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Go back to list view
            MovieList listScreen = app.GetScreen<MovieList>("movieList");
            app.ShowScreen(listScreen);
        }

        private void label4_Click(object sender, EventArgs e) {

        }




        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void MovieComboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            movieId = MovieComboBox2.SelectedIndex;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            date = dateTimePicker1.Value;
        }

        private void Time_TextChanged(object sender, EventArgs e) {
            
        }

        private void RoomComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                roomNumber = RoomComboBox.SelectedIndex;

            }
            catch (FormatException) {                      
                 MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);             
            }
        }
    }

}

