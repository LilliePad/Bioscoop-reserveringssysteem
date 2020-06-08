using System;

namespace Project.Errors {

    class PermissionException : Exception {

        public PermissionException(string message) : base(message) { }

    }

}
