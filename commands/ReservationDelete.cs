using System;
using Project.Base;
using Project.Enums;
using Project.Helpers;
using Project.Services;
using Project.Models;


namespace Bioscoop_reserveringssysteem.commands {
    class ReservationDelete : Command {

        public override string GetCategory() {
            return "reservation";
        }

        public override string GetName() {
            return "delete";
        }

        public override string GetUsage() {
            return "reservation/delete <id>";
        }

        public override bool RequireAdmin() {
            return true;
        }
        

    }
}
