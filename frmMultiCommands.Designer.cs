using System.ComponentModel;

namespace SessionManagement
{
    public partial class frmMultiCommands : System.Windows.Forms.Form
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private ComponentResourceManager componentResourceManager;
        private void InitializeComponent()
        {
            components = new Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            txtFileName = new System.Windows.Forms.TextBox();
            btFileBrowser = new System.Windows.Forms.Button();
            contextForDataGridCommands = new System.Windows.Forms.ContextMenuStrip(components);
            contextDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            contextInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            btCancel = new System.Windows.Forms.Button();
            btOK = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btSaveFileAs = new System.Windows.Forms.Button();
            btSaveFile = new System.Windows.Forms.Button();
            btNewFile = new System.Windows.Forms.Button();
            dataGridCommands = new System.Windows.Forms.DataGridView();
            colCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            contextForDataGridCommands.SuspendLayout();
            groupBox2.SuspendLayout();
            ((ISupportInitialize)dataGridCommands).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtFileName);
            groupBox1.Controls.Add(btFileBrowser);
            groupBox1.Location = new System.Drawing.Point(8, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(572, 48);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 17);
            label1.TabIndex = 5;
            label1.Text = "Commands File";
            // 
            // txtFileName
            // 
            txtFileName.Location = new System.Drawing.Point(104, 16);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new System.Drawing.Size(374, 25);
            txtFileName.TabIndex = 4;
            // 
            // btFileBrowser
            // 
            btFileBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btFileBrowser.Location = new System.Drawing.Point(484, 16);
            btFileBrowser.Name = "btFileBrowser";
            btFileBrowser.Size = new System.Drawing.Size(80, 25);
            btFileBrowser.TabIndex = 3;
            btFileBrowser.Text = "Open";
            btFileBrowser.UseVisualStyleBackColor = true;
            btFileBrowser.Click += btFileBrowser_Click;
            // 
            // contextForDataGridCommands
            // 
            contextForDataGridCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { contextDeleteRow, contextInsertRow });
            contextForDataGridCommands.Name = "contextForDataGridCommands";
            contextForDataGridCommands.Size = new System.Drawing.Size(134, 48);
            // 
            // contextDeleteRow
            // 
            contextDeleteRow.Name = "contextDeleteRow";
            contextDeleteRow.Size = new System.Drawing.Size(133, 22);
            contextDeleteRow.Text = "Delete Row";
            contextDeleteRow.Click += contextDeleteRow_Click;
            // 
            // contextInsertRow
            // 
            contextInsertRow.Name = "contextInsertRow";
            contextInsertRow.Size = new System.Drawing.Size(133, 22);
            contextInsertRow.Text = "Insert Row";
            contextInsertRow.Click += contextInsertRow_Click;
            // 
            // btCancel
            // 
            btCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btCancel.Location = new System.Drawing.Point(492, 387);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(88, 27);
            btCancel.TabIndex = 4;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btCancel_Click;
            // 
            // btOK
            // 
            btOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btOK.Location = new System.Drawing.Point(398, 387);
            btOK.Name = "btOK";
            btOK.Size = new System.Drawing.Size(88, 27);
            btOK.TabIndex = 3;
            btOK.Text = "Run";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btSaveFileAs);
            groupBox2.Controls.Add(btSaveFile);
            groupBox2.Controls.Add(btNewFile);
            groupBox2.Controls.Add(dataGridCommands);
            groupBox2.Location = new System.Drawing.Point(8, 49);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(572, 333);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // btSaveFileAs
            // 
            btSaveFileAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btSaveFileAs.Location = new System.Drawing.Point(168, 302);
            btSaveFileAs.Name = "btSaveFileAs";
            btSaveFileAs.Size = new System.Drawing.Size(80, 25);
            btSaveFileAs.TabIndex = 4;
            btSaveFileAs.Text = "Save As";
            btSaveFileAs.UseVisualStyleBackColor = true;
            btSaveFileAs.Click += btSaveFileAs_Click;
            // 
            // btSaveFile
            // 
            btSaveFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btSaveFile.Location = new System.Drawing.Point(87, 302);
            btSaveFile.Name = "btSaveFile";
            btSaveFile.Size = new System.Drawing.Size(80, 25);
            btSaveFile.TabIndex = 4;
            btSaveFile.Text = "Save";
            btSaveFile.UseVisualStyleBackColor = true;
            btSaveFile.Click += btSaveFile_Click;
            // 
            // btNewFile
            // 
            btNewFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btNewFile.Location = new System.Drawing.Point(6, 302);
            btNewFile.Name = "btNewFile";
            btNewFile.Size = new System.Drawing.Size(80, 25);
            btNewFile.TabIndex = 4;
            btNewFile.Text = "New";
            btNewFile.UseVisualStyleBackColor = true;
            btNewFile.Click += btNewFile_Click;
            // 
            // dataGridCommands
            // 
            dataGridCommands.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridCommands.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colCommand, colTimeout });
            dataGridCommands.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            dataGridCommands.EnableHeadersVisualStyles = false;
            dataGridCommands.Location = new System.Drawing.Point(4, 15);
            dataGridCommands.MultiSelect = false;
            dataGridCommands.Name = "dataGridCommands";
            dataGridCommands.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridCommands.RowHeadersWidth = 30;
            dataGridCommands.Size = new System.Drawing.Size(562, 281);
            dataGridCommands.TabIndex = 2;
            dataGridCommands.CellEnter += dataGridCommands_CellEnter;
            dataGridCommands.RowHeaderMouseClick += dataGridCommands_RowHeaderMouseClick;
            dataGridCommands.RowsAdded += dataGridCommands_RowsAdded;
            // 
            // colCommand
            // 
            colCommand.Frozen = true;
            colCommand.HeaderText = "Command";
            colCommand.Name = "colCommand";
            colCommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            colCommand.Width = 430;
            // 
            // colTimeout
            // 
            colTimeout.HeaderText = "Timeout (ms)";
            colTimeout.Name = "colTimeout";
            colTimeout.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmMultiCommands
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(592, 420);
            Controls.Add(groupBox2);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(groupBox1);
            Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMultiCommands";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Multi Commands";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextForDataGridCommands.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((ISupportInitialize)dataGridCommands).EndInit();
            ResumeLayout(false);
        }

        private IContainer components = null;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button btFileBrowser;

        private System.Windows.Forms.TextBox txtFileName;

        private System.Windows.Forms.Button btCancel;

        private System.Windows.Forms.Button btOK;

        private System.Windows.Forms.ContextMenuStrip contextForDataGridCommands;

        private System.Windows.Forms.ToolStripMenuItem contextDeleteRow;

        private System.Windows.Forms.ToolStripMenuItem contextInsertRow;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.DataGridView dataGridCommands;

        private System.Windows.Forms.Button btSaveFile;

        private System.Windows.Forms.Button btNewFile;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button btSaveFileAs;

        private System.Windows.Forms.DataGridViewTextBoxColumn colCommand;

        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeout;
    }
}
