namespace Project.Data {

    public class BulkUpdate {

        public void Begin() {
            Program.GetInstance().GetDatabase().RegisterBulkUpdate(this);
        }

        public void End() {
            Program.GetInstance().GetDatabase().RemoveBulkUpdate(this);
        }

    }

}
