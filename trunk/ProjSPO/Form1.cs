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
using System.Collections;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using ZedGraph;

delegate void AddText(string text);
namespace ProjSPO
{   
    public partial class Form1 : Form
    {
        int _capacity = 30;

        // Здесь храним данные
        List<double> _data;
        List<double> _data1;
        Form4 MiniForm;
        // Для генерации слуайных данные по таймеру
        Random _rnd = new Random();

        // Интервал изменения данных по вертикали
        double _ymin = -1.0;
        double _ymax = 1.0;

        Thread thr1, thr2, thr3,thr4;
        TreeNode[] tn;
        TreeNode[] Serv;
        string []tempMem;
        string[] tempServ;
        public Form1()
        {
            MiniForm = new Form4();
            MiniForm.Visible = false;
            MiniForm.Enabled = false;
            MiniForm.Text = "Hidden";
            _data = new List<double>();
            _data1 = new List<double>();
            InitializeComponent();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            Threads();

            int i = 0;
            tempMem = new string[15];
            tempServ = new string[550];
            Serv = treeView1.Nodes.Find("Службы", true);
            tn = treeView1.Nodes.Find("Память", true);
            ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                
                tn[0].Nodes.Add(moDisk["Model"].ToString());
                tempMem[i]= moDisk["Model"].ToString();
                i++;
            }
            Services();
            treeView1.ImageList = imageList1;
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = this.BackColor;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = this.BackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = this.BackColor;
            DrawGraph();
            timer1.Start();
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
        private void AddTextLabel2(string text)//хитрая добавлялка на основе делегата т.к. в др потоке не доступны все наши лейблы и др элементы
        {
            try
            {
                if (this.label2.InvokeRequired) //если этот метод AddTextLabel2 вызван из ДРУГОГО ПОТОКА (т.е. если мы хотим обратиться к лейбл2 из др потока)
                {
                    AddText d = new AddText(AddTextLabel2);   //заводим делегата(т.е. переменную делегатного типа AddText),который будет вызывать этуже функцию AddTextLabel2
                    this.Invoke(d, new object[] { text });   //invoke выполняет указанный делегат(d) в том потоке которому принадлежит список оргументов т.е. т.к. object принадлежит основному потоку то делегат будет выполнен в этом потоке,и делегат вызовет опять этуже функцию AddTextLabel2
                }
                else     //т.к. выше делегат вызывает эту же функцию но уже в основном потоке (с помощью Invoke)
                {          //то просто выводим текст на лэйбл 2 т.к. мы уже в основном потоке
                    this.label2.Text = text;
                }
            }
            catch (Exception Ex)
            {
            }
        }
        private void AddTextLabel3(string text)//хитрая добавлялка на основе делегата т.к. в др потоке не доступны все наши лейблы и др элементы
        {
            try
            {
                if (this.label3.InvokeRequired) //если этот метод AddTextLabel2 вызван из ДРУГОГО ПОТОКА (т.е. если мы хотим обратиться к лейбл2 из др потока)
                {
                    AddText d = new AddText(AddTextLabel3);   //заводим делегата(т.е. переменную делегатного типа AddText),который будет вызывать этуже функцию AddTextLabel2
                    this.Invoke(d, new object[] { text });   //invoke выполняет указанный делегат(d) в том потоке которому принадлежит список оргументов т.е. т.к. object принадлежит основному потоку то делегат будет выполнен в этом потоке,и делегат вызовет опять этуже функцию AddTextLabel2
                }
                else     //т.к. выше делегат вызывает эту же функцию но уже в основном потоке (с помощью Invoke)
                {          //то просто выводим текст на лэйбл 2 т.к. мы уже в основном потоке
                    this.label3.Text = text;
                }
            }
            catch (Exception Ex)
            {
            }
        }
        private void AddTextLabel4(string text)//хитрая добавлялка на основе делегата т.к. в др потоке не доступны все наши лейблы и др элементы
        {
            try
            {
                if (this.label4.InvokeRequired) //если этот метод AddTextLabel2 вызван из ДРУГОГО ПОТОКА (т.е. если мы хотим обратиться к лейбл2 из др потока)
                {
                    AddText d = new AddText(AddTextLabel4);   //заводим делегата(т.е. переменную делегатного типа AddText),который будет вызывать этуже функцию AddTextLabel2
                    this.Invoke(d, new object[] { text });   //invoke выполняет указанный делегат(d) в том потоке которому принадлежит список оргументов т.е. т.к. object принадлежит основному потоку то делегат будет выполнен в этом потоке,и делегат вызовет опять этуже функцию AddTextLabel2
                }
                else     //т.к. выше делегат вызывает эту же функцию но уже в основном потоке (с помощью Invoke)
                {          //то просто выводим текст на лэйбл 2 т.к. мы уже в основном потоке
                    this.label4.Text = text;
                }
            }
            catch (Exception Ex)
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
                try {dataGridView1.Rows.Add("Название : " , ss.GetPropertyValue("Name").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Видео процессор : " , ss.GetPropertyValue("VideoProcessor").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Адаптер RAM : " , ss.GetPropertyValue("AdapterRAM").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Описание видеорежима : " , ss.GetPropertyValue("VideoModeDescription").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("AdapterCompatibility : " , ss.GetPropertyValue("AdapterCompatibility").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("AdapterDACType : " , ss.GetPropertyValue("AdapterDACType").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Availability : " , ss.GetPropertyValue("Availability").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Caption : " , ss.GetPropertyValue("Caption").ToString()); }
                catch (Exception) { }
                try{dataGridView1.Rows.Add("ColorTableEntries : " , ss.GetPropertyValue("ColorTableEntries").ToString());}
                catch(Exception){};
                try {dataGridView1.Rows.Add("ConfigManagerErrorCode : " , ss.GetPropertyValue("ConfigManagerErrorCode").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("ConfigManagerUserConfig : " , ss.GetPropertyValue("ConfigManagerUserConfig").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CreationClassName : " , ss.GetPropertyValue("CreationClassName").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentBitsPerPixel : " , ss.GetPropertyValue("CurrentBitsPerPixel").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentHorizontalResolution : " , ss.GetPropertyValue("CurrentHorizontalResolution").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentNumberOfColors : " , ss.GetPropertyValue("CurrentNumberOfColors").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentNumberOfColumns : " , ss.GetPropertyValue("CurrentNumberOfColumns").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentNumberOfRows : " , ss.GetPropertyValue("CurrentNumberOfRows").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentRefreshRate : " , ss.GetPropertyValue("CurrentRefreshRate").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentScanMode : " , ss.GetPropertyValue("CurrentScanMode").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("CurrentVerticalResolution : " , ss.GetPropertyValue("CurrentVerticalResolution").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Description : " , ss.GetPropertyValue("Description").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("DeviceID : " , ss.GetPropertyValue("DeviceID").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("DeviceSpecificPens : " , ss.GetPropertyValue("DeviceSpecificPens").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("DitherType : " , ss.GetPropertyValue("DitherType").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("DriverDate : " , ss.GetPropertyValue("DriverDate").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("DriverVersion : " , ss.GetPropertyValue("DriverVersion").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add(" ErrorCleared : " , ss.GetPropertyValue("ErrorCleared").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("ErrorDescription : " , ss.GetPropertyValue("ErrorDescription").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("ICMIntent : " , ss.GetPropertyValue("ICMIntent").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("ICMMethod : " , ss.GetPropertyValue("ICMMethod").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("InfFilename : " , ss.GetPropertyValue("InfFilename").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("InfSection : " , ss.GetPropertyValue("InfSection").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("InstallDate : " , ss.GetPropertyValue("InstallDate").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("InstalledDisplayDrivers : " , ss.GetPropertyValue("InstalledDisplayDriverse").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("LastErrorCode : " , ss.GetPropertyValue("LastErrorCode").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("MaxMemorySupported : " , ss.GetPropertyValue("MaxMemorySupported").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("MaxNumberControlled : " , ss.GetPropertyValue("MaxNumberControlled").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("MaxRefreshRate : " , ss.GetPropertyValue("MaxRefreshRate").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("MinRefreshRate : " , ss.GetPropertyValue("MinRefreshRate").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Monochrome : " , ss.GetPropertyValue("Monochrome").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("Name : " , ss.GetPropertyValue("Name").ToString()); }
                catch (Exception) { }
                try{dataGridView1.Rows.Add("NumberOfColorPlanes : " , ss.GetPropertyValue("NumberOfColorPlanes").ToString());}
                catch(Exception){};
                try {dataGridView1.Rows.Add("NumberOfVideoPages : " , ss.GetPropertyValue("NumberOfVideoPages").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("PNPDeviceID : " , ss.GetPropertyValue("PNPDeviceID").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("PowerManagementSupported : " , ss.GetPropertyValue("PowerManagementSupported").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("ProtocolSupported : " , ss.GetPropertyValue("ProtocolSupported").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("ReservedSystemPaletteEntries : " , ss.GetPropertyValue("ReservedSystemPaletteEntries").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("SpecificationVersion : " , ss.GetPropertyValue("SpecificationVersion").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("Status : " , ss.GetPropertyValue("Status").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("StatusInfo : " , ss.GetPropertyValue("StatusInfo").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("SystemCreationClassName : " , ss.GetPropertyValue("SystemCreationClassName").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("SystemName : " , ss.GetPropertyValue("SystemName").ToString()); }
                catch (Exception) { }
                try{dataGridView1.Rows.Add("SystemPaletteEntries : " , ss.GetPropertyValue("SystemPaletteEntries").ToString());}
                catch(Exception){};
                try {dataGridView1.Rows.Add("TimeOfLastReset : " , ss.GetPropertyValue("TimeOfLastReset").ToString()); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("VideoArchitecture : " , ss.GetPropertyValue("VideoArchitecture").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("VideoMemoryType : " , ss.GetPropertyValue("VideoMemoryType").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("VideoModeDescription : " , ss.GetPropertyValue("VideoModeDescription").ToString()); }
                catch (Exception) { }
                try {dataGridView1.Rows.Add("VideoProcessor : " , ss.GetPropertyValue("VideoProcessor").ToString()); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("VideoMode : ", ss.GetPropertyValue("VideoMode").ToString()); }
                catch (Exception) { };

            }     
            return Vid;
        }

        //-----------------------------------------------------------------
        private string NetworkConnect()
        {
            string ret = "null";
            string myHost = System.Net.Dns.GetHostName();
            try { dataGridView1.Rows.Add("Хост", myHost); }
            catch (Exception) { };
            try { dataGridView1.Rows.Add("IP адрес", System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString()); }
            catch (Exception) { };

            ObjectQuery objectQuery_Network = new ObjectQuery("select * from Win32_NetworkConnection");
            ManagementObjectSearcher searcherNetwork = new ManagementObjectSearcher(objectQuery_Network);
            ManagementObjectCollection valsNetwork = searcherNetwork.Get();
            foreach (ManagementObject ss in valsNetwork)
            {
               try { dataGridView1.Rows.Add("AccessMask: " , ss.GetPropertyValue("AccessMask").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("Caption: " , ss.GetPropertyValue("Caption").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("Comment: " , ss.GetPropertyValue("Comment").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("ConnectionState: " , ss.GetPropertyValue("ConnectionState").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("ConnectionType: " , ss.GetPropertyValue("ConnectionType").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("Description: " , ss.GetPropertyValue("Description").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("DisplayType: " , ss.GetPropertyValue("DisplayType").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("InstallDate: " , ss.GetPropertyValue("InstallDate").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("LocalName: " , ss.GetPropertyValue("LocalName").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("Name: " , ss.GetPropertyValue("Name").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("Persistent: " , ss.GetPropertyValue("Persistent").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("ProviderName: " , ss.GetPropertyValue("ProviderName").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("RemoteName: " , ss.GetPropertyValue("RemoteName").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("RemotePath: " , ss.GetPropertyValue("RemotePath").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("ResourceType: " , ss.GetPropertyValue("ResourceType").ToString());}
                catch (Exception) { }
               try {   dataGridView1.Rows.Add("Status: " , ss.GetPropertyValue("Status").ToString());}
                catch (Exception) { }
               try {  dataGridView1.Rows.Add("UserName: " , ss.GetPropertyValue("UserName").ToString()); }
               catch (Exception) { }
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private string Ident()
        {
            WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher find = new ManagementObjectSearcher(query);
            string ret = "null";
            foreach (ManagementObject mo in find.Get())
            {
                try{dataGridView1.Rows.Add("Описание " , mo["Description"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Серийный номер " , mo["IdentifyingNumber"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Commonly used product name." , mo["Name"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Universally Unique Identifier of  product." , mo["UUID"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Caption " , mo["Caption"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("SKUNumber " , mo["SKUNumber"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Version " , mo["Version"]);}
                catch(Exception){};
                try{dataGridView1.Rows.Add("Vendor продукта." , mo["Vendor"]); }
                catch (Exception) { };
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private string Boot()
        {
            string ret = "null";
            WqlObjectQuery query = new WqlObjectQuery(
                "SELECT * FROM Win32_BootConfiguration");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                try {dataGridView1.Rows.Add("Загрузочная директория " , mo["BootDirectory"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Описание " , mo["Description"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Директроия временных файлов загрузки" , mo["ScratchDirectory"]) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Captionе " , mo["Caption"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("ConfigurationPath" , mo["ConfigurationPath"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("LastDrive " , mo["LastDrive"]);
                }catch(Exception){};
                try {dataGridView1.Rows.Add("Name" , mo["Name"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("SettingID " , mo["SettingID"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Директория временных файлов." , mo["TempDirectory"]); }
                catch (Exception) { };
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private string CompSys()
        {
            string ret = "null";

            WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher find = new ManagementObjectSearcher(query);
            try
            {
                foreach (ManagementObject mo in find.Get())
                {
                   try{dataGridView1.Rows.Add("Компьютер относиться к домену " , mo["Domain"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Производитель" , mo["Manufacturer"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("AdminPasswordStatus" , mo["AdminPasswordStatus"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("AutomaticManagedPagefile" , mo["AutomaticManagedPagefile"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("AutomaticResetBootOption" , mo["AutomaticResetBootOption"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("AutomaticResetCapability" , mo["AutomaticResetCapability"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("BootOptionOnLimit" , mo["BootOptionOnLimit"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("ПBootOptionOnWatchDog" , mo["BootOptionOnWatchDog"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("BootROMSupported" , mo["BootROMSupported"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("BootupState" , mo["BootupState"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Caption" , mo["Caption"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("ChassisBootupState" , mo["ChassisBootupState"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("CreationClassName" , mo["CreationClassName"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("CurrentTimeZone" , mo["CurrentTimeZone"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("DaylightInEffect" , mo["DaylightInEffect"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Description" , mo["Description"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("DNSHostName" , mo["DNSHostName"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Domain" , mo["Domain"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("DomainRole" , mo["DomainRole"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("EnableDaylightSavingsTime" , mo["EnableDaylightSavingsTime"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("FrontPanelResetStatus" , mo["FrontPanelResetStatus"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("InfraredSupported" , mo["InfraredSupported"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("InitialLoadInfo" , mo["InitialLoadInfo"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("InstallDate" , mo["InstallDate"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("KeyboardPasswordStatus" , mo["KeyboardPasswordStatus"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("LastLoadInfo" , mo["LastLoadInfo"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Model" , mo["Model"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Name" , mo["Name"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("NameFormat" , mo["NameFormat"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("NetworkServerModeEnabled" , mo["NetworkServerModeEnabled"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("NumberOfLogicalProcessors" , mo["NumberOfLogicalProcessors"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("NumberOfProcessors" , mo["NumberOfProcessors"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PartOfDomain" , mo["PartOfDomain"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PauseAfterReset" , mo["PauseAfterReset"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PCSystemType" , mo["PCSystemType"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PowerManagementSupported" , mo["PowerManagementSupported"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PowerOnPasswordStatus" , mo["PowerOnPasswordStatus"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PowerState" , mo["PowerState"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PowerSupplyState" , mo["PowerSupplyState"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PrimaryOwnerContact" , mo["PrimaryOwnerContact"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("PrimaryOwnerName" , mo["PrimaryOwnerName"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("ResetCapability" , mo["ResetCapability"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("SystemStartupDelay" , mo["SystemStartupDelay"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("SystemType" , mo["SystemType"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("ThermalState" , mo["ThermalState"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("TotalPhysicalMemory" , mo["TotalPhysicalMemory"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("UserName" , mo["UserName"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("WakeUpType" , mo["WakeUpType"].ToString());}
                   catch(Exception){};
                   try{dataGridView1.Rows.Add("Workgroup" , mo["Workgroup"].ToString());}
                   catch(Exception){};
                   try { dataGridView1.Rows.Add("Имя модели, данное производителем " , mo["Model"].ToString()); }
                   catch (Exception) { }; 
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
                dataGridView1.Rows.Add("Роль" ,Roles[Convert.ToInt32(mo["DomainRole"])]);
            }
            return ret;
        }
        //-----------------------------------------------------------------
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
                try {dataGridView1.Rows.Add( "Width of window borders." , mo["BorderWidth"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("ALT,TAB - разрешено " , mo["CoolSwitch"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Lenght of time between cursor blincks. " , mo["CursorBlinkRate"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Show content of windows when are draged." , mo["DragFullWindows"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Grid settings for dragging windows." , mo["GridGranularity"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Grid settings for icon spacing. " , mo["IconSpacing"]); }
                catch (Exception) { };
                try {dataGridView1.Rows.Add("Font used for the names of icons." , mo["IconTitleFaceName"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Icon ront size. " , mo["IconTitleSize"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Wrapping of icon title." , mo["IconTitleWrap"]) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Name of the desktop profile." , mo["Name"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Screen saver is active." , mo["ScreenSaverActive"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Name of the screen saver executable." , mo["ScreenSaverExecutable"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Is screen saver protected with password." , mo["ScreenSaverSecure"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Time to pass to activate screen saver." , mo["ScreenSaverTimeout"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("File name for desktop background." , mo["Wallpaper"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Wallpaper fills entire screen." , mo["WallpaperStretched"]);}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Wallpaper is tiled." , mo["WallpaperTiled"]);}
                catch(Exception){};
            }
            return ret;

        }
        //-----------------------------------------------------------------
        private string DiskParts()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_DiskPartition");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                try{dataGridView1.Rows.Add("Размер блока " , mo["BlockSize"] + " Bytes");}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Загрузочный диск " , mo["Bootable"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Активный загрузочный диск " , mo["BootPartition"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Заголовок " , mo["Caption"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Описание " , mo["Description"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Уникальный индификатор раздела " , mo["DeviceID"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Индекс диска ." , mo["DiskIndex"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Детали описаня ошибки в  LastErrorCode." , mo["ErrorDescription"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Типо определения ошибки " , mo["ErrorMethodology"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Скрытые секторы " , mo["HiddenSectors"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Индексный номер раздела " , mo["Index"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("ПОследняя ошибка устройства " , mo["LastErrorCode"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Общее количество последовательных блоков " , mo["NumberOfBlocks"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Раздел, помечеый как ведущий." , mo["PrimaryPartition"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Свободное описание  " , mo["Purpose"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Общий размер разделов " , mo["Size"] + " bytes");}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Стартовое смещение " , mo["StartingOffset"]);}
                catch(Exception){};
                try{ dataGridView1.Rows.Add("Статус " , mo["Status"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Тип раздела " , mo["Type"]); }
                catch(Exception){};
            }
            return ret;
        }
        //-----------------------------------------------------------------
        private string Environment()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_Environment");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                try{ dataGridView1.Rows.Add("Описание", mo["Description"]); }
                catch (Exception) { };
                try{ dataGridView1.Rows.Add("Имя",mo["Name"]);}
                catch (Exception) { };
                try{ dataGridView1.Rows.Add("Пользлватель",mo["UserName"]);}
                catch (Exception) { };
                try{ dataGridView1.Rows.Add("Переменная", mo["VariableValue"]); }
                catch (Exception) { };
            }
            return ret;
        }
        //----------------------------------------------------------------
        private string Group()
        {
            string ret = "Null";
            WqlObjectQuery query = new WqlObjectQuery(
                "Select * from Win32_Group where LocalAccount = 'true'");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                 try{dataGridView1.Rows.Add("Заголовок " , mo["Caption"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Описание " , mo["Description"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Домен " , mo["Domain"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Профиль орпеделёный на локальной машине " , mo["LocalAccount"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Группа " , mo["Name"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Идентификтор безопасности (SID)." , mo["SID"]);}
                 catch(Exception){};
                 try{dataGridView1.Rows.Add("Тип идентификатора безопасности " , GetSidType(Convert.ToInt32(mo["SIDType"])));}
                 catch(Exception){};
                 try {dataGridView1.Rows.Add("Статус " , mo["Status"]); }
                 catch (Exception) { };
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
        private string LDisk()
        {
            string ret = "Null";
            string cmiPath = @"\root\cimv2:Win32_LogicalDisk.DeviceID='C:'";
            ManagementObject mo = new ManagementObject(cmiPath);
            try {dataGridView1.Rows.Add("Описание " , mo["Description"]); }
            catch (Exception) { };
             try {dataGridView1.Rows.Add("Файловай система " , mo["FileSystem"]);}
             catch(Exception){};
             try {dataGridView1.Rows.Add("Свободно места на диске " , mo["FreeSpace"]);}
             catch(Exception){};
             try {dataGridView1.Rows.Add("Размер " , mo["Size"]); }
             catch (Exception) { };
            return ret;
        }
        //-------------------------------------------------------
        private string OperSys()
        {
            string ret = "Null";
            WqlObjectQuery query =
        new WqlObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher find =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject mo in find.Get())
            {
                try {dataGridView1.Rows.Add("Boot device name " , mo["BootDevice"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Build number" , mo["BuildNumber"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Caption" , mo["Caption"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Code page used by OS" , mo["CodeSet"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Country code" , mo["CountryCode"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Latest service pack installed" , mo["CSDVersion"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Computer system name" , mo["CSName"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Time zone (minute offset from GMT" , mo["CurrentTimeZone"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS is debug build" , mo["Debug"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS is distributed across several nodes." , mo["Distributed"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Encryption level of transactions" , mo["EncryptionLevel"] + " bits");}
                catch(Exception){};
                try { dataGridView1.Rows.Add(">>Priority increase for foreground app" , GetForeground(mo));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Available physical memory" , mo["FreePhysicalMemory"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Available virtual memory" , mo["FreeVirtualMemory"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add( "Free paging-space withou swapping." , mo["FreeSpaceInPagingFiles"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Installation date " , ManagementDateTimeConverter.ToDateTime(mo["InstallDate"].ToString()));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("What type of memory optimization......" , (Convert.ToInt16(mo["LargeSystemCache"]) == 0 ? "for applications" : "for system performance"));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Time from last boot " , mo["LastBootUpTime"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Local date and time " , ManagementDateTimeConverter.ToDateTime(mo["LocalDateTime"].ToString()));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Language identifier (LANGID) " , mo["Locale"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Local date and time. " , ManagementDateTimeConverter.ToDateTime(mo["LocalDateTime"].ToString()));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Max# of processes supported by OS" , mo["MaxNumberOfProcesses"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Max memory available for process." , mo["MaxProcessMemorySize"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Current number of processes" , mo["NumberOfProcesses"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Currently stored user sessions." , mo["NumberOfUsers"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS language version" , mo["OSLanguage"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS product suite version" , GetSuite(mo));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS type" , GetOSType(mo));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Number of Windows Plus! " , mo["PlusProductID"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Version of Windows Plus! " , mo["PlusVersionNumber"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Type of installed OS. " , GetProductType(mo));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Registered user of OS. " , mo["RegisteredUser"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Serial number of product. " , mo["SerialNumber"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Serial number of product. " , mo["SerialNumber"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("ServicePack major version. " , mo["ServicePackMajorVersion"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("ServicePack minor version. " , mo["ServicePackMinorVersion"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Total number to store in paging files" , mo["SizeStoredInPagingFiles"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Status. " , mo["Status"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("ServicePack minor version. " , mo["ServicePackMinorVersion"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("OS suite. " , GetOSSuite(mo));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Physical disk partition with OS. " , mo["SystemDevice"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("System directory. " , mo["SystemDirectory"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Total virtual memory. " , mo["TotalVirtualMemorySize"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Total physical memory. " , mo["TotalVisibleMemorySize"] + " kilobytes");}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Version number of OS. " , mo["Version"]);}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Windows directory. " , mo["WindowsDirectory"]); }
                catch (Exception) { };
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
                try {dataGridView1.Rows.Add("-- Processor #" , i + " -" ) ;}
                catch(Exception){};  
                try {dataGridView1.Rows.Add("Processor address width in bits." , mo["AddressWidth"] );}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Architecture of processor." , GetArchitecture(mo) ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Caption." , mo["Caption"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Manufacturer " , mo["Manufacturer"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("DeviceID " , mo["DeviceID"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("NumberOfCores " , mo["NumberOfCores"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("NumberOfLogicalProcessors " , mo["NumberOfLogicalProcessors"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("OtherFamilyDescription " , mo["OtherFamilyDescription"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("PNPDeviceID " , mo["PNPDeviceID"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("ProcessorId " , mo["ProcessorId"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("ProcessorType " , mo["ProcessorType"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Role " , mo["Role"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("SocketDesignation " , mo["SocketDesignation"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Stepping " , mo["Stepping"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("SystemName " , mo["SystemName"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("UniqueId " , mo["UniqueId"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("UpgradeMethod " , mo["UpgradeMethod"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Version " , mo["Version"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Processor address width in bits." , mo["AddressWidth"] ) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Usage status of the processor." , GetCpuStatus(mo) ) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Current clock speed (in MHz)." , mo["CurrentClockSpeed"] ) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("MaxClockSpeed (in MHz)." , mo["MaxClockSpeed"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Processor data width." , mo["DataWidth"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Unique string identification." , mo["DeviceID"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("External clock frequency." , mo["ExtClock"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Processor family." , GetFamily(mo) ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("L2 cache size." , mo["L2CacheSize"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("L2 cache speed." , mo["L2CacheSpeed"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("L3 cache size." , mo["L3CacheSize"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("L3 cache speed." , mo["L3CacheSpeed"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Load percentage (average value for second)." , mo["LoadPercentage"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Manufacturer." , mo["Manufacturer"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Maximum speed (in MHz)." , mo["MaxClockSpeed"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Name." , mo["Name"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Support for power management." , mo["PowerManagementSupported"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Unique identificator describing processor" , mo["ProcessorId"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Processor type." , GetProcessorType(mo) ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Role (CPU/math)." , mo["Role"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Socket designation." , mo["SocketDesignation"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Status." , mo["Status"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Status information." , GetStatusInfo(mo) ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("Processor version." , mo["Version"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("VoltageCaps " , mo["VoltageCaps"] ) ;}
                catch(Exception){};
                try {dataGridView1.Rows.Add("CurrentVoltage " , mo["CurrentVoltage"] ) ;}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Socket voltage." , mo["VoltageCaps"]); }
                catch (Exception) { };
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
                try {dataGridView1.Rows.Add( "--- Chasis setting #" , i) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Chasis type." , GetChasisType(mo));}catch(Exception){};
                try {dataGridView1.Rows.Add("Description." , mo["Description"]) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Depth of physical package (in inches)." , mo["Depth"]) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Height of physical package (in inches).." , mo["Height"]) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Width of physical package (in inches)." , mo["Width"] ) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Weight." , mo["Weight"] ) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Service philosophy " , GetServicePhilosophy(mo)) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Status." , mo["Status"]) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Property includes visible alarm." , mo["VisibleAlarm"]) ;}catch(Exception){};
                try {dataGridView1.Rows.Add("Property includes visible alarm." , mo["VisibleAlarm"]); }
                catch (Exception) { };
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
                AddTextLabel4(ret);
            } while (true);
        }
        //----------------------------------------------------------
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
                AddTextLabel2(ret);
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
        private void LoadOP()
        {
            do
            {
                string ret = "Null";
                MEMORYSTATUSEX msex = new MEMORYSTATUSEX();
                if (GlobalMemoryStatusEx(msex))
                {
                    ret = "Всего памяти" + msex.ullTotalPhys / 1024 / 1024 + " MB" +
                    "\nДоступно памяти " + msex.ullAvailPhys / 1024 / 1024 + " MB";
                }
                AddTextLabel1(ret);
            } while (true);
            //return ret;
        }
        //----------------------------------------------------------

        private string HDDParts()
        {
            string ret = "";
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    dataGridView1.Rows.Add("Drive " , d.Name);
                    dataGridView1.Rows.Add("File type ", d.DriveType);
                    if (d.IsReady == true)
                    {
                        dataGridView1.Rows.Add("Volume label: ", d.VolumeLabel);
                        dataGridView1.Rows.Add("File system: ", d.DriveFormat);
                        dataGridView1.Rows.Add("Available space to current user: ", d.AvailableFreeSpace+" bytes");
                        dataGridView1.Rows.Add("Total available space: ", d.TotalFreeSpace + " bytes");
                        dataGridView1.Rows.Add("Total size of drive: ", d.TotalSize + " bytes");
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
        
       public void MemoryList()
        {
            ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE Model = '" +  treeView1.SelectedNode.Text + "'"); 
         foreach (ManagementObject moDisk in mosDisks.Get()) 
	      {
                try {dataGridView1.Rows.Add("Type: " , moDisk["MediaType"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add( "Model: " , moDisk["Model"].ToString());}
                catch (Exception) { };
                try { dataGridView1.Rows.Add( "Name: " , moDisk["Name"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add( "Serial: " , moDisk["SerialNumber"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add( "Interface: " , moDisk["InterfaceType"].ToString()); }
                catch (Exception) { };
               try {  dataGridView1.Rows.Add( "Capacity: " , moDisk["Size"].ToString() + " bytes (" + Math.Round(((((double)Convert.ToDouble(moDisk["Size"]) / 1024) / 1024) / 1024), 2) + " GB)");}
               catch (Exception) { };
               try {  dataGridView1.Rows.Add( "Partitions: " , moDisk["Partitions"].ToString());}
               catch (Exception) { };
               try {  dataGridView1.Rows.Add( "Signature: " , moDisk["Signature"].ToString());}
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Firmware: " , moDisk["FirmwareRevision"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Cylinders: " , moDisk["TotalCylinders"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Sectors: " , moDisk["TotalSectors"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Heads: " , moDisk["TotalHeads"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Tracks: " , moDisk["TotalTracks"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Bytes per Sector: " , moDisk["BytesPerSector"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Sectors per Track: " , moDisk["SectorsPerTrack"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Tracks per Cylinder: " , moDisk["TracksPerCylinder"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "CompressionMethod: " , moDisk["CompressionMethod"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "DefaultBlockSize: " , moDisk["DefaultBlockSize"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Description: " , moDisk["Description"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "DeviceID: " , moDisk["DeviceID"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Manufacturer: " , moDisk["Manufacturer"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "MaxBlockSize: " , moDisk["MaxBlockSize"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "MaxMediaSize: " , moDisk["MaxMediaSize"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "MinBlockSize: " , moDisk["MinBlockSize"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "PNPDeviceID: " , moDisk["PNPDeviceID"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SCSIBus: " , moDisk["SCSIBus"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SCSILogicalUnit: " , moDisk["SCSILogicalUnit"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SCSIPort: " , moDisk["SCSIPort"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SCSITargetId: " , moDisk["SCSITargetId"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SerialNumber: " , moDisk["SerialNumber"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "SystemName: " , moDisk["SystemName"].ToString()); }
               catch (Exception) { };
               try { dataGridView1.Rows.Add( "Manufacturer: " , moDisk["Manufacturer"].ToString()); }
               catch (Exception) { };

	      }
        }
        //----------------------------------------------------------
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
        private string Bios()
        {
            string ret = "Null";
            ObjectQuery objectQuery_BIOS = new ObjectQuery("select * from Win32_BIOS");

            ManagementObjectSearcher searcherBIOS = new ManagementObjectSearcher(objectQuery_BIOS);
            ManagementObjectCollection valsBIOS = searcherBIOS.Get();

            foreach (ManagementObject val in valsBIOS)
            { 
                 try{dataGridView1.Rows.Add("Name = " , Convert.ToString(val.GetPropertyValue("Name"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "Manufacturer = " , Convert.ToString(val.GetPropertyValue("Manufacturer"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "Version = " , Convert.ToString(val.GetPropertyValue("Version"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "ReleaseDate = " , Convert.ToString(val.GetPropertyValue("ReleaseDate"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "BuildNumber = " , Convert.ToString(val.GetPropertyValue("BuildNumber"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "Caption" , Convert.ToString(val.GetPropertyValue("Caption"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "CodeSet = " , Convert.ToString(val.GetPropertyValue("CodeSet"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "CurrentLanguage = " , Convert.ToString(val.GetPropertyValue("CurrentLanguage"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "SerialNumberr = " , Convert.ToString(val.GetPropertyValue("SerialNumber"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "IdentificationCode = " , Convert.ToString(val.GetPropertyValue("IdentificationCode"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "Description = " , Convert.ToString(val.GetPropertyValue("Description"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "LanguageEdition = " , Convert.ToString(val.GetPropertyValue("LanguageEdition"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "Status = " , Convert.ToString(val.GetPropertyValue("Status"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "OtherTargetOS = " , Convert.ToString(val.GetPropertyValue("OtherTargetOS"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "InstallDate = " , Convert.ToString(val.GetPropertyValue("InstallDate"))); }
                 catch(Exception ){}
                 try{dataGridView1.Rows.Add( "SMBIOSBIOSVersion = " , Convert.ToString(val.GetPropertyValue("SMBIOSBIOSVersion"))); }
                 catch(Exception ){}
                 try { dataGridView1.Rows.Add( "SoftwareElementID = " , Convert.ToString(val.GetPropertyValue("SoftwareElementID"))); }
                 catch (Exception) { }


            }
            return ret;
        }
        //----------------------------------------------------------
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
                dataGridView1.Rows.Add("Название",name);
                appKey.Close();
            }
            key.Close();
            return ret;
        }

        ArrayList arrServices = new ArrayList();

        private void Services()
        {
            int i = 0;
            ManagementClass mcServices = new ManagementClass("Win32_Service");
            foreach (ManagementObject moService in mcServices.GetInstances())
            {
                Serv[0].Nodes.Add(moService.GetPropertyValue("Name").ToString());
                tempServ[i] = moService.GetPropertyValue("Name").ToString();
                i++;
            }
        }
        public void ServList()
        {
            ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name = '" + treeView1.SelectedNode.Text + "'");
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                try { dataGridView1.Rows.Add("Description: " , moDisk["Description"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add("Path: " , moDisk["Path"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add("Type: " , moDisk["Type"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add("State: " , moDisk["State"].ToString()); }
                catch (Exception) { };
                try { dataGridView1.Rows.Add("Start-up Type: " , moDisk["StartMode"].ToString()); }
                catch (Exception) { };
            }
        }
        //----------------------------------------------------------
        private string USBList()
        {
            string ret = "";

            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
            foreach (var device in searcher.Get())
            {

                try{dataGridView1.Rows.Add("Номер",(string)device.GetPropertyValue("DeviceID"));}
                catch(Exception){};
                try{dataGridView1.Rows.Add("PNP номер",(string)device.GetPropertyValue("PNPDeviceID"));}
                catch(Exception){};
                try { dataGridView1.Rows.Add("Описание", (string)device.GetPropertyValue("Description")); }
                catch (Exception) { };
            }

            return ret;
        }
        //----------------------------------------------------------
        private string SysFonts()
        {
            string ret = "";
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily font in fonts.Families)
            {
                dataGridView1.Rows.Add("Название", font.Name);
            }
            return ret;
        }
        //----------------------------------------------------------
        private string Process()
        {
            string ret = "";
            System.Diagnostics.Process[] processes= System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process instance in processes)
            {
                dataGridView1.Rows.Add(instance.ProcessName + ".exe",instance.Id.ToString());
            }
            return ret;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridView1.Rows.Clear();
             GC.Collect();
             dataGridView1.BackgroundColor = this.BackColor;
             for (int i = 0; i < tempMem.Length ; i++)
             {
                 if (treeView1.SelectedNode.Text == tempMem[i])
                     MemoryList();
             }

             for (int i = 0; i < tempServ.Length; i++)
             {
                 if (treeView1.SelectedNode.Text == tempServ[i])
                     ServList();
             }

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
                Desktop();
            if(treeView1.SelectedNode.Text=="ОС")
                OperSys();
            if(treeView1.SelectedNode.Text=="Идентификация ПК")
                Ident();
            if (treeView1.SelectedNode.Text == "Загрузка ОС")
                Boot();
            if (treeView1.SelectedNode.Text == "Окружение")
                Environment();
            if (treeView1.SelectedNode.Text == "Шрифты")
               SysFonts();
            if (treeView1.SelectedNode.Text == "Службы")
            {
                label1.Text = tempServ[0] + '\n';
                for (int i = 1; i < tempServ.Length; i++)
                {
                    if (tempServ[i]==null)
                        return;
                    dataGridView1.Rows.Add(tempServ[i]);
                }
            }
            if (treeView1.SelectedNode.Text == "Принтеры")
            {
                int i = 1;
                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    dataGridView1.Rows.Add("Принтер "+i.ToString(), strPrinter);
                    i++;
                }
            }
            if (treeView1.SelectedNode.Text == "Программы") 
                Installed();
            if (treeView1.SelectedNode.Text == "Групповая политика")
                Group();

            
            if (treeView1.SelectedNode.Text == "Память")
                HDDParts();

            if (treeView1.SelectedNode.Text == "Процессор")
                Processor();

            if (treeView1.SelectedNode.Text == "Видеокарта")
            {
                label1.Text = VideoCard() + "\n";
                RegistryKey RegKey = Registry.LocalMachine;
                RegKey = RegKey.OpenSubKey("SOFTWARE\\Microsoft\\DirectX");
                Object DXVer = RegKey.GetValue("Version");
                label1.Text += DXVer.ToString();
            }
            if (treeView1.SelectedNode.Text == "Компьютерная система")
                 CompSys();
            if (treeView1.SelectedNode.Text == "Материнская плата")
                BaseBoard();
            if (treeView1.SelectedNode.Text == "SCSI контроллер")
                SCSIController();
            if (treeView1.SelectedNode.Text == "IDE контроллер")
                IDEContr();
            if (treeView1.SelectedNode.Text == "Видео конфигурация")
                VideoConfig();
            if (treeView1.SelectedNode.Text == "BIOS")
                Bios();
            if (treeView1.SelectedNode.Text == "Сетевой адаптер")
                LanAdapter();

            if (treeView1.SelectedNode.Text == "Температура HDD")
            {
                // label1.Text = GetDriveTemp();
                if (thr1.IsAlive != true) thr1.Start();
                if(thr1.ThreadState == System.Threading.ThreadState.Suspended) thr1.Resume();
            }
            if (treeView1.SelectedNode.Text == "Загрузка ОП")
            {
                if (thr2.IsAlive!=true) thr2.Start();
                if (thr2.ThreadState == System.Threading.ThreadState.Suspended) thr2.Resume();
            }
            if (treeView1.SelectedNode.Text == "Загрузка ЦП")
            {
                if (thr3.IsAlive != true) thr3.Start();
                if (thr3.ThreadState == System.Threading.ThreadState.Suspended) thr3.Resume();
            }
            if (treeView1.SelectedNode.Text == "Запущенные процессы")
                Process();
            if (treeView1.SelectedNode.Text == "Проверка интернет")
                dataGridView1.Rows.Add("Доступ в интернет ", ConnectionAvailable("http://www.google.com").ToString());
            if (treeView1.SelectedNode.Text == "Сетевое соеденение")
                NetworkConnect();
            if (treeView1.SelectedNode.Text == "Тест")
            {
                Form3 TestForm = new Form3();
                TestForm.ShowDialog();
               // if (thr4.IsAlive != true) thr4.Start();
               // if (thr4.ThreadState == ThreadState.Suspended) thr4.Resume();
            }

            if (treeView1.SelectedNode.Text == "USB")
                 USBList();
            if (treeView1.SelectedNode.Text == "CDRom")
            { // не забудьте указать букву сидюка :-)
                mciSendString("open F: type CDAudio alias driveF", null, 0, IntPtr.Zero);
                mciSendString("set driveF door open", null, 0, IntPtr.Zero);
                // mciSendString("set driveG door closed", null, 0, IntPtr.Zero); // закрыть лоток
            }


        }

        private string BaseBoard()
        {
            string ret="Null";

            ObjectQuery objectQuery_Board = new ObjectQuery("select * from Win32_BaseBoard");

            ManagementObjectSearcher searcherBoard = new ManagementObjectSearcher(objectQuery_Board);
            ManagementObjectCollection valsBoard = searcherBoard.Get();

            foreach (ManagementObject val in valsBoard)
            {
                
                try{dataGridView1.Rows.Add("Manufacturer ",Convert.ToString(val.GetPropertyValue("Manufacturer"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("SerialNumberr " , Convert.ToString(val.GetPropertyValue("SerialNumber"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Caption " , Convert.ToString(val.GetPropertyValue("Caption"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Description " , Convert.ToString(val.GetPropertyValue("Description"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Status " , Convert.ToString(val.GetPropertyValue("Status"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Version " , Convert.ToString(val.GetPropertyValue("Version"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("InstallDate " , Convert.ToString(val.GetPropertyValue("InstallDate"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Model " , Convert.ToString(val.GetPropertyValue("Model"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Name " , Convert.ToString(val.GetPropertyValue("Name"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("OtherIdentifyingInfo " , Convert.ToString(val.GetPropertyValue("OtherIdentifyingInfo"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Product " , Convert.ToString(val.GetPropertyValue("Product"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("SKU " , Convert.ToString(val.GetPropertyValue("SKU"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("SlotLayout " , Convert.ToString(val.GetPropertyValue("SlotLayout"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Tag " , Convert.ToString(val.GetPropertyValue("Tag"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Weight " , Convert.ToString(val.GetPropertyValue("Weight"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Width " , Convert.ToString(val.GetPropertyValue("Width"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("PoweredOn " , Convert.ToString(val.GetPropertyValue("PoweredOn"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("HostingBoard " , Convert.ToString(val.GetPropertyValue("HostingBoard"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("HotSwappable " , Convert.ToString(val.GetPropertyValue("HotSwappable"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Depth " , Convert.ToString(val.GetPropertyValue("Depth"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Heightn " , Convert.ToString(val.GetPropertyValue("Height"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Removable " , Convert.ToString(val.GetPropertyValue("Removable"))); }
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Replaceable " , Convert.ToString(val.GetPropertyValue("Replaceable"))); }
                catch (Exception) { }
            }

            return ret;
        }

        private string IDEContr()
        {
            string ret = "Null";
            ObjectQuery objectQuery_IDE = new ObjectQuery("select * from Win32_IDEController");
            ManagementObjectSearcher searcherIDE = new ManagementObjectSearcher(objectQuery_IDE);
            ManagementObjectCollection valsIDE = searcherIDE.Get();
            foreach (ManagementObject val in valsIDE)
            {
               try{dataGridView1.Rows.Add("Manufacturer ", Convert.ToString(val.GetPropertyValue("Manufacturer")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("Name ", Convert.ToString(val.GetPropertyValue("Name")));}
               catch(Exception ){}
                try{dataGridView1.Rows.Add("DeviceID ", Convert.ToString(val.GetPropertyValue("DeviceID")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Description ", Convert.ToString(val.GetPropertyValue("Description")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("PNPDeviceID ", Convert.ToString(val.GetPropertyValue("PNPDeviceID")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("SystemName ", Convert.ToString(val.GetPropertyValue("SystemName")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Caption ",Convert.ToString(val.GetPropertyValue("Caption")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("MaxNumberControlled " , Convert.ToString(val.GetPropertyValue("MaxNumberControlled")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("PowerManagementCapabilities " , Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("PowerManagementSupported " , Convert.ToString(val.GetPropertyValue("PowerManagementSupported")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("ProtocolSupported " , Convert.ToString(val.GetPropertyValue("ProtocolSupported")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("Status ", Convert.ToString(val.GetPropertyValue("Status")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("StatusInfo ", Convert.ToString(val.GetPropertyValue("StatusInfo")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("SystemCreationClassName ", Convert.ToString(val.GetPropertyValue("SystemCreationClassName")));}
                catch(Exception ){}
                try{dataGridView1.Rows.Add("TimeOfLastReset ", Convert.ToString(val.GetPropertyValue("TimeOfLastReset"))); }
                catch (Exception) { }
            }
            return ret;
        }


        private string SCSIController()
        {
            string ret = "Null";
            ObjectQuery objectQuery_SCSI = new ObjectQuery("select * from Win32_SCSIController");
            ManagementObjectSearcher searcherSCSI = new ManagementObjectSearcher(objectQuery_SCSI);
            ManagementObjectCollection valsSCSI = searcherSCSI.Get();
            foreach (ManagementObject val in valsSCSI)
            {
               try{dataGridView1.Rows.Add("Manufacturer " , Convert.ToString(val.GetPropertyValue("Manufacturer"))); }
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("Name " , Convert.ToString(val.GetPropertyValue("Name")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("DeviceID " , Convert.ToString(val.GetPropertyValue("DeviceID")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("Description " , Convert.ToString(val.GetPropertyValue("Description")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("PNPDeviceID " , Convert.ToString(val.GetPropertyValue("PNPDeviceID")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("SystemName " , Convert.ToString(val.GetPropertyValue("SystemName")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("Caption " , Convert.ToString(val.GetPropertyValue("Caption")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("MaxNumberControlled " , Convert.ToString(val.GetPropertyValue("MaxNumberControlled")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("PowerManagementCapabilities " , Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("PowerManagementSupported " , Convert.ToString(val.GetPropertyValue("PowerManagementSupported")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("ProtocolSupported " , Convert.ToString(val.GetPropertyValue("ProtocolSupported")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("Status " , Convert.ToString(val.GetPropertyValue("Status")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("StatusInfo " , Convert.ToString(val.GetPropertyValue("StatusInfo")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("SystemCreationClassName " , Convert.ToString(val.GetPropertyValue("SystemCreationClassName")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("ControllerTimeouts " , Convert.ToString(val.GetPropertyValue("ControllerTimeouts")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName")));}
               catch(Exception ){}
               try{ dataGridView1.Rows.Add("DeviceMap " , Convert.ToString(val.GetPropertyValue("DeviceMap")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("DriverName " , Convert.ToString(val.GetPropertyValue("DriverName")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("HardwareVersion " , Convert.ToString(val.GetPropertyValue("HardwareVersion")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("MaxDataWidth " , Convert.ToString(val.GetPropertyValue("MaxDataWidth")));}
               catch(Exception ){}
               try{dataGridView1.Rows.Add("MaxTransferRate " , Convert.ToString(val.GetPropertyValue("MaxTransferRate")));}
               catch(Exception ){}
               try { dataGridView1.Rows.Add("ProtectionManagement " , Convert.ToString(val.GetPropertyValue("ProtectionManagement"))); }
               catch(Exception ){}
               
            }
            return ret;
        }

        private string VideoConfig()
        {
            string ret = "Null";
            ObjectQuery objectQuery_VidConf = new ObjectQuery("select * from Win32_VideoConfiguration");
            ManagementObjectSearcher searcherVidConf = new ManagementObjectSearcher(objectQuery_VidConf);
            ManagementObjectCollection valsVidConf = searcherVidConf.Get();
            foreach (ManagementObject val in valsVidConf)
            {
                try {dataGridView1.Rows.Add("ActualColorResolution " , Convert.ToString(val.GetPropertyValue("ActualColorResolution"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("AdapterChipType " , Convert.ToString(val.GetPropertyValue("AdapterChipType"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("AdapterCompatibility " , Convert.ToString(val.GetPropertyValue("AdapterCompatibility"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("AdapterDACType " , Convert.ToString(val.GetPropertyValue("AdapterDACType"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("BitsPerPixel " , Convert.ToString(val.GetPropertyValue("BitsPerPixel"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ColorPlanes " , Convert.ToString(val.GetPropertyValue("ColorPlanes"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("HorizontalResolution " , Convert.ToString(val.GetPropertyValue("HorizontalResolution"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("VerticalResolution " , Convert.ToString(val.GetPropertyValue("VerticalResolution"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("MonitorType " , Convert.ToString(val.GetPropertyValue("MonitorType"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("Name " , Convert.ToString(val.GetPropertyValue("Name"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("MonitorManufacturer " , Convert.ToString(val.GetPropertyValue("MonitorManufacturer"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ScreenHeight " , Convert.ToString(val.GetPropertyValue("ScreenHeight"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ScreenWidth " , Convert.ToString(val.GetPropertyValue("ScreenWidth"))); }
                catch (Exception) { }
             
            }
            return ret;
        }

        private string Battary()
        {
              string ret = "Null";
              ObjectQuery objectQuery_SCSI = new ObjectQuery("select * from Win32_PortableBattery");
            ManagementObjectSearcher searcherSCSI = new ManagementObjectSearcher(objectQuery_SCSI);
            ManagementObjectCollection valsSCSI = searcherSCSI.Get();
            foreach (ManagementObject val in valsSCSI)
            {
                try {dataGridView1.Rows.Add("Availability " , Convert.ToString(val.GetPropertyValue("Availability"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("BatteryRechargeTime " , Convert.ToString(val.GetPropertyValue("BatteryRechargeTime"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("BatteryStatus " , Convert.ToString(val.GetPropertyValue("BatteryStatus"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("Description " , Convert.ToString(val.GetPropertyValue("Description"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("PNPDeviceID " , Convert.ToString(val.GetPropertyValue("PNPDeviceID"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("SystemName " , Convert.ToString(val.GetPropertyValue("SystemName"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("Caption " , Convert.ToString(val.GetPropertyValue("Caption"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("MaxNumberControlled " , Convert.ToString(val.GetPropertyValue("MaxNumberControlled"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("PowerManagementCapabilities " , Convert.ToString(val.GetPropertyValue("PowerManagementCapabilities"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("PowerManagementSupported " , Convert.ToString(val.GetPropertyValue("PowerManagementSupported"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ProtocolSupported " , Convert.ToString(val.GetPropertyValue("ProtocolSupported"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("Status " , Convert.ToString(val.GetPropertyValue("Status"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("StatusInfo " , Convert.ToString(val.GetPropertyValue("StatusInfo"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("SystemCreationClassName " , Convert.ToString(val.GetPropertyValue("SystemCreationClassName"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ControllerTimeouts " , Convert.ToString(val.GetPropertyValue("ControllerTimeouts"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("CreationClassName " , Convert.ToString(val.GetPropertyValue("CreationClassName"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("DeviceMap " , Convert.ToString(val.GetPropertyValue("DeviceMap"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("DriverName " , Convert.ToString(val.GetPropertyValue("DriverName"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("HardwareVersion " , Convert.ToString(val.GetPropertyValue("HardwareVersion"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("MaxDataWidth " , Convert.ToString(val.GetPropertyValue("MaxDataWidth"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("MaxTransferRate " , Convert.ToString(val.GetPropertyValue("MaxTransferRate"))); }
                catch (Exception) { }
                try { dataGridView1.Rows.Add("ProtectionManagement " , Convert.ToString(val.GetPropertyValue("ProtectionManagement"))); }
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
               try {dataGridView1.Rows.Add("Name " , Convert.ToString(val.GetPropertyValue("Name")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("Manufacturer " , Convert.ToString(val.GetPropertyValue("Manufacturer")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("PNPDeviceID " , Convert.ToString(val.GetPropertyValue("PNPDeviceID")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("ProductName " , Convert.ToString(val.GetPropertyValue("ProductName")));}
               catch (Exception) { }
               try { dataGridView1.Rows.Add("ServiceName " , Convert.ToString(val.GetPropertyValue("ServiceName")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("SystemName " , Convert.ToString(val.GetPropertyValue("SystemName")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("DeviceID; " , Convert.ToString(val.GetPropertyValue("DeviceID;")));}
               catch (Exception) { }
               try { dataGridView1.Rows.Add("Description " , Convert.ToString(val.GetPropertyValue("Description")));} 
               catch (Exception) { }
               try { dataGridView1.Rows.Add("MACAddress " , Convert.ToString(val.GetPropertyValue("MACAddress")));}
               catch (Exception) { }
               try { dataGridView1.Rows.Add("PermanentAddress " , Convert.ToString(val.GetPropertyValue("PermanentAddress")));}
               catch (Exception) { }
               try { dataGridView1.Rows.Add("Status " , Convert.ToString(val.GetPropertyValue("Status"))); } 
               catch (Exception) { }
            }
            return ret;
        }
        private void ResizeForm(object sender, EventArgs e)
        {
            Значение.Width = this.Width - 445;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                double temp1, temp2;
                // Вычислим новое значение
                //  double newValue = _rnd.NextDouble() * (_ymax - _ymin) + _ymin;

                // Добавим его в конец списка
                temp1 = (double)performanceCounter1.NextValue();
                temp2 = (double)performanceCounter2.NextValue();
                if (temp1 > 100)
                    temp1 = 101;
                if (temp2 > 100)
                    temp2 = 101;

                _data.Add(temp1); //processor
                _data1.Add(temp2); //memory
                // Удалим первый элемент в списке данных, 
                // если заполнили максимальную емкость
                if (_data.Count > _capacity)
                {
                    _data.RemoveAt(0);
                }
                if (_data1.Count > _capacity)
                {
                    _data1.RemoveAt(0);
                }


                DrawGraph();
                label1.Text = "Загрузка ЦП: " + ((int)temp1).ToString() + "%"; //processor
                label3.Text = "Загрузка ОП: " + ((int)temp2).ToString() + "%"; //memory
                notifyIcon1.Text = label1.Text + "  " + label3.Text;
            }
            catch (Exception)
            {
                label1.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                label1.Text = "     Ошибка инициализации счётчиков";
                label3.Text = "";  
                zedGraphControl1.Visible = false;
                zedGraphControl2.Visible = false;
                zedGraphControl2.Enabled = false; 
                zedGraphControl1.Enabled = false;
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.ShowDialog();
        }
        private void DrawGraph()
        {

            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;
            GraphPane pane1 = zedGraphControl2.GraphPane;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            pane1.CurveList.Clear();

            pane.Fill.Color = this.BackColor;
            pane1.Fill.Color = this.BackColor;

           
            // Создадим список точек
            PointPairList list = new PointPairList();
            PointPairList list1 = new PointPairList();

            // Интервал, где есть данные
            double xmin = 0;
            double xmax = _capacity;

            // Расстояние между соседними точками по горизонтали
            double dx = 1.0;

            double curr_x = 0;

            // Заполняем список точек
            foreach (double val in _data)
            {
                list.Add(curr_x, val);
                curr_x += dx;
            }
            curr_x = 0;
            foreach (double val1 in _data1)
            {
                list1.Add(curr_x, val1);
                curr_x += dx;
            }


            // Очистим список кривых от прошлых рисунков (кадров)
            pane.CurveList.Clear();
            pane1.CurveList.Clear();
            LineItem myCurve = pane.AddCurve("Загрузка процессора", list, Color.Blue, SymbolType.None);
            LineItem myCurve1 = pane1.AddCurve("Использованно памяти", list1, Color.Pink, SymbolType.None);


            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = xmin;
            pane.XAxis.Scale.Max = xmax;
            
            pane1.XAxis.Scale.Min = xmin;
            pane1.XAxis.Scale.Max = xmax;

            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = -5;//_ymin;
            pane.YAxis.Scale.Max = 105;//_ymax;

            pane1.YAxis.Scale.Min = -5;//_ymin;
            pane1.YAxis.Scale.Max = 105;//_ymax;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();
            zedGraphControl2.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
            zedGraphControl2.Invalidate();
            
        }

        private void MinimizeFrm_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Visible = false;
            this.Enabled = false;
        }

        private void ShowFrm_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Visible = true;
            this.Enabled = true;
        }

        private void CloseFrm_Click(object sender, EventArgs e)
        {
            try
            {
                if (thr1.IsAlive == true)
                    thr1.Abort();
            }
            catch (Exception) { };
            try
            {
                if (thr2.IsAlive == true)
                    thr2.Abort();
            }
            catch (Exception) { };
            try
            {
            if (thr3.IsAlive == true)
                thr3.Abort();
            }catch (Exception) { };
            try
            {
            if (thr4.IsAlive == true)
                thr4.Abort();
            } catch (Exception) { };
            this.Close();

        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            Form3 TestFrm = new Form3();
            TestFrm.Show();
        }

        private void DblClkNt(object sender, MouseEventArgs e)
        {
            if (this.Visible == true && this.Enabled == true)
            {
                this.Hide();
                this.Visible = false;
                this.Enabled = false;
                return;
            }
            if (this.Enabled == false && this.Visible == false)
            {
                this.Show();
                this.Visible = true;
                this.Enabled = true;
                return;
            }
            
        }

        private void MiniReal_Click(object sender, EventArgs e)
        {
            if (MiniForm.Visible == false  && MiniForm.Enabled == false && MiniForm.Text == "Hidden")
            {
                MiniForm.Visible = true;
                MiniForm.Enabled = true;
                MiniForm.Show();
                MiniForm.Text = "Show";
                return;
            }
            if (MiniForm.Visible == true && MiniForm.Enabled == true && MiniForm.Text == "Show")
            {
                MiniForm.Visible = false;
                MiniForm.Enabled = false;
                MiniForm.Hide() ;
                MiniForm.Text = "Hidden";
                return;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
       
    }
}
