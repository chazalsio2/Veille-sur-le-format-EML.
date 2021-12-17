using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sujet_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //label4.MaximumSize = 30;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "il n'y a pas de piece joint";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.eml)|*.eml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           
                if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(openFileDialog.FileName);
                var eml = MsgReader.Mime.Message.Load(fileInfo);
                textBox3.Text = fileInfo.Name;



                if (eml.Headers != null)
                {

                    if (eml.Headers.To != null)
                    {
                        foreach (var recipient in eml.Headers.To)
                        {
                            var to = recipient.Address;
                            mailde.Text = to;
                        }
                    }
                    if (eml.Headers.From != null)
                    {
                        var from = eml.Headers.From;
                        mail.Text = from.Address;

                    }


                }
                if (eml.Attachments != null)
                {
                    var Attachment = eml.Attachments.ToArray();
                   
                    foreach (var attachment in Attachment)
                    {
                        var piece_j = "FileName : " + attachment.FileName + " \r\n";
                        piece_j += "ContentId : " + attachment.ContentId + " \r\n";
                        piece_j += "ContentDescription : " + attachment.ContentDescription + " \r\n";
                        piece_j += "ContentDisposition : " + attachment.ContentDisposition + " \r\n";
                        piece_j += "ContentTransferEncoding : " + attachment.ContentTransferEncoding + " \r\n";
                        piece_j += "ContentType : " + attachment.ContentType + " \r\n";
                        piece_j += "Body : " + attachment.Body + " \r\n";
                        piece_j += "BodyEncoding : " + attachment.BodyEncoding + " \r\n";
                        piece_j += "IsAttachment : " + attachment.IsAttachment + " \r\n";
                        piece_j += "IsInline : " + attachment.IsInline + " \r\n";
                        piece_j += "IsMultiPart : " + attachment.IsMultiPart + " \r\n";
                        piece_j += "IsText : " + attachment.IsText + " \r\n";
                        piece_j += "MessageParts : " + attachment.MessageParts + " \r\n";
                        piece_j += "\r\n";

                        textBox2.Text += piece_j;

                    }

                }
                else
                {
                    textBox2.Text += "hello";
                }

                var subject = eml.Headers.Subject;

                if (subject != null)
                {
                    sujet.Text = subject;
                }
                if (eml.TextBody != null)
                {
                    var textBody = System.Text.Encoding.UTF8.GetString(eml.TextBody.Body);
                    textBox1.Text = textBody;
                    //var p = System.Text.Encoding.UTF8.GetString(eml.Headers.To);

                }
                else
                {
                    textBox1.Text = "il n'y a pas de message";
                }

                if (eml.HtmlBody != null)
                {
                    var htmlBody = System.Text.Encoding.UTF8.GetString(eml.HtmlBody.Body);

                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
