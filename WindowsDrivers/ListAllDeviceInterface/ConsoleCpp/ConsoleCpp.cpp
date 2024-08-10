// ConsoleCpp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>
#include <Dbt.h>
#include <cfgmgr32.h>
#pragma comment(lib, "Cfgmgr32.lib")

//https://learn.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_interface_lista

int main()
{
    std::cout << "Hello World!\n";

    CONFIGRET cr = CR_SUCCESS;
    PWSTR DeviceInterfaceList = NULL;
    ULONG DeviceInterfaceListLength = 0;

    do {
        cr = CM_Get_Device_Interface_List_Size(&DeviceInterfaceListLength,
            (LPGUID)&GUID_DEVINTERFACE_VOLUME,
            NULL,
            CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES);

        if (cr != CR_SUCCESS)
        {
            break;
        }

        if (DeviceInterfaceList != NULL) {
            HeapFree(GetProcessHeap(),
                0,
                DeviceInterfaceList);
        }

        DeviceInterfaceList = (PWSTR)HeapAlloc(GetProcessHeap(),
            HEAP_ZERO_MEMORY,
            DeviceInterfaceListLength * sizeof(WCHAR));

        if (DeviceInterfaceList == NULL)
        {
            cr = CR_OUT_OF_MEMORY;
            break;
        }

        cr = CM_Get_Device_Interface_List((LPGUID)&GUID_DEVINTERFACE_VOLUME,
            NULL,
            DeviceInterfaceList,
            DeviceInterfaceListLength,
            CM_GET_DEVICE_INTERFACE_LIST_ALL_DEVICES);
    } while (cr == CR_BUFFER_SMALL);

    if (cr != CR_SUCCESS)
    {
        std::cout << "Erro ao carregar interface\n";
    }
    else {
        std::wcout << DeviceInterfaceList << std::endl;
    }

    



}
