using System;
using System.Drawing;
using System.Windows.Forms;
namespace NCrypt
{
    partial class Main
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EncryptFile = new System.Windows.Forms.Button();
            this.DecryptFile = new System.Windows.Forms.Button();
            this.SelectFile = new System.Windows.Forms.Button();
            this.DeleteFile = new System.Windows.Forms.Button();
            this.SelectKey = new System.Windows.Forms.Button();
            this.SelectKeyDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileList = new System.Windows.Forms.ListBox();
            this.BitSize = new System.Windows.Forms.ComboBox();
            this.EncryptType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateKeys = new System.Windows.Forms.Button();
            this.SaveKey = new System.Windows.Forms.SaveFileDialog();
            this.SelectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Status = new System.Windows.Forms.TextBox();
            this.KeyWindow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EncryptFile
            // 
            this.EncryptFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EncryptFile.Location = new System.Drawing.Point(385, 389);
            this.EncryptFile.Name = "EncryptFile";
            this.EncryptFile.Size = new System.Drawing.Size(70, 70);
            this.EncryptFile.TabIndex = 8;
            this.EncryptFile.Text = "Encrypt File(s)";
            this.EncryptFile.UseVisualStyleBackColor = true;
            this.EncryptFile.Click += new System.EventHandler(this.EncryptFile_Click);
            // 
            // DecryptFile
            // 
            this.DecryptFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DecryptFile.Location = new System.Drawing.Point(385, 313);
            this.DecryptFile.Name = "DecryptFile";
            this.DecryptFile.Size = new System.Drawing.Size(70, 70);
            this.DecryptFile.TabIndex = 7;
            this.DecryptFile.Text = "Decrypt File(s)";
            this.DecryptFile.UseVisualStyleBackColor = true;
            this.DecryptFile.Click += new System.EventHandler(this.DecryptFile_Click);
            // 
            // SelectFile
            // 
            this.SelectFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectFile.Location = new System.Drawing.Point(385, 161);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(70, 70);
            this.SelectFile.TabIndex = 5;
            this.SelectFile.Text = "Select File(s)";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // DeleteFile
            // 
            this.DeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DeleteFile.Location = new System.Drawing.Point(385, 237);
            this.DeleteFile.Name = "DeleteFile";
            this.DeleteFile.Size = new System.Drawing.Size(70, 70);
            this.DeleteFile.TabIndex = 6;
            this.DeleteFile.Text = "Delete File(s)";
            this.DeleteFile.UseVisualStyleBackColor = true;
            this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // SelectKey
            // 
            this.SelectKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SelectKey.Location = new System.Drawing.Point(385, 9);
            this.SelectKey.Name = "SelectKey";
            this.SelectKey.Size = new System.Drawing.Size(70, 70);
            this.SelectKey.TabIndex = 3;
            this.SelectKey.Text = "Select Key";
            this.SelectKey.UseVisualStyleBackColor = true;
            this.SelectKey.Click += new System.EventHandler(this.SelectKey_Click);
            // 
            // SelectKeyDialog
            // 
            this.SelectKeyDialog.FileName = "SelectKeyDialog";
            // 
            // FileList
            // 
            this.FileList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(12, 148);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(350, 301);
            this.FileList.TabIndex = 0;
            // 
            // BitSize
            // 
            this.BitSize.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BitSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BitSize.FormattingEnabled = true;
            this.BitSize.Location = new System.Drawing.Point(171, 35);
            this.BitSize.Name = "BitSize";
            this.BitSize.Size = new System.Drawing.Size(121, 21);
            this.BitSize.TabIndex = 2;
            // 
            // EncryptType
            // 
            this.EncryptType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.EncryptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptType.FormattingEnabled = true;
            this.EncryptType.Location = new System.Drawing.Point(12, 35);
            this.EncryptType.Name = "EncryptType";
            this.EncryptType.Size = new System.Drawing.Size(121, 21);
            this.EncryptType.TabIndex = 1;
            this.EncryptType.SelectedIndexChanged += new System.EventHandler(this.EncryptType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Encryption  Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bit Size:";
            // 
            // GenerateKeys
            // 
            this.GenerateKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GenerateKeys.Location = new System.Drawing.Point(385, 85);
            this.GenerateKeys.Name = "GenerateKeys";
            this.GenerateKeys.Size = new System.Drawing.Size(70, 70);
            this.GenerateKeys.TabIndex = 4;
            this.GenerateKeys.Text = "Generate Key";
            this.GenerateKeys.UseVisualStyleBackColor = true;
            this.GenerateKeys.Click += new System.EventHandler(this.GenerateKeys_Click);
            // 
            // SelectFileDialog
            // 
            this.SelectFileDialog.FileName = "SelectFileDialog";
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status.Cursor = System.Windows.Forms.Cursors.Default;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(12, 101);
            this.Status.Multiline = true;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Size = new System.Drawing.Size(350, 41);
            this.Status.TabIndex = 17;
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KeyWindow
            // 
            this.KeyWindow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.KeyWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeyWindow.Cursor = System.Windows.Forms.Cursors.Default;
            this.KeyWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyWindow.Location = new System.Drawing.Point(12, 62);
            this.KeyWindow.Multiline = true;
            this.KeyWindow.Name = "KeyWindow";
            this.KeyWindow.ReadOnly = true;
            this.KeyWindow.Size = new System.Drawing.Size(350, 33);
            this.KeyWindow.TabIndex = 18;
            this.KeyWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(461, 462);
            this.Controls.Add(this.KeyWindow);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.GenerateKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EncryptType);
            this.Controls.Add(this.BitSize);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.SelectKey);
            this.Controls.Add(this.DeleteFile);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.DecryptFile);
            this.Controls.Add(this.EncryptFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        void OnExit(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private System.Windows.Forms.Button EncryptFile;
        private System.Windows.Forms.Button DecryptFile;
        private Button SelectFile;
        private Button DeleteFile;
        private Button SelectKey;
        private OpenFileDialog SelectKeyDialog;
        private ListBox FileList;
        private ComboBox BitSize;
        private ComboBox EncryptType;
        private Label label1;
        private Label label2;
        private Button GenerateKeys;
        private SaveFileDialog SaveKey;
        private OpenFileDialog SelectFileDialog;
        private TextBox Status;
        private TextBox KeyWindow;
    }
}

