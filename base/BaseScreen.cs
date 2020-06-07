using Project.Errors;
using Project.Models;
using Project.Services;
using System;
using System.Windows.Forms;

namespace Project.Base {

    public class BaseScreen : Form {

        public virtual string GetHandle() {
            throw new NotImplementedException();
        }

        public virtual bool IsDefault() {
            return false;
        }

        public virtual void Init() {  }

        public virtual void OnShow() {  }

        public virtual bool RequireLogin() {
            return true;
        }

        public virtual bool RequireAdmin() {
            return false;
        }

    }   

}
