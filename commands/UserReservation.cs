using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Models;
using Project.Services;

namespace Project.Commands {

    class UserReservation : Command {

        public override string GetName() {
            return "Reservation";
        }

        public override bool RequireLogin() {
            return true;
        }