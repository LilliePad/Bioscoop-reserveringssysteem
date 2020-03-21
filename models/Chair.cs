using Project.Base;
using Project.Helpers;
using Project.Records;
using Project.Services;

namespace Project.Models {

    class Chair : Model {

        public int id = -1;
        public int row;
        public int number;
        public double price;
        public string type;


        public Chair(ChairRecord record) {
            this.id = record.id;           
            this.row = record.row;
            this.number = record.number;
            this.price = record.price;
            this.type = record.type;
        }

        public Chair(int row, int number, double price, string type) {
            this.row = row;
            this.number = number;
            this.price = price;
            this.type = type;
        }

        public override bool Validate() {
            return true;
        }
    
    }

}


