using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ispda.Entities
{
    internal class Mes
    {
        public static DialogResult Info(string message)
        {
            return MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Question(string message)
        {
            return MessageBox.Show(message, "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
