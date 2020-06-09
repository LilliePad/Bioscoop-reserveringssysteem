using Project.Forms.Layouts;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Project.Base;
using Project.Models;
using Project.Services;
using System.Linq;
using Project.Helpers;
using Project;
using Project.Forms;


namespace Project.Forms {

    public class MovieSelect : BaseLayout {

        private System.Windows.Forms.Label Create_a_movie_text;
        private System.Windows.Forms.PictureBox pictureBox1;

        private string movieName;
        private string movieDiscription;
        private string movieGenre;
        private int maximum;
        private int movieDuration;
        private int currentShow;
        private Movie movie;
        private Panel panel1;
        private TextBox Discription_input;
        private Label genre;
        private Label playtime;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private StorageFile image;

        public MovieSelect() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "movieSelect";
        }

        public override bool RequireLogin() {
            return false;
        }

        public void SetMovie(Movie movie) {
            this.movie = movie;
        }

        public override void OnShow() {
            base.OnShow();
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");
            MovieService movieservice = app.GetService<MovieService>("movies");
            ShowService showService = app.GetService<ShowService>("shows");

       

            for (int i = 0; i < 50; i++) {
                DateTime date = DateTime.Now;
                Show show = new Show(1, 1, date.AddHours(i));
                if (!showService.SaveShow(show)) {
                    MessageBox.Show("Error: " + ValidationHelper.GetErrorList(show), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }




            }
            this.Create_a_movie_text.Text = movie.name;
            this.pictureBox1.Image = movie.GetImage();
            this.Discription_input.Text = movie.discription;
            this.genre.Text = "Genre = " + movie.genre;
            this.playtime.Text = "Speeltijd =" + movie.duration + " Minuten";


            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();


            List<Show> shows = showService.GetShowsByMovie(movie);
            List<Show> list = shows.Where(i => i.startTime > DateTime.Now).OrderBy(i => i.startTime).ToList();
            maximum = shows.Count;
            currentShow = 0;



            var rowCount = 10;
            var columnCount = 5;

            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.RowCount = rowCount;
            

           
            for (int i = 0; i < columnCount; i++) {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++) {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount; i++) {
                for (int j = 0; j < columnCount; j++) {
                    
                    try {
                        var button = new Button();
                        Show show = list[currentShow];
                        button.Text = string.Format(show.startTime.ToString("yyyy-MM-dd HH:mm"));
                        button.Name = string.Format(currentShow + "");
                        button.Dock = DockStyle.Fill;
                        button.Click += (sender, e) => { MyHandler(sender, e, button.Name); };
                        this.tableLayoutPanel1.Controls.Add(button, j, i);
                        currentShow += 1;
                    }
                    catch {
                        j = columnCount;
                    }
                    
                }
            }
        }
            
        
        private void InitializeComponent() {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.genre = new System.Windows.Forms.Label();
            this.playtime = new System.Windows.Forms.Label();
            this.Discription_input = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(7, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(61, 58);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "C";
            this.Create_a_movie_text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.genre);
            this.panel1.Controls.Add(this.playtime);
            this.panel1.Controls.Add(this.Create_a_movie_text);
            this.panel1.Controls.Add(this.Discription_input);
            this.panel1.Location = new System.Drawing.Point(40, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1800, 900);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(641, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 58);
            this.label1.TabIndex = 21;
            this.label1.Text = "Voorstellingen";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(650, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 395);
            this.tableLayoutPanel1.TabIndex = 20;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // genre
            // 
            this.genre.AutoSize = true;
            this.genre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.genre.Location = new System.Drawing.Point(17, 330);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(0, 20);
            this.genre.TabIndex = 19;
            // 
            // playtime
            // 
            this.playtime.AutoSize = true;
            this.playtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.playtime.Location = new System.Drawing.Point(17, 360);
            this.playtime.Name = "playtime";
            this.playtime.Size = new System.Drawing.Size(0, 20);
            this.playtime.TabIndex = 17;
            // 
            // Discription_input
            // 
            this.Discription_input.Location = new System.Drawing.Point(223, 66);
            this.Discription_input.Multiline = true;
            this.Discription_input.Name = "Discription_input";
            this.Discription_input.ReadOnly = true;
            this.Discription_input.Size = new System.Drawing.Size(400, 250);
            this.Discription_input.TabIndex = 15;
            this.Discription_input.TextChanged += new System.EventHandler(this.Discription_input_TextChanged);
            // 
            // MovieSelect
            // 
            this.ClientSize = new System.Drawing.Size(1360, 807);
            this.Controls.Add(this.panel1);
            this.Name = "MovieSelect";
            this.Load += new System.EventHandler(this.MovieCreate_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        void MyHandler(object sender, EventArgs e, string showId) {
            Program app = Program.GetInstance();
            ShowService showService = app.GetService<ShowService>("shows");
            ReservationCreate reservationScreen = app.GetScreen<ReservationCreate>("reservationCreate");

            List<Show> shows = showService.GetShowsByMovie(movie);
            Show show = shows[int.Parse(showId)];
            reservationScreen.GetShow(show);
            app.ShowScreen(reservationScreen);
        }

        private void Discription_input_TextChanged(object sender, EventArgs e) {
        movieDiscription = Discription_input.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void Create_a_movie_text_Click(object sender, EventArgs e) {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void pictureBox1_Click(object sender, System.EventArgs e) {

        }

        private void MovieCreate_Load(object sender, System.EventArgs e) {

        }
    }
}

