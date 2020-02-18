using Project_Base;

namespace Project_Data {

    class Database : BaseDatabase {

        public string test;
        public string test2;

        public override string GetFileName() {
            return "test";
        }

    }

}