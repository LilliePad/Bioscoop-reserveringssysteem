using System;
using System.Windows.Forms;
using Project.Forms.Layouts;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Forms {

    public class ChairEdit : BaseLayout {

        // Frontend
        private Panel panel;
        private Label title;

        private Label rowLabel;
        private Label rowValue;

        private Label columnLabel;
        private Label columnValue;

        private Button saveButton;
        private Button deleteButton;
        private Button cancelButton;

        // Backend
        private Room room;
        private int row;
        private NumericUpDown priceInput;
        private Label priceLabel;
        private int column;

        public ChairEdit() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "chairEdit";
        }

        public override bool RequireAdmin() {
            return true;
        }

        public override void OnShow() {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");
            Chair chair = chairManager.GetChairByRoomAndPosition(room, row, column);

            base.OnShow();

            columnValue.Text = "Kolom  " + column;
            rowValue.Text = "Rij  " + row;

            // Update price input
            priceInput.Value = chair != null ? (decimal) chair.price : 0;

            // Update save button
            saveButton.Text = chair != null ? "Stoel opslaan" : "Stoel aanmaken";
            deleteButton.Enabled = chair != null;
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceInput = new System.Windows.Forms.NumericUpDown();
            this.columnValue = new System.Windows.Forms.Label();
            this.rowValue = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.priceLabel);
            this.panel.Controls.Add(this.priceInput);
            this.panel.Controls.Add(this.columnValue);
            this.panel.Controls.Add(this.rowValue);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.columnLabel);
            this.panel.Controls.Add(this.rowLabel);
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.saveButton);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 20;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.priceLabel.Location = new System.Drawing.Point(9, 162);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(35, 17);
            this.priceLabel.TabIndex = 26;
            this.priceLabel.Text = "Prijs";
            // 
            // priceInput
            // 
            this.priceInput.DecimalPlaces = 2;
            this.priceInput.Location = new System.Drawing.Point(156, 162);
            this.priceInput.Name = "priceInput";
            this.priceInput.Size = new System.Drawing.Size(120, 20);
            this.priceInput.TabIndex = 25;
            // 
            // columnValue
            // 
            this.columnValue.AutoSize = true;
            this.columnValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.columnValue.Location = new System.Drawing.Point(151, 126);
            this.columnValue.Name = "columnValue";
            this.columnValue.Size = new System.Drawing.Size(69, 17);
            this.columnValue.TabIndex = 24;
            this.columnValue.Text = "<column>";
            // 
            // rowValue
            // 
            this.rowValue.AutoSize = true;
            this.rowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rowValue.Location = new System.Drawing.Point(151, 94);
            this.rowValue.Name = "rowValue";
            this.rowValue.Size = new System.Drawing.Size(46, 17);
            this.rowValue.TabIndex = 23;
            this.rowValue.Text = "<row>";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(316, 209);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 23);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.columnLabel.Location = new System.Drawing.Point(9, 126);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(63, 17);
            this.columnLabel.TabIndex = 21;
            this.columnLabel.Text = "Kolomen";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rowLabel.Location = new System.Drawing.Point(9, 94);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(40, 17);
            this.rowLabel.TabIndex = 20;
            this.rowLabel.Text = "Rijen";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(166, 209);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(140, 23);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Stoel verwijderen";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // title
            // 
            this.title.AutoEllipsis = true;
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.Control;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.title.Location = new System.Drawing.Point(3, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(300, 46);
            this.title.TabIndex = 3;
            this.title.Text = "Stoel Bewerken";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(11, 209);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Stoel aanmaken";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ChairEdit
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel);
            this.Name = "ChairEdit";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).EndInit();
            this.ResumeLayout(false);

        }

        public void SetChairInfo(Room room, int row, int column) {
            this.room = room;
            this.row = row;
            this.column = column;
        }
      
        private void AddButton_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");

            // Find or create chair
            Chair chair = chairManager.GetChairByRoomAndPosition(room, row, column);
            bool isNew = false;

            if(chair == null) {
                chair = new Chair(room.id, row, column, 0, "default");
                isNew = true;
            }

            chair.price = (double) priceInput.Value;

            // Save chair
            if(!chairManager.SaveChair(chair)) {
                GuiHelper.ShowError(ValidationHelper.GetErrorList(chair));
                return;
            }

            saveButton.Text = "Stoel opslaan";
            deleteButton.Enabled = true;
            GuiHelper.ShowInfo("Stoel succesvol " + (isNew ? "aangemaakt" : "aangepast"));
        }

        private void DeleteButton_Click(object sender, EventArgs args) {
            Program app = Program.GetInstance();
            ChairService chairManager = app.GetService<ChairService>("chairs");

            // Find the chair
            Chair chair = chairManager.GetChairByRoomAndPosition(room, row, column);

            if(chair == null) {
                GuiHelper.ShowError("Er bestaat geen stoel op deze positie");
                return;
            }

            // Ask for confirmation
            if(!GuiHelper.ShowConfirm("Weet je zeker dat je deze stoel wilt verwijderen?")) {
                return;
            }

            // Delete it
            if(!chairManager.DeleteChair(chair)) {
                GuiHelper.ShowError("Kon stoel niet verwijderen");
                return;
            }

            saveButton.Text = "Stoel aanmaken";
            deleteButton.Enabled = false;
            GuiHelper.ShowInfo("Stoel succesvol verwijderd");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomDetail roomDetail = app.GetScreen<RoomDetail>("roomDetail");

            app.ShowScreen(roomDetail);
        }

    }

}