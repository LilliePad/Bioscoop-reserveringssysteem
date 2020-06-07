using System.Windows.Forms;

namespace Project.Helpers {

    class GuiHelper {

        public static void ShowInfo(string message) {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message) {
            MessageBox.Show(message, "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

}
