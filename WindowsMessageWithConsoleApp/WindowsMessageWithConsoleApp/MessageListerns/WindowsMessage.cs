using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMessageWithConsoleApp.MessageHandlers
{
    //https://wiki.winehq.org/List_Of_Windows_Messages
    //https://learn.microsoft.com/pt-br/windows/win32/winmsg/window-notifications

    public enum WindowsMessage 
    {
        WM_NULL = 0x0000,
        WM_KEYDOWN = 0x0100, //Keydown do teclado
        WM_DEVICECHANGE = 0x0219 //Mudança em dipositivo: Drives, add hadware etc
    }
}
