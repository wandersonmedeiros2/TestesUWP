using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.NativeWin32
{
    public enum DBT : int
    {
        DBT_DEVNODES_CHANGED = 0x0007, // Um dispositivo foi adicionado ou removido do sistema.
        DBT_QUERYCHANGECONFIG = 0x0017, //A permissão é solicitada para alterar a configuração atual (encaixar ou desencaixar).
        DBT_CONFIGCHANGED = 0x0018, //A configuração atual foi alterada devido a um encaixe ou desencaixe.
        DBT_CONFIGCHANGECANCELED = 0x0019, //  Uma solicitação para alterar a configuração atual (encaixar ou desencaixar) foi cancelada.
        DBT_DEVICEARRIVAL = 0x8000, //Um dispositivo ou parte da mídia foi inserido e agora está disponível.
        DBT_DEVICEQUERYREMOVE = 0x8001, // A permissão é solicitada para remover um dispositivo ou uma parte da mídia. Qualquer aplicativo pode negar essa solicitação e cancelar a remoção.
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002, //Uma solicitação para remover um dispositivo ou parte da mídia foi cancelada.
        DBT_DEVICEREMOVEPENDING = 0x8003, //Um dispositivo ou parte da mídia está prestes a ser removido. Não é possível negar.
        DBT_DEVICEREMOVECOMPLETE = 0x8004, // Um dispositivo ou parte da mídia foi removido.
        DBT_DEVICETYPESPECIFIC = 0x8005, // Ocorreu um evento específico do dispositivo.
        DBT_CUSTOMEVENT = 0x8006, // Ocorreu um evento personalizado.
        DBT_USERDEFINED = 0xffff // O significado dessa mensagem é definido pelo usuário.
    }
}
