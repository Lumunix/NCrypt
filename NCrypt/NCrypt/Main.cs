using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCrypt
{
    public partial class Main : Form
    {
        NCryptRSA RSA = new NCryptRSA();
        NCryptAES AES = new NCryptAES();
        public Main()
        {
            //Initialize the form and set the form to fixed window
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //Set the Encrytion type drop down
            EncryptType.DataSource = (new string[] {"RSA","AES","HYBRID"});
            //disable the encryption and decryption buttons and file loader
            EncryptFile.Enabled = false;
            DecryptFile.Enabled = false;
            SelectFile.Enabled = false;
            DeleteFile.Enabled = false;
            //Set inital status
            KeyWindow.Text = "N/A";
            Status.Text = "No key file. Generate a new encryption key or load an existing one";
        }

        private void DecryptFile_Click(object sender, EventArgs e)
        {
            var Files = new ArrayList(FileList.Items);
            foreach (String File in Files)
            {
                bool DecryptionComplete = false;
                switch (EncryptType.SelectedItem.ToString())
                {
                    case ("RSA"):
                        //Check that data is compatible with key
                        if(RSA.RSACheckData(File,false))
                            DecryptionComplete = RSA.DecryptFile(File);
                        break;

                    default:
                        //nothing
                        break;
                }
                //remove file if it was decrypted properly
                if(DecryptionComplete)
                    FileList.Items.Remove(File);
            }

            //Status text updates
            if (FileList.Items.Count != 0)
                Status.Text = "The decryption operation failed on one or more files, File is incompatible or wrong key is being used.";
            else
                Status.Text = "The decryption operation completed sucessfully.";
            
        }

        private void EncryptFile_Click(object sender, EventArgs e)
        {
            
            var Files = new ArrayList(FileList.Items);
            foreach (String File in Files)
            {
                bool EncryptionComplete = false;
                switch (EncryptType.SelectedItem.ToString())
                {
                    case ("RSA"):
                        if (RSA.RSACheckData(File, true))
                            EncryptionComplete = RSA.EncryptFile(File);
                        break;

                    default:
                        //nothing
                        break;
                }
                if(EncryptionComplete)
                    FileList.Items.Remove(File);
            }
            //Status text updates
            if (FileList.Items.Count != 0)
                Status.Text = "The encryption operation failed on one or more files, File is incompatible or a larger bit size key is needed.";
            else
                Status.Text = "The encryption operation completed sucessfully.";
        }
        //allows user to select file to be encrypted or decrypted
        private void SelectFile_Click(object sender, EventArgs e)
        {
             this.SelectFileDialog.Multiselect = true;
             DialogResult dr = this.SelectFileDialog.ShowDialog();
             if (dr == System.Windows.Forms.DialogResult.OK)
             {
                 // Read the files 
                 foreach (String File in SelectFileDialog.FileNames)
                 {
                     FileList.Items.Add(File);
                 }
             }
        }

        //Select the Type of encryption  to use
        private void EncryptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EncryptType.SelectedItem.ToString())
            {
                case ("RSA"):
                    //Set the GUI  to the vaild keysizes for the encryption type of the RSA keyservice
                    BitSize.DataSource = RSA.ValidKeys();
                    break;

                case ("AES"):
                   // NCryptRSA Keys = new NCryptRSA();
                   // BitSize.DataSource = Keys.ValidKeys();
                    break;

                default:
                    //Application error or invalid drop down
                    break;
            }

            EncryptFile.Enabled = false;
            DecryptFile.Enabled = false;
            SelectFile.Enabled = false;
            DeleteFile.Enabled = false;
        }

        private void GenerateKeys_Click(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.UtcNow;
            string fName =  BitSize.SelectedItem.ToString() + EncryptType.SelectedItem.ToString() + "_" + CurrentTime.ToString("MM_dd_yy_H_mm_ss");
            SaveKey.FileName = fName;
             
            if (SaveKey.ShowDialog() == DialogResult.OK)
            {
                
                switch (EncryptType.SelectedItem.ToString())
                {
                    case ("RSA"):
                        //Write RSA keys
                        RSA.GenerateKey(SaveKey.FileName, Convert.ToInt32(BitSize.SelectedItem.ToString()));
                        break;

                    default:
                        //nothing
                        break;
                }
                KeyWindow.Text = "Key File (PublicPrivate): " + Path.GetFileName(SaveKey.FileName);
            }
            Status.Text = "";
            EncryptFile.Enabled = true;
            DecryptFile.Enabled = true;
            SelectFile.Enabled = true;
            DeleteFile.Enabled = true;
        }

        private void SelectKey_Click(object sender, EventArgs e)
        {
            bool FullKey = false;
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                switch (EncryptType.SelectedItem.ToString())
                {
                    case ("RSA"):
                        RSA.GetKey(SelectKeyDialog.FileName);
                        FullKey = RSA.CheckKey();
                        break;

                    default:
                        break;

                }
                
            }
            //If we have the full key then we want to unlock both buttons else just unlock encrypt
            if (FullKey)
            {
                EncryptFile.Enabled = true;
                DecryptFile.Enabled = true;
                KeyWindow.Text = "Key File (PublicPrivate): " + Path.GetFileName(SelectKeyDialog.FileName);
                Status.Text = "";
            }
            else
            {
                EncryptFile.Enabled = true;
                DecryptFile.Enabled = false;
                KeyWindow.Text = "Key File (Public): " + Path.GetFileName(SelectKeyDialog.FileName);
                Status.Text = "";
            }
            SelectFile.Enabled = true;
            DeleteFile.Enabled = true;
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            //Remove Item from listbox if not empty
            if (FileList.SelectedIndex != -1)
                FileList.Items.RemoveAt(FileList.SelectedIndex);   
        }

    }
}
