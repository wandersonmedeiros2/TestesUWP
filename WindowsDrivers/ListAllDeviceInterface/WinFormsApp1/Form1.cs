
//BASE DE CONHECIMENTO
//https://learn.microsoft.com/en-us/windows-hardware/drivers/kernel/defining-and-exporting-new-guids
//https://learn.microsoft.com/pt-br/windows/win32/devio/device-events
//https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-volume

using System.Diagnostics;
using WinFormsApp1.Base;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private IDerviceEventRegisterManager _derviceEventRegisterManager;
        private Guid _guidDeviceInterface = new Guid("53F5630D-B6BF-11D0-94F2-00A0C91EFB8B");

        public Form1()
        {
            InitializeComponent();
            _derviceEventRegisterManager = new DerviceEventRegisterManager();

            _derviceEventRegisterManager.RegisterListernHandle(Handle, _guidDeviceInterface);
        }

        ~Form1()
        {
            _derviceEventRegisterManager.UnregisterListernHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x0219)
            {
                Debug.WriteLine($"Message: {m.Msg}");
                Debug.WriteLine($"WParam: {m.WParam}");
                Debug.WriteLine($"LParam: {m.LParam}");
            }
            base.WndProc(ref m);    
        }
    }
}
