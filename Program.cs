using System;
using System.Windows.Forms;

namespace zpl2printer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if(args != null && args.Length > 0 && args[0].StartsWith("^XA") && args[0].EndsWith("^XZ"))
            {
                RawPrinterHelper.SendStringToPrinter(args.Length > 2 ? args[2] : Properties.Settings.Default.PrinterName, args[0], args.Length > 1 && int.TryParse(args[1], out int _amount) ? _amount : 1);
            }
            else if (Clipboard.ContainsText())
            {
                var _cb = Clipboard.GetText();
                if(!string.IsNullOrWhiteSpace(_cb) && _cb.StartsWith("^XA") && _cb.EndsWith("^XZ"))
                {
                    RawPrinterHelper.SendStringToPrinter(Properties.Settings.Default.PrinterName, _cb, 1);
                }
            }
        }
    }
}
