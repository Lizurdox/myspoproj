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
using System.Runtime.InteropServices;
//using GetCoreTempInfoNET;
using System.Collections;
using System.Threading;

delegate void AddText(string text);
namespace ProjSPO
{   
    public partial class Form1 : Form
    {
        Thread thr1, thr2, thr3,thr4;
        public Form1()
        {
            InitializeComponent();
            HDDList.Enabled = false;
            HDDList.Visible = false;
            listBox1.Visible = false;
            listBox1.Enabled = false;
            Threads();
        }
        public void Threads()
        {
            thr1 = new Thread(GetDriveTemp);
            thr2 = new Thread(LoadOP);
            thr3 = new Thread(Load);
            thr4 = new Thread(Test);
        }
        private void AddTextLabel1(string text)//хитрая добавлялка на основе делегата т.к. в др потоке не доступны все наши лейблы и др элементы
        {
            try
            {
                if (this.label1.InvokeRequired) //если этот метод AddTextLabel2 вызван из ДРУГОГО ПОТОКА (т.е. если мы хотим обратиться к лейбл2 из др потока)
                {
                    AddText d = new AddText(AddTextLabel1);   //заводим делегата(т.е. переменную делегатного типа AddText),который будет вызывать этуже функцию AddTextLabel2
                    this.Invoke(d, new object[] { text });   //invoke выполняет указанный делегат(d) в том потоке которому принадлежит список оргументов т.е. т.к. object принадлежит основному потоку то делегат будет выполнен в этом потоке,и делегат вызовет опять этуже функцию AddTextLabel2
                }
                else     //т.к. выше делегат вызывает эту же функцию но уже в основном потоке (с помощью Invoke)
                {          //то просто выводим текст на лэйбл 2 т.к. мы уже в основном потоке
                    this.label1.Text = text;
                }
            }
            catch(Exception Ex)
            {
            }
        }
        //-----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = VideoCard() + "\n";
            RegistryKey RegKey = Registry.LocalMachine;
            RegKey = RegKey.OpenSubKey("SOFTWARE\\Microsoft\\DirectX");
            Object DXVer = RegKey.GetValue("Version");
            label1.Text+= DXVer.ToString();
        }
        private string VideoCard()
        {
            string Vid = "null";
            ObjectQuery objectQuery_Video = new ObjectQuery("select * from Win32_VideoController");
            ManagementObjectSearcher searcherVideo = new ManagementObjectSearcher(objectQuery_Video);
            ManagementObjectCollection valsVideo = searcherVideo.Get();

            foreach (ManagementObject ss in valsVideo)
            {
                try { Vid = "Название : " + ss.GetPropertyValue("Name").ToString(); }
                catch (Exception) { }
                try { Vid += "\nВидео процессор : " + ss.GetPropertyValue("VideoProcessor").ToString(); }
                catch (Exception) { }
                try { Vid += "\nАдаптер RAM : " + ss.GetPropertyValue("AdapterRAM").ToString(); }
                catch (Exception) { }
                try { Vid += "\nОписание видеорежима : " + ss.GetPropertyValue("VideoModeDescription").ToString(); }
                catch (Exception) { }
                try { Vid += "\nAdapterCompatibility : " + ss.GetPropertyValue("AdapterCompatibility").ToString(); }
                catch (Exception) { }
                try { Vid += "\nAdapterDACType : " + ss.GetPropertyValue("AdapterDACType").ToString(); }
                catch (Exception) { }
                try { Vid += "\nAvailability : " + ss.GetPropertyValue("Availability").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCaption : " + ss.GetPropertyValue("Caption").ToString(); }
                catch (Exception) { }
                // Vid += "ColorTableEntries : " + ss.GetPropertyValue("ColorTableEntries").ToString();
                try { Vid += "\nConfigManagerErrorCode : " + ss.GetPropertyValue("ConfigManagerErrorCode").ToString(); }
                catch (Exception) { }
                try { Vid += "\nConfigManagerUserConfig : " + ss.GetPropertyValue("ConfigManagerUserConfig").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCreationClassName : " + ss.GetPropertyValue("CreationClassName").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentBitsPerPixel : " + ss.GetPropertyValue("CurrentBitsPerPixel").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentHorizontalResolution : " + ss.GetPropertyValue("CurrentHorizontalResolution").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentNumberOfColors : " + ss.GetPropertyValue("CurrentNumberOfColors").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentNumberOfColumns : " + ss.GetPropertyValue("CurrentNumberOfColumns").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentNumberOfRows : " + ss.GetPropertyValue("CurrentNumberOfRows").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentRefreshRate : " + ss.GetPropertyValue("CurrentRefreshRate").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentScanMode : " + ss.GetPropertyValue("CurrentScanMode").ToString(); }
                catch (Exception) { }
                try { Vid += "\nCurrentVerticalResolution : " + ss.GetPropertyValue("CurrentVerticalResolution").ToString(); }
                catch (Exception) { }
                try { Vid += "\nDescription : " + ss.GetPropertyValue("Description").ToString(); }
                catch (Exception) { }
                try { Vid += "\nDeviceID : " + ss.GetPropertyValue("DeviceID").ToString(); }
                catch (Exception) { }
                //    Vid += "DeviceSpecificPens : " + ss.GetPropertyValue("DeviceSpecificPens").ToString();
                try { Vid += "\nDitherType : " + ss.GetPropertyValue("DitherType").ToString(); }
                catch (Exception) { }
                try { Vid += "\nDriverDate : " + ss.GetPropertyValue("DriverDate").ToString(); }
                catch (Exception) { }
                try { Vid += "\nDriverVersion : " + ss.GetPropertyValue("DriverVersion").ToString(); }
                catch (Exception) { }
                //  Vid += " ErrorCleared : " + ss.GetPropertyValue("ErrorCleared").ToString();
                //    Vid += "ErrorDescription : " + ss.GetPropertyValue("ErrorDescription").ToString();
                //    Vid += "ICMIntent : " + ss.GetPropertyValue("ICMIntent").ToString();
                //      Vid += "ICMMethod : " + ss.GetPropertyValue("ICMMethod").ToString();
                try { Vid += "\nInfFilename : " + ss.GetPropertyValue("InfFilename").ToString(); }
                catch (Exception) { }
                try { Vid += "\nInfSection : " + ss.GetPropertyValue("InfSection").ToString(); }
                catch (Exception) { }
                //   Vid += "InstallDate : " + ss.GetPropertyValue("InstallDate").ToString();
                //Vid += "InstalledDisplayDrivers : " + ss.GetPropertyValue("InstalledDisplayDriverse").ToString();
                //    Vid += "\nLastErrorCode : " + ss.GetPropertyValue("LastErrorCode").ToString();
                //    Vid += "\nMaxMemorySupported : " + ss.GetPropertyValue("MaxMemorySupported").ToString();
                //     Vid += "\nMaxNumberControlled : " + ss.GetPropertyValue("MaxNumberControlled").ToString();
                try { Vid += "\nMaxRefreshRate : " + ss.GetPropertyValue("MaxRefreshRate").ToString(); }
                catch (Exception) { }
                try { Vid += "\nMinRefreshRate : " + ss.GetPropertyValue("MinRefreshRate").ToString(); }
                catch (Exception) { }
                try { Vid += "\nMonochrome : " + ss.GetPropertyValue("Monochrome").ToString(); }
                catch (Exception) { }
                try { Vid += "\nName : " + ss.GetPropertyValue("Name").ToString(); }
                catch (Exception) { }
                //  Vid += "\nNumberOfColorPlanes : " + ss.GetPropertyValue("NumberOfColorPlanes").ToString();
                //  Vid += "\nNumberOfVideoPages : " + ss.GetPropertyValue("NumberOfVideoPages").ToString();
                try { Vid += "\nPNPDeviceID : " + ss.GetPropertyValue("PNPDeviceID").ToString(); }
                catch (Exception) { }
                // Vid += "\nPowerManagementSupported : " + ss.GetPropertyValue("PowerManagementSupported").ToString();
                //  Vid += "\nProtocolSupported : " + ss.GetPropertyValue("ProtocolSupported").ToString();
                //  Vid += "\nReservedSystemPaletteEntries : " + ss.GetPropertyValue("ReservedSystemPaletteEntries").ToString();
                //  Vid += "\nSpecificationVersion : " + ss.GetPropertyValue("SpecificationVersion").ToString();
                try { Vid += "\nStatus : " + ss.GetPropertyValue("Status").ToString(); }
                catch (Exception) { }
                // Vid += "\nStatusInfo : " + ss.GetPropertyValue("StatusInfo").ToString();
                try { Vid += "\nSystemCreationClassName : " + ss.GetPropertyValue("SystemCreationClassName").ToString(); }
                catch (Exception) { }
                try { Vid += "\nSystemName : " + ss.GetPropertyValue("SystemName").ToString(); }
                catch (Exception) { }
                //  Vid += "\nSystemPaletteEntries : " + ss.GetPropertyValue("SystemPaletteEntries").ToString();
                //  Vid += "\nTimeOfLastReset : " + ss.GetPropertyValue("TimeOfLastReset").ToString();
                try { Vid += "\nVideoArchitecture : " + ss.GetPropertyValue("VideoArchitecture").ToString(); }
                catch (Exception) { }
                try { Vid += "\nVideoMemoryType : " + ss.GetPropertyValue("VideoMemoryType").ToString(); }
                catch (Exception) { }
                try { Vid += "\nVideoModeDescription : " + ss.GetPropertyValue("VideoModeDescription").ToString(); }
                catch (Exception) { }
                try { Vid += "\nVideoProcessor : " + ss.GetPropertyValue("VideoProcessor").ToString(); }
                catch (Exception) { }
                //Vid += "\nVideoMode : " + ss.GetPropertyValue("VideoMode").ToString();

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
            string ret = "null";
            string myHost = System.Net.Dns.GetHostName();
            ret = "Хост " + myHost;
            ret += "\nIP адрес" + System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();

            ObjectQuery objectQuery_Network = new ObjectQuery("select * from Win32_NetworkConnection");
            ManagementObjectSearcher searcherNetwork = new ManagementObjectSearcher(objectQuery_Network);
            ManagementObjectCollection valsNetwork = searcherNetwork.Get();
            foreach (ManagementObject ss in valsNetwork)
            {
               try { ret += "AccessMask: " + ss.GetPropertyValue("AccessMask").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "Caption: " + ss.GetPropertyValue("Caption").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "Comment: " + ss.GetPropertyValue("Comment").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "ConnectionState: " + ss.GetPropertyValue("ConnectionState").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "ConnectionType: " + ss.GetPropertyValue("ConnectionType").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "Description: " + ss.GetPropertyValue("Description").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "DisplayType: " + ss.GetPropertyValue("DisplayType").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "InstallDate: " + ss.GetPropertyValue("InstallDate").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "LocalName: " + ss.GetPropertyValue("LocalName").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "Name: " + ss.GetPropertyValue("Name").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "Persistent: " + ss.GetPropertyValue("Persistent").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "ProviderName: " + ss.GetPropertyValue("ProviderName").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "RemoteName: " + ss.GetPropertyValue("RemoteName").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "RemotePath: " + ss.GetPropertyValue("RemotePath").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "ResourceType: " + ss.GetPropertyValue("ResourceType").ToString() + '\n';}
                catch (Exception) { }
               try {  ret += "Status: " + ss.GetPropertyValue("Status").ToString() + '\n';}
                catch (Exception) { }
               try { ret += "UserName: " + ss.GetPropertyValue("UserName").ToString(); }
               catch (Exception) { }
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
                "Caption " + mo["Caption"] + '\n' +
                "SKUNumber " + mo["SKUNumber"] + '\n' +
                "Version " + mo["Version"] + '\n' +
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
                "Captionе " + mo["Caption"] + '\n' +
                "ConfigurationPath" + mo["ConfigurationPath"] + '\n' +
                "LastDrive " + mo["LastDrive"] + '\n' +
                "Name" + mo["Name"] + '\n' +
                "SettingID " + mo["SettingID"] + '\n' +
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
            try
            {
                foreach (ManagementObject mo in find.Get())
                {
                    ret = "Компьютер относиться к домену " + mo["Domain"].ToString();
                   ret += "\nПроизводитель" + mo["Manufacturer"].ToString();
                   ret += "\nAdminPasswordStatus" + mo["AdminPasswordStatus"].ToString();
                   ret += "\nAutomaticManagedPagefile" + mo["AutomaticManagedPagefile"].ToString();
                   ret += "\nAutomaticResetBootOption" + mo["AutomaticResetBootOption"].ToString();
                   ret += "\nAutomaticResetCapability" + mo["AutomaticResetCapability"].ToString();
                  // ret += "\nBootOptionOnLimit" + mo["BootOptionOnLimit"].ToString();
                 //  ret += "\nПBootOptionOnWatchDog" + mo["BootOptionOnWatchDog"].ToString();
                   ret += "\nBootROMSupported" + mo["BootROMSupported"].ToString();
                   ret += "\nBootupState" + mo["BootupState"].ToString();
                   ret += "\nCaption" + mo["Caption"].ToString();
                   ret += "\nChassisBootupState" + mo["ChassisBootupState"].ToString();
                   ret += "\nCreationClassName" + mo["CreationClassName"].ToString();
                   ret += "\nCurrentTimeZone" + mo["CurrentTimeZone"].ToString();
                   ret += "\nDaylightInEffect" + mo["DaylightInEffect"].ToString();
                   ret += "\nDescription" + mo["Description"].ToString();
                   ret += "\nDNSHostName" + mo["DNSHostName"].ToString();
                   ret += "\nDomain" + mo["Domain"].ToString();
                   ret += "\nDomainRole" + mo["DomainRole"].ToString();
                   ret += "\nEnableDaylightSavingsTime" + mo["EnableDaylightSavingsTime"].ToString();
                   ret += "\nFrontPanelResetStatus" + mo["FrontPanelResetStatus"].ToString();
                   ret += "\nInfraredSupported" + mo["InfraredSupported"].ToString();
                  // ret += "\nInitialLoadInfo" + mo["InitialLoadInfo"].ToString();
                  // ret += "\nInstallDate" + mo["InstallDate"].ToString();
                   ret += "\nKeyboardPasswordStatus" + mo["KeyboardPasswordStatus"].ToString();
                  // ret += "\nLastLoadInfo" + mo["LastLoadInfo"].ToString();
                   ret += "\nModel" + mo["Model"].ToString();
                   ret += "\nName" + mo["Name"].ToString();
                  // ret += "\nNameFormat" + mo["NameFormat"].ToString();
                   ret += "\nNetworkServerModeEnabled" + mo["NetworkServerModeEnabled"].ToString();
                   ret += "\nNumberOfLogicalProcessors" + mo["NumberOfLogicalProcessors"].ToString();
                   ret += "\nNumberOfProcessors" + mo["NumberOfProcessors"].ToString();
                   ret += "\nPartOfDomain" + mo["PartOfDomain"].ToString();
                   ret += "\nPauseAfterReset" + mo["PauseAfterReset"].ToString();
                   ret += "\nPCSystemType" + mo["PCSystemType"].ToString();
                 //  ret += "\nPowerManagementSupported" + mo["PowerManagementSupported"].ToString();
                   ret += "\nPowerOnPasswordStatus" + mo["PowerOnPasswordStatus"].ToString();
                   ret += "\nPowerState" + mo["PowerState"].ToString();
                   ret += "\nPowerSupplyState" + mo["PowerSupplyState"].ToString();
                  // ret += "\nPrimaryOwnerContact" + mo["PrimaryOwnerContact"].ToString();
                   ret += "\nPrimaryOwnerName" + mo["PrimaryOwnerName"].ToString();
                   ret += "\nResetCapability" + mo["ResetCapability"].ToString();
                 //  ret += "\nSystemStartupDelay" + mo["SystemStartupDelay"].ToString();
                   ret += "\nSystemType" + mo["SystemType"].ToString();
                   ret += "\nThermalState" + mo["ThermalState"].ToString();
                   ret += "\nTotalPhysicalMemory" + mo["TotalPhysicalMemory"].ToString();
                   ret += "\nUserName" + mo["UserName"].ToString();
                   ret += "\nWakeUpType" + mo["WakeUpType"].ToString();
                   ret += "\nWorkgroup" + mo["Workgroup"].ToString();
                   ret += "\nИмя модели, данное производителем " + mo["Model"].ToString(); ;
                    return ret;
                }
            }
            catch (Exception ex)
            {
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
                "Manufacturer " + mo["Manufacturer"] + '\n' +
                "DeviceID " + mo["DeviceID"] + '\n' +
                "NumberOfCores " + mo["NumberOfCores"] + '\n' +
                "NumberOfLogicalProcessors " + mo["NumberOfLogicalProcessors"] + '\n' +
                "OtherFamilyDescription " + mo["OtherFamilyDescription"] + '\n' +
                "PNPDeviceID " + mo["PNPDeviceID"] + '\n' +
                "ProcessorId " + mo["ProcessorId"] + '\n' +
                "ProcessorType " + mo["ProcessorType"] + '\n' +
                "Role " + mo["Role"] + '\n' +
                "SocketDesignation " + mo["SocketDesignation"] + '\n' +
                "Stepping " + mo["Stepping"] + '\n' +
                "SystemName " + mo["SystemName"] + '\n' +
                "UniqueId " + mo["UniqueId"] + '\n' +
                "UpgradeMethod " + mo["UpgradeMethod"] + '\n' +
                "Version " + mo["Version"] + '\n' +
                "Processor address width in bits." + mo["AddressWidth"] + '\n' +
                "Usage status of the processor." + GetCpuStatus(mo) + '\n' +
                "Current clock speed (in MHz)." + mo["CurrentClockSpeed"] + '\n' +
                "MaxClockSpeed (in MHz)." + mo["MaxClockSpeed"] + '\n' +
                "Processor data width." + mo["DataWidth"] + '\n' +
                "Unique string identification." + mo["DeviceID"] + '\n' +
                "External clock frequency." + mo["ExtClock"] + '\n' +
                "Processor family." + GetFamily(mo) + '\n' +
                "L2 cache size." + mo["L2CacheSize"] + '\n' +
                "L2 cache speed." + mo["L2CacheSpeed"] + '\n' +
                "L3 cache size." + mo["L3CacheSize"] + '\n' +
                "L3 cache speed." + mo["L3CacheSpeed"] + '\n' +
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
                "VoltageCaps " + mo["VoltageCaps"] + '\n' +
                "CurrentVoltage " + mo["CurrentVoltage"] + '\n' +
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
           //label1.Text = GetDriveTemp();
        }

        public void GetDriveTemp()
        {
            string ret = "Nulll";
            const byte TEMPERATURE_ATTRIBUTE = 194;
            do
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        byte[] arrVendorSpecific = (byte[])queryObj.GetPropertyValue("VendorSpecific");
                        //Find the temperature attribute
                        int tempIndex = Array.IndexOf(arrVendorSpecific, TEMPERATURE_ATTRIBUTE);
                        ret = "Температура HDD " + arrVendorSpecific[tempIndex + 5].ToString() + " С°";
                    }
                }
                catch (ManagementException err)
                {
                    Console.WriteLine("An error occurred while querying for WMI data: " + err.Message);
                }
                AddTextLabel1(ret);
            } while (true);
        }
        //----------------------------------------------------------
        private void button16_Click(object sender, EventArgs e)
        {
            //label1.Text = Load();
        }
        private void Load()
        {
            do
            {
                string ret = "Null";
                ManagementClass class1 = new ManagementClass("Win32_Processor");
                foreach (ManagementObject ob in class1.GetInstances())
                {
                    ret = "Name - " + ob.GetPropertyValue("Name").ToString().Trim();
                    ret += "\n Status - " + ob.GetPropertyValue("Status");
                    object percents = ob.GetPropertyValue("LoadPercentage");
                    if (percents != null)
                        ret += "\n LoadPercentage - " + percents;
                    else
                        ret += "\n LoadPercentage - null";

                }
                AddTextLabel1(ret);
            } while (true);
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
          //  label1.Text = LoadOP();
        }
        private void LoadOP()
        {
            do
            {
                string ret = "Null";
                MEMORYSTATUSEX msex = new MEMORYSTATUSEX();
                if (GlobalMemoryStatusEx(msex))
                {
                    ret = "Всего памяти " + msex.ullTotalPhys / 1024 / 1024 + " MB" +
                    "\nДоступно памяти " + msex.ullAvailPhys / 1024 / 1024 + " MB";
                }
                AddTextLabel1(ret);
            } while (true);
            //return ret;
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
                label1.Text += "\nName: " + moDisk["Name"].ToString();
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

              //  label1.Text += "\nCompressionMethod: " + moDisk["CompressionMethod"].ToString();
                //label1.Text += "\nDefaultBlockSize: " + moDisk["DefaultBlockSize"].ToString();
                label1.Text += "\nDescription: " + moDisk["Description"].ToString();
                label1.Text += "\nDeviceID: " + moDisk["DeviceID"].ToString();
                label1.Text += "\nManufacturer: " + moDisk["Manufacturer"].ToString();
               // label1.Text += "\nMaxBlockSize: " + moDisk["MaxBlockSize"].ToString();
                //label1.Text += "\nMaxMediaSize: " + moDisk["MaxMediaSize"].ToString();
               // label1.Text += "\nMinBlockSize: " + moDisk["MinBlockSize"].ToString();
                label1.Text += "\nPNPDeviceID: " + moDisk["PNPDeviceID"].ToString();
                //label1.Text += "\nSCSIBus: " + moDisk["SCSIBus"].ToString();
                label1.Text += "\nSCSILogicalUnit: " + moDisk["SCSILogicalUnit"].ToString();

                label1.Text += "\nSCSIPort: " + moDisk["SCSIPort"].ToString();
                label1.Text += "\nSCSITargetId: " + moDisk["SCSITargetId"].ToString();
                label1.Text += "\nSerialNumber: " + moDisk["SerialNumber"].ToString();
                label1.Text += "\nSystemName: " + moDisk["SystemName"].ToString();
                label1.Text += "\nManufacturer: " + moDisk["Manufacturer"].ToString();

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
        //----------------------------------------------------------
        private void button23_Click(object sender, EventArgs e)
        {
           
            label1.Text = Bios();
        }
        private string Bios()
        {
            string ret = "Null";
            ObjectQuery objectQuery_BIOS = new ObjectQuery("select * from Win32_BIOS");

            ManagementObjectSearcher searcherBIOS = new ManagementObjectSearcher(objectQuery_BIOS);
            ManagementObjectCollection valsBIOS = searcherBIOS.Get();

            foreach (ManagementObject val in valsBIOS)
            { 
                try{ret = "Name = " + Convert.ToString(val.GetPropertyValue("Name")); }catch(Exception ){}
                 try{ret += "\nManufacturer = " + Convert.ToString(val.GetPropertyValue("Manufacturer")); }catch(Exception ){}
                 try{ret += "\nVersion = " + Convert.ToString(val.GetPropertyValue("Version")); }catch(Exception ){}
                 try{ret += "\nReleaseDate = " + Convert.ToString(val.GetPropertyValue("ReleaseDate")); }catch(Exception ){}
                 try{ret += "\nBuildNumber = " + Convert.ToString(val.GetPropertyValue("BuildNumber")); }catch(Exception ){}
                 try{ret += "\nCaption" + Convert.ToString(val.GetPropertyValue("Caption")); }catch(Exception ){}
                 try{ret += "\nCodeSet = " + Convert.ToString(val.GetPropertyValue("CodeSet")); }catch(Exception ){}
                 try{ret += "\nCurrentLanguage = " + Convert.ToString(val.GetPropertyValue("CurrentLanguage")); }catch(Exception ){}
                 try{ret += "\nSerialNumberr = " + Convert.ToString(val.GetPropertyValue("SerialNumber")); }catch(Exception ){}
                 try{ret += "\nIdentificationCode = " + Convert.ToString(val.GetPropertyValue("IdentificationCode")); }catch(Exception ){}
                 try{ret += "\nDescription = " + Convert.ToString(val.GetPropertyValue("Description")); }catch(Exception ){}
                 try{ret += "\nLanguageEdition = " + Convert.ToString(val.GetPropertyValue("LanguageEdition")); }catch(Exception ){}
                 try{ret += "\nStatus = " + Convert.ToString(val.GetPropertyValue("Status")); }catch(Exception ){}
                 try{ret += "\nOtherTargetOS = " + Convert.ToString(val.GetPropertyValue("OtherTargetOS")); }catch(Exception ){}
                 try{ret += "\nInstallDate = " + Convert.ToString(val.GetPropertyValue("InstallDate")); }catch(Exception ){}
                 try{ret += "\nSMBIOSBIOSVersion = " + Convert.ToString(val.GetPropertyValue("SMBIOSBIOSVersion")); }catch(Exception ){}
                 try { ret += "\nSoftwareElementID = " + Convert.ToString(val.GetPropertyValue("SoftwareElementID")); }
                 catch (Exception) { }


            }
            return ret;
        }
        //----------------------------------------------------------
        private void button24_Click(object sender, EventArgs e)
        {
            Test();
        }
        private void Test()
        {
            SinCalculator Test = new SinCalculator(2000);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int u = 0; u < 500; u++)
            {
                Random rand = new Random();
                int[] mas1 = new int[1000];
                double[] mas2 = new double[1000];
                for (int i = 0; i < 1000; i++)
                {
                    mas1[i] = rand.Next();
                    mas2[i] = rand.NextDouble();
                }

                for (int i = mas1.Length - 1; i > 0; i--)
                    for (int j = 0; j < i; j++)
                        if (mas1[j] > mas1[j + 1])
                        {
                            double t = mas2[i];
                            mas2[i] = mas2[mas2.Length - i];
                            mas2[mas2.Length - i] = t;
                            int tmp = mas1[j];
                            mas1[j] = mas1[j + 1];
                            mas1[j + 1] = tmp;
                        }
                ///////////////

                for (int i = 0; i < 200; i++)
                    Test.Sin(20).ToString(); 
            }
            sw.Stop();
            TimeSpan ts;
            ts = sw.Elapsed;
            AddTextLabel1(ts.ToString());
        }
        public class SinCalculator
        {
            const double PIMul2 = Math.PI * 2.0;
            const double PIDiv2 = Math.PI / 2.0;

            double[] _table;
            double _coef;

            public SinCalculator(int tableSize)
            {
                _coef = PIDiv2 / tableSize;
                double[] table = new double[tableSize];
                for (int i = 0; i < table.Length; ++i)
                {
                    table[i] = Math.Sin(_coef * i);
                }
                _table = table;
            }

            public double Sin(double a)
    {
        // Используем свойства синуса для некоторого уменьшения размера таблицы.
        // Если будет сильно медленно, то можно просто таблицу сделать побольше в 4 раза
        if (a < 0) return -Sin(-a);
 
        a = a - Math.Truncate(a / PIMul2) * PIMul2;
        if (a > Math.PI) return -Sin(a - Math.PI);
        if (a > PIDiv2) return Sin(Math.PI - a);
 
        // Тут собственно возвращаем ближайшее из таблички
        return _table[(int)Math.Round(a / _coef)];
    }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            label1.Text = Installed();
        }
        private string Installed()
        {
            string ret = "";
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            string[] skeys = key.GetSubKeyNames(); // Все подключи из key
            int length = skeys.Length;
            // Проход по всем подключам
            for (int i = 0; i < length; i++)
            {
                // Получаем очередной подключ
                RegistryKey appKey = key.OpenSubKey(skeys[i]);
                string name;

                try // Пробуем получить значение DisplayName
                {
                    name = appKey.GetValue("DisplayName").ToString();
                }
                catch (Exception)
                {
                    // Если не указано имя, то пропускаем ключ
                    continue;
                }
                ret += name + "\n";
                appKey.Close();
            }
            key.Close();
            return ret;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Services();
            listBox1.Enabled = true;
            listBox1.Visible = true;
        }
        ArrayList arrServices = new ArrayList();
        private string Services()
        {
            string ret = "Null";
            // Create a new ManagementClass object binded to the Win32_Service WMI class
            ManagementClass mcServices = new ManagementClass("Win32_Service");

            // Loop through each service
            foreach (ManagementObject moService in mcServices.GetInstances())
            {
                // Create a new array that holds the ListBox item ID and service name
                string[] srvArray = new string[2];
                srvArray[0] = listBox1.Items.Add(moService.GetPropertyValue("Caption").ToString()).ToString();
                srvArray[1] = moService.GetPropertyValue("Name").ToString();
                // Store the array in the ArrayList
                arrServices.Add(srvArray);
            }
            return ret;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            ManagementClass mcServices = new ManagementClass("Win32_Service");
            // Loop through each service
            foreach (ManagementObject moService in mcServices.GetInstances())
            {
                // Get back the array with the index of the selected ListBox item from the ArrayList
                string[] srvArray = (string[])arrServices[listBox1.SelectedIndex];
                // If the current service name
                if (moService.GetPropertyValue("Name").ToString() == srvArray[1])
                {
                    // Set the fields accordingly
                    label1.Text = "\n\n" + moService.GetPropertyValue("Description").ToString();
                    label1.Text += "\nPath: " + moService.GetPropertyValue("PathName");
                    label1.Text += "\nType: " + moService.GetPropertyValue("ServiceType");
                    label1.Text += "\nState:  " + moService.GetPropertyValue("State");
                    label1.Text += "\nStart-up Type:  " + moService.GetPropertyValue("StartMode");
                }
            }
        }
        //----------------------------------------------------------
        private void button27_Click(object sender, EventArgs e)
        {
            label1.Text = USBList();
        }
        private string USBList()
        {
            string ret = "";

            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
            foreach (var device in searcher.Get())
            {

                ret += (string)device.GetPropertyValue("DeviceID") + "\n" +
                (string)device.GetPropertyValue("PNPDeviceID") + "\n" +
                (string)device.GetPropertyValue("Description") + "\n\n";
            }

            return ret;
        }
        //----------------------------------------------------------
        private void button28_Click(object sender, EventArgs e)
        {
            label1.Text = SysFonts();
        }
        private string SysFonts()
        {
            string ret = "";
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily font in fonts.Families)
            {  
                ret += font.Name + "\n";
            }
            return ret;
        }
        //----------------------------------------------------------
        private void button29_Click(object sender, EventArgs e)
        {
            label1.Text = Process();
        }
        private string Process()
        {
            string ret = "";
            System.Diagnostics.Process[] processes= System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
               ret+= instance.ProcessName+".exe" + "\n";
            }
            return ret;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GC.Collect();
             
