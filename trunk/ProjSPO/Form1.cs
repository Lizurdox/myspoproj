using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.Net;

namespace ProjSPO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HDDList.Enabled = false;
            HDDList.Visible = false;
        }

        //-----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = VideoCard();
        }
        private string VideoCard()
        {
            ManagementScope sc = new ManagementScope(@"\\.\root\cimv2", null);
            ManagementPath ph = new ManagementPath(@"Win32_VideoController");
            ManagementClass mc = new ManagementClass(sc, ph, null);
            string Vid = "null";
            foreach (ManagementObject ss in mc.GetInstances())
            {
                try
                {
                    Vid = "Название : " + ss.GetPropertyValue("Name").ToString() + '\n'
                  + "Видео процессор : " + ss.GetPropertyValue("VideoProcessor").ToString() + '\n'
                  + "Адаптер RAM : " + ss.GetPropertyValue("AdapterRAM").ToString() + '\n'
                  + "Описание видеорежима : " + ss.GetPropertyValue("VideoModeDescription").ToString() + '\n'
                  + "Частота обновления : " + ss.GetPropertyValue("CurrentRefreshRate").ToString();
                }
                catch (NullReferenceException ex)
                {
                }
            }
            return Vid;
        }
        //-----------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = NetworkConnect();
        }
        private string NetworkConnect()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkConnection");
            ManagementObjectCollection managementObj = managementClass.GetInstances();
            string ret = "Null";
            string myHost = System.Net.Dns.GetHostName();
            ret = "Хост " + myHost;
            ret += "\nIP адрес" + System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();
            foreach (ManagementObject mo in managementObj)
            {

                ret = "AccessMask: " + mo["AccessMask"].ToString() + '\n' +
                "AccessMask: " + mo["AccessMask"] + '\n' +
                 "Caption: " + mo["Caption"] + '\n' +
                 "Comment: " + mo["Comment"] + '\n' +
                 "ConnectionState: " + mo["ConnectionState"] + '\n' +
                 "ConnectionType: " + mo["ConnectionType"] + '\n' +
                 "Description: " + mo["Description"] + '\n' +
                 "DisplayType: " + mo["DisplayType"] + '\n' +
                 "InstallDate: " + mo["InstallDate"] + '\n' +
                 "LocalName: " + mo["LocalName"] + '\n' +
                 "Name: " + mo["Name"] + '\n' +
                 "Persistent: " + mo["Persistent"] + '\n' +
                 "ProviderName: " + mo["ProviderName"] + '\n' +
                 "RemoteName: " + mo["RemoteName"] + '\n' +
                 "RemotePath: " + mo["RemotePath"] + '\n' +
                 "ResourceType: " + mo["ResourceType"] + '\n' +
                 "Status: " + mo["Status"] + '\n' +
                 "UserName: " + mo["UserName"];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = Ident();
        }
        private string Ident()
        {
            WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher find = new ManagementObjectSearcher(query);
            string ret = "null";
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Описание " + mo["Description"] + '\n' +
                "Серийный номер " + mo["IdentifyingNumber"] + '\n' +
                "Commonly used product name." + mo["Name"] + '\n' +
                "Universally Unique Identifier of  product." + mo["UUID"] + '\n' +
                "Vendor продукта." + mo["Vendor"];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = Boot();
        }
        private string Boot()
        {
            string ret = "null";
            WqlObjectQuery query = new WqlObjectQuery(
                "SELECT * FROM Win32_BootConfiguration");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Загрузочная директория " + mo["BootDirectory"] + '\n' +
                "Описание " + mo["Description"] + '\n' +
                "Директроия временных файлов загрузки" + mo["ScratchDirectory"] + '\n' +
                "Директория временных файлов." + mo["TempDirectory"];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = CompSys();
        }
        private string CompSys()
        {
            string ret = "null";

            WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher find = new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Компьютер относиться к домену " + mo["Domain"] + '\n' +
                "Производитель" + mo["Manufacturer"] + '\n' +
                "Имя модели, данное производителем " + mo["Model"];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = CompSys2();
        }
        private string CompSys2()
        {
            string ret = "Null";
            string[] Roles = {
								 "Standalone Workstation", // 0
								 "Member Workstation",  // 1
								 "Standalone Server",  // 2
								 "Member Server",   // 3
								 "Backup Domain Controller", // 4
								 "Primary Domain Controller" // 5
							 };

            WqlObjectQuery query = new WqlObjectQuery(
                "SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = Roles[Convert.ToInt32(mo["DomainRole"])];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = Desktop();
        }
        public string Desktop()
        {
            string ret = "Null";
            // Получить настройки рабочего стола
            WqlObjectQuery query = new WqlObjectQuery(
                "SELECT * FROM Win32_Desktop WHERE Name = '.Default'");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                // Значения могут быть изменены 
                // в реестре "HKEY_CURRENT_USER\Control Panel\Desktop"
                ret = "Width of window borders." + mo["BorderWidth"] + '\n' +
                "ALT+TAB - разрешено " + mo["CoolSwitch"] + '\n' +
                    // Значения в мс
                "Lenght of time between cursor blincks. " + mo["CursorBlinkRate"] + '\n' +
                "Show content of windows when are draged." + mo["DragFullWindows"] + '\n' +
                "Grid settings for dragging windows." + mo["GridGranularity"] + '\n' +
                "Grid settings for icon spacing. " + mo["IconSpacing"] + '\n' +
                "Font used for the names of icons." + mo["IconTitleFaceName"] + '\n' +
                "Icon ront size. " + mo["IconTitleSize"] + '\n' +
                "Wrapping of icon title." + mo["IconTitleWrap"] + '\n' +
               "Name of the desktop profile." + mo["Name"] + '\n' +
                "Screen saver is active." + mo["ScreenSaverActive"] + '\n' +
               "Name of the screen saver executable." + mo["ScreenSaverExecutable"] + '\n' +
                "Is screen saver protected with password." + mo["ScreenSaverSecure"] + '\n' +
                "Time to pass to activate screen saver." + mo["ScreenSaverTimeout"] + '\n' +
                "File name for desktop background." + mo["Wallpaper"] + '\n' +
                "Wallpaper fills entire screen." + mo["WallpaperStretched"] + '\n' +
                "Wallpaper is tiled." + mo["WallpaperTiled"];
            }
            return ret;

        }
        //-----------------------------------------------------------------
        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = DiskParts();
        }
        private string DiskParts()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_DiskPartition");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Размер блока " + mo["BlockSize"] + " Bytes" + '\n' +
                "Загрузочный диск " + mo["Bootable"] + '\n' +
                "Активный загрузочный диск " + mo["BootPartition"] + '\n' +
                "Заголовок " + mo["Caption"] + '\n' +
                "Описание " + mo["Description"] + '\n' +
                "Уникальный индификатор раздела " + mo["DeviceID"] + '\n' +
                "Индекс диска ." + mo["DiskIndex"] + '\n' +
                "Детали описаня ошибки в  LastErrorCode." + mo["ErrorDescription"] + '\n' +
                "Типо определения ошибки " + mo["ErrorMethodology"] + '\n' +
                "Скрытые секторы " + mo["HiddenSectors"] + '\n' +
                "Индексный номер раздела " + mo["Index"] + '\n' +
                "ПОследняя ошибка устройства " + mo["LastErrorCode"] + '\n' +
                "Общее количество последовательных блоков " + mo["NumberOfBlocks"] + '\n' +
                "Раздел, помечеый как ведущий." + mo["PrimaryPartition"] + '\n' +
                "Свободное описание  " + mo["Purpose"] + '\n' +
                "Общий размер разделов " + mo["Size"] + " bytes" + '\n' +
                "Стартовое смещение " + mo["StartingOffset"] + '\n' +
                "Статус " + mo["Status"] + '\n' +
                "Тип раздела " + mo["Type"];
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = Environment();
        }
        private string Environment()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_Environment");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = mo["Description"] + " - " + mo["Name"] +
                    " - " + mo["UserName"] + " - " + mo["VariableValue"];
            }
            return ret;
        }
        //----------------------------------------------------------------
        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = Group();
        }
        private string Group()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_Group where LocalAccount = 'true'");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Заголовок " + mo["Caption"] + '\n' +
                 "Описание " + mo["Description"] + '\n' +
                 "Домен " + mo["Domain"] + '\n' +
                 "Профиль орпеделёный на локальной машине " + mo["LocalAccount"] + '\n' +
                 "Группа " + mo["Name"] + '\n' +
                 "Идентификтор безопасности (SID)." + mo["SID"] + '\n' +
                 "Тип идентификатора безопасности " + GetSidType(Convert.ToInt32(mo["SIDType"])) + '\n' +
                 "Статус " + mo["Status"];
            }
            return ret;
        }
        public static string GetSidType(int type)
        {
            switch (type)
            {
                case 1: return "SidTypeUser";
                case 2: return "SidTypeGroup";
                case 3: return "SidTypeDomain";
                case 4: return "SidTypeAlias";
                case 5: return "SidTypeWellKnownGroup";
                case 6: return "SidTypeDeletedAccount";
                case 7: return "SidTypeInvalid";
                case 8: return "SidTypeUnknown";
                case 9: return "SidTypeComputer";
            }
            return string.Empty;
        }
        //----------------------------------------------------
        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = LDisk();
        }
        private string LDisk()
        {
            string ret = "Null";
            string cmiPath = @"\root\cimv2:Win32_LogicalDisk.DeviceID='C:'";
            ManagementObject mo = new ManagementObject(cmiPath);
            ret = "Описание " + mo["Description"] + '\n' +
            "Файловай система " + mo["FileSystem"] + '\n' +
            "Свободно места на диске " + mo["FreeSpace"] + '\n' +
            "Размер " + mo["Size"];
            return ret;
        }
        //-------------------------------------------------------
        private void button12_Click(object sender, EventArgs e)
        {
            label1.Text = OperSys();
        }
        private string OperSys()
        {
            string ret = "Null";
            WqlObjectQuery query =
        new WqlObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                ret = "Boot device name " + mo["BootDevice"] + '\n' +
                "Build number" + mo["BuildNumber"] + '\n' +
                "Caption" + mo["Caption"] + '\n' +
                "Code page used by OS" + mo["CodeSet"] + '\n' +
                "Country code" + mo["CountryCode"] + '\n' +
                "Latest service pack installed" + mo["CSDVersion"] + '\n' +
                "Computer system name" + mo["CSName"] + '\n' +
                "Time zone (minute offset from GMT" + mo["CurrentTimeZone"] + '\n' +
                "OS is debug build" + mo["Debug"] + '\n' +
                "OS is distributed across several nodes." + mo["Distributed"] + '\n' +
                "Encryption level of transactions" + mo["EncryptionLevel"] + " bits" + '\n' +
                ">>Priority increase for foreground app" + GetForeground(mo) + '\n' +
                "Available physical memory" + mo["FreePhysicalMemory"] + " kilobytes" + '\n' +
                "Available virtual memory" + mo["FreeVirtualMemory"] + " kilobytes" + '\n' +
                "Free paging-space withou swapping." + mo["FreeSpaceInPagingFiles"] + '\n' +
                "Installation date " + ManagementDateTimeConverter.ToDateTime(mo["InstallDate"].ToString()) + '\n' +
                "What type of memory optimization......" + (Convert.ToInt16(mo["LargeSystemCache"]) == 0 ? "for applications" : "for system performance") + '\n' +
                "Time from last boot " + mo["LastBootUpTime"] + '\n' +
                "Local date and time " + ManagementDateTimeConverter.ToDateTime(mo["LocalDateTime"].ToString()) + '\n' +
                "Language identifier (LANGID) " + mo["Locale"] + '\n' +
                "Local date and time. " + ManagementDateTimeConverter.ToDateTime(mo["LocalDateTime"].ToString()) + '\n' +
                "Max# of processes supported by OS" + mo["MaxNumberOfProcesses"] + '\n' +
                "Max memory available for process." + mo["MaxProcessMemorySize"] + " kilobytes" + '\n' +
                "Current number of processes" + mo["NumberOfProcesses"] + '\n' +
                "Currently stored user sessions." + mo["NumberOfUsers"] + '\n' +
                "OS language version" + mo["OSLanguage"] + '\n' +
                "OS product suite version" + GetSuite(mo) + '\n' +
                "OS type" + GetOSType(mo) + '\n' +
                "Number of Windows Plus! " + mo["PlusProductID"] + '\n' +
                "Version of Windows Plus! " + mo["PlusVersionNumber"] + '\n' +
                "Type of installed OS. " + GetProductType(mo) + '\n' +
                "Registered user of OS. " + mo["RegisteredUser"] + '\n' +
                "Serial number of product. " + mo["SerialNumber"] + '\n' +
                "Serial number of product. " + mo["SerialNumber"] + '\n' +
                "ServicePack major version. " + mo["ServicePackMajorVersion"] + '\n' +
                "ServicePack minor version. " + mo["ServicePackMinorVersion"] + '\n' +
                "Total number to store in paging files" + mo["SizeStoredInPagingFiles"] + " kilobytes" + '\n' +
                "Status. " + mo["Status"] + '\n' +
                "ServicePack minor version. " + mo["ServicePackMinorVersion"] + '\n' +
                "OS suite. " + GetOSSuite(mo) + '\n' +
                "Physical disk partition with OS. " + mo["SystemDevice"] + '\n' +
                "System directory. " + mo["SystemDirectory"] + '\n' +
                "Total virtual memory. " + mo["TotalVirtualMemorySize"] + " kilobytes" + '\n' +
                "Total physical memory. " + mo["TotalVisibleMemorySize"] + " kilobytes" + '\n' +
                "Version number of OS. " + mo["Version"] + '\n' +
                "Windows directory. " + mo["WindowsDirectory"];
            }
            return ret;
        }
        private static string GetForeground(ManagementObject mo)
        {
            int i = Convert.ToInt16(mo["ForegroundApplicationBoost"]);
            switch (i)
            {
                case 0: return "None";
                case 1: return "Minimum";
                case 2: return "Maximum (defualt value)";
            }
            return "Boost not defined.";
        }

        private static string GetSuite(ManagementObject mo)
        {
            uint i = Convert.ToUInt32(mo["OSProductSuite"]);
            switch (i)
            {
                case 1: return "Small Business";
                case 2: return "Enterprise";
                case 4: return "BackOffice";
                case 8: return "Communication Server";
                case 16: return "Terminal Server";
                case 32: return "Small Business (Restricted)";
                case 64: return "Embedded NT";
                case 128: return "Data Center";
            }
            return "OS suite not defined.";
        }

        // Тип операционной системы
        private static string GetOSType(ManagementObject mo)
        {
            uint i = Convert.ToUInt16(mo["OSType"]);
            switch (i)
            {
                case 16: return "WIN95";
                case 17: return "WIN98";
                case 18: return "WINNT";
                case 19: return "WINCE";
            }
            return "Other OS systems aren not covered.";
        }

        private static string GetProductType(ManagementObject mo)
        {
            uint i = Convert.ToUInt32(mo["ProductType"]);
            switch (i)
            {
                case 1: return "Work Station";
                case 2: return "Domain Controller";
                case 3: return "Server";
            }
            return "Product type not defined.";
        }

        private static string GetOSSuite(ManagementObject mo)
        {
            uint i = Convert.ToUInt32(mo["SuiteMask"]);

            string suite = "";
            if ((i & 1) == 1) suite += "Small Business";
            if ((i & 2) == 2)
            {
                if (suite.Length > 0) suite += ", "; suite += "Enterprise";
            }
            if ((i & 4) == 4)
            {
                if (suite.Length > 0) suite += ", "; suite += "Back Office";
            }
            if ((i & 8) == 8)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Communications";
            }
            if ((i & 16) == 16)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Terminal";
            }
            if ((i & 32) == 32)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Small Business Restricted";
            }
            if ((i & 64) == 64)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Embedded NT";
            }
            if ((i & 128) == 128)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Data Center";
            }
            if ((i & 256) == 256)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Single User";
            }
            if ((i & 512) == 512)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Personal";
            }
            if ((i & 1024) == 1024)
            {
                if (suite.Length > 0)
                    suite += ", ";
                suite += "Blade";
            }
            return suite;
        }
        //----------------------------------------
        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = Processor();
        }
        private string Processor()
        {
            string ret = "Null";
            // Получаем все процессоры компьютера
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_Processor");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            int i = 0;
            foreach (ManagementObject mo in find.Get())
            {
                ret = "-- Processor #" + i + " -" + '\n' +
                "Processor address width in bits." + mo["AddressWidth"] + '\n' +
                "Architecture of processor." + GetArchitecture(mo) + '\n' +
                "Caption." + mo["Caption"] + '\n' +
                "Processor address width in bits." + mo["AddressWidth"] + '\n' +
                "Usage status of the processor." + GetCpuStatus(mo) + '\n' +
                "Current clock speed (in MHz)." + mo["CurrentClockSpeed"] + '\n' +
                "Processor data width." + mo["DataWidth"] + '\n' +
                "Unique string identification." + mo["DeviceID"] + '\n' +
                "External clock frequency." + mo["ExtClock"] + '\n' +
                "Processor family." + GetFamily(mo) + '\n' +
                "L2 cache size." + mo["L2CacheSize"] + '\n' +
                "L2 cache speed." + mo["L2CacheSpeed"] + '\n' +
                "Load percentage (average value for second)." + mo["LoadPercentage"] + '\n' +
                "Manufacturer." + mo["Manufacturer"] + '\n' +
                "Maximum speed (in MHz)." + mo["MaxClockSpeed"] + '\n' +
                "Name." + mo["Name"] + '\n' +
                "Support for power management." + mo["PowerManagementSupported"] + '\n' +
                "Unique identificator describing processor" + mo["ProcessorId"] + '\n' +
                "Processor type." + GetProcessorType(mo) + '\n' +
                "Role (CPU/math)." + mo["Role"] + '\n' +
                "Socket designation." + mo["SocketDesignation"] + '\n' +
                "Status." + mo["Status"] + '\n' +
                "Status information." + GetStatusInfo(mo) + '\n' +
                "Processor version." + mo["Version"] + '\n' +
                "Socket voltage." + mo["VoltageCaps"];
                i++;
            }
            return ret;
        }
        private static string GetArchitecture(ManagementObject mo)
        {
            int i = Convert.ToInt32(mo["Architecture"]);
            switch (i)
            {
                case 0: return "x86";
                case 1: return "MIPS";
                case 2: return "Alpha";
                case 3: return "PowerPC";
                case 4: return "ia64";
            }
            return "Undefined";
        }

        private static string GetCpuStatus(ManagementObject mo)
        {
            int i = Convert.ToInt32(mo["CpuStatus"]);
            switch (i)
            {
                case 0: return "Unknown";
                case 1: return "CPU Enabled";
                case 2: return "CPU Disabled by User via BIOS Setup";
                case 3: return "CPU Disabled By BIOS (POST Error)";
                case 4: return "CPU is Idle";
                case 5: return "This value is reserved.";
                case 6: return "This value is reserved.";
                case 7: return "Other";
            }
            return "Undefined";
        }

        private static string GetFamily(ManagementObject mo)
        {
            int i = Convert.ToInt32(mo["Family"]);
            switch (i)
            {
                case 1: return "Other";
                case 2: return "Unknown";
                case 3: return "8086";
                case 4: return "80286";
                case 5: return "80386";
                case 6: return "80486";
                case 7: return "8087";
                case 8: return "80287";
                case 9: return "80387";
                case 10: return "80487";
                case 11: return "PentiumR brand";
                case 12: return "PentiumR Pro";
                case 13: return "PentiumR II";
                case 14: return "PentiumR processor with MMX technology";
                case 15: return "CeleronT";
                case 16: return "PentiumR II Xeon";
                case 17: return "PentiumR III";
                case 18: return "M1 Family";
                case 19: return "M2 Family";
                case 24: return "K5 Family";
                case 25: return "K6 Family";
                case 26: return "K6-2";
                case 27: return "K6-3";
                case 28: return "AMD AthlonT Processor Family";
                case 29: return "AMDR DuronT Processor";
                case 30: return "AMD2900 Family";
                case 31: return "K6-2+";
                case 32: return "Power PC Family";
                case 33: return "Power PC 601";
                case 34: return "Power PC 603";
                case 35: return "Power PC 603+";
                case 36: return "Power PC 604";
                case 37: return "Power PC 620";
                case 38: return "Power PC X704";
                case 39: return "Power PC 750";
                case 48: return "Alpha Family";
                case 49: return "Alpha 21064";
                case 50: return "Alpha 21066";
                case 51: return "Alpha 21164";
                case 52: return "Alpha 21164PC";
                case 53: return "Alpha 21164a";
                case 54: return "Alpha 21264";
                case 55: return "Alpha 21364";
                case 64: return "MIPS Family";
                case 65: return "MIPS R4000";
                case 66: return "MIPS R4200";
                case 67: return "MIPS R4400";
                case 68: return "MIPS R4600";
                case 69: return "MIPS R10000";
                case 80: return "SPARC Family";
                case 81: return "SuperSPARC";
                case 82: return "microSPARC II";
                case 83: return "microSPARC IIep";
                case 84: return "UltraSPARC";
                case 85: return "UltraSPARC II";
                case 86: return "UltraSPARC IIi";
                case 87: return "UltraSPARC III";
                case 88: return "UltraSPARC IIIi";
                case 96: return "68040";
                case 97: return "68xxx Family";
                case 98: return "68000";
                case 99: return "68010";
                case 100: return "68020";
                case 101: return "68030";
                case 112: return "Hobbit Family";
                case 120: return "CrusoeT TM5000 Family";
                case 121: return "CrusoeT TM3000 Family";
                case 128: return "Weitek";
                case 130: return "ItaniumT Processor";
                case 144: return "PA-RISC Family";
                case 145: return "PA-RISC 8500";
                case 146: return "PA-RISC 8000";
                case 147: return "PA-RISC 7300LC";
                case 148: return "PA-RISC 7200";
                case 149: return "PA-RISC 7100LC";
                case 150: return "PA-RISC 7100";
                case 160: return "V30 Family";
                case 176: return "PentiumR III XeonT";
                case 177: return "PentiumR III Processor with IntelR SpeedStepT Technology";
                case 178: return "PentiumR 4";
                case 179: return "IntelR XeonT";
                case 180: return "AS400 Family";
                case 181: return "IntelR XeonT processor MP";
                case 182: return "AMD AthlonXPT Family";
                case 183: return "AMD AthlonMPT Family";
                case 184: return "IntelR ItaniumR 2";
                case 185: return "AMD OpteronT Family";
                case 190: return "K7";
                case 200: return "IBM390 Family";
                case 201: return "G4";
                case 202: return "G5";
                case 250: return "i860";
                case 251: return "i960";
                case 260: return "SH-3";
                case 261: return "SH-4";
                case 280: return "ARM";
                case 281: return "StrongARM";
                case 300: return "6x86";
                case 301: return "MediaGX";
                case 302: return "MII";
                case 320: return "WinChip";
                case 350: return "DSP";
                case 500: return "Video Processor";
            }
            return "Undefined processor family";
        }

        private static string GetProcessorType(ManagementObject mo)
        {
            int i = Convert.ToInt32(mo["ProcessorType"]);
            switch (i)
            {
                case 1: return "Other";
                case 2: return "Unknown";
                case 3: return "Central Processor";
                case 4: return "Math Processor";
                case 5: return "DSP Processor";
                case 6: return "Video Processor";
            }
            return "Undefined type";
        }

        private static string GetStatusInfo(ManagementObject mo)
        {
            int i = Convert.ToInt32(mo["StatusInfo"]);
            switch (i)
            {
                case 1: return "Other";
                case 2: return "Unknown";
                case 3: return "Enabled";
                case 4: return "Disabled";
                case 5: return "Not applicable";
            }
            return "StatusInfo not defined.";
        }
        //-------------------------------------------------------
        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text = Module();
        }
        private string Module()
        {
            string ret = "Null";
            // Перечисляем все модули компьютера
            WqlObjectQuery query = new WqlObjectQuery(
                "SELECT * FROM Win32_SystemEnclosure");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            int i = 0;
            foreach (ManagementObject mo in find.Get())
            {
                ret = "--- Chasis setting #" + i + '\n' +
                "Chasis type." + GetChasisType(mo) + '\n' +
                "Description." + mo["Description"] + '\n' +
                "Depth of physical package (in inches)." + mo["Depth"] + '\n' +
                "Height of physical package (in inches).." + mo["Height"] + '\n' +
                "Width of physical package (in inches)." + mo["Width"] + '\n' +
                "Weight." + mo["Weight"] + '\n' +
                "Service philosophy " + GetServicePhilosophy(mo) + '\n' +
                "Status." + mo["Status"] + '\n' +
                "Property includes visible alarm." + mo["VisibleAlarm"] + '\n' +
                "Property includes visible alarm." + mo["VisibleAlarm"];
                i++;
            }
            return ret;
        }
        private static string GetChasisType(ManagementObject mo)
        {
            System.UInt16[] type = (System.UInt16[])mo["ChassisTypes"];
            String returnType = "";
            for (int i = 0; i < type.Length; i++)
            {
                if (i > 0) returnType += ", ";
                switch (type[i])
                {
                    case 1:
                        returnType += "Other";
                        break;
                    case 2:
                        returnType += "Unknown";
                        break;
                    case 3:
                        returnType += "Desktop";
                        break;
                    case 4:
                        returnType += "Low Profile Desktop";
                        break;
                    case 5:
                        returnType += "Pizza Box";
                        break;
                    case 6:
                        returnType += "Mini Tower";
                        break;
                    case 7:
                        returnType += "Tower";
                        break;
                    case 8:
                        returnType += "Portable";
                        break;
                    case 9:
                        returnType += "Laptop";
                        break;
                    case 10:
                        returnType += "Notebook";
                        break;
                    case 11:
                        returnType += "Hand Held";
                        break;
                    case 12:
                        returnType += "Docking Station";
                        break;
                    case 13:
                        returnType += "All in One";
                        break;
                    case 14:
                        returnType += "Sub Notebook";
                        break;
                    case 15:
                        returnType += "Space-Saving";
                        break;
                    case 16:
                        returnType += "Lunch Box";
                        break;
                    case 17:
                        returnType += "Main System Chassis";
                        break;
                    case 18:
                        returnType += "Expansion Chassis";
                        break;
                    case 19:
                        returnType += "SubChassis";
                        break;
                    case 20:
                        returnType += "Bus Expansion Chassis";
                        break;
                    case 21:
                        returnType += "Peripheral Chassis";
                        break;
                    case 22:
                        returnType += "Storage Chassis";
                        break;
                    case 23:
                        returnType += "Rack Mount Chassis";
                        break;
                    case 24:
                        returnType += "Sealed-Case PC";
                        break;
                }
            }
            return returnType;
        }

        private static string GetServicePhilosophy(ManagementObject mo)
        {
            int i = Convert.ToInt16(mo["ServicePhilosophy"]);
            switch (i)
            {
                case 0:
                    return "Unknown";
                case 1:
                    return "Other";
                case 2:
                    return "Service From Top";
                case 3:
                    return "Service From Front";
                case 4:
                    return "Service From Back";
                case 5:
                    return "Service From Side";
                case 6:
                    return "Sliding Trays";
                case 7:
                    return "Removable Sides";
                case 8:
                    return "Moveable";
            }
            return "Service philosophy not defined.";
        }
        //----------------------------------------------------------
        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text = GetDriveTemp();
        }

        public string GetDriveTemp()
        {
            string ret = "Nulll";
            const byte TEMPERATURE_ATTRIBUTE = 194;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    byte[] arrVendorSpecific = (byte[])queryObj.GetPropertyValue("VendorSpecific");
                    //Find the temperature attribute
                    int tempIndex = Array.IndexOf(arrVendorSpecific, TEMPERATURE_ATTRIBUTE);
                    ret = "Температура HDD " + arrVendorSpecific[tempIndex + 5].ToString() + " С°";
                    return ret;
                }
            }
            catch (ManagementException err)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + err.Message);
            }
            return ret;
        }
        //----------------------------------------------------------
        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = Load();
        }
        private string Load()
        {
            string ret = "Null";
            ManagementClass class1 = new ManagementClass("Win32_Processor");
            foreach (ManagementObject ob in class1.GetInstances())
            {
                ret ="Name - " + ob.GetPropertyValue("Name").ToString().Trim();
                ret += "\n Status - " + ob.GetPropertyValue("Status");
                object percents = ob.GetPropertyValue("LoadPercentage");
                if (percents != null)
                    ret += "\n LoadPercentage - " + percents;
                else
                    ret += "\n LoadPercentage - null";
                return ret;
            }
            return ret;
            }
        //----------------------------------------------------------
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text = LoadOP();
        }
        private string LoadOP()
        {
            string ret = "Null";
            MEMORYSTATUSEX msex = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(msex))
            {
                ret = "Всего памяти " + msex.ullTotalPhys / 1024 / 1024 + " MB" + 
                "\nДоступно памяти " + msex.ullAvailPhys / 1024 / 1024 + " MB";
            }
            return ret;
        }
        //----------------------------------------------------------
        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text = HDDParts();
        }
        private string HDDParts()
        {
            string ret = "";
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    ret += "Drive " + d.Name;
                    ret +="\n File type: "+ d.DriveType;
                    if (d.IsReady == true)
                    {
                        ret +="\n Volume label: " + d.VolumeLabel;
                        ret +="\n File system: " + d.DriveFormat;
                        ret +="\n Available space to current user: "+ d.AvailableFreeSpace+" bytes";
                        ret += "\n Total available space: " + d.TotalFreeSpace + " bytes";
                        ret += "\n Total size of drive: " + d.TotalSize + " bytes" + "\n\n";
                    }
                }
            return ret;
        }
        //----------------------------------------------------------
         [DllImport("winmm.dll")] 
	     static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);
        
        private void button19_Click(object sender, EventArgs e)
        {
            // не забудьте указать букву сидюка :-)
            mciSendString("open F: type CDAudio alias driveF", null, 0, IntPtr.Zero);
            mciSendString("set driveF door open", null, 0, IntPtr.Zero);
            // mciSendString("set driveG door closed", null, 0, IntPtr.Zero); // закрыть лоток
        }
        //----------------------------------------------------------
        private void button20_Click(object sender, EventArgs e)
        {
            label1.Text="";
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                label1.Text += strPrinter + '\n';
            }
        }
        //----------------------------------------------------------
        private void button21_Click(object sender, EventArgs e)
        {
            HDDList.Visible = true;
            HDDList.Enabled = true;
          ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"); 
	      foreach (ManagementObject moDisk in mosDisks.Get()) 
          {
              HDDList.Items.Add(moDisk["Model"].ToString());
	      }
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" + HDDList.SelectedItem + "'"); 
         foreach (ManagementObject moDisk in mosDisks.Get()) 
	      { 
	            label1.Text = "Type: " + moDisk["MediaType"].ToString();
                label1.Text += "\nModel: " + moDisk["Model"].ToString();
                label1.Text += "\nSerial: " + moDisk["SerialNumber"].ToString();
                label1.Text += "\nInterface: " + moDisk["InterfaceType"].ToString();
                label1.Text += "\nCapacity: " + moDisk["Size"].ToString() + " bytes (" + Math.Round(((((double)Convert.ToDouble(moDisk["Size"]) / 1024) / 1024) / 1024), 2) + " GB)";
                label1.Text += "\nPartitions: " + moDisk["Partitions"].ToString();
                label1.Text += "\nSignature: " + moDisk["Signature"].ToString();
                label1.Text += "\nFirmware: " + moDisk["FirmwareRevision"].ToString();
                label1.Text += "\nCylinders: " + moDisk["TotalCylinders"].ToString();
                label1.Text += "\nSectors: " + moDisk["TotalSectors"].ToString();
                label1.Text += "\nHeads: " + moDisk["TotalHeads"].ToString();
                label1.Text += "\nTracks: " + moDisk["TotalTracks"].ToString();
                label1.Text += "\nBytes per Sector: " + moDisk["BytesPerSector"].ToString();
                label1.Text += "\nSectors per Track: " + moDisk["SectorsPerTrack"].ToString();
                label1.Text += "\nTracks per Cylinder: " + moDisk["TracksPerCylinder"].ToString();
	      }
        }
        //----------------------------------------------------------
        private void button22_Click(object sender, EventArgs e)
        {
            label1.Text ="Доступ в интернет :   " + ConnectionAvailable("http://www.google.com").ToString();
        }
        public bool ConnectionAvailable(string strServer)
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);

                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Интернет безусловно есть! 
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // сервер вернул отрицательный ответ, возможно что инета нет
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Ошибка, значит интернета у нас нет. Плачем :'(
                return false;
            }
        }

    }
}
