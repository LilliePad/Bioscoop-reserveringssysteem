using System;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ShowDetail : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private Label movieLabel;
        private Label movieValue;

        private Label roomLabel;
        private Label roomValue;

        private Label datetimeLabel;
        private Label datetimeValue;

        private Button deleteButton;
        private Button cancelButton;

        // Backend
        private Show show;

        public ShowDetail() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "showDetail";
        }

        public override void OnShow() {
            base.OnShow();

            movieValue.Text = show.GetMovie().name;
            roomValue.Text = "Number: " + show.GetRoom().number;
            datetimeValue.Text = show.startTime.ToString(Program.DATETIME_FORMAT);
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.movieLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.movieValue = new System.Windows.Forms.Label();
            this.roomValue = new System.Windows.Forms.Label();
            this.datetimeValue = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.datetimeValue);
            this.panel.Controls.Add(this.roomValue);
            this.panel.Controls.Add(this.movieValue);
            this.panel.Controls.Add(this.datetimeLabel);
            this.panel.Controls.Add(this.roomLabel);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.movieLabel);
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.title);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 20;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(183, 268);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // movieLabel
            // 
            this.movieLabel.AutoEllipsis = true;
            this.movieLabel.AutoSize = true;
            this.movieLabel.BackColor = System.Drawing.SystemColors.Control;
            this.movieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.movieLabel.Location = new System.Drawing.Point(15, 89);
            this.movieLabel.Name = "movieLabel";
            this.movieLabel.Size = new System.Drawing.Size(38, 20);
            this.movieLabel.TabIndex = 22;
            this.movieLabel.Text = "Film";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(13, 268);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 23);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Verwijderen";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(-1, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(347, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Voorsteling details";
            // 
            // roomLabel
            // 
            this.roomLabel.AutoEllipsis = true;
            this.roomLabel.AutoSize = true;
            this.roomLabel.BackColor = System.Drawing.SystemColors.Control;
            this.roomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roomLabel.Location = new System.Drawing.Point(15, 138);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(40, 20);
            this.roomLabel.TabIndex = 24;
            this.roomLabel.Text = "Zaal";
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.AutoEllipsis = true;
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.datetimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datetimeLabel.Location = new System.Drawing.Point(15, 189);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(103, 20);
            this.datetimeLabel.TabIndex = 25;
            this.datetimeLabel.Text = "Datum en tijd";
            // 
            // movieValue
            // 
            this.movieValue.AutoEllipsis = true;
            this.movieValue.AutoSize = true;
            this.movieValue.BackColor = System.Drawing.SystemColors.Control;
            this.movieValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.movieValue.Location = new System.Drawing.Point(179, 91);
            this.movieValue.Name = "movieValue";
            this.movieValue.Size = new System.Drawing.Size(68, 20);
            this.movieValue.TabIndex = 26;
            this.movieValue.Text = "<movie>";
            // 
            // roomValue
            // 
            this.roomValue.AutoEllipsis = true;
            this.roomValue.AutoSize = true;
            this.roomValue.BackColor = System.Drawing.SystemColors.Control;
            this.roomValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.roomValue.Location = new System.Drawing.Point(179, 138);
            this.roomValue.Name = "roomValue";
            this.roomValue.Size = new System.Drawing.Size(63, 20);
            this.roomValue.TabIndex = 27;
            this.roomValue.Text = "<room>";
            // 
            // datetimeValue
            // 
            this.datetimeValue.AutoEllipsis = true;
            this.datetimeValue.AutoSize = true;
            this.datetimeValue.BackColor = System.Drawing.SystemColors.Control;
            this.datetimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datetimeValue.Location = new System.Drawing.Point(179, 189);
            this.datetimeValue.Name = "datetimeValue";
            this.datetimeValue.Size = new System.Drawing.Size(89, 20);
            this.datetimeValue.TabIndex = 28;
            this.datetimeValue.Text = "<datetime>";
            // 
            // ShowDetail
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel);
            this.Name = "ShowDetail";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetShow(Show show) {
            this.show = show;
        }

        private void DeleteButton_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ShowService showManager = app.GetService<ShowService>("shows");
       
            // Delete show
            if(!showManager.DeleteShow(show)) {
                GuiHelper.ShowError("Kon voorstelling niet verwijderen");
                return;
            }
            
            ShowList newScreen = app.GetScreen<ShowList>("showList");

            app.ShowScreen(newScreen);
            GuiHelper.ShowInfo("Voorstelling succesvol verwijderd");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ShowList editScreen = app.GetScreen<ShowList>("showList");
            app.ShowScreen(editScreen);
        }

    }

}