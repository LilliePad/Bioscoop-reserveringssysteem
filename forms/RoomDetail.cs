using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;


namespace Project.Forms {

    public class RoomDetail : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;
        private Label subTitle;

        private TableLayoutPanel container;

        private Button deleteButton;
        private Button cancelButton;
        
        // Backend
        private Room room;

        public RoomDetail() {
            InitializeComponent();
        }


        public override string GetHandle() {
            return "roomDetail";
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");

            base.OnShow();
            subTitle.Text = "Zaal " + room.number;

            container.Controls.Clear();
            container.RowStyles.Clear();
            container.ColumnStyles.Clear();

            // Create grid
            List<Chair> chairs = chairService.GetChairsByRoom(room);

            int maximum = chairs.Count;
            int highestRow = 0;
            int highestColumn = 0;

            for (int x = 1; x < maximum; x++) {
                if (highestRow < chairs[x].row) {
                    highestRow = chairs[x].row;
                }

                if (highestColumn < chairs[x].number) {
                    highestColumn = chairs[x].number;
                }
            }

            container.ColumnCount = highestColumn;
            container.RowCount = highestRow;

            for (int i = 0; i < highestColumn; i++) {
                container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / highestColumn));
            }

            for (int i = 0; i < highestRow; i++) {
                container.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / highestRow));
            }

            for (int i = 0; i < highestRow; i++) {
                for (int j = 0; j < highestColumn; j++) {
                    Button button = new Button();
                    bool taken = chairService.GetChairByRoomAndPosition(room, i + 1, j + 1) != null;

                    button.Text = string.Format(taken ? "{0}-{1}" : "Leeg", i + 1, j + 1);
                    button.Name = string.Format("button" + (i + 1) + "-" + (j + 1));
                    button.Dock = DockStyle.Fill;

                    button.Click += (sender, e) => {
                        ChairButton_Click(sender, e, button.Name);
                    };

                    container.Controls.Add(button, j, i);
                }
            }
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.subTitle = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.container);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.subTitle);
            this.panel.Location = new System.Drawing.Point(40, 115);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1800, 1000);
            this.panel.TabIndex = 20;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(192, 662);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Annuleer";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(20, 662);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 23);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "Zaal verwijderen";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
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
            this.container.TabIndex = 23;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(-10, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(248, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Bewerk zaal ";
            // 
            // subTitle
            // 
            this.subTitle.AutoSize = true;
            this.subTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.subTitle.Location = new System.Drawing.Point(21, 82);
            this.subTitle.Name = "subTitle";
            this.subTitle.Size = new System.Drawing.Size(40, 17);
            this.subTitle.TabIndex = 4;
            this.subTitle.Text = "Zaal ";
            // 
            // RoomEdit
            // 
            this.ClientSize = new System.Drawing.Size(1262, 857);
            this.Controls.Add(this.panel);
            this.Name = "RoomEdit";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
        }

        public void SetRoom(Room room) {
            this.room = room;
        }

        void ChairButton_Click(object sender, EventArgs e, string buttonString) {
            Program app = Program.GetInstance();
            
            string[] parts = buttonString.Replace("button", "").Split('-');
            int row = ValidationHelper.ParseInt(parts[0]);
            int column = ValidationHelper.ParseInt(parts[1]);

            // Redirect to screen
            ChairEdit editScreen = app.GetScreen<ChairEdit>("chairEdit");

            editScreen.SetChairInfo(room, row, column);
            app.ShowScreen(editScreen);
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");

            // Delete room
            if(!roomService.DeleteRoom(room)) {
                GuiHelper.ShowError("Kon zaal niet verwijderen");
                return;
            }

            // Redirect to screen
            RoomList newScreen = app.GetScreen<RoomList>("roomList");

            app.ShowScreen(newScreen);
            GuiHelper.ShowInfo("Zaal succesvol verwijderd");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomList editScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(editScreen);
        }

    }

}
            

 