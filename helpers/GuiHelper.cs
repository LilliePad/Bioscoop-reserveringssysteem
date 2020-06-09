using System.Windows.Forms;

namespace Project.Helpers {

    class GuiHelper {

        public static DialogResult ShowInfo(string message) {
            return MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowWarning(string message) {
            return MessageBox.Show(message, "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowError(string message) {
            return MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ShowConfirm(string message) {
            return MessageBox.Show(message, "Error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes;
        }

    }

}