            if (thr1.IsAlive == true)
            {
                thr1.Suspend();
            }
            if (thr2.IsAlive == true)
            {
                thr2.Suspend();
            }
            if (thr3.IsAlive == true)
            {
                thr3.Suspend();
            }
            if (thr4.IsAlive == true)
            {
                thr4.Suspend();
            }
            if(treeView1.SelectedNode.Text=="Рабочий стол")
                label1.Text = Desktop();
            if(treeView1.SelectedNode.Text=="ОС")
                label1.Text = OperSys();
            if(treeView1.SelectedNode.Text=="Идентификация ПК")
                label1.Text = Ident();
            if (treeView1.SelectedNode.Text == "Загрузка ОС")
                label1.Text = Boot();
            if (treeView1.SelectedNode.Text == "Окружение")
                label1.Text = Environment();
            if (treeView1.SelectedNode.Text == "Шрифты")
                label1.Text = SysFonts();
            if (treeView1.SelectedNode.Text == "Службы")
            {
                Services();
                listBox1.Enabled = true;
                listBox1.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Принтеры")
            {
                label1.Text = "";
                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    label1.Text += strPrinter + '\n';
                }
            }
            if (treeView1.SelectedNode.Text == "Программы") 
                label1.Text = Installed();
            if (treeView1.SelectedNode.Text == "Групповая политика")
                label1.Text = Group();

            
            if (treeView1.SelectedNode.Text == "Память")
                label1.Text = HDDParts();

