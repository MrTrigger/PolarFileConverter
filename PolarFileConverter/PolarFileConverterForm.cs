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
using System.Xml;
using System.Xml.Linq;

namespace PolarFileConverter
{
    public partial class PolarFileConverterForm : Form
    {
        public PolarFileConverterForm()
        {
            InitializeComponent();

            openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog1.Multiselect = true;
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileNames.Count() > 0)
            {
                foreach (var filename in openFileDialog1.FileNames)
                    ConvertFile(filename);

                MessageBox.Show("Finished!");
            }
        }

        private void ConvertFile(String filename)
        {
            XElement xElem = XElement.Load(filename);

            string hrmFilePath = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".hrm";

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreWhitespace = true;

            using (System.IO.StreamWriter hrmFile = new System.IO.StreamWriter(hrmFilePath))
            using (XmlTextReader xmlReader = new XmlTextReader(filename))
            {
                int interval = 0;

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        switch (xmlReader.Name)
                        {
                            case "recording-rate":
                                interval = int.Parse(xmlReader.ReadInnerXml());

                                // Always use interval=5, add samples if the source file uses another interval
                                hrmFile.WriteLine("[Params]");
                                hrmFile.WriteLine("Interval=5");
                                hrmFile.WriteLine();
                                break;

                            case "type":
                                if (xmlReader.ReadInnerXml() == "HEARTRATE")
                                {
                                    xmlReader.ReadToFollowing("values");
                                    string[] hrValues = xmlReader.ReadInnerXml().Split(',');
                                    hrmFile.WriteLine("[HRData]");

                                    int numSamples = interval / 5;
                                    foreach (var v in hrValues)
                                    {
                                        for (int i = 0; i < numSamples; i++)
                                            hrmFile.WriteLine(v);
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
