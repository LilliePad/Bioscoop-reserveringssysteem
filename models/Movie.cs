using System;
using System.Drawing;
using Project.Base;
using Project.Records;

namespace Project.Models {

    class Movie : Model {

        public int id = -1;
        public string name;
        public string genre;
        public int duration;
        public string imagePath;

        public Movie(MovieRecord record) {
            id = record.id;
            name = record.name;
            genre = record.genre;
            duration = record.duration;
            imagePath = record.imagePath;
        }

        public Movie(string name, string genre, int duration, string imagePath) {
            this.name = name;
            this.duration = duration;
            this.genre = genre;
            this.imagePath = imagePath;
        }

        public override bool Validate() {
            if (name == null || name.Length == 0) {
                AddError("name", "Naam mag niet leeg zijn.");
                return false;
            }

            if (genre == null || genre.Length == 0) {
                AddError("genre", "Genre mag niet leeg zijn.");
                return false;
            }

            if (duration < 1) {
                AddError("duration", "Tijd moet groter dan 0 zijn.");
                return false;
            }

            if (GetImage() == null) {
                AddError("imagePath", "Afbeelding moet een geldige afbeelding zijn.");
                return false;
            }

            return true;
        }

        public Image GetImage() {
            try {
                return Image.FromFile(imagePath);
            } catch(Exception) {
                return null;
            }
        }

    }

}