            if (treeView1.SelectedNode.Text == "Процессор")
                label1.Text = Processor();

            if (treeView1.SelectedNode.Text == "Видеокарта")
            {
                label1.Text = VideoCard() + "\n";
                RegistryKey RegKey = Registry.LocalMachine;
                RegKey = RegKey.OpenSubKey("SOFTWARE\\Microsoft\\DirectX");
                Object DXVer = RegKey.GetValue("Version");
                label1.Text += DXVer.ToString();
            }
            if (treeView1.SelectedNode.Text == "Компьютерная система")
                 label1.Text = CompSys();
            if (treeView1.SelectedNode.Text == "Материнская плата")
                label1.Text = BaseBoard();
            if (treeView1.SelectedNode.Text == "SCSI контроллер")
                label1.Text = SCSIController();
            if (treeView1.SelectedNode.Text == "IDE контроллер")
                label1.Text = IDEContr();
            if (treeView1.SelectedNode.Text == "Видео конфигурация")
                label1.Text = VideoConfig();
            if (treeView1.SelectedNode.Text == "BIOS")
                label1.Text = Bios();
            if (treeView1.SelectedNode.Text == "Сетевой адаптер")
                label1.Text = LanAdapter();

            if (treeView1.SelectedNode.Text == "Температура HDD")
            {
                // label1.Text = GetDriveTemp();
                if (thr1.IsAlive != true) thr1.Start();
                if(thr1.ThreadState == ThreadState.Suspended) thr1.Resume();
            }
            if (treeView1.SelectedNode.Text == "Загрузка ОП")
            {
                //     label1.Text = LoadOP();
                if (thr2.IsAlive!=true) thr2.Start();
                if (thr2.ThreadState == ThreadState.Suspended) thr2.Resume();
            }
            if (treeView1.SelectedNode.Text == "Загрузка ЦП")
            {
                // label1.Text = Load();
                if (thr3.IsAlive != true) thr3.Start();
                if (thr3.ThreadState == ThreadState.Suspended) thr3.Resume();
            }
            if (treeView1.SelectedNode.Text == "Запущенные процессы")
                label1.Text = Process();
            if (treeView1.SelectedNode.Text == "Проверка интернет")
                label1.Text = "Доступ в интернет :   " + ConnectionAvailable("http://www.google.com").ToString();
            if (treeView1.SelectedNode.Text == "Сетевое соеденение")
                label1.Text = NetworkConnect();
            if (treeView1.SelectedNode.Text == "Тест")
            {
                if (thr4.IsAlive != true) thr4.Start();
                if (thr4.ThreadState == ThreadState.Suspended) thr4.Resume();
            }

            if (treeView1.SelectedNode.Text == "USB")
                 label1.Text = USBList();
            if (treeView1.SelectedNode.Text == "CDRom")
            { // не забудьте указать букву сидюка :-)
                mciSendString("open F: type CDAudio alias driveF", null, 0, IntPtr.Zero);
                mciSendString("set driveF door open", null, 0, IntPtr.Zero);
                // mciSendString("set driveG door closed", null, 0, IntPtr.Zero); // закрыть лоток
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = BaseBoard();
        }
        private string BaseBoard()
        {
            string ret="Null";

            ObjectQuery objectQuery_Board = new ObjectQuery("select * from Win32_BaseBoard");

            ManagementObjectSearcher searcherBoard = new ManagementObjectSearcher(objectQuery_Board);
            ManagementObjectCollection valsBoard = searcherBoard.Get();

            foreach (ManagementObject val in valsBoard)
            {
                try{ret = "Manufacturer = " + Convert.ToString(val.GetPropertyValue("Manufacturer")); }catch(Exception ){}
                try{ret += "\nSerialNumberr = " + Convert.ToString(val.GetPropertyValue("SerialNumber")); }catch(Exception ){}
                try{ret += "\nCaption = " + Convert.ToString(val.GetPropertyValue("Caption")); }catch(Exception ){}
                try{ret += "\nDescription = " + Convert.ToString(val.GetPropertyValue("Description")); }catch(Exception ){}
                try{ret += "\nStatus = " + Convert.ToString(val.GetPropertyValue("Status")); }catch(Exception ){}
                try{ret += "\nVersion = " + Convert.ToString(val.GetPropertyValue("Version")); }catch(Exception ){}
                try{ret += "\nInstallDate = " + Convert.ToString(val.GetPropertyValue("InstallDate")); }catch(Exception ){}
                try{ret += "\nCreationClassName = " + Convert.ToString(val.GetPropertyValue("CreationClassName")); }catch(Exception ){}
                try{ret += "\nModel = " + Convert.ToString(val.GetPropertyValue("Model")); }catch(Exception ){}
                try{ret += "\nName = " + Convert.ToString(val.GetPropertyValue("Name")); }catch(Exception ){}
                try{ret += "\nOtherIdentifyingInfo = " + Convert.ToString(val.GetPropertyValue("OtherIdentifyingInfo")); }catch(Exception ){}
                try{ret += "\nProduct = " + Convert.ToString(val.GetPropertyValue("Product")); }catch(Exception ){}
                try{ret += "\nSKU = " + Convert.ToString(val.GetPropertyValue("SKU")); }catch(Exception ){}
                try{ret += "\nSlotLayout = " + Convert.ToString(val.GetPropertyValue("SlotLayout")); }catch(Exception ){}
                try{ret += "\nTag = " + Convert.ToString(val.GetPropertyValue("Tag")); }catch(Exception ){}
                try{ret += "\nWeight = " + Convert.ToString(val.GetPropertyValue("Weight")); }catch(Exception ){}
                try{ret += "\nWidth = " + Convert.ToString(val.GetPropertyValue("Width")); }catch(Exception ){}
                try{ret += "\nPoweredOn = " + Convert.ToString(val.GetPropertyValue("PoweredOn")); }catch(Exception ){}
                try{ret += "\nHostingBoard = " + Convert.ToString(val.GetPropertyValue("HostingBoard")); }catch(Exception ){}
                try{ret += "\nHotSwappable = " + Convert.ToString(val.GetPropertyValue("HotSwappable")); }catch(Exception ){}
                try{ret += "\nDepth = " + Convert.ToString(val.GetPropertyValue("Depth")); }catch(Exception ){}
                try{ret += "\nHeightn = " + Convert.ToString(val.GetPropertyValue("Height")); }catch(Exception ){}
                try{ret += "\nRemovable = " + Convert.ToString(val.GetPropertyValue("Removable")); }catch(Exception ){}
                try { ret += "\nReplaceable = " + Convert.ToString(val.GetPropertyValue("Replaceable")); }
                catch (Exception) { }
            }

            return ret;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label1.Text = IDEContr();
        }
        private string IDEContr()
        {
            string ret = "Null";
            ObjectQuery objectQuery_IDE = new ObjectQuery("select * from Win32_IDEController");
            ManagementObjectSearcher searcherIDE = new ManagementObjectSearcher(objectQuery_IDE);
            ManagementObjectCollection valsIDE = searcherIDE.Get();
            foreach (ManagementObject val in valsIDE)
            {
               try{ ret = "Manufacturer " + Convert.ToString(val.GetPropertyValue("Manufacturer"));}catch(Exception ){}
               try{ ret += "\nName " + Convert.ToString(val.GetPropertyValue("Name"));}catch(Exception ){}
                try{ret += "\nDeviceID " + Convert.ToString(val.GetPropertyValue("DeviceID"));}catch(Exception ){}
                try{ret += "\nDescription " + Convert.ToString(val.GetPropertyValue("Description"));}catch(Exception ){}
                try{ret += "\nPNPDeviceID " + Convert.ToString(val.GetPropertyValue("PNPDeviceID"));}catch(Exception ){}
                try{ret += "\nSystemName " + Convert.ToString(val.GetPropertyValue("SystemName"));}catch(Exception ){}
                try{ret += "\nCaption " + Convert.ToString(val.GetPropertyValue("Caption"));}catch(Exception ){}
                try{ret += "\nCreationClassName " + Convert.ToString(val.GetPropertyValue("CreationClassName"));}catch(Exception ){}
                try{ret += "\nMaxNumberControlled " + Convert.ToString(val.GetPropertyValue("MaxNumberControlled"));}catch(Exception ){}
                try{ret += "\nPowerManagementCapabilities " + Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities"));}catch(Exception ){}
                try{ret += "\nPowerManagementSupported " + Convert.ToString(val.GetPropertyValue("PowerManagementSupported"));}catch(Exception ){}
                try{ret += "\nProtocolSupported " + Convert.ToString(val.GetPropertyValue("ProtocolSupported"));}catch(Exception ){}
                try{ret += "\nStatus " + Convert.ToString(val.GetPropertyValue("Status"));}catch(Exception ){}
                try{ret += "\nStatusInfo " + Convert.ToString(val.GetPropertyValue("StatusInfo"));}catch(Exception ){}
                try{ret += "\nSystemCreationClassName " + Convert.ToString(val.GetPropertyValue("SystemCreationClassName"));}catch(Exception ){}
                try { ret += "\nTimeOfLastReset " + Convert.ToString(val.GetPropertyValue("TimeOfLastReset")); }
                catch (Exception) { }
            }
            return ret;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label1.Text = SCSIController();
        }
        private string SCSIController()
        {
            string ret = "Null";
            ObjectQuery objectQuery_SCSI = new ObjectQuery("select * from Win32_SCSIController");
            ManagementObjectSearcher searcherSCSI = new ManagementObjectSearcher(objectQuery_SCSI);
            ManagementObjectCollection valsSCSI = searcherSCSI.Get();
            foreach (ManagementObject val in valsSCSI)
            {
               try{ ret = "Manufacturer " + Convert.ToString(val.GetPropertyValue("Manufacturer")); }catch(Exception ){}
               try{ ret += "\nName " + Convert.ToString(val.GetPropertyValue("Name"));}catch(Exception ){}
               try{ret += "\nDeviceID " + Convert.ToString(val.GetPropertyValue("DeviceID"));}catch(Exception ){}
               try{ret += "\nDescription " + Convert.ToString(val.GetPropertyValue("Description"));}catch(Exception ){}
               try{ ret += "\nPNPDeviceID " + Convert.ToString(val.GetPropertyValue("PNPDeviceID"));}catch(Exception ){}
               try{ret += "\nSystemName " + Convert.ToString(val.GetPropertyValue("SystemName"));}catch(Exception ){}
               try{ret += "\nCaption " + Convert.ToString(val.GetPropertyValue("Caption"));}catch(Exception ){}
               try{ret += "\nCreationClassName " + Convert.ToString(val.GetPropertyValue("CreationClassName"));}catch(Exception ){}
               try{ret += "\nMaxNumberControlled " + Convert.ToString(val.GetPropertyValue("MaxNumberControlled"));}catch(Exception ){}
               try{ret += "\nPowerManagementCapabilities " + Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities"));}catch(Exception ){}
               try{ ret += "\nPowerManagementSupported " + Convert.ToString(val.GetPropertyValue("PowerManagementSupported"));}catch(Exception ){}
               try{ ret += "\nProtocolSupported " + Convert.ToString(val.GetPropertyValue("ProtocolSupported"));}catch(Exception ){}
               try{ ret += "\nStatus " + Convert.ToString(val.GetPropertyValue("Status"));}catch(Exception ){}
               try{ ret += "\nStatusInfo " + Convert.ToString(val.GetPropertyValue("StatusInfo"));}catch(Exception ){}
               try{ret += "\nSystemCreationClassName " + Convert.ToString(val.GetPropertyValue("SystemCreationClassName"));}catch(Exception ){}
               try{ ret += "\nControllerTimeouts " + Convert.ToString(val.GetPropertyValue("ControllerTimeouts"));}catch(Exception ){}
               try{ ret += "\nCreationClassName " + Convert.ToString(val.GetPropertyValue("CreationClassName"));}catch(Exception ){}
               try{ ret += "\nDeviceMap " + Convert.ToString(val.GetPropertyValue("DeviceMap"));}catch(Exception ){}
               try{ret += "\nDriverName " + Convert.ToString(val.GetPropertyValue("DriverName"));}catch(Exception ){}
               try{ret += "\nHardwareVersion " + Convert.ToString(val.GetPropertyValue("HardwareVersion"));}catch(Exception ){}
               try{ret += "\nMaxDataWidth " + Convert.ToString(val.GetPropertyValue("MaxDataWidth"));}catch(Exception ){}
               try{ret += "\nMaxTransferRate " + Convert.ToString(val.GetPropertyValue("MaxTransferRate"));}catch(Exception ){}
               try { ret += "\nProtectionManagement " + Convert.ToString(val.GetPropertyValue("ProtectionManagement")); }catch(Exception ){}
               
            }
            return ret;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            label1.Text = VideoConfig();
        }
        private string VideoConfig()
        {
            string ret = "Null";
            ObjectQuery objectQuery_VidConf = new ObjectQuery("select * from Win32_VideoConfiguration");
            ManagementObjectSearcher searcherVidConf = new ManagementObjectSearcher(objectQuery_VidConf);
            ManagementObjectCollection valsVidConf = searcherVidConf.Get();
            foreach (ManagementObject val in valsVidConf)
            {
                try { ret = "ActualColorResolution " + Convert.ToString(val.GetPropertyValue("ActualColorResolution")); }
                catch (Exception) { }
                try { ret += "\nAdapterChipType " + Convert.ToString(val.GetPropertyValue("AdapterChipType")); }
                catch (Exception) { }
                try { ret += "\nAdapterCompatibility " + Convert.ToString(val.GetPropertyValue("AdapterCompatibility")); }
                catch (Exception) { }
                try { ret += "\nAdapterDACType " + Convert.ToString(val.GetPropertyValue("AdapterDACType")); }
                catch (Exception) { }
                try { ret += "\nBitsPerPixel " + Convert.ToString(val.GetPropertyValue("BitsPerPixel")); }
                catch (Exception) { }
                try { ret += "\nColorPlanes " + Convert.ToString(val.GetPropertyValue("ColorPlanes")); }
                catch (Exception) { }
                try { ret += "\nHorizontalResolution " + Convert.ToString(val.GetPropertyValue("HorizontalResolution")); }
                catch (Exception) { }
                try { ret += "\nVerticalResolution " + Convert.ToString(val.GetPropertyValue("VerticalResolution")); }
                catch (Exception) { }
                try { ret += "\nMonitorType " + Convert.ToString(val.GetPropertyValue("MonitorType")); }
                catch (Exception) { }
                try { ret += "\nName " + Convert.ToString(val.GetPropertyValue("Name")); }
                catch (Exception) { }
                try { ret += "\nMonitorManufacturer " + Convert.ToString(val.GetPropertyValue("MonitorManufacturer")); }
                catch (Exception) { }
                try { ret += "\nScreenHeight " + Convert.ToString(val.GetPropertyValue("ScreenHeight")); }
                catch (Exception) { }
                try { ret += "\nScreenWidth " + Convert.ToString(val.GetPropertyValue("ScreenWidth")); }
                catch (Exception) { }
             
            }
            return ret;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            label1.Text = Battary();
        }
        private string Battary()
        {
              string ret = "Null";
              ObjectQuery objectQuery_SCSI = new ObjectQuery("select * from Win32_PortableBattery");
            ManagementObjectSearcher searcherSCSI = new ManagementObjectSearcher(objectQuery_SCSI);
            ManagementObjectCollection valsSCSI = searcherSCSI.Get();
            foreach (ManagementObject val in valsSCSI)
            {
                try { ret = "Availability " + Convert.ToString(val.GetPropertyValue("Availability")); }
                catch (Exception) { }
                try { ret += "\nBatteryRechargeTime " + Convert.ToString(val.GetPropertyValue("BatteryRechargeTime")); }
                catch (Exception) { }
                try { ret += "\nBatteryStatus " + Convert.ToString(val.GetPropertyValue("BatteryStatus")); }
                catch (Exception) { }
                try { ret += "\nDescription " + Convert.ToString(val.GetPropertyValue("Description")); }
                catch (Exception) { }
                try { ret += "\nPNPDeviceID " + Convert.ToString(val.GetPropertyValue("PNPDeviceID")); }
                catch (Exception) { }
                try { ret += "\nSystemName " + Convert.ToString(val.GetPropertyValue("SystemName")); }
                catch (Exception) { }
                try { ret += "\nCaption " + Convert.ToString(val.GetPropertyValue("Caption")); }
                catch (Exception) { }
                try { ret += "\nCreationClassName " + Convert.ToString(val.GetPropertyValue("CreationClassName")); }
                catch (Exception) { }
                try { ret += "\nMaxNumberControlled " + Convert.ToString(val.GetPropertyValue("MaxNumberControlled")); }
                catch (Exception) { }
                try { ret += "\nPowerManagementCapabilities " + Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities")); }
                catch (Exception) { }
                try { ret += "\nPowerManagementSupported " + Convert.ToString(val.GetPropertyValue("PowerManagementSupported")); }
                catch (Exception) { }
                try { ret += "\nProtocolSupported " + Convert.ToString(val.GetPropertyValue("ProtocolSupported")); }
                catch (Exception) { }
                try { ret += "\nStatus " + Convert.ToString(val.GetPropertyValue("Status")); }
                catch (Exception) { }
                try { ret += "\nStatusInfo " + Convert.ToString(val.GetPropertyValue("StatusInfo")); }
                catch (Exception) { }
                try { ret += "\nSystemCreationClassName " + Convert.ToString(val.GetPropertyValue("SystemCreationClassName")); }
                catch (Exception) { }
                try { ret += "\nControllerTimeouts " + Convert.ToString(val.GetPropertyValue("ControllerTimeouts")); }
                catch (Exception) { }
                try { ret += "\nCreationClassName " + Convert.ToString(val.GetPropertyValue("CreationClassName")); }
                catch (Exception) { }
                try { ret += "\nDeviceMap " + Convert.ToString(val.GetPropertyValue("DeviceMap")); }
                catch (Exception) { }
                try { ret += "\nDriverName " + Convert.ToString(val.GetPropertyValue("DriverName")); }
                catch (Exception) { }
                try { ret += "\nHardwareVersion " + Convert.ToString(val.GetPropertyValue("HardwareVersion")); }
                catch (Exception) { }
                try { ret += "\nMaxDataWidth " + Convert.ToString(val.GetPropertyValue("MaxDataWidth")); }
                catch (Exception) { }
                try { ret += "\nMaxTransferRate " + Convert.ToString(val.GetPropertyValue("MaxTransferRate")); }
                catch (Exception) { }
                try { ret += "\nProtectionManagement " + Convert.ToString(val.GetPropertyValue("ProtectionManagement")); }
                catch (Exception) { }
               
            }
            return ret;
        }
        //--------------------------------
        private string LanAdapter()
        {
            string ret = "Null";
            ObjectQuery objectQuery_Lan = new ObjectQuery("select * from Win32_NetworkAdapter");
            ManagementObjectSearcher searcherLan = new ManagementObjectSearcher(objectQuery_Lan);
            ManagementObjectCollection valsLan = searcherLan.Get();
            foreach (ManagementObject val in valsLan)
            {
               try { ret = "\nName " + Convert.ToString(val.GetPropertyValue("Name"));} catch (Exception) { }
               try { ret += "\nManufacturer " + Convert.ToString(val.GetPropertyValue("Manufacturer"));} catch (Exception) { }
               try { ret += "\nPNPDeviceID " + Convert.ToString(val.GetPropertyValue("PNPDeviceID"));} catch (Exception) { }
               try { ret += "\nProductName " + Convert.ToString(val.GetPropertyValue("ProductName"));} catch (Exception) { }
               try { ret += "\nServiceName " + Convert.ToString(val.GetPropertyValue("ServiceName"));} catch (Exception) { }
               try { ret += "\nSystemName " + Convert.ToString(val.GetPropertyValue("SystemName"));} catch (Exception) { }
               try { ret += "\nDeviceID; " + Convert.ToString(val.GetPropertyValue("DeviceID;"));} catch (Exception) { }
               try { ret += "\nDescription " + Convert.ToString(val.GetPropertyValue("Description"));} catch (Exception) { }
               try { ret += "\nMACAddress " + Convert.ToString(val.GetPropertyValue("MACAddress"));} catch (Exception) { }
               try { ret += "\nPermanentAddress " + Convert.ToString(val.GetPropertyValue("PermanentAddress"));} catch (Exception) { }
               try { ret += "\nStatus " + Convert.ToString(val.GetPropertyValue("Status")); } catch (Exception) { }
            }
            return ret;
        }


       // [STAThread]
        //private unsafe string DevicesApi()
        //{
        //    string ret;
        //    int PnPHandle = SetupAPI.SetupDiGetClassDevs(
        //        null,
        //        null,
        //        null,
        //        SetupAPI.ClassDevsFlags.DIGCF_ALLCLASSES | SetupAPI.ClassDevsFlags.DIGCF_PRESENT
        //    );
        //    int result = -1;
        //    int DeviceIndex = 0;

        //    while (result != 0)
        //    {
        //        SetupAPI.SP_DEVINFO_DATA DeviceInfoData = new SetupAPI.SP_DEVINFO_DATA();
        //        DeviceInfoData.cbSize = Marshal.SizeOf(DeviceInfoData);

        //        result = SetupAPI.SetupDiEnumDeviceInfo(PnPHandle, DeviceIndex, ref DeviceInfoData);

        //        if (result == 1)
        //        {
        //            int RequiredSize = 0;
        //            SetupAPI.DATA_BUFFER Buffer = new SetupAPI.DATA_BUFFER();
        //            result = SetupAPI.SetupDiGetDeviceRegistryProperty(
        //                PnPHandle,
        //                ref DeviceInfoData,
        //                SetupAPI.RegPropertyType.SPDRP_DEVICEDESC,
        //                null,
        //                ref Buffer,
        //                1024,
        //                ref RequiredSize
        //                );


        //            ret+=Buffer.Buffer + "\n";
                    
        //        }

        //        DeviceIndex++;
        //    }


        //    return ret;
        //}

    }
}
