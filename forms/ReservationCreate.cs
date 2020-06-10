using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ReservationCreate : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private ListView container;

        private PictureBox imagePreview;
        private Button selectChairButton;
        private Button saveButton;

        // Backend
        private Show show;
        private Button cancelButton;
        private List<Chair> chairs = new List<Chair>();

        public ReservationCreate() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "reservationCreate";
        }

        public override void OnShow() {
            base.OnShow();

            // Update labels
            title.Text = show.GetMovie().name;
            imagePreview.Image = show.GetMovie().GetImage();

            // Update chair list
            container.Items.Clear();

            for (int i = 0; i < chairs.Count; i++) {
                Chair chair = chairs[i];
                ListViewItem item = new ListViewItem("Reserveer:  rij " + chair.row + " " + "nummer " + chair.number + "  prijs: €" + chair.price , i);

                item.Tag = "rij: " + chair.row + " " + "nummer: " + chair.number;
                container.Items.Add(item);
            }
        }

        private void InitializeComponent() {
            this.selectChairButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.ListView();
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectChairButton
            // 
            this.selectChairButton.Location = new System.Drawing.Point(273, 418);
            this.selectChairButton.Name = "selectChairButton";
            this.selectChairButton.Size = new System.Drawing.Size(140, 23);
            this.selectChairButton.TabIndex = 2;
            this.selectChairButton.Text = "Stoel kiezen";
            this.selectChairButton.UseVisualStyleBackColor = true;
            this.selectChairButton.Click += new System.EventHandler(this.SelectChairButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(0, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Reserveren";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // imagePreview
            // 
            this.imagePreview.Location = new System.Drawing.Point(10, 67);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(250, 350);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePreview.TabIndex = 4;
            this.imagePreview.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(466, 46);
            this.title.TabIndex = 6;
            this.title.Text = "Movie Name Placeholder";
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(273, 91);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(250, 300);
            this.container.TabIndex = 10;
            this.container.TabStop = false;
            this.container.TileSize = new System.Drawing.Size(40, 40);
            this.container.UseCompatibleStateImageBehavior = false;
            this.container.View = System.Windows.Forms.View.List;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.selectChairButton);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.imagePreview);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.container);
            this.panel.Location = new System.Drawing.Point(42, 118);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(163, 480);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ReservationCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 648);
            this.Controls.Add(this.panel);
            this.Name = "ReservationCreate";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.panel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        public void SetShow(Show show) {
            this.show = show;
            chairs.Clear();
        }

        private void SelectChairButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairSelect chairSelectScreen = app.GetScreen<ChairSelect>("chairSelect");

            chairSelectScreen.SetShow(show);
            app.ShowScreen(chairSelectScreen);
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            UserService userService = app.GetService<UserService>("users");

            // Calculate total price
            double totalPrice = 0;

            foreach (Chair chair in chairs) {
                totalPrice += chair.price;
            }

            // Ask for confirmation
            if(!GuiHelper.ShowConfirm("Het totaal bedrag is " + totalPrice + " euro. Wil je de reservering afronden?")) {
                return;
            }

            // Save reservations
            foreach (Chair chair in chairs) {
                Reservation reservation = new Reservation(show.id, userService.GetCurrentUser().id, chair.id);

                if (!reservationService.SaveReservation(reservation)) {
                    GuiHelper.ShowError(ValidationHelper.GetErrorList(reservation));
                }
            }

            // Redirect to screeen
            ReservationList reservationList = app.GetScreen<ReservationList>("reservationList");

            app.ShowScreen(reservationList);
            GuiHelper.ShowInfo("Reservering succesvol aangemaakt");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            MovieDetailUser movieDetailUser = app.GetScreen<MovieDetailUser>("movieDetailUser");

            movieDetailUser.SetMovie(show.GetMovie());
            app.ShowScreen(movieDetailUser);
        }

        public void AddChair(Chair chair) {
            chairs.Add(chair);
        }

        public bool ContainsChair(Chair chair) {
            return chairs.Where(i => i.id == chair.id).Any();
        }

    }
}
