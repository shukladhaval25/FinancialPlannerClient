﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.EmailManager;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class FinancialPlannerSendEmailConfiguration : DevExpress.XtraEditors.XtraForm
    {
        PlannerMainReport plannerMainReport;
        internal Client client;
        string plannerOption;
        DataTable dtAttachment;
        string filePath;
        public FinancialPlannerSendEmailConfiguration(PlannerMainReport plannerMainReport, Client client, string plannerOption)
        {
            InitializeComponent();
            this.plannerMainReport = plannerMainReport;
            this.client = client;
            this.plannerOption = plannerOption;
        }

        private void FinancialPlannerSendEmailConfiguration_Load(object sender, EventArgs e)
        {
            ClientContactInfo clientContactInfo = new ClientContactInfo();
            var contactInfo = clientContactInfo.Get(client.ID);
            txtToEmail.Text = contactInfo.PrimaryEmail;
            exportReport();
        }

        private async void exportReport()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                string fileName = string.Format("{0}-{1}-{2}.{3}", this.client.ID, plannerOption, DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute, "pdf");

                filePath = Path.Combine(tempPath, fileName);
                await Task.Run(() => this.plannerMainReport.ExportToPdf(filePath));
                dtAttachment = new DataTable();
                dtAttachment.Columns.Add("FileName");
                dtAttachment.Columns.Add("FilePath");

                DataRow dr = dtAttachment.NewRow();
                dr["FileName"] = fileName;
                dr["FilePath"] = filePath;
                dtAttachment.Rows.Add(dr);

                Icon fileIcon = getIcon(filePath);

                grdAttachment.DataSource = dtAttachment;
                picProcessing.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured while exporting report." + ex.ToString());
            }
            finally
            {
                btnSendFinancialPlannerReport.Enabled = true;
            }
        }

        private void btnSendFinancialPlannerReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Attachment attachment = getQuarterlyReviewTemplateForEmail(reviewSheetPath);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(MailServer.FromEmail);
                mailMessage.To.Add(new MailAddress(txtToEmail.Text));
                if (!string.IsNullOrEmpty(txtCC.Text))
                {
                    mailMessage.CC.Add(new MailAddress(txtCC.Text));
                }
                mailMessage.Subject = txtSubject.Text;
                mailMessage.IsBodyHtml = false;
                //mailMessage.Attachments.Add(attachment);
                mailMessage.Body = txtEmaiBody.Text;
                
                bool isEmailSend = EmailService.SendEmailWithChilkat(mailMessage, filePath);
                if (isEmailSend)
                {
                    MessageBox.Show("Financial Plan send successfully to '" + txtToEmail.Text + "'.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to send email to '" + txtToEmail.Text + "'. Check your email configuration setting.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                MessageBox.Show(ex.ToString());
            }
        }
        private Icon getIcon(string filePath)
        {
            // Initialize the ListView, ImageList and Form.
            //listView1 = new ListView();
            //imageList1 = new ImageList();
            //listView1.Location = new Point(37, 12);
            //listView1.Size = new Size(151, 262);
            //listView1.SmallImageList = imageList1;
            //listView1.View = View.SmallIcon;
            //this.ClientSize = new System.Drawing.Size(292, 266);
            //this.Controls.Add(this.listView1);
            //this.Text = "Form1";

            // Get the c:\ directory.
            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\Users\shukl\AppData\Local\Temp");

            //ListViewItem item;
            //listView1.BeginUpdate();

            // For each file in the c:\ directory, create a ListViewItem
            // and set the icon to the icon extracted from the file.
            System.IO.FileInfo file = new FileInfo(filePath);
            //foreach (System.IO.FileInfo file in dir.GetFiles())
            //{
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                //item = new ListViewItem(file.Name, 1);

                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                //if (!imageList1.Images.ContainsKey(file.Extension))
                //{
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
            return iconForFile;
                    //imageList1.Images.Add(file.Extension, iconForFile);
                   //this.Icon = iconForFile;
                //}
                //item.ImageKey = file.Extension;
                //listView1.Items.Add(item);
            //}
            //listView1.EndUpdate();
        }

        private void gridViewAttachment_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (gridViewAttachment.Columns[0].Name == "Img")
            {
                //e.CellValue = getIcon(filePath);
            }
        }
        //public static System.Drawing.Icon GetFileIcon(string name, IconSize size,
        //                                      bool linkOverlay)
        //{
        //    Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
        //    uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;

        //    if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;


        //    /* Check the size specified for return. */
        //    if (IconSize.Small == size)
        //    {
        //        flags += Shell32.SHGFI_SMALLICON; // include the small icon flag
        //    }
        //    else
        //    {
        //        flags += Shell32.SHGFI_LARGEICON;  // include the large icon flag
        //    }

        //    Shell32.SHGetFileInfo(name,
        //        Shell32.FILE_ATTRIBUTE_NORMAL,
        //        ref shfi,
        //        (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
        //        flags);


        //}
    }
}