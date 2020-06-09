using System;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Models;
using Project.Services;
using Project.Helpers;

namespace Project.Forms {

    public partial class RoomCreateDesign : BaseLayout {

        private Panel panel;
        private Label title;

        private Label numberLabel;
        private NumericUpDown numberInput;

        private Label rowLabel;
        private NumericUpDown rowInput;

        private Label columnLabel;
        private NumericUpDown columnInput;

        private Button saveButton;
        private Button cancelButton;

        public RoomCreateDesign() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "roomCreate";
        }

        public override void OnShow() {
            base.OnShow();

            numberInput.Text = "";
            rowInput.Text = "";
            columnInput.Text = "";
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.numberInput = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.rowInput = new System.Windows.Forms.NumericUpDown();
            this.columnInput = new System.Windows.Forms.NumericUpDown();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.columnInput);
            this.panel.Controls.Add(this.rowInput);
            this.panel.Controls.Add(this.numberInput);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.rowLabel);
            this.panel.Controls.Add(this.columnLabel);
            this.panel.Controls.Add(this.numberLabel);
            this.panel.Location = new System.Drawing.Point(40, 115);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 20;
            // 
            // numberInput
            // 
            this.numberInput.Location = new System.Drawing.Point(125, 79);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(495, 20);
            this.numberInput.TabIndex = 24;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(281, 221);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(125, 221);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Opslaan";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(293, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Zaal aanmaken";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rowLabel.Location = new System.Drawing.Point(9, 125);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(40, 17);
            this.rowLabel.TabIndex = 6;
            this.rowLabel.Text = "Rijen";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.columnLabel.Location = new System.Drawing.Point(10, 171);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(74, 17);
            this.columnLabel.TabIndex = 18;
            this.columnLabel.Text = "Colommen";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numberLabel.Location = new System.Drawing.Point(10, 82);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(91, 17);
            this.numberLabel.TabIndex = 4;
            this.numberLabel.Text = "Zaal nummer";
            // 
            // rowInput
            // 
            this.rowInput.Location = new System.Drawing.Point(125, 122);
            this.rowInput.Name = "rowInput";
            this.rowInput.Size = new System.Drawing.Size(495, 20);
            this.rowInput.TabIndex = 25;
            // 
            // columnInput
            // 
            this.columnInput.Location = new System.Drawing.Point(125, 168);
            this.columnInput.Name = "columnInput";
            this.columnInput.Size = new System.Drawing.Size(495, 20);
            this.columnInput.TabIndex = 26;
            // 
            // RoomCreateDesign
            // 
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel);
            this.Name = "RoomCreateDesign";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnInput)).EndInit();
            this.ResumeLayout(false);

        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");
            RoomService roomManager = app.GetService<RoomService>("rooms");

            // Save room
            Room room = new Room((int) numberInput.Value);

            if (!roomManager.SaveRoom(room)) {
                GuiHelper.ShowError(ValidationHelper.GetErrorList(room));
                return;
            }

            // Create chairs
            int rows = (int) rowInput.Value;
            int columns = (int)columnInput.Value;

            for (int i = 1; i <= rows; i++) {
                for(int j = 1; j <= columns; j++) {
                    Chair chair = new Chair(room.id, i, j, 0, "default");

                    if (!chairManager.SaveChair(chair)) {
                        GuiHelper.ShowError(ValidationHelper.GetErrorList(room));
                    }
                }
            }
            
            // Go back to list view
            RoomList listScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(listScreen);
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomList editScreen = app.GetScreen<RoomList>("roomList");
            app.ShowScreen(editScreen);
        }

    }

}
