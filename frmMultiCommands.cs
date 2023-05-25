using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SessionManagement
{
    public partial class frmMultiCommands : Form
    {
        public frmMultiCommands()
        {
            this.InitializeComponent();
            this.loadCommand = false;
            this.defaultTimeout = 500;
        }

        public String[] readTextFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch 
            {
            }
            return Array.Empty<String>();
        }

        public void WriteFile(string filename, String[] commandList)
        {
            try
            {
                File.WriteAllLines(filename, commandList);
            }
            catch //(Exception ex)
            {
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btFileBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new ()
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    FilterIndex = 0,
                    RestoreDirectory = true
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    this.txtFileName.Text = fileName;
                    this.arrCommands = this.readTextFile(fileName);
                    this.loadCommandsToDataGridView(this.arrCommands);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btFileBrowser_Click\n" + ex.ToString());
            }
        }

        public void loadCommandsToDataGridView(String[] commandList)
        {
            if (commandList != null)
            {
                try
                {
                    this.loadCommand = true;
                    string[] array = Array.Empty<string>();
                    this.dataGridCommands.Rows.Clear();

                    for (int i = 0; i < commandList.Length; i++)
                    {
                        array = commandList[i].Split(new char[]{';'});
                        
                        this.dataGridCommands.Rows.Add(new object[]
                        {
                            array[0],
                            array[1]
                        });
                    }
                    this.loadCommand = false;
                }
                catch //(Exception ex)
                {
                    this.loadCommand = false;
                }
            }
        }

        public String[] getCommandsFromDataGridView()
        {
            List<String> commands = new (dataGridCommands.Rows.Count);
            try
            {
                for (int i = 0; i < this.dataGridCommands.Rows.Count - 1; i++)
                {
                    DataGridViewRow currentRow = this.dataGridCommands.Rows[i];

                    if (currentRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("The timout of command #" + (i + 1).ToString() + " should be an interger!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return null;
                    }
                    if (!int.TryParse(currentRow.Cells[1].Value.ToString(), out _))
                    {
                        MessageBox.Show("The timout of command #" + (i + 1).ToString() + " should be an interger!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return null;
                    }
                    if (int.Parse(currentRow.Cells[1].Value.ToString()) < 0)
                    {
                        MessageBox.Show("The timout of command #" + (i + 1).ToString() + " should be a positive interger!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return null;
                    }

                    string value = currentRow.Cells[0].Value + ";" + currentRow.Cells[1].Value;
                    
                    commands.Add(value);
                }
            }
            catch //(Exception ex)
            {
                
            }
            return commands.ToArray();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                String[] commandsFromDataGridView = this.getCommandsFromDataGridView();
                if (commandsFromDataGridView != null)
                {
                    if (commandsFromDataGridView.Length > 0)
                    {
                        this.runMultiCommands(commandsFromDataGridView);
                        base.Close();
                    }
                    else
                    {
                        MessageBox.Show("No command found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void contextDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.dataGridCommands.SelectedRows.Count > 0)
            {
                try
                {
                    this.dataGridCommands.Rows.Remove(this.dataGridCommands.SelectedRows[0]);
                }
                catch //(Exception ex)
                {
                }
            }
        }


        private void dataGridCommands_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridCommands.Rows[e.RowIndex].Selected = true;
            int num = this.dataGridCommands.Rows[0].Height * (e.RowIndex + 1);
            if (e.Button == MouseButtons.Right)
            {
                this.contextForDataGridCommands.Show(this.dataGridCommands, e.X, e.Y + num);
            }
        }

        private void contextInsertRow_Click(object sender, EventArgs e)
        {
            if (this.dataGridCommands.SelectedRows.Count > 0)
            {
                try
                {
                    this.dataGridCommands.Rows.Insert(this.dataGridCommands.SelectedRows[0].Index, 1);
                }
                catch //(Exception ex)
                {
                }
            }
        }

        private void dataGridCommands_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1 && e.RowIndex < this.dataGridCommands.Rows.Count - 1 && this.dataGridCommands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    this.dataGridCommands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.defaultTimeout;
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void btNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                while (this.dataGridCommands.Rows.Count > 1)
                {
                    this.dataGridCommands.Rows.RemoveAt(0);
                }
            }
            catch //(Exception ex)
            {
            }
            this.loadCommand = false;
            this.txtFileName.Text = "";
            this.dataGridCommands.Focus();
        }

        private void btSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                String[] commandsFromDataGridView = this.getCommandsFromDataGridView();
                if (commandsFromDataGridView != null)
                {
                    if (!File.Exists(this.txtFileName.Text))
                    {
                        SaveFileDialog saveFileDialog = new ()
                        {
                            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                            FilterIndex = 1,
                            RestoreDirectory = true
                        };

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            this.txtFileName.Text = saveFileDialog.FileName;
                    }

                    this.WriteFile(this.txtFileName.Text, commandsFromDataGridView);
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void btSaveFileAs_Click(object sender, EventArgs e)
        {
            try
            {
                String[] commandsFromDataGridView = this.getCommandsFromDataGridView();
                if (commandsFromDataGridView != null)
                {
                    SaveFileDialog saveFileDialog = new ()
                    {
                        Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        this.txtFileName.Text = saveFileDialog.FileName;

                    this.WriteFile(this.txtFileName.Text, commandsFromDataGridView);
                }
            }
            catch //(Exception ex)
            {
            }
        }

        private void dataGridCommands_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!this.loadCommand)
            {
                if (this.dataGridCommands.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    if (this.dataGridCommands.Rows[e.RowIndex - 1].Cells[1].Value == null)
                    {
                        this.dataGridCommands.Rows[e.RowIndex - 1].Cells[1].Value = this.defaultTimeout;
                    }
                }
            }
        }

        private String[] arrCommands = null;

        public frmMultiCommands.RunMultiCommands runMultiCommands;

        private bool loadCommand;

        private readonly int defaultTimeout;


        public delegate void RunMultiCommands(String[] arrCommands);
    }
}
