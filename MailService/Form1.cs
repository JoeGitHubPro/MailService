using MailService.MailSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailService
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            txtCvAtachment.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //txtSender.Text = "suezcanal26@gmail.com";
            //txtSenderPassword.Text = "roekamplsraigpvu";
            txtSender.Text = "youssef.mohamed.net.eg@gmail.com";
            txtSenderPassword.Text = "bccttblcwpxizydt";
            txtSubject.Text = "Software InternShip";
            txtWelcome.Text = "Request Back-end InternShip";
            txtFixedMessage.Text = ".Net Development";
            txtPortfolioUrl.Text = "https://joegithubpro.github.io/Profile";
            txtFooter.Text = "Youssef Mohamed Ali";
            txtTemplateUrl.Text = @"E:\Windows\Underway\Project\MailService\MailService\Files\Template.html";
            txtFacebook.Text = "https://www.facebook.com/profile.php?id=100004471519479";
            txtTwitter.Text = "https://twitter.com/Y_mohamed_Ali?t=uW04TUW-iDrdq0u9GFRm9g&s=09";
            txtLinkedin.Text = "https://www.linkedin.com/in/youssef-mohamed-71a368217";
            txtGithub.Text = "https://github.com/JoeGitHubPro";

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string mailBody = GetTempString(txtTemplateUrl.Text, txtPortfolioUrl.Text);


            try
            {
                Email email = new Email();
                email.SendMail(txtReceiver.Text, txtSender.Text, txtSenderPassword.Text, mailBody, txtCvAtachment.Text, txtSubject.Text, "smtp.gmail.com", 587);

                MessageBox.Show("Mail Send successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erorr)
            {

                MessageBox.Show(erorr.Message, "Can not send", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Attachment files may made e-mail as spam", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes" button
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtCvAtachment.Text = openFileDialog1.FileName;
                    txtCvAtachment.ReadOnly = false;
                }
            }




        }

        private string GetTempString(string TemplateUrl, string portfolioUrl)
        {
            string body = File.ReadAllText(TemplateUrl)
                            .Replace("ID-Welcome-1111-0000", txtWelcome.Text)
                            .Replace("ID-Header-1111-1111", txtFixedMessage.Text)
                            .Replace("ID-Body-1111-2222", txtCoverMassege.Text)
                            .Replace("ID-Body-1111-9999", txtCoverMassegeDown.Text)
                            .Replace("ID-Portfolio-1111-3333", portfolioUrl)
                            .Replace("ID-Footer-1111-4444", txtFooter.Text)
                            .Replace("ID-Facebook-1111-5555", txtFacebook.Text)
                            .Replace("ID-Twitter-1111-6666", txtTwitter.Text)
                            .Replace("ID-Linkedin-1111-7777", txtLinkedin.Text)
                            .Replace("ID-Github-1111-8888", txtGithub.Text);


            return body;
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtTemplateUrl.Text = openFileDialog2.FileName;
            }


        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(txtTemplateUrl.Text);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}




