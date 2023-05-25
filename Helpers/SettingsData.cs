using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionManagement
{
    internal class SettingsData
    {
        private static SettingsData __SettingsData = null;
        public static SettingsData Instance
        {
            get
            {
                if (__SettingsData == null)
                {

                    if (File.Exists(SettingsFilePath))
                    {
                        String jsonString = File.ReadAllText(SettingsFilePath);
                        __SettingsData = JsonSerializer.Deserialize<SettingsData>(jsonString);
                    }
                    else
                    {
                        __SettingsData = new SettingsData();
                        __SettingsData.Save();
                    }
                }

                return __SettingsData;
            }
        }
        
        public void Save() {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(SettingsFilePath, jsonString);
        }



        public string PuttyLocation { get; set; }

        public string WinSCPLocation { get; set; }


        public string DefaultDatabaseLocation { get; set; }

        public string QuickPuttySetting { get; set; } = "Default Settings";
        public string QuickPuttyProtocol { get; set; } = "SSH";
        public string CreatePuttySetting { get; set; } = "Default Settings";



        public bool ViewToolbarsQuickSession { get; set; } = true;
        public bool ViewToolbarsMSC { get; set; } = true;
        public bool ViewSessionManager { get; set; } = true;
        public String SessionManagerPosition { get; set; } = "Left";



        public int SessionManagerWidth { get; set; } = 22;

        public int QuickConnectionTimeout { get; set; } = 2000;
        public int QuickUsernameTimeout { get; set; } = 1000;
        public int QuickPasswordTimout { get; set; } = 1000;




        [JsonIgnore]
        public List<PuttySession> __PuttySessionsList;
        [JsonIgnore]
        public List<PuttySession> PuttySessionsList
        {
            get
            {
                if (__PuttySessionsList == null)
                {
                    __PuttySessionsList = new List<PuttySession>();
                    readPuttySessionFromRegistry();
                }

                return __PuttySessionsList;

            }
        }
        public void readPuttySessionFromRegistry()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\SimonTatham\\PuTTY\\Sessions", true);

                if (registryKey != null)
                {
                    __PuttySessionsList.Clear();

                    foreach (String sessName in registryKey.GetSubKeyNames())
                    {
                        RegistryKey registryKey2 = registryKey.OpenSubKey(sessName, true);
                        PuttySession puttySession = new()
                        {
                            SessionName = sessName,
                            SessionHost = registryKey2.GetValue("HostName").ToString(),
                            Protocol = registryKey2.GetValue("Protocol").ToString(),
                            PortNumber = int.Parse(registryKey2.GetValue("PortNumber").ToString()),
                            UserName = registryKey2.GetValue("UserName").ToString()
                        };

                        if (puttySession.SessionHost.Contains("@"))
                        {
                            string[] array = puttySession.SessionHost.Split(new char[] { '@' });

                            puttySession.SessionHost = array[1];
                            if (String.IsNullOrEmpty(puttySession.UserName))
                                puttySession.UserName = array[0];
                        }

                        registryKey2.Close();
                        __PuttySessionsList.Add(puttySession);
                    }
                    registryKey.Close();

                }
            }
            catch //(Exception ex)
            {
            }
        }

        [JsonIgnore]
        public readonly Dictionary<String, decimal> Ports = new(3) {
            {"SSH", 22m },
            {"Telnet", 23m },
            {"RLogin", 513m }
        };


        [JsonIgnore]
        private Dictionary<Architecture, String> PuttyDownload = new(3) {
                { Architecture.X64,"https://the.earth.li/~sgtatham/putty/latest/w64/putty.exe" },
                { Architecture.X86,"https://the.earth.li/~sgtatham/putty/latest/w32/putty.exe" },
                { Architecture.Arm64,"https://the.earth.li/~sgtatham/putty/latest/wa64/putty.exe" }
            };

        [JsonIgnore]
        public Architecture ExecutionArchitecture
        {
            get
            {
                return RuntimeInformation.ProcessArchitecture;
            }
        }

        [JsonIgnore]
        public String PuttyDownloadPath
        {
            get
            {
                Architecture currentArch = ExecutionArchitecture;

                if (!PuttyDownload.ContainsKey(currentArch))
                {
                    MessageBox.Show($"No link available for architecture {currentArch}");
                    return "";
                }

                return PuttyDownload[currentArch];
            }
        }

        [JsonIgnore]
        private static String SettingsFilePath { get { return Path.Combine(ProcessPath, "settings.json"); } }

        [JsonIgnore]
        public static String ProcessPath { get { return Path.GetDirectoryName(Environment.ProcessPath); } }
    }
}
