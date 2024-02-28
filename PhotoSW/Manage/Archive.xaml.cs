using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using Ionic.Zip;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Threading;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class Archive : Window, IComponentConnector
    {
        private string root = string.Empty;

        private string ArchiveFilePath = string.Empty;

        private bool isAcquired = false;

        private bool IsrequireArchive = true;


        public Archive()
        {
            this.InitializeComponent();
            this.root = Environment.CurrentDirectory;
            this.ArchiveFilePath = this.root + "\\";
            this.ArchiveFilePath = Path.Combine(this.ArchiveFilePath, "DigiArchive");
            if (!Directory.Exists(this.ArchiveFilePath))
            {
                Directory.CreateDirectory(this.ArchiveFilePath);
            }
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this.ArchiveProgress.Minimum = 0.0;
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    do
                    {
                        Login login = new Login();
                        login.Show();
                        base.Close();
                    }
                    while (false);
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        while (!false)
                        {
                            if (5 != 0)
                            {
                                goto Block_6;
                            }
                        }
                    }
                Block_6: ;
                }
                while (false)
                {
                }
            }
            while (6 == 0);
        }

        private void btnSelectdFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                    do
                    {
                        bool arg_5F_0;
                        bool expr_0F = arg_5F_0 = (dialogResult == System.Windows.Forms.DialogResult.OK);
                        if (7 != 0)
                        {
                            arg_5F_0 = !expr_0F;
                        }
                        if (arg_5F_0)
                        {
                            break;
                        }
                        this.txtSelectedfolder.Text = folderBrowserDialog.SelectedPath + "\\";
                    }
                    while (false);
                }
                while (3 == 0);
            }
            catch (Exception serviceException)
            {
                if (3 != 0)
                {
                    string message;
                    if (!false)
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnArchive_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                try
                {
                    bool arg_60_0 = !(this.txtSelectedfolder.Text != "");
                    bool expr_63;
                    do
                    {
                        bool flag = arg_60_0;
                        expr_63 = (arg_60_0 = flag);
                    }
                    while (false);
                    if (!expr_63)
                    {
                        string expr_6C = this.txtSelectedfolder.Text;
                        if (!false)
                        {
                            this.Go(expr_6C);
                        }
                        if (8 != 0)
                        {
                        }
                    }
                    else
                    {
                        while (false)
                        {
                        }
                        System.Windows.MessageBox.Show(UIConstant.SelectFolderFirst);
                    }
                }
                catch (Exception serviceException)
                {
                    if (!false)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
        }

        private void Go(string movearchive)
		{
			int getitem;
			
			ThreadStart start;
			while (true)
			{
				if (false)
				{
					goto IL_34;
				}
				
				IL_10:
				if (!false)
				{
					
					goto IL_1D;
				}
				continue;
				IL_34:
				if (3 != 0)
				{
					if (false)
					{
						return;
					}
					if (6 != 0)
					{
						break;
					}
					goto IL_10;
				}
				IL_1D:
				getitem = 0;
				start = delegate
				{
					PhotoBusiness photoBusiness = new PhotoBusiness();
					List<PhotoInfo> expr_2D8 = photoBusiness.GetArchiveImages();
					List<PhotoInfo> list;
					if (!false)
					{
						list = expr_2D8;
					}
					int arg_29C_0;
					int expr_2EE = arg_29C_0 = list.Count;
					int arg_29C_1;
					int expr_27 = arg_29C_1 = 0;
					bool flag;
					bool arg_29E_0;
					if (expr_27 == 0)
					{
						flag = (expr_2EE <= expr_27);
						if (!flag)
						{
							if (2 == 0)
							{
								goto IL_259;
							}
							int num = 0;
							foreach (PhotoInfo current in list)
							{
								num++;
								getitem = list.Count;
								photoBusiness.SetArchiveDetails(current.DG_Photos_FileName);
								try
								{
									string sourceFileName = LoginUser.DigiFolderPath + current.DG_Photos_FileName;
									string path = Path.Combine(LoginUser.DigiFolderThumbnailPath, current.DG_Photos_CreatedOn.ToString("yyyyMMdd"), current.DG_Photos_FileName);
									string path2 = Path.Combine(LoginUser.DigiFolderBigThumbnailPath, current.DG_Photos_CreatedOn.ToString("yyyyMMdd"), current.DG_Photos_FileName);
									string path3 = LoginUser.DigiFolderCropedPath + current.DG_Photos_FileName;
									string path4 = LoginUser.DigiFolderPath + "\\GreenImage\\" + current.DG_Photos_FileName;
									string destFileName = ArchiveFilePath + "\\" + current.DG_Photos_FileName;
									bool arg_192_0;
									do
									{
										File.Move(sourceFileName, destFileName);
										if (false)
										{
											goto IL_19E;
										}
										bool expr_132 = arg_192_0 = File.Exists(path);
										if (false)
										{
											goto IL_192;
										}
										if (expr_132)
										{
											File.Delete(path);
										}
										if (File.Exists(path3))
										{
											File.Delete(path3);
										}
										flag = !File.Exists(path2);
									}
									while (false);
									if (!flag)
									{
										File.Delete(path2);
									}
									flag = !File.Exists(path4);
									arg_192_0 = flag;
									IL_192:
									if (!arg_192_0)
									{
										File.Delete(path4);
									}
									IL_19E:;
								}
								catch (Exception serviceException)
								{
									string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
									ErrorHandler.ErrorHandler.LogFileWrite(message);
								}
								if (-1 != 0)
								{
									object[] arg = new object[]
									{
										num,
										getitem
									};
									this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action<object[]>(this.Update), arg);
								}
							}
						}
						else
						{
							System.Windows.MessageBox.Show(UIConstant.AlredyArchivedImages);
							this.IsrequireArchive = false;
						}
						bool expr_252 = arg_29E_0 = !this.IsrequireArchive;
						if (6 == 0)
						{
							goto IL_29E;
						}
						flag = expr_252;
						IL_259:
						if (flag)
						{
							return;
						}
						this.ZipPhotos(this.ArchiveFilePath, this.root + "\\", movearchive);
						arg_29C_0 = (this.isAcquired ? 1 : 0);
						arg_29C_1 = 0;
					}
					arg_29E_0 = (arg_29C_0 == arg_29C_1);
					IL_29E:
					flag = arg_29E_0;
					while (!flag)
					{
						System.Windows.MessageBox.Show(UIConstant.ImagesArchivedSuccessfully);
						this.isAcquired = false;
						if (!false)
						{
							break;
						}
					}
				};
				goto IL_34;
			}
			new Thread(start).Start();
		}

        private void Update(object[] obj)
        {
            int num;
            int num2;
            if (4 != 0)
            {
                num = (int)obj[0];
                num2 = (int)obj[1];
                this.btnArchive.IsEnabled = false;
                if (4 == 0)
                {
                    return;
                }
                this.ArchiveProgress.Maximum = (double)num2;
            }
            this.ArchiveProgress.Value = (double)num;
            this.txtfilescopied.Text = num2 + " File(s) found.";
        }

        private void ZipPhotos(string Folderpathtoarchive, string FoldertosaveArchived, string MoveArchiveFolder)
        {
            try
            {
                using (ZipFile zipFile = new ZipFile())
                {
                    zipFile.UseZip64WhenSaving = Zip64Option.AsNecessary;
                    zipFile.AddDirectory(Folderpathtoarchive);
                    zipFile.Comment = "This zip was created at " + new CustomBusineses().ServerDateTime().ToString();
                    do
                    {
                        zipFile.Save(FoldertosaveArchived + "DigiArchive" + DateTime.Today.ToString("yyyyMMdd") + ".zip");
                    }
                    while (!true);
                }
                string sourceFileName = Path.Combine(FoldertosaveArchived, "DigiArchive" + DateTime.Today.ToString("yyyyMMdd") + ".zip");
                string destFileName = Path.Combine(MoveArchiveFolder, "DigiArchive" + DateTime.Today.ToString("yyyyMMdd") + ".zip");
                File.Move(sourceFileName, destFileName);
                bool arg_128_0 = Directory.Exists(Folderpathtoarchive);
                bool expr_128;
                do
                {
                    expr_128 = (arg_128_0 = !arg_128_0);
                }
                while (false);
                if (!expr_128)
                {
                    Directory.Delete(Folderpathtoarchive, true);
                }
                this.isAcquired = true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(UIConstant.ErrorinArchive + ex.Message);
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] expr_B4 = Directory.GetFiles(target_dir);
            string[] array;
            if (!false)
            {
                array = expr_B4;
            }
            string[] expr_CA = Directory.GetDirectories(target_dir);
            string[] array2;
            if (!false)
            {
                array2 = expr_CA;
            }
            string[] array3 = array;
            int expr_2E = 0;
            int num;
            if (!false)
            {
                num = expr_2E;
            }
            while (true)
            {
                int arg_8E_0;
                int expr_5F = arg_8E_0 = num;
                int arg_8E_1;
                int expr_64 = arg_8E_1 = array3.Length;
                if (!true)
                {
                    goto IL_8E;
                }
                if (expr_5F >= expr_64)
                {
                    array3 = array2;
                    num = 0;
                    goto IL_91;
                }
                string path = array3[num];
                goto IL_3E;
            IL_59:
                int arg_59_0;
                int arg_59_1;
                int expr_59 = arg_59_0 += arg_59_1;
                if (!false)
                {
                    num = expr_59;
                    continue;
                }
            IL_58:
                arg_59_1 = 1;
                goto IL_59;
            IL_3E:
                File.SetAttributes(path, FileAttributes.Normal);
                File.Delete(path);
                if (!false)
                {
                    arg_59_0 = num;
                    goto IL_58;
                }
                goto IL_7F;
            IL_91:
                int expr_91 = arg_59_0 = num;
                int expr_95 = arg_59_1 = array3.Length;
                if (7 == 0)
                {
                    goto IL_59;
                }
                string target_dir2;
                if (expr_91 < expr_95)
                {
                    target_dir2 = array3[num];
                    goto IL_7F;
                }
                Directory.Delete(target_dir, false);
                if (!false)
                {
                    break;
                }
                goto IL_80;
            IL_8E:
                num = arg_8E_0 + arg_8E_1;
                goto IL_91;
            IL_80:
                Archive.DeleteDirectory(target_dir2);
                if (5 != 0)
                {
                    arg_8E_0 = num;
                    arg_8E_1 = 1;
                    goto IL_8E;
                }
                goto IL_3E;
            IL_7F:
                goto IL_80;
            }
        }

 
    }
}
