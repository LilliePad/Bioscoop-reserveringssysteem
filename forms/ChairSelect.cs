using Project.Forms.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Models;
using Project.Services;
using Project.Helpers;
using System.Drawing.Text;


namespace Project.Forms {
    public partial class ChairSelect : BaseLayout {
        private Panel roomSelect;
        private Label Chose_Chair_Text;
        private Label label2;
        private ListView container;
        private Show show;



        private int RoomNumber;
        private int Maximum;
        private int HighestColum;
        private int HighestRow;
        private TableLayoutPanel tableLayoutPanel1;
        private Room room;
        public ChairSelect() {
            InitializeComponent();
        }


        public override string GetHandle() {
            return "chairSelect";
        }

        public void SetRoom(Room room) {
            this.room = room;
        }
        public void SetShow(Show show) {
            this.show = show;
        }


        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");

            base.OnShow();
            

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            try {
                RoomNumber = room.number;
                chairService.GetChairsByRoom(roomService.GetRoomByNumber(RoomNumber));
            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            List<Chair> chairs = chairService.GetChairsByRoom(roomService.GetRoomByNumber(RoomNumber));
            Maximum = chairs.Count;
            HighestRow = 0;
            HighestColum = 0;
            for (int x = 1; x < Maximum; x++) {
                if (HighestRow < chairs[x].row) {
                    HighestRow = chairs[x].row;
                }
                if (HighestColum < chairs[x].number) {
                    HighestColum = chairs[x].number;
                }

            }

            var rowCount = HighestRow;
            var columnCount = HighestColum;

            this.tableLayoutPanel1.ColumnCount = HighestColum;
            this.tableLayoutPanel1.RowCount = HighestRow;






            for (int i = 0; i < columnCount; i++) {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++) {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount; i++) {
                for (int j = 0; j < columnCount; j++) {
                    Chair chair = chairService.GetChairByRoomAndPosition(roomService.GetRoomByNumber(RoomNumber), i + 1, j + 1);
                    if (chair == null) {
                        var button = new Button();
                        button.Name = string.Format("button " + (i + 1) + "-" + (j + 1));
                        button.Dock = DockStyle.Fill;
                        button.Click += (sender, e) => { MyHandler(sender, e, button.Name); };
                        this.tableLayoutPanel1.Controls.Add(button, j, i);

                    }
                    else {
                        var button = new Button();
                        button.Text = string.Format("{0}-{1}", i + 1, j + 1);
                        button.Name = string.Format("button" + (i + 1) + "-" + (j + 1));
                        button.Dock = DockStyle.Fill;
                        button.Click += (sender, e) => { MyHandler(sender, e, button.Name); };
                        this.tableLayoutPanel1.Controls.Add(button, j, i);
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.container = new System.Windows.Forms.ListView();
            this.roomSelect = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Chose_Chair_Text = new System.Windows.Forms.Label();
            this.roomSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.HideSelection = false;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(121, 97);
            this.container.TabIndex = 0;
            this.container.UseCompatibleStateImageBehavior = false;
            // 
            // roomSelect
            // 
            this.roomSelect.Controls.Add(this.tableLayoutPanel1);
            this.roomSelect.Controls.Add(this.label2);
            this.roomSelect.Controls.Add(this.Chose_Chair_Text);
            this.roomSelect.Location = new System.Drawing.Point(40, 115);
            this.roomSelect.Name = "roomSelect";
            this.roomSelect.Size = new System.Drawing.Size(1800, 1000);
            this.roomSelect.TabIndex = 20;
            this.roomSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 134);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 500);
            this.tableLayoutPanel1.TabIndex = 23;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 22;
            // 
            // Chose_Chair_Text
            // 
            this.Chose_Chair_Text.AutoSize = true;
            this.Chose_Chair_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Chose_Chair_Text.Location = new System.Drawing.Point(-10, 0);
            this.Chose_Chair_Text.Name = "Chose_Chair_Text";
            this.Chose_Chair_Text.Size = new System.Drawing.Size(270, 46);
            this.Chose_Chair_Text.TabIndex = 3;
            this.Chose_Chair_Text.Text = "Kies een stoel";
            this.Chose_Chair_Text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // ChairSelect
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.roomSelect);
            this.Name = "ChairSelect";
            this.Load += new System.EventHandler(this.RoomCreateDesign_Load);
            this.Controls.SetChildIndex(this.roomSelect, 0);
            this.roomSelect.ResumeLayout(false);
            this.roomSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        private void RoomCreateDesign_Load(object sender, EventArgs e) {

        }

        private void Create_a_movie_text_Click(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {


        }


        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) {

        }


        private void button2_Click_1(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");

            try {
                roomService.DeleteRoom(room);
                MessageBox.Show("room is deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RoomList newScreen = app.GetScreen<RoomList>("roomList");

                app.ShowScreen(newScreen);
            }
            catch {
                MessageBox.Show("room could not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Name_text_Click(object sender, EventArgs e) {

        }

        void MyHandler(object sender, EventArgs e, string buttonString) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            ChairService chairService = app.GetService<ChairService>("chairs");

            ReservationCreate reservationScreen = app.GetScreen<ReservationCreate>("reservationCreate");

            Chair chair = chairService.GetChairByRoomAndPosition(roomService.GetRoomByNumber(RoomNumber), 1, 1);





            if (room == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonString = buttonString.Replace("button", "");
            string[] parts = buttonString.Split('-');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);





            reservationScreen.SetRow(row);
            reservationScreen.SetColum(col);
            reservationScreen.SetRoom(room);
            app.ShowScreen(reservationScreen);

        }
    }
}


