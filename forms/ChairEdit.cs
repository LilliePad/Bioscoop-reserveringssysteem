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
        private Label columnLabel;

        private Button addButton;
        private Button deleteButton;
        private Button cancelButton;

        // Backend
        private Room room;
        private int row;
        private int column;

        public ChairEdit() {
            InitializeComponent();
        }

        public override string GetHandle() {
            return "chairEdit";
        }

        public override void OnShow() {
            base.OnShow();

            this.columnLabel.Text = "Kolom  " + column;
            this.rowLabel.Text = "Rij  " + row;
        }

        private void InitializeComponent() {
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.columnLabel);
            this.panel.Controls.Add(this.rowLabel);
            this.panel.Controls.Add(this.deleteButton);
            this.panel.Controls.Add(this.title);
            this.panel.Controls.Add(this.addButton);
            this.panel.Location = new System.Drawing.Point(40, 106);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(993, 534);
            this.panel.TabIndex = 20;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(318, 171);
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
            this.columnLabel.Size = new System.Drawing.Size(0, 17);
            this.columnLabel.TabIndex = 21;
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rowLabel.Location = new System.Drawing.Point(9, 94);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(0, 17);
            this.rowLabel.TabIndex = 20;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(168, 171);
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
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 171);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(140, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Stoel aanmaken";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ChairEdit
            // 
            this.ClientSize = new System.Drawing.Size(1260, 673);
            this.Controls.Add(this.panel);
            this.Name = "ChairEdit";
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
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

            // Create and save chair
            Chair chair = new Chair(room.id, row, column, 0, "default");

            if(!chairManager.SaveChair(chair)) {
                GuiHelper.ShowError(ValidationHelper.GetErrorList(chair));
                return;
            }

            GuiHelper.ShowInfo("Stoel succesvol aangemaakt");
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

            // Delete it
            if(!chairManager.DeleteChair(chair)) {
                GuiHelper.ShowError("Kon stoel niet verwijderen");
                return;
            }
            
            GuiHelper.ShowInfo("Stoel succesvol verwijderd");
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Program app = Program.GetInstance();
            RoomDetail roomDetail = app.GetScreen<RoomDetail>("roomDetail");

            app.ShowScreen(roomDetail);
        }

    }

}