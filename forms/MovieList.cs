using Project.Forms.Layouts;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
namespace Project.Forms {

    public partial class MovieList : BaseLayout {
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.LinkLabel Movie1;

        public MovieList() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieList));
            this.Movie1 = new System.Windows.Forms.LinkLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // Movie1
            // 
            this.Movie1.AutoSize = true;
            this.Movie1.Location = new System.Drawing.Point(59, 169);
            this.Movie1.Name = "Movie1";
            this.Movie1.Size = new System.Drawing.Size(0, 13);
            this.Movie1.TabIndex = 2;
            this.Movie1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(40, 106);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1193, 486);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Movie.jpg");
            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Movie1);
            this.Controls.Add(this.listView1);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.Movie1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
      
        }

        private void MovieList_Load(object sender, System.EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e) {
            Program app = Program.GetInstance();
            MovieService movieManager = app.GetService<MovieService>("movies");
            
        }
    }
}
