using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace SessionManagement
{
	public partial class frmSessionManager : DockContent
    {
        SettingsData CurrentApplicationSettings = SettingsData.Instance;

        public frmSessionManager()
		{
			this.InitializeComponent();
		}

		public string createUniqueNodeName(TreeNode treeNode, string inputName, string type)
		{
			string text = inputName;
			int i = 0;
			int num = 2;
			string result;
			try
			{
				if (type == "folder")
				{
					while (i < treeNode.Nodes.Count)
					{
						if (treeNode.Nodes[i].Text == text && int.Parse(treeNode.Nodes[i].Name) == 0)
						{
							text = inputName + "(" + num.ToString() + ")";
							num++;
							i = -1;
						}
						i++;
					}
				}
				else
				{
					while (i < treeNode.Nodes.Count)
					{
						if (treeNode.Nodes[i].Text == text && int.Parse(treeNode.Nodes[i].Name) > 0)
						{
							text = inputName + "(" + num.ToString() + ")";
							num++;
							i = -1;
						}
						i++;
					}
				}
				result = text;
			}
			catch //(Exception ex)
			{
				result = text;
			}
			return result;
		}

		public void createNewFolder(TreeNode treeNode)
		{
            TreeNode treeNode2 = new()
            {
                Name = "0",
                Text = this.createUniqueNodeName(treeNode, "New Folder", "folder"),
                ContextMenuStrip = this.contextForFolder,
                ImageIndex = 1,
                SelectedImageIndex = 1
            };
            treeNode2.EnsureVisible();
			treeNode.Nodes.Add(treeNode2);
			this.treeSessions.SelectedNode = treeNode2;
			treeNode2.BeginEdit();
		}

		private void contextFolderForDatabase_Click(object sender, EventArgs e)
		{
			this.createNewFolder(this.treeSessions.SelectedNode);
		}

		private void treeSessions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.treeSessions.SelectedNode = e.Node;
		}

		private void contextFolderForFolder_Click(object sender, EventArgs e)
		{
			this.createNewFolder(this.treeSessions.SelectedNode);
		}

		private void contextSessionForFolder_Click(object sender, EventArgs e)
		{
			new frmSession
			{
				createOrUpdateSession = new frmSession.CreateOrUpdateSession(this.createOrUpdateSession)
			}.ShowDialog();
		}

		private void contextSessionForDatabase_Click(object sender, EventArgs e)
		{
			new frmSession
			{
				createOrUpdateSession = new frmSession.CreateOrUpdateSession(this.createOrUpdateSession)
			}.ShowDialog();
		}

		public void createOrUpdateSession(Session sess)
		{
			try
			{
				TreeNode selectedNode = this.treeSessions.SelectedNode;
				if (int.Parse(selectedNode.Name) <= 0)
				{
					if (Global.AvailableSessions == null)
						Global.AvailableSessions = new List<Session>();
					
					Global.AvailableSessions.Add(sess);
                    TreeNode treeNode = new ()
                    {
                        Name = sess.SessionID.ToString(),
                        Text = sess.SessionName,
                        ContextMenuStrip = this.contextForSession,
                        ImageIndex = 2,
                        SelectedImageIndex = 2
                    };

                    treeNode.EnsureVisible();
					treeNode.BeginEdit();
					
					this.setToolTipsForSessionNode(treeNode, sess);
					this.treeSessions.SelectedNode.Nodes.Add(treeNode);
					this.alertWhenDuplicateNodeName(treeNode);
					this.treeSessions.SelectedNode = treeNode;
				}
				else
				{
					this.modifyExistingSession(selectedNode, sess);
				}
			}
			catch //(Exception ex)
			{
			}
		}

		public void modifyExistingSession(TreeNode selectedNode, Session sess)
		{
			if (selectedNode.Name == sess.SessionID.ToString())
			{
				selectedNode.Text = sess.SessionName;
				this.setToolTipsForSessionNode(selectedNode, sess);
			}
		}

		private void treeSessions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (int.Parse(e.Node.Name) > 0)
			{
				Session session = this.findSessionFromAvailableSessions(int.Parse(e.Node.Name));
				if (session != null)
				{
					this.openSession(session);
				}
			}
		}

		private void contextConnect_Click(object sender, EventArgs e)
		{
			Session session = this.findSessionFromAvailableSessions(int.Parse(this.treeSessions.SelectedNode.Name));
			if (session != null)
			{
				this.openSession(session);
			}
		}

		public Session findSessionFromAvailableSessions(int ID)
		{
			Session result;
			if (Global.AvailableSessions == null)
			{
				result = null;
			}
			else if (((Session)Global.AvailableSessions[ID - 1]).SessionID == ID)
			{
				result = (Session)Global.AvailableSessions[ID - 1];
			}
			else
			{
				for (int i = 0; i < Global.AvailableSessions.Count; i++)
				{
					if (((Session)Global.AvailableSessions[i]).SessionID == ID)
					{
						return (Session)Global.AvailableSessions[i];
					}
				}
				result = null;
			}
			return result;
		}

		public void openDatabase(string fileType)
		{
			try
			{
				OpenFileDialog openFileDialog = new ();
				if (fileType == "dat")
				{
					openFileDialog.Filter = "Database Files (*.dat)|*.dat";
					openFileDialog.Title = "Open database";
				}
				else if (fileType == "xml")
				{
					openFileDialog.Filter = "XML Files (*.xml)|*.xml";
					openFileDialog.Title = "Select XML file to import";
				}
				openFileDialog.FilterIndex = 0;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\Databases";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					this.loadDatabaseFromXMLFile(fileName, this.treeSessions);
					if (fileType == "xml")
					{
						MessageBox.Show("Database is imported successfully!", "Import database", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch //(Exception ex)
			{
			}
		}

		private void contextOpenDatabase_Click(object sender, EventArgs e)
		{
			this.openDatabase("dat");
		}

		public void createDatabaseIDAndLocation(TreeNode treeNode, string location)
		{
			if (Global.DatabaseLocation == null)
				Global.DatabaseLocation = new List<String>();
			
			if (Path.GetExtension(location) != ".dat")
				Global.DatabaseLocation.Add("");
			else
				Global.DatabaseLocation.Add(location);
			
			treeNode.Name = "-" + Global.DatabaseLocation.Count.ToString();
		}

		public void setToolTipsForSessionNode(TreeNode treeNode, Session sess)
		{
			if (sess.SessionCredentials.UserName != "")
				treeNode.ToolTipText = $"{sess.SessionCredentials.UserName}@{sess.SessionHost} ({sess.SessionProtocol}/{sess.SessionPort})";
			else
				treeNode.ToolTipText = $"{sess.SessionHost} ({sess.SessionProtocol}/{sess.SessionPort})";
		}

		public void loadDatabaseFromXMLFile(string fileName, TreeView treeView)
		{
			XmlTextReader xmlTextReader = null;
			TreeNode treeNode = null;
			try
			{
				treeView.BeginUpdate();
				xmlTextReader = new XmlTextReader(fileName);
				TreeNode treeNode2 = null;
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType == XmlNodeType.Element)
					{
						if (xmlTextReader.Name == "root" || xmlTextReader.Name == "container" || xmlTextReader.Name == "connection")
						{
							TreeNode treeNode3 = new();
							bool isEmptyElement = xmlTextReader.IsEmptyElement;
							this.setContextMenuForNode(treeNode3, xmlTextReader.Name);
							int attributeCount = xmlTextReader.AttributeCount;
							if (attributeCount > 0)
							{
								for (int i = 0; i < attributeCount; i++)
								{
									xmlTextReader.MoveToAttribute(i);
									this.SetAttributeValue(treeNode3, xmlTextReader.Name, xmlTextReader.Value);
								}
								xmlTextReader.MoveToElement();
							}
							if (xmlTextReader.Name == "root")
							{
								this.createDatabaseIDAndLocation(treeNode3, fileName);
								treeNode3.ImageIndex = 0;
								treeNode3.SelectedImageIndex = 0;
								treeNode = treeNode3;
							}
							else if (xmlTextReader.Name == "container")
							{
								treeNode3.Name = "0";
								treeNode3.ImageIndex = 1;
								treeNode3.SelectedImageIndex = 1;
							}
							else
							{
								treeNode3.ImageIndex = 2;
								treeNode3.SelectedImageIndex = 2;
								Session sess = new();
								this.createSession(treeNode3, sess, xmlTextReader);
								this.setToolTipsForSessionNode(treeNode3, sess);
							}

							if (treeNode2 != null)
								treeNode2.Nodes.Add(treeNode3);
							else
								treeView.Nodes.Add(treeNode3);
							
							if (!isEmptyElement)
								treeNode2 = treeNode3;
						}
					}
					if (xmlTextReader.NodeType == XmlNodeType.EndElement)
					{
						if (xmlTextReader.Name == "root" || xmlTextReader.Name == "container" || xmlTextReader.Name == "connection")
							treeNode2 = treeNode2.Parent;
					}
					else if (xmlTextReader.NodeType == XmlNodeType.None)
							break;
					
				}
			}
			finally
			{
				treeView.EndUpdate();
				this.expandTreeNode(treeNode);
				this.treeSessions.SelectedNode = treeNode;
				xmlTextReader.Close();
			}
		}

		public void SetAttributeValue(TreeNode treeNode, string attributeName, string value)
		{
			if (attributeName == "name")
				treeNode.Text = value;
			else if (attributeName == "expanded")
			{
				if (value == "True")
					treeNode.Tag = "True";
			}
		}

		public void createDatabaseFromPuttySessions()
		{
			try
			{
                TreeNode treeNode = new()
                {
                    Text = "PuTTY Sessions",
                    ImageIndex = 0,
                    SelectedImageIndex = 0
                };

                this.createDatabaseIDAndLocation(treeNode, "");
				this.setContextMenuForNode(treeNode, "root");

				this.treeSessions.Nodes.Add(treeNode);
				for (int i = 0; i < CurrentApplicationSettings.PuttySessionsList.Count; i++)
				{
					PuttySession puttySession = CurrentApplicationSettings.PuttySessionsList[i] as PuttySession;
					if (puttySession.SessionHost != "")
					{
                        TreeNode treeNode2 = new()
                        {
                            ImageIndex = 2,
                            SelectedImageIndex = 2
                        };
                        this.setContextMenuForNode(treeNode2, "connection");

                        Session session = new()
                        {
                            SessionName = puttySession.SessionName,
                            SessionHost = puttySession.SessionHost,
                            SessionPort = puttySession.PortNumber,
							SessionProtocol = puttySession.Protocol,

                            SessionCredentials = new BasicCredentials()
                            {
                                UserName = puttySession.UserName
                            }
                        };
                        Global.AvailableSessions.Add(session);

						session.SessionID = Global.AvailableSessions.Count;

						treeNode2.Name = session.SessionID.ToString();
						treeNode2.Text = session.SessionName;
						this.setToolTipsForSessionNode(treeNode2, session);
						treeNode.Nodes.Add(treeNode2);
					}
				}
			}
			catch //(Exception ex)
			{
			}
		}

		public void saveDatabaseToXMLFile(string fileName, TreeNode treeNode)
		{
			try
			{
				XmlTextWriter xmlTextWriter = new (fileName, Encoding.UTF8);
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteRaw("\r\n");
				xmlTextWriter.WriteStartElement("root");
				xmlTextWriter.WriteAttributeString("type", "database");
				xmlTextWriter.WriteAttributeString("name", treeNode.Text);

				string value = "False";
				if (treeNode.IsExpanded)
					value = "True";
				
				xmlTextWriter.WriteAttributeString("expanded", value);
				this.SaveNodes(treeNode.Nodes, xmlTextWriter);
				xmlTextWriter.WriteRaw("\r\n");
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Close();
			}
			catch //(Exception ex)
			{
			}
		}

		public void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter writer)
		{
			try
			{
				for (int i = 0; i < nodesCollection.Count; i++)
				{
					string value = "False";
					writer.WriteRaw("\r\n");
					writer.WriteRaw("\t");
					TreeNode treeNode = nodesCollection[i];
					if (int.Parse(treeNode.Name) == 0)
					{
						writer.WriteStartElement("container");
						writer.WriteAttributeString("type", "folder");
						writer.WriteAttributeString("name", treeNode.Text);
						if (treeNode.IsExpanded)
						{
							value = "True";
						}
						writer.WriteAttributeString("expanded", value);
					}
					else if (int.Parse(treeNode.Name) > 0)
					{
						writer.WriteRaw("\t");
						writer.WriteStartElement("connection");
						writer.WriteAttributeString("type", "PuTTY");
						writer.WriteAttributeString("name", treeNode.Text);
						Session sess = this.findSessionFromAvailableSessions(int.Parse(treeNode.Name));
						this.saveSession(sess, writer);
					}
					if (treeNode.Nodes.Count > 0)
					{
						writer.WriteRaw("\t");
						this.SaveNodes(treeNode.Nodes, writer);
					}
					writer.WriteRaw("\r\n");
					writer.WriteRaw("\t");
					writer.WriteEndElement();
				}
			}
			catch //(Exception ex)
			{
			}
		}


		public void WriteFullItem(XmlTextWriter writer, String name, int text) => WriteFullItem(writer, name, text.ToString());
		
		public void WriteFullItem(XmlTextWriter writer, String name, String text) {

            writer.WriteRaw("\r\n");
            writer.WriteRaw("\t\t\t");
            writer.WriteStartElement(name);
            writer.WriteValue(text);
            writer.WriteEndElement();
        }

		public void saveSession(Session sess, XmlTextWriter writer)
		{
			try
			{
                WriteFullItem(writer, "name",sess.SessionName);
                WriteFullItem(writer, "protocol", sess.SessionProtocol);
                WriteFullItem(writer, "host", sess.SessionHost);
                WriteFullItem(writer, "port", sess.SessionPort);

                WriteFullItem(writer, "session", sess.SessionConfig);
                WriteFullItem(writer, "description", sess.SessionDescription);
                WriteFullItem(writer, "login", sess.SessionCredentials.UserName);
                WriteFullItem(writer, "password", sess.SessionCredentials.Password);


                WriteFullItem(writer, "connectiontimeout", sess.ConnectionTimeout);
                WriteFullItem(writer, "logintimeout", sess.UsernameTimeout);
                WriteFullItem(writer, "passwordtimeout", sess.PasswordTimeout);
                WriteFullItem(writer, "commandtimeout", sess.CommandTimeout);


                if (sess.PostLoginCommands.Length > 0)
                    WriteFullItem(writer, "command1", sess.PostLoginCommands[0]);
				else
                    WriteFullItem(writer, "command1", "");

                if (sess.PostLoginCommands.Length > 1)
                    WriteFullItem(writer, "command2", sess.PostLoginCommands[1]);
                else
                    WriteFullItem(writer, "command2", "");

                if (sess.PostLoginCommands.Length > 2)
                    WriteFullItem(writer, "command3", sess.PostLoginCommands[2]);
                else
                    WriteFullItem(writer, "command3", "");

                if (sess.PostLoginCommands.Length > 3)
                    WriteFullItem(writer, "command4", sess.PostLoginCommands[3]);
                else
                    WriteFullItem(writer, "command4", "");

                if (sess.PostLoginCommands.Length > 4)
                    WriteFullItem(writer, "command5", sess.PostLoginCommands[4]);
                else
                    WriteFullItem(writer, "command5", "");


                WriteFullItem(writer, "postcommands", sess.PostLogin.ToString());
                WriteFullItem(writer, "ftpusername", sess.FTPCredentials.UserName);
                WriteFullItem(writer, "ftppassword", sess.FTPCredentials.Password);
                WriteFullItem(writer, "sftpusername", sess.SFTPCredentials.UserName);
                WriteFullItem(writer, "sftppassword", sess.SFTPCredentials.Password);

			}
			catch //(Exception ex)
			{
			}
		}

		public void setContextMenuForNode(TreeNode treeNode, string nodeName)
		{
			if (nodeName == "root")
				treeNode.ContextMenuStrip = this.contextForDatabase;
			else if (nodeName == "container")
				treeNode.ContextMenuStrip = this.contextForFolder;
			else if (nodeName == "connection")
				treeNode.ContextMenuStrip = this.contextForSession;
		}

		public void createSession(TreeNode treeNode, Session sess, XmlTextReader reader)
		{
			if (sess != null)
			{
				try
				{
					if (Global.AvailableSessions == null)
						Global.AvailableSessions = new List<Session>();

					Global.AvailableSessions.Add(sess);
					if (Global.AvailableSessions == null)
						sess.SessionID = 0;
					else
						sess.SessionID = Global.AvailableSessions.Count;

					int sessionID = sess.SessionID;
					treeNode.Name = sessionID.ToString();
					while (reader.Read())
					{
						if (reader.NodeType == XmlNodeType.Element)
						{
							string name = reader.Name;
							switch (name)
							{
								case "name":
									reader.Read();
									sess.SessionName = reader.Value;
									break;
								case "protocol":
									reader.Read();
									sess.SessionProtocol = reader.Value;
									break;
								case "host":
									reader.Read();
									sess.SessionHost = reader.Value;
									break;
								case "port":
									reader.Read();
									sess.SessionPort = int.Parse(reader.Value);
									break;
								case "session":
									reader.Read();
									sess.SessionConfig = reader.Value;
									break;
								case "description":
									reader.Read();
									sess.SessionDescription = reader.Value;
									break;
								case "login":
									reader.Read();
									sess.SessionCredentials.UserName = reader.Value;
									if (sess.SessionCredentials.UserName.Contains("\r\n"))
									{
										sess.SessionCredentials.UserName = "";
									}
									break;
								case "password":
									reader.Read();
									sess.SessionCredentials.Password = reader.Value;
									if (sess.SessionCredentials.Password.Contains("\r\n"))
									{
										sess.SessionCredentials.Password = "";
									}
									break;
								case "connectiontimeout":
									reader.Read();
									sess.ConnectionTimeout = int.Parse(reader.Value);
									break;
								case "logintimeout":
									reader.Read();
									sess.UsernameTimeout = int.Parse(reader.Value);
									break;
								case "passwordtimeout":
									reader.Read();
									sess.PasswordTimeout = int.Parse(reader.Value);
									break;
								case "commandtimeout":
									reader.Read();
									sess.CommandTimeout = int.Parse(reader.Value);
									break;
								case "command1":
								case "command2":
								case "command3":
								case "command4":
								case "command5":
									reader.Read();
									if (!reader.Value.Contains("\r\n"))
										sess.PostLoginCommands.Append(reader.Value);
									break;
								case "postcommands":
									reader.Read();
									sess.PostLogin = bool.Parse(reader.Value);
									break;
								case "ftpusername":
									reader.Read();
									sess.FTPCredentials.UserName = reader.Value;
									if (sess.FTPCredentials.UserName.Contains("\r\n"))
									{
										sess.FTPCredentials.UserName = "";
									}
									break;
								case "ftppassword":
									reader.Read();
									sess.FTPCredentials.Password = reader.Value;
									if (sess.FTPCredentials.Password.Contains("\r\n"))
									{
										sess.FTPCredentials.Password = "";
									}
									break;
								case "sftpusername":
									reader.Read();
									sess.SFTPCredentials.UserName = reader.Value;
									if (sess.SFTPCredentials.UserName.Contains("\r\n"))
									{
										sess.SFTPCredentials.UserName = "";
									}
									break;
								case "sftppassword":
									reader.Read();
									sess.SFTPCredentials.Password = reader.Value;
									if (sess.SFTPCredentials.Password.Contains("\r\n"))
									{
										sess.SFTPCredentials.Password = "";
									}
									break;
							}
						}
						else if (reader.NodeType == XmlNodeType.EndElement)
						{
							if (reader.Name == "connection")
							{
								break;
							}
						}
					}
				}
				catch //(Exception ex)
				{
				}
			}
		}

		public void expandTreeNode(TreeNode treeNode)
		{
			if ((String)treeNode.Tag == "True")
				treeNode.Expand();
			
			for (int i = 0; i < treeNode.Nodes.Count; i++)
				this.expandTreeNode(treeNode.Nodes[i]);
		}

		private void contextConfigForSession_Click(object sender, EventArgs e)
		{
			frmSession frmSession = new ();
			TreeNode selectedNode = this.treeSessions.SelectedNode;
			Session sess = this.findSessionFromAvailableSessions(int.Parse(this.treeSessions.SelectedNode.Name));
			frmSession.loadExistingSession(sess);
			frmSession.createOrUpdateSession = new frmSession.CreateOrUpdateSession(this.createOrUpdateSession);
			frmSession.ShowDialog();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			e.Cancel = true;
			base.Hide();
			this.hideSessionManager();
		}

		private void frmSessionManager_Load(object sender, EventArgs e)
		{
			try
			{
				this.iState = 0;
				this.treeNodeCopy = null;
				this.treeNodeIsCopied = null;
				Global.DatabaseLocation = new List<String>();
				if (File.Exists(CurrentApplicationSettings.DefaultDatabaseLocation))
				{
					this.loadDatabaseFromXMLFile(CurrentApplicationSettings.DefaultDatabaseLocation, this.treeSessions);
				}
				this.treeSessions.TreeViewNodeSorter = new frmSessionManager.NodeSorter();
			}
			catch //(Exception ex)
			{
			}
		}

		public void alertWhenDuplicateNodeName(TreeNode treeNode)
		{
			if (treeNode.Parent != null)
			{
				foreach (object obj in treeNode.Parent.Nodes)
				{
					TreeNode treeNode2 = (TreeNode)obj;
					if (treeNode2 != treeNode && treeNode2.Text == treeNode.Text)
					{
						if (int.Parse(treeNode2.Name) == 0 && int.Parse(treeNode.Name) == 0)
						{
							MessageBox.Show("This name is used for another folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							break;
						}
						if (int.Parse(treeNode2.Name) > 0 && int.Parse(treeNode.Name) > 0)
						{
							MessageBox.Show("This name is used for another session", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							break;
						}
					}
				}
			}
		}

		private void treeSessions_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			string oldName = e.Node.Text;
			base.BeginInvoke(new Action(delegate()
			{
				this.updateAvailableSessionAfterRenamingSessionName(e.Node, oldName);
			}));
		}

		public void updateAvailableSessionAfterRenamingSessionName(TreeNode treeNode, string oldName)
		{
			if (treeNode.Text.Trim() == "")
			{
				treeNode.Text = oldName;
			}
			else
			{
				if (int.Parse(treeNode.Name) > 0)
				{
					Session session = this.findSessionFromAvailableSessions(int.Parse(treeNode.Name));
					if (session != null)
						session.SessionName = treeNode.Text;
				}
				if (treeNode.Text != oldName)
				{
					this.alertWhenDuplicateNodeName(treeNode);
					this.treeSessions.Sort();
				}
				this.treeSessions.SelectedNode = treeNode;
			}
		}

		private void contextFTPExternal_Click(object sender, EventArgs e)
		{
			Session session = this.findSessionFromAvailableSessions(int.Parse(this.treeSessions.SelectedNode.Name));
			if (session != null)
				this.openExtraSession(session, "ftp");
		}

		private void contextSFTPExternal_Click(object sender, EventArgs e)
		{
			Session session = this.findSessionFromAvailableSessions(int.Parse(this.treeSessions.SelectedNode.Name));
			if (session != null)
				this.openExtraSession(session, "sftp");
		}

		private void contextConnectExternal_Click(object sender, EventArgs e)
		{
			Session session = this.findSessionFromAvailableSessions(int.Parse(this.treeSessions.SelectedNode.Name));
			if (session != null)
			{
				if (!File.Exists(CurrentApplicationSettings.PuttyLocation))
				{
					MessageBox.Show("Putty.exe file does not exist. Go to Tools -> Options... to configure PuTTY file");
					return;
				}

				try
				{
					string str = $" -load \"{session.SessionConfig}\" -{session.SessionProtocol.ToLower()}";
					
					if (session.SessionPort != -1)
						str += $" -P {session.SessionPort}";
					
					Process process = Process.Start(new ProcessStartInfo(CurrentApplicationSettings.PuttyLocation)
					{
						Arguments = str + " " + session.SessionHost,
						UseShellExecute = false,
						CreateNoWindow = false,
						WindowStyle = ProcessWindowStyle.Hidden,
						RedirectStandardInput = true,
						RedirectStandardOutput = true,
						RedirectStandardError = true
					});
				}
				catch //(Exception ex)
				{
				}
			}

		}

		private void contextCreateDatabase_Click(object sender, EventArgs e)
		{
			this.createNewDatabase();
		}

		public string createUniqueDatabaseName(string inputName)
		{
			string text = inputName;
			int i = 0;
			int num = 2;
			string result;
			try
			{
				while (i < this.treeSessions.Nodes.Count)
				{
					if (this.treeSessions.Nodes[i].Text == text)
					{
						text = inputName + "(" + num.ToString() + ")";
						num++;
						i = -1;
					}
					i++;
				}
				result = text;
			}
			catch //(Exception ex)
			{
				result = text;
			}
			return result;
		}

		public void createNewDatabase()
		{
			try
			{
				TreeNode treeNode = new ();
				this.createDatabaseIDAndLocation(treeNode, "");
				treeNode.Text = this.createUniqueDatabaseName("New database");
				treeNode.ContextMenuStrip = this.contextForDatabase;
				treeNode.ImageIndex = 0;
				treeNode.SelectedImageIndex = 0;
				treeNode.EnsureVisible();
				this.treeSessions.Nodes.Add(treeNode);
				treeNode.BeginEdit();
				this.treeSessions.SelectedNode = treeNode;
			}
			catch //(Exception ex)
			{
			}
		}

		public void CopyNode(TreeNode treeNode)
		{
			try
			{
				if (this.iState == 2)
				{
					if (this.treeNodeIsCopied != null)
					{
						if (int.Parse(this.treeNodeIsCopied.Name) > 0)
						{
							this.treeNodeIsCopied.ImageIndex = 2;
							this.treeNodeIsCopied.SelectedImageIndex = 2;
						}
						else
						{
							this.treeNodeIsCopied.ImageIndex = 1;
							this.treeNodeIsCopied.SelectedImageIndex = 1;
						}
					}
				}
				this.iState = 1;
				this.treeNodeIsCopied = treeNode;
				this.treeNodeCopy = (TreeNode)this.treeNodeIsCopied.Clone();
			}
			catch //(Exception ex)
			{
			}
		}

		public void CutNode(TreeNode treeNode)
		{
			try
			{
				if (this.treeNodeIsCopied != null)
				{
					if (int.Parse(this.treeNodeIsCopied.Name) > 0)
					{
						this.treeNodeIsCopied.ImageIndex = 2;
						this.treeNodeIsCopied.SelectedImageIndex = 2;
					}
					else
					{
						this.treeNodeIsCopied.ImageIndex = 1;
						this.treeNodeIsCopied.SelectedImageIndex = 1;
					}
				}
				this.iState = 2;
				this.treeNodeIsCopied = treeNode;
				this.treeNodeCopy = (TreeNode)this.treeNodeIsCopied.Clone();
				if (int.Parse(treeNode.Name) > 0)
				{
					treeNode.ImageIndex = 3;
					treeNode.SelectedImageIndex = 3;
				}
				else
				{
					treeNode.ImageIndex = 4;
					treeNode.SelectedImageIndex = 4;
				}
			}
			catch //(Exception ex)
			{
			}
		}

		public void ClearCopyOrCut()
		{
			try
			{
				if (this.treeNodeIsCopied != null)
				{
					if (int.Parse(this.treeNodeIsCopied.Name) > 0)
					{
						this.treeNodeIsCopied.ImageIndex = 2;
						this.treeNodeIsCopied.SelectedImageIndex = 2;
					}
					else
					{
						this.treeNodeIsCopied.ImageIndex = 1;
						this.treeNodeIsCopied.SelectedImageIndex = 1;
					}
				}
				this.iState = 0;
				this.treeNodeCopy = null;
				this.treeNodeIsCopied = null;
			}
			catch //(Exception ex)
			{
			}
		}

		public void PasteNode(TreeNode treeNode)
		{
			if (int.Parse(treeNode.Name) <= 0)
			{
				if (this.iState != 0 && this.treeNodeCopy != null)
				{
					if (this.treeNodeIsCopied != treeNode)
					{
						try
						{
							if (this.iState == 2 && this.treeNodeIsCopied != null)
								this.treeSessions.Nodes.Remove(this.treeNodeIsCopied);

							TreeNode treeNode2 = (TreeNode)this.treeNodeCopy.Clone();
							if (int.Parse(treeNode2.Name) == 0)
								treeNode2.Text = this.createUniqueNodeName(treeNode, treeNode2.Text, "folder");
							else
								treeNode2.Text = this.createUniqueNodeName(treeNode, treeNode2.Text, "session");
							
							treeNode.Nodes.Add(treeNode2);
							this.cloneAllSessionsInTreeNode(treeNode2);
							treeNode.Expand();
						
							if (this.iState == 2)
								this.iState = 0;
						}
						catch //(Exception ex)
						{
						}
					}
				}
			}
		}

		public void deleteNode(TreeNode treeNode)
		{
			if (treeNode != null)
			{
				if (treeNode.Parent != null)
				{
					try
					{
						string caption;
						if (int.Parse(treeNode.Name) > 0)
							caption = "Delete Session";
						else
							caption = "Delete Folder";
						
						DialogResult dialogResult = MessageBox.Show($"Do you really want to delete {treeNode.Text}?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
							this.treeSessions.Nodes.Remove(treeNode);
					}
					catch //(Exception ex)
					{
					}
				}
			}
		}

		public void cloneAllSessionsInTreeNode(TreeNode treeNode)
		{
			try
			{
				if (int.Parse(treeNode.Name) > 0)
				{
					Session fromSession = findSessionFromAvailableSessions(int.Parse(treeNode.Name));
					Session session = new ();
					session.copySession(fromSession);
					Global.AvailableSessions.Add(session);
					session.SessionID = Global.AvailableSessions.Count;
					session.SessionName = treeNode.Text;
					treeNode.Name = session.SessionID.ToString();
				}
				else
				{
					for (int i = 0; i < treeNode.Nodes.Count; i++)
					{
						this.cloneAllSessionsInTreeNode(treeNode.Nodes[i]);
						if ((String)treeNode.Nodes[i].Tag == "True")
						{
							treeNode.Nodes[i].Expand();
						}
					}
				}
			}
			catch //(Exception ex)
			{
			}
		}

		public void renameNode(TreeNode treeNode)
		{
			if (treeNode != null && treeNode.Parent != null)
				treeNode.BeginEdit();
		}

		public string GetDatabaseLocation(int databaseID)
		{
			int num = -databaseID;

			if (Global.DatabaseLocation.Count < num)
				return "";

			return Global.DatabaseLocation[num - 1].ToString();
		}

		public void SetDatabaseLocation(int databaseID, string location)
		{
			int num = -databaseID;

			if (Global.DatabaseLocation.Count >= num)
				Global.DatabaseLocation[num - 1] = location;
		}

		public string GetFileNameToSave(string fileName)
		{
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Database Files (*.dat)|*.dat",
                FilterIndex = 2,
                RestoreDirectory = true,
                InitialDirectory = Directory.GetCurrentDirectory() + "\\Databases",
                FileName = fileName
            };
			
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
				return saveFileDialog.FileName;

			return "";
		}

		public void SaveDatabase(TreeNode treeNode)
		{
			if (treeNode != null)
			{
				try
				{
					if (treeNode.Parent == null && int.Parse(treeNode.Name) < 0)
					{
						string text = this.GetDatabaseLocation(int.Parse(treeNode.Name));
						if (text != "")
						{
							this.saveDatabaseToXMLFile(text, treeNode);
						}
						else
						{
							text = this.GetFileNameToSave(treeNode.Text);
							if (text != "")
							{
								this.SetDatabaseLocation(int.Parse(treeNode.Name), text);
								this.saveDatabaseToXMLFile(text, treeNode);
							}
						}
						if (CurrentApplicationSettings.DefaultDatabaseLocation == "")
						{
                            CurrentApplicationSettings.DefaultDatabaseLocation = text;
                            CurrentApplicationSettings.Save();
						}
					}
				}
				catch //(Exception ex)
				{
				}
			}
		}

		public void SaveAllDatabases()
		{
			for (int i = 0; i < this.treeSessions.Nodes.Count; i++)
			{
				TreeNode treeNode = this.treeSessions.Nodes[i];
				if (this.GetDatabaseLocation(int.Parse(treeNode.Name)) == "")
				{
					DialogResult dialogResult = MessageBox.Show($"Do you want to save {treeNode.Text}?", "Save database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
						this.SaveDatabase(treeNode);
				}
				else
					this.SaveDatabase(treeNode);
			}
		}

		public void RenameDatabase(string dbID, string dbName)
		{
			for (int i = 0; i < this.treeSessions.Nodes.Count; i++)
			{
				if (this.treeSessions.Nodes[i].Name == dbID)
				{
					this.treeSessions.Nodes[i].Text = dbName;
					TreeNode selectedNode = this.treeSessions.Nodes[i];
					this.treeSessions.Sort();
					this.treeSessions.SelectedNode = selectedNode;
					break;
				}
			}
		}

		public void OpenAllSessionsInFolder(TreeNode treeNode)
		{
			try
			{
				for (int i = 0; i < treeNode.Nodes.Count; i++)
				{
					if (int.Parse(treeNode.Nodes[i].Name) > 0)
					{
						Session session = this.findSessionFromAvailableSessions(int.Parse(treeNode.Nodes[i].Name));
						if (session != null)
							this.openSession(session);
					}
				}
			}
			catch //(Exception ex)
			{
			}
		}

		private void contextDeleteForSession_Click(object sender, EventArgs e)
		{
			this.deleteNode(this.treeSessions.SelectedNode);
		}

		private void contextCopyForSession_Click(object sender, EventArgs e)
		{
			this.CopyNode(this.treeSessions.SelectedNode);
		}

		private void contextCutForSession_Click(object sender, EventArgs e)
		{
			this.CutNode(this.treeSessions.SelectedNode);
		}

		private void contextRenameForSession_Click(object sender, EventArgs e)
		{
			this.renameNode(this.treeSessions.SelectedNode);
		}

		private void contextPasteForFolder_Click(object sender, EventArgs e)
		{
			this.PasteNode(this.treeSessions.SelectedNode);
		}

		private void contextCutForFolder_Click(object sender, EventArgs e)
		{
			this.CutNode(this.treeSessions.SelectedNode);
		}

		private void contextCopyForFolder_Click(object sender, EventArgs e)
		{
			this.CopyNode(this.treeSessions.SelectedNode);
		}

		private void contextDeleteForFolder_Click(object sender, EventArgs e)
		{
			this.deleteNode(this.treeSessions.SelectedNode);
		}

		private void contextForFolder_Opening(object sender, CancelEventArgs e)
		{
			this.contextPasteForFolder.Enabled = this.iState != 0;
		}

		private void contextRenameForFolder_Click(object sender, EventArgs e)
		{
			this.renameNode(this.treeSessions.SelectedNode);
		}

		private void contextConnectAllForFolder_Click(object sender, EventArgs e)
		{
			this.OpenAllSessionsInFolder(this.treeSessions.SelectedNode);
		}

		private void contextPasteForDatabase_Click(object sender, EventArgs e)
		{
			this.PasteNode(this.treeSessions.SelectedNode);
		}

		private void contextForDatabase_Opening(object sender, CancelEventArgs e)
		{
			try
			{
				contextPasteForDatabase.Enabled = iState != 0;
				
				string databaseLocation = GetDatabaseLocation(int.Parse(treeSessions.SelectedNode.Name));
				
				contextSetDefaultForDatabase.Enabled = databaseLocation != CurrentApplicationSettings.DefaultDatabaseLocation;
			}
			catch //(Exception ex)
			{
			}
		}

		private void contextSaveForDatabase_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeSessions.SelectedNode;
			SaveDatabase(selectedNode);
		}

		private void contextPropertiesForDatabase_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeSessions.SelectedNode;
			string databaseLocation = GetDatabaseLocation(int.Parse(selectedNode.Name));
			new frmDatabaseProperties(selectedNode.Name, selectedNode.Text, databaseLocation)
			{
				renameDatabase = new frmDatabaseProperties.RenameDatabase(RenameDatabase)
			}.ShowDialog();
		}

		private void contextSetDefaultForDatabase_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeSessions.SelectedNode;
			string databaseLocation = GetDatabaseLocation(int.Parse(selectedNode.Name));
			if (databaseLocation != CurrentApplicationSettings.DefaultDatabaseLocation)
			{
                CurrentApplicationSettings.DefaultDatabaseLocation = databaseLocation;
                CurrentApplicationSettings.Save();
			}
		}

		private void treeSessions_KeyPress(object sender, KeyPressEventArgs e)
		{
			char keyChar = e.KeyChar;
			if (keyChar != '\r')
			{
				if (keyChar == '\u001b')
					this.ClearCopyOrCut();
			}
			else
			{
				int num = int.Parse(this.treeSessions.SelectedNode.Name);
				if (num > 0)
				{
					Session session = this.findSessionFromAvailableSessions(num);
					if (session != null)
						this.openSession(session);
				}
			}
		}

		private void treeSessions_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode selectedNode = this.treeSessions.SelectedNode;
			if (selectedNode != null)
			{
				try
				{
					if (e.Modifiers == Keys.Control)
					{
						Keys keyCode = e.KeyCode;
						if (keyCode != Keys.C)
						{
							switch (keyCode)
							{
							case Keys.V:
								this.PasteNode(selectedNode);
								break;
							case Keys.X:
								if (selectedNode.Parent != null)
								{
									this.CutNode(selectedNode);
								}
								break;
							}
						}
						else if (selectedNode.Parent != null)
						{
							this.CopyNode(selectedNode);
						}
					}
					else if (e.KeyCode == Keys.Delete)
					{
						this.deleteNode(this.treeSessions.SelectedNode);
					}
					else if (e.KeyCode == Keys.F2)
					{
						this.renameNode(this.treeSessions.SelectedNode);
					}
				}
				catch //(Exception ex)
				{
				}
			}
		}

		private void contextCloseDatabaseForDatabase_Click(object sender, EventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.treeSessions.SelectedNode;
				string databaseLocation = this.GetDatabaseLocation(int.Parse(selectedNode.Name));
				DialogResult dialogResult = MessageBox.Show("Do you really want to close this database?", "Close database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult != DialogResult.No)
				{
					this.SaveDatabase(selectedNode);
					this.treeSessions.Nodes.Remove(selectedNode);
				}
			}
			catch //(Exception ex)
			{
			}
		}

		private void frmSessionManager_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveAllDatabases();
		}

		private void treeSessions_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				TreeNode selectedNode = this.treeSessions.SelectedNode;
				int num = int.Parse(selectedNode.Name);
				string text;
				if (num > 0)
				{
					Session session = this.findSessionFromAvailableSessions(num);
					if (session.SessionCredentials.UserName != "")
						text = $"Session - {session.SessionCredentials.UserName}@{session.SessionHost} ({session.SessionProtocol}/{session.SessionPort})";
					else
						text = $"Session - {session.SessionHost} ({session.SessionProtocol}/{session.SessionPort})";
				}
				else if (num == 0)
					text = "Folder - " + selectedNode.Text;
				else
					text = "Database - " + selectedNode.Text;

				this.displayStatus(text);
			}
			catch //(Exception ex)
			{
			}
		}

		//private const int IS_COPY = 1;

		//private const int IS_CUT = 2;

		//private const int IS_NONE = 0;

		//private const int INDEX_DATABASE = 0;

		//private const int INDEX_FOLDER = 1;

		//private const int INDEX_FOLDER_CUT = 4;

		//private const int INDEX_SESSION = 2;

		//private const int INDEX_SESSION_CUT = 3;

		private TreeNode treeNodeCopy;

		private TreeNode treeNodeIsCopied;

		private int iState;

		public frmSessionManager.OpenSession openSession;

		public frmSessionManager.HideSessionManager hideSessionManager;

		public frmSessionManager.OpenExtraSession openExtraSession;

		public frmSessionManager.DisplayStatus displayStatus;

		public delegate void OpenSession(Session sess);

		public delegate void HideSessionManager();

		public delegate void OpenExtraSession(Session sess, string type);

		public delegate void DisplayStatus(string text);

		public class NodeSorter : IComparer
		{
			public int Compare(object x, object y)
			{
				TreeNode treeNode = x as TreeNode;
				TreeNode treeNode2 = y as TreeNode;
				try
				{
					if (int.Parse(treeNode.Name) > 0 && int.Parse(treeNode2.Name) > 0)
						return string.Compare(treeNode.Text, treeNode2.Text);
					
					if (int.Parse(treeNode.Name) <= 0 && int.Parse(treeNode2.Name) <= 0)
						return string.Compare(treeNode.Text, treeNode2.Text);
				}
				catch //(Exception ex)
				{
				}
				return int.Parse(treeNode.Name) - int.Parse(treeNode2.Name);
			}
		}
	}
}
