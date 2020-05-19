using System.Windows.Forms;

namespace Project.Forms {

    public partial class MovieList : Form {

        private int number = 0;
        private Label testText;

        public MovieList() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            testText = new System.Windows.Forms.Label();
            SuspendLayout();

            testText.AutoSize = true;
            testText.Location = new System.Drawing.Point(856, 373);
            testText.Name = "label1";
            testText.Size = new System.Drawing.Size(64, 25);
            testText.TabIndex = 0;
            testText.Text = "label1";
            testText.Click += new System.EventHandler(this.label1_Click);

            ClientSize = new System.Drawing.Size(1939, 1024);
            Controls.Add(testText);
            Name = "MovieList";
            ResumeLayout(false);
            PerformLayout();

        }

        private void label1_Click(object sender, System.EventArgs e) {
            number += 1;
            testText.Text = "Clicked: " + number;
        }

    }

}
