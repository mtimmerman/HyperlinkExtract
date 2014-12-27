using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace HyperlinkExtract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(textBox3.Text) as HttpWebRequest;

            NetworkCredential cred = new NetworkCredential("mtimmerman", "HaOnVli");

            request.Credentials = cred;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string text = reader.ReadToEnd();

                        Regex regex = new Regex(@"seeVideo\.asp\?update=[0-9]*");

                        MatchCollection coll = regex.Matches(text);

                        listBox1.Items.Clear();
                        if (coll != null)
                        {
                            listBox1.Items.AddRange(coll.Cast<Match>().Select(m => "http://members.laylaextreme.com/" + m.Value).ToArray());
                        }

                        MessageBox.Show(listBox1.Items.Count.ToString());

                        //for (int i = 0; i < listBox1.Items.Count; i++)
                        //{
                        //    Application.DoEvents();
                        //    HttpWebRequest listRequest = WebRequest.Create(listBox1.Items[i].ToString()) as HttpWebRequest;

                        //    listRequest.Credentials = cred;

                        //    using (HttpWebResponse listResponse = listRequest.GetResponse() as HttpWebResponse)
                        //    {
                        //        using (StreamReader listReader = new StreamReader(listResponse.GetResponseStream()))
                        //        {
                        //            text = listReader.ReadToEnd();

                        //            Regex photoRegex = new Regex(@"series/[a-zA-Z|\W]*/www.laylaextreme.com-[0-9]*.jpg");                                    

                        //            MatchCollection listColl = photoRegex.Matches(text);

                        //            if (listBox1.Items[i].ToString().IndexOf("page=") < 0)
                        //            {
                        //                Regex pageRegex = new Regex(@"seePhotos\.asp\?update=[0-9]*&page=[0-9]");
                        //                MatchCollection pageColl = pageRegex.Matches(text);

                        //                listBox1.Items.AddRange(pageColl.Cast<Match>().Select(m => "http://members.laylaextreme.com/" + m.Value).ToArray());
                        //            }

                        //            listBox2.Items.Clear();

                        //            listBox2.Items.AddRange(listColl.Cast<Match>().Select(m => "http://members.laylaextreme.com/" + m.Value).ToArray());

                        //            foreach (string str2 in listBox2.Items)
                        //            {
                        //                Application.DoEvents();
                        //                if (str2.IndexOf("/out") < 0 && str2.IndexOf("/th/") < 0)
                        //                {
                        //                    string[] split = str2.Split('/');
                        //                    string filename = string.Format(@"c:\Test\{0}\{1}", split[split.Length - 2], split[split.Length - 1]);

                        //                    if (File.Exists(filename))
                        //                    {
                        //                        continue;
                        //                    }
                        //                    if (!Directory.Exists(Path.GetDirectoryName(filename)))
                        //                    {
                        //                        Directory.CreateDirectory(Path.GetDirectoryName(filename));
                        //                    }

                        //                    HttpWebRequest downloadRequest = WebRequest.Create(str2) as HttpWebRequest;
                        //                    downloadRequest.Credentials = cred;

                        //                    try
                        //                    {
                        //                        using (HttpWebResponse downloadResponse = downloadRequest.GetResponse() as HttpWebResponse)
                        //                        {                                                    
                        //                            byte[] buffer = new byte[512];
                        //                            int count = 0;

                        //                            using (FileStream fs = File.Create(filename))
                        //                            {
                        //                                try
                        //                                {
                        //                                    while ((count = downloadResponse.GetResponseStream().Read(buffer, 0, buffer.Length)) > 0)
                        //                                    {
                        //                                        fs.Write(buffer, 0, count);
                        //                                    }
                        //                                }
                        //                                finally
                        //                                {
                        //                                    fs.Close();
                        //                                }
                        //                            }
                        //                        }
                        //                    }
                        //                    catch
                        //                    {
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
                finally
                {
                    response.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}
