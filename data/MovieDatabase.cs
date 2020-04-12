using System.Collections.Generic;
using Project.Base;
using Project.Records;

namespace Project.Data {

    class MovieDatabase : Database {

        public List<MovieRecord> movies = new List<MovieRecord>();

        public override string GetFileName() {
            return "movies";
        }

    }

}