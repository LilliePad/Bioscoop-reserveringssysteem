using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;
using System.Drawing;


namespace Project.Forms {

    public class ChairSelect : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private TableLayoutPanel container;

        // Backend
        private Show show;

        public ChairSelect() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "chairSelect";
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            ReservationCreate reservationCreate = app.GetScreen<ReservationCreate>("reservationCreate");

            base.OnShow();

            container.Controls.Clear();
            container.RowStyles.Clear();
            container.ColumnStyles.Clear();

            // Get chairs and room size
            List<Chair> chairs = chairService.GetChairsByRoom(show.GetRoom());

            int Maximum = chairs.Count;
            int highestRow = 0;
            int highestColum = 0;

            for (int x = 1; x < Maximum; x++) {
                if (highestRow < chairs[x].row) {
                    highestRow = chairs[x].row;
                }

                if (highestColum < chairs[x].number) {
                    highestColum = chairs[x].number;
                }
            }

            container.ColumnCount = highestColum;
            container.RowCount = highestRow;

            for (int i = 0; i < highestColum; i++) {
                container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / highestColum));
            }

            for (int i = 0; i < highestRow; i++) {
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / highestRow));
            }

            for (int i = 0; i < highestRow; i++) {
                for (int j = 0; j < highestColum; j++) {
                    Chair chair = chairService.GetChairByRoomAndPosition(show.GetRoom(), i + 1, j + 1);

                    // Ignore if chair doesn't exist
                    if (chair == null) {
                        continue;
                    }

                    if (reservationService.IsChairTaken(chair, show) || reservationCreate.ContainsChair(chair)) {
                        Button button = new Button();

                        button.Text = string.Format("Niet beschikbaar");
                        button.BackColor = Color.Red; 
                        button.Name = string.Format("button" + (i + 1) + "-" + (j + 1));
                        
                        button.Dock = DockStyle.Fill;

                        button.Click += (sender, e) => {
                            ChairButton_Click(sender, e, button.Name);
                        };

                        container.Controls.Add(button, j, i);
                    } else {
                        Button button = new Button();

                        button.Text = string.Format("R" + i + "-N" + j + " prijs: " + chair.price);
                        button.BackColor = Color.Green;
                        button.Name = string.Format("button" + (i + 1) + "-" + (j + 1));
                        button.Dock = DockStyle.Fill;

                        button.Click += (sender, e) => {
                            ChairButton_Click(sender, e, button.Name);
                        };

                        container.Controls.Add(button, j, i);
                    }
                }
            }
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.container);
            this.panel.Controls.Add(this.title);
            this.panel.Location = new System.Drawing.Point(40, 115);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1800, 1000);
            this.panel.TabIndex = 20;
            // 
            // container
            // 
            this.container.ColumnCount = 2;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Location = new System.Drawing.Point(20, 134);
            this.container.Name = "container";
            this.container.RowCount = 2;
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.container.Size = new System.Drawing.Size(1000, 500);
            this.container.TabIndex = 30;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(-6, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(270, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Kies een stoel";
            // 
            // ChairSelect
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel);
            this.Name = "ChairSelect";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }

        public void SetShow(Show show) {
            this.show = show;
        }

        void ChairButton_Click(object sender, EventArgs e, string buttonString) {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            ReservationService reservationService = app.GetService<ReservationService>("reservations");
            ReservationCreate reservationScreen = app.GetScreen<ReservationCreate>("reservationCreate");

            // Parse button data
            string[] parts = buttonString.Replace("button", "").Split('-');
            int row = ValidationHelper.ParseInt(parts[0]);
            int col = ValidationHelper.ParseInt(parts[1]);

            // Get chair
            Chair chair = chairService.GetChairByRoomAndPosition(show.GetRoom(), row, col);

            if (reservationService.IsChairTaken(chair, show) || reservationScreen.ContainsChair(chair)) {
                GuiHelper.ShowError("Deze stoel is niet beschikbaar");
                return;
            }

            reservationScreen.AddChair(chair);

            // Redirect to screen
            app.ShowScreen(reservationScreen);
        }

    }

}


