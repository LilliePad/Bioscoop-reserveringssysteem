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


namespace Project.Forms {
    public partial class RoomEdit : BaseLayout {
        private Panel roomSelect;
        private Label Create_a_movie_text;
        private Label Name_text;
        private Label label2;
        private ListView container;


        private int RoomNumber;
        private int Maximum;
        private int HighestColum;
        private int HighestRow;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private int Position;
        private Room room;
        private Button button;
        public RoomEdit() {
            InitializeComponent();
        }


        public override string GetHandle() {
            return "roomEdit";
        }

        public void SetRoom(Room room) {
            this.room = room;
        }

        public override void OnShow() {
            this.Name_text.Text = "Zaal " + room.number;
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");

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
                        button.Name = string.Format("button " + (i+1) + "-" + (j+1)); 
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
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.roomSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomSelect
            // 
            this.roomSelect.Controls.Add(this.button2);
            this.roomSelect.Controls.Add(this.tableLayoutPanel1);
            this.roomSelect.Controls.Add(this.label2);
            this.roomSelect.Controls.Add(this.Create_a_movie_text);
            this.roomSelect.Controls.Add(this.Name_text);
            this.roomSelect.Location = new System.Drawing.Point(40, 115);
            this.roomSelect.Name = "roomSelect";
            this.roomSelect.Size = new System.Drawing.Size(1800, 1000);
            this.roomSelect.TabIndex = 20;
            this.roomSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "room delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
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
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 22;
            // 
            // Create_a_movie_text
            // 
            this.Create_a_movie_text.AutoSize = true;
            this.Create_a_movie_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Create_a_movie_text.Location = new System.Drawing.Point(-10, 0);
            this.Create_a_movie_text.Name = "Create_a_movie_text";
            this.Create_a_movie_text.Size = new System.Drawing.Size(310, 58);
            this.Create_a_movie_text.TabIndex = 3;
            this.Create_a_movie_text.Text = "Bewerk zaal ";
            this.Create_a_movie_text.Click += new System.EventHandler(this.Create_a_movie_text_Click);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(21, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(45, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Zaal ";
            this.Name_text.Click += new System.EventHandler(this.Name_text_Click);
            // 
            // RoomEdit
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.roomSelect);
            this.Name = "RoomEdit";
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

        private void Movie_create_button_Click(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void Colum_input_TextChanged(object sender, EventArgs e) {
            try {


            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Row_input_TextChanged(object sender, EventArgs e) {
            try {


            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Price_Input_TextChanged(object sender, EventArgs e) {

            try {


            }
            catch (FormatException) {
                MessageBox.Show("voer hier enkel cijfers in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

           
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) {

        }

        private void roomSelect_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");
            Chair chair = chairService.GetChairByRoomAndPosition(roomService.GetRoomById(1), 2, 1);
            try {
                chairService.DeleteChair(chair);
            }
            catch {
                MessageBox.Show("chair could not be deleted" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

            ChairEdit editScreen = app.GetScreen<ChairEdit>("chairEdit");

            Chair chair = chairService.GetChairByRoomAndPosition(roomService.GetRoomByNumber(RoomNumber), 1, 1);





            if (room == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            buttonString = buttonString.Replace("button", "");
            string[] parts = buttonString.Split('-');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);

            editScreen.SetRow(row);
            editScreen.SetColum(col);
            editScreen.SetRoom(room);
            app.ShowScreen(editScreen);

        }
            private void ButtonEdit_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomService roomService = app.GetService<RoomService>("rooms");
            ChairService chairService = app.GetService<ChairService>("chairs");

            ChairEdit editScreen = app.GetScreen<ChairEdit>("chairEdit");
            
            Chair chair = chairService.GetChairByRoomAndPosition(roomService.GetRoomByNumber(RoomNumber), 1, 1);

            
            
            

            if (room == null) {
                MessageBox.Show("Error: Kon geen film vinden voor dit item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            editScreen.SetRoom(room);
            app.ShowScreen(editScreen);
        }
    }
}

 