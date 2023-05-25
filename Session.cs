using System;
using System.Collections;
using System.Linq;

namespace SessionManagement
{
    public class BasicCredentials {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class Session
    {

        public Session()
        {

        }

        public int SessionID { get; set; } = -1;

        public string SessionName { get; set; }

        public string SessionHost { get; set; }

        public int SessionPort { get; set; } = -1;

        public string SessionProtocol { get; set; }

        public string SessionDescription { get; set; } = "";
        public string SessionConfig { get; set; } = SettingsData.Instance.CreatePuttySetting;
        public BasicCredentials SessionCredentials = new ();

        public int ConnectionTimeout { get; set; } = 2000;

        public int UsernameTimeout { get; set; } = 1000;

        public int PasswordTimeout { get; set; } = 1000;

        public bool PostLogin { get; set; } = false;

        public int CommandTimeout { get; set; } = 1000;

        public String[] PostLoginCommands { get; set; } = Array.Empty<String>();

        public BasicCredentials SFTPCredentials = new ();
        public BasicCredentials FTPCredentials = new ();


        public void copySession(Session fromSession)
        {

            SessionID = fromSession.SessionID;
            SessionName = fromSession.SessionName;
            SessionHost = fromSession.SessionHost;
            SessionPort = fromSession.SessionPort;
            SessionProtocol = fromSession.SessionProtocol;
            SessionDescription = fromSession.SessionDescription;
            SessionConfig = fromSession.SessionConfig;
            SFTPCredentials = fromSession.SFTPCredentials;
            FTPCredentials = fromSession.FTPCredentials;
            ConnectionTimeout = fromSession.ConnectionTimeout;
            UsernameTimeout = fromSession.UsernameTimeout;
            PasswordTimeout = fromSession.PasswordTimeout;
            PostLogin = fromSession.PostLogin;
            CommandTimeout = fromSession.CommandTimeout;
            PostLoginCommands = fromSession.PostLoginCommands;
            SessionCredentials = fromSession.SessionCredentials;
        }

    }
}
