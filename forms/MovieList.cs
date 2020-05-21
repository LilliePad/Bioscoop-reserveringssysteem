using Project.Forms.Layouts;

namespace Project.Forms {

    public partial class MovieList : BaseLayout {

        public MovieList() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.SuspendLayout();

            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Name = "MovieList";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.ResumeLayout(false);
        }

        private void MovieList_Load(object sender, System.EventArgs e) {

        }

    }

}
