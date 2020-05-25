using System.Windows.Forms;

namespace Project.Base {

    public abstract class BaseScreen : Form {

        public abstract string GetHandle();

        public virtual bool IsDefault() {
            return false;
        }

    }   

}
