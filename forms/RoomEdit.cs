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
        private TextBox Room_input;
        private Label Name_text;
        private Label label2;

        
        private int RoomNumber;
        private int RoomId;
        private int Maximum;
        private int Colum;
        private double Price;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private string Type;

        public RoomEdit() {
            InitializeComponent();
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairService = app.GetService<ChairService>("chairs");
            RoomService roomService = app.GetService<RoomService>("rooms");

            List<Chair> chairs = chairService.GetChairsByRoom(roomService.GetRoomById(1));
            Maximum = chairs.Count;
            MessageBox.Show("" + Maximum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var rowCount = 10;
            var columnCount = 10;

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++) {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++) {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount; i++) {
                for (int j = 0; j < columnCount; j++) {

                    var button = new Button();
                    button.Text = string.Format("{0}{1}", i, j);
                    button.Name = string.Format("button_{0}{1}", i, j);
                    button.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }
        }
        public override string GetHandle() {
            return "roomEdit";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.roomSelect = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Create_a_movie_text = new System.Windows.Forms.Label();
            this.Room_input = new System.Windows.Forms.TextBox();
            this.Name_text = new System.Windows.Forms.Label();
            this.roomSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomSelect
            // 
            this.roomSelect.Controls.Add(this.button1);
            this.roomSelect.Controls.Add(this.tableLayoutPanel1);
            this.roomSelect.Controls.Add(this.label2);
            this.roomSelect.Controls.Add(this.Create_a_movie_text);
            this.roomSelect.Controls.Add(this.Room_input);
            this.roomSelect.Controls.Add(this.Name_text);
            this.roomSelect.Location = new System.Drawing.Point(40, 115);
            this.roomSelect.Name = "roomSelect";
            this.roomSelect.Size = new System.Drawing.Size(1800, 1000);
            this.roomSelect.TabIndex = 20;
            this.roomSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "room select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 400);
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
            // Room_input
            // 
            this.Room_input.Location = new System.Drawing.Point(125, 82);
            this.Room_input.Name = "Room_input";
            this.Room_input.Size = new System.Drawing.Size(495, 22);
            this.Room_input.TabIndex = 14;
            this.Room_input.TextChanged += new System.EventHandler(this.Room_input_TextChanged);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name_text.Location = new System.Drawing.Point(10, 82);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(106, 20);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Zaal nummer";
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

        private void Room_input_TextChanged(object sender, EventArgs e) {
            try {
                RoomNumber = int.Parse(Room_input.Text);

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

        private void button1_Click(object sender, EventArgs e) {
        }
    }
}
