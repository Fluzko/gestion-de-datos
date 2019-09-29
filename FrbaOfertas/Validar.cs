using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    class Validar
    {
        public static void numerico(KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && (char.IsNumber(e.KeyChar)) && (e.KeyChar == (char)Keys.Back))
                e.Handled = true;
        }

        public static void letras(KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar == (char)Keys.Back))
                e.Handled = true;
        }


    }
}
