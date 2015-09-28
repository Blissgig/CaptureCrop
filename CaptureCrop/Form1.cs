using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureCrop
{
    public partial class Form1 : Form
    {
        private RegisterHotKeyClass RegisterKey = null;
        private FileSystemWatcher FolderWatcher = null;
        private string msSaveFolder = "";
        private string msMonitorFolder = "";
        private Int16 iLeft = 0;
        private Int16 iTop = 0;
        private Int16 iRight = 0;
        private Int16 iBottom = 0;
        private float fDPI = 96;
        private byte bFileType = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string sValue = "";

                sValue = GetSetting("Location");
                if (Directory.Exists(sValue) == true)
                {
                    msSaveFolder = sValue;
                    this.lblSaveFolder.Text = msSaveFolder;
                }


                sValue = GetSetting("MonitorFolder");
                if (Directory.Exists(sValue) == true)
                {
                    msMonitorFolder = sValue;
                    this.lblMonitorFolder.Text = msMonitorFolder;
                }


                sValue = GetSetting("SetupOption");
                if (sValue.ToLower() == "monitor folder")
                {
                    this.cboSetupOption.SelectedIndex = 1;
                }
                else
                {
                    this.cboSetupOption.SelectedIndex = 0;
                }


                sValue = GetSetting("SaveOriginal");
                if (sValue.ToLower() == "checked")
                {
                    this.chkSaveOriginal.CheckState = CheckState.Checked;
                }
                else
                {
                    this.chkSaveOriginal.CheckState = CheckState.Unchecked;
                }


                //Crop values
                sValue = GetSetting("Bottom");
                if (IsNumeric(sValue) == true)
                {
                    iBottom = Convert.ToInt16(sValue);
                }
                this.txtBottom.Text = iBottom.ToString();


                sValue = GetSetting("Left");
                if (IsNumeric(sValue) == true)
                {
                    iLeft = Convert.ToInt16(sValue);
                }
                this.txtLeft.Text = iLeft.ToString();


                sValue = GetSetting("Top");
                if (IsNumeric(sValue) == true)
                {
                    iTop = Convert.ToInt16(sValue);
                }
                this.txtTop.Text = iTop.ToString();


                sValue = GetSetting("Right");
                if (IsNumeric(sValue) == true)
                {
                    iRight = Convert.ToInt16(sValue);
                }
                this.txtRight.Text = iRight.ToString();


                sValue = GetSetting("DPI");
                if (IsNumeric(sValue) == true)
                {
                    fDPI = Convert.ToInt16(sValue);
                }
                this.txtDPI.Text = fDPI.ToString();


                sValue = GetSetting("FileType");
                if (IsNumeric(sValue) == true)
                {
                    this.cboFileType.SelectedIndex = Convert.ToInt16(sValue);
                }
                else
                {
                    this.cboFileType.SelectedIndex = 1; //jpeg
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void SetupOption()
        {
            try
            {
                string sValue = "";

                //Cleaunup
                if (FolderWatcher != null)
                {
                    FolderWatcher.Dispose();
                    FolderWatcher = null;
                }

                if (RegisterKey != null)
                {
                    RegisterKey.StopHotKey();
                    RegisterKey = null;
                }

                //Print Screen or Monitor Folder
                sValue = GetSetting("SetupOption");
                if (sValue.ToLower() == "monitor folder")
                {
                    if (Directory.Exists(msMonitorFolder) == false)
                    {
                        MessageBox.Show("The folder selected to monitor does not exist or is not available.  Please select another folder.", 
                            "Monitor Folder Issue",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.cboSetupOption.SelectedIndex = 0; //Reset back
                    }
                    else if (msMonitorFolder.ToLower() == msSaveFolder.ToLower())
                    {
                        MessageBox.Show("The folder to monitor cannot be the same folder where the images are saved.  Please select another folder.", 
                            "Monitor Folder Issue",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.cboSetupOption.SelectedIndex = 0; //Reset back
                    }
                    else
                    {
                        FolderWatcher = new FileSystemWatcher();
                        FolderWatcher.Path = msMonitorFolder;
                        FolderWatcher.IncludeSubdirectories = false; //The concern here is that the default setting is c:\, too many writes!
                        FolderWatcher.NotifyFilter = NotifyFilters.LastAccess |
                            NotifyFilters.LastWrite |
                            NotifyFilters.FileName |
                            NotifyFilters.DirectoryName;
                        FolderWatcher.Created += new FileSystemEventHandler(FolderChanged);
                        FolderWatcher.EnableRaisingEvents = true;
                    }
                }
                else
                {
                    this.lblSaveFolder.Text = msSaveFolder;
                    RegisterKey = new RegisterHotKeyClass();
                    RegisterKey.Keys = Keys.PrintScreen;
                    RegisterKey.ModKey = 0;
                    RegisterKey.WindowHandle = this.Handle;
                    RegisterKey.HotKey += new RegisterHotKeyClass.HotKeyPass(PrintScreenPressed);
                    RegisterKey.StarHotKey();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void FolderChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                //Get the file's extension 
                string sExt = (Path.GetExtension(e.FullPath) ?? string.Empty).ToLower();


                // filter file types 
                switch (sExt.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".bmp":
                    case ".gif":
                    case ".tiff":
                        Bitmap BitmapSource = new Bitmap(e.FullPath);
                        ProcessImage(BitmapSource, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        } 

        private void PrintScreenPressed()
        {
            try
            {
                Rectangle ScreenBounds = Screen.GetBounds(Point.Empty);

                //Capture Screenshot
                using (Bitmap BitmapSource = new Bitmap(ScreenBounds.Width, ScreenBounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(BitmapSource))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, ScreenBounds.Size);
                    }
                    ProcessImage(BitmapSource);
                    SystemSounds.Beep.Play();
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void ProcessImage(Bitmap BitmapSource, bool Monitor = false)
        {
            try
            {
                //Insure that the crop values are not larger than the image
                if ((iLeft + iRight) > BitmapSource.Width)
                {
                    MessageBox.Show("This image is not as wide as Left and Right crop values.", "Crop Issue", MessageBoxButtons.OK);
                    return;
                }
                else if ((iTop + iBottom) > BitmapSource.Height)
                {
                    MessageBox.Show("This image is not as high as Top and Bottom crop values.", "Crop Issue", MessageBoxButtons.OK);
                    return;
                }

                string sExt = ".jpg";
                ImageFormat imgFormat = ImageFormat.Jpeg;
                string sFileName =
                    DateTime.Now.Year.ToString() + "." +
                    DateTime.Now.Month.ToString("00") + "." +
                    DateTime.Now.Day.ToString("00") + "." +
                    DateTime.Now.Hour.ToString("00") + "." +
                    DateTime.Now.Minute.ToString("00") + "." +
                    DateTime.Now.Second.ToString("00") + "." +
                    DateTime.Now.Millisecond.ToString("0000");


                switch (bFileType)
                {
                    case 0:
                        sExt = ".bmp";
                        imgFormat = ImageFormat.Bmp;
                        break;

                    case 1:
                        sExt = ".jpg";
                        imgFormat = ImageFormat.Jpeg;
                        break;

                    case 2:
                        sExt = ".png";
                        imgFormat = ImageFormat.Png;
                        break;
                }

                sFileName += sExt;

                //Crop
                Rectangle CropRect = new Rectangle(iLeft, iTop, (BitmapSource.Width - (iLeft + iRight)), (BitmapSource.Height - (iTop + iBottom)));
                Bitmap BitmapCloned = new Bitmap(BitmapSource).Clone(CropRect, BitmapSource.PixelFormat);
                Bitmap BitmapResized = new Bitmap(BitmapCloned, new Size(CropRect.Width, CropRect.Height));


                //Set DPI:
                BitmapResized.SetResolution(fDPI, fDPI);

                //Save the file
                BitmapResized.Save(msSaveFolder + "\\" + sFileName, imgFormat);

                //Save the original
                if (this.chkSaveOriginal.Checked == true && Monitor == false)
                {
                    string sOriginal = msSaveFolder + "\\Original Captures";
                    if (Directory.Exists(sOriginal) == false)
                    {
                        Directory.CreateDirectory(sOriginal);
                    }
                    BitmapSource.Save(sOriginal + "\\" + sFileName, imgFormat);
                }

                //Cleanup
                BitmapCloned.Dispose();
                BitmapResized.Dispose();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void GetMonitorFolder()
        {
            try
            {
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();

                dlgFolder.Description = "Folder you wquld like to monitor.";

                if (dlgFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    msMonitorFolder = dlgFolder.SelectedPath.ToString();

                    if (msMonitorFolder.ToLower() == msSaveFolder.ToLower())
                    {
                        msMonitorFolder = "";
                        this.lblMonitorFolder.Text = "No folder selected.";
                        MessageBox.Show("The folder to monitor cannot be the same folder where the images are saved.  Please select another folder.",
                            "Monitor Folder Issue",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SaveSetting("MonitorFolder", msMonitorFolder);
                        this.lblMonitorFolder.Text = msMonitorFolder;

                        if (FolderWatcher != null)
                        {
                            FolderWatcher.Path = msMonitorFolder;
                        }
                    }
                }

                dlgFolder.Dispose();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void cboSetupOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSetting("SetupOption", this.cboSetupOption.Text);

            SetupOption();
        }

        private void cboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSetting("FileType", this.cboFileType.SelectedIndex.ToString());

            bFileType = Convert.ToByte(this.cboFileType.SelectedIndex);
        }

        private void cmdFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();

                dlgFolder.Description = "Folder where the saved captured images are to be stored.";
                
                if (dlgFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    msSaveFolder = dlgFolder.SelectedPath.ToString();
                    SaveSetting("Location", msSaveFolder);
                    this.lblSaveFolder.Text = msSaveFolder;
                }
                dlgFolder.Dispose();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void cmdMonitorFolder_Click(object sender, EventArgs e)
        {
            GetMonitorFolder();
        }

        private void cmdBatch_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();

                dlgFolder.Description = "Batch files all image files from this folder.";

                if (dlgFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dlgFolder.SelectedPath.ToString());

                    FileInfo[] ImageFiles = dirInfo.GetFiles("*.jpg").Concat(dirInfo.GetFiles("*.jpeg")).Concat(dirInfo.GetFiles("*.png")).ToArray();

                    for (int i = 0; i < ImageFiles.Length; ++i)
                    {
                        FileInfo ImageFile = ImageFiles[i];
                        Bitmap ImageBitmap = new Bitmap(ImageFile.FullName);

                        ProcessImage(ImageBitmap);
                    }

                    MessageBox.Show("Image Files Process Completed", "Process Completed", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void chkSaveOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSetting("SaveOriginal", chkSaveOriginal.CheckState.ToString());
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtBottom_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void txtDPI_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsNumeric(txtDPI.Text) == true)
            {
                SaveSetting("DPI", txtDPI.Text);
                fDPI = Convert.ToInt16(txtDPI.Text);
            }
        }

        private void txtBottom_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsNumeric(txtBottom.Text) == true)
            {
                SaveSetting("Bottom", txtBottom.Text);
                iBottom = Convert.ToInt16(txtBottom.Text);
            }
        }

        private void txtRight_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsNumeric(txtRight.Text) == true)
            {
                SaveSetting("Right", txtRight.Text);
                iRight = Convert.ToInt16(txtRight.Text);
            }
        }

        private void txtTop_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsNumeric(txtTop.Text) == true)
            {
                SaveSetting("Top", txtTop.Text);
                iTop = Convert.ToInt16(txtTop.Text);
            }
        }

        private void txtLeft_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsNumeric(txtLeft.Text) == true)
            {
                SaveSetting("Left", txtLeft.Text);
                iLeft = Convert.ToInt16(txtLeft.Text);
            }
        }

        private bool IsNumeric(string Input)
        {
            bool bReurn = false;
            int Output = 0;


            if (int.TryParse(Input, out Output))
            {
                bReurn = true;
            }

            return bReurn;
        }

        private string GetSetting(string Setting)
        {
            string sReturn = "";

            try
            {
                sReturn = Application.UserAppDataRegistry.GetValue(Setting).ToString();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return sReturn;
        }

        private void SaveSetting(string Setting, string Value)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue(Setting, Value);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void LogException(Exception ex)
        {
            try
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {

            }
        }


    }
}
