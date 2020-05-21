using Project.Forms.Layouts;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;
namespace Project.Forms {

    public partial class MovieList : BaseLayout {

        private System.Windows.Forms.ListView container;

        public MovieList() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.SuspendLayout();

            // 
            // Container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(40, 129);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(670, 499);
            this.container.TabIndex = 2;
            this.container.UseCompatibleStateImageBehavior = false;

            // 
            // MovieList
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.container);
            this.Name = "MovieList";
            this.Controls.SetChildIndex(this.container, 0);
            this.ResumeLayout(false);
        }

    }
}
