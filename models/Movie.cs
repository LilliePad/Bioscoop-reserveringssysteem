using System;
using System.Drawing;
using Project.Base;
using Project.Records;

namespace Project.Models {

    public class Movie : Model {

        public int id = -1;
        public string name;
        public string discription;
        public string genre;
        public int duration;
        public StorageFile image;

        public Movie(MovieRecord record) {
            id = record.id;
            name = record.name;
            discription = record.discription;
            genre = record.genre;
            duration = record.duration;
            image = record.image;
        }

        public Movie(string name, string discription, string genre, int duration, StorageFile image) {
            this.name = name;
            this.discription = discription;
            this.duration = duration;
            this.genre = genre;
            this.image = image;
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
                return Image.FromFile(image.location);
            } catch(Exception) {
                return null;
            }
        }

    }

}
