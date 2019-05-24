using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PluginInterface;

namespace OOP_UI
{
    public partial class TypeOfFile : Form
    {
        string WhatAction;
        private List<Enterprises> qEnterprisesList;
        public List<Enterprises> TheValue { get { return qEnterprisesList; } }
        private List<EnteprisesSerializer> Serializers = new List<EnteprisesSerializer>
        {
            new Binary(),
            new JSON(),
            new Alex()
        };
        private List<IPlugin> qPluginsList;

        public TypeOfFile(List<Enterprises> pEnterprisesList, List<IPlugin> pPluginsList,string action)
        {
            InitializeComponent();

            WhatAction = action;
            qEnterprisesList = pEnterprisesList;
            qPluginsList = pPluginsList;

            CBType.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var item in Serializers)
            {
                CBType.Items.Add(item.Name);
            }

            CBType.SelectedIndex = 0;

            CBPlugins.DropDownStyle = ComboBoxStyle.DropDownList;

            if (WhatAction != "save")
            {
                LabelChoise.Enabled = false;
                CheckChoise.Enabled = false;
                LabelPlugins.Enabled = false;
                CBPlugins.Enabled = false;
            }
            else
            {
                foreach (var item in qPluginsList)
                {
                    CBPlugins.Items.Add(item.Name);
                }

                CBPlugins.SelectedIndex = 0;
            }

        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            string FileType = CBType.SelectedItem.ToString();

            EnteprisesSerializer Serializator = Serializers[CBType.SelectedIndex];

            string FileExtension = Serializator.FileExtenstion;

            string FilePath;

            if (WhatAction == "save")
            {

                string ExpansionFilter;

                if (CheckChoise.Checked)
                {
                    string newExpansion = FileExtension + qPluginsList[CBPlugins.SelectedIndex].Expansion;

                    ExpansionFilter = qPluginsList[CBPlugins.SelectedIndex].Name + " (*" + newExpansion + ")|*" + newExpansion;

                }
                else
                {
                    ExpansionFilter = FileType + " (*" + FileExtension + ")|*" + FileExtension;
                }

                SaveDialog.Filter = ExpansionFilter;
                SaveDialog.InitialDirectory = "D:\\";

                if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                FilePath = SaveDialog.FileName;

                using (FileStream newStream = new FileStream(FilePath, FileMode.Create))
                {
                    Serializator.Serialize(newStream, qEnterprisesList);
                }

                if (CheckChoise.Checked)
                {
                    byte[] TextBytes;


                    if (Serializator.FinalResult == "string")
                        using (StreamReader ReadStream = new StreamReader(FilePath))
                        {
                            TextBytes = System.Text.Encoding.UTF8.GetBytes(ReadStream.ReadToEnd());
                        }
                    else
                        TextBytes = File.ReadAllBytes(FilePath);

                    using (FileStream pluginStream = new FileStream(FilePath, FileMode.Create))
                    {
                        qPluginsList[CBPlugins.SelectedIndex].Encode(pluginStream, TextBytes);
                    }
                }

                MessageBox.Show("Успешное сохранение!");
            }
            else
            {
                string ExpansionFilter;

                ExpansionFilter = FileType + " (*" + FileExtension + ")|*" + FileExtension;

                foreach (var item in qPluginsList)
                {
                    ExpansionFilter += "|" + item.Name + " (*" + FileExtension + item.Expansion + ")|*" + FileExtension + item.Expansion;
                }

                OpenDialog.Filter = ExpansionFilter;
                OpenDialog.InitialDirectory = "D:\\";

                if (OpenDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                FilePath = OpenDialog.FileName;

                string FileExpansion = FilePath.Substring(FilePath.LastIndexOf("."));
                bool DidCreateCopyFile = false;

                if (FileExpansion != FileExtension)
                {
                    int NumberInList = 0;
                    bool DoesWeHavaPlugin = false;

                    for (int i = 0; i < qPluginsList.Count; i++)
                    {
                        if (FileExpansion == qPluginsList[i].Expansion)
                        {
                            NumberInList = i;
                            DoesWeHavaPlugin = true;
                            break;
                        }
                    }

                    if (!DoesWeHavaPlugin)
                    {
                        MessageBox.Show("Невозможно загрузить файл, так как отсутствует соответствующий плагин");
                        return;
                    }
                    else
                    {
                        DidCreateCopyFile = true;

                        string CopyFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Temp");

                        DirectoryInfo pluginDirectory = new DirectoryInfo(CopyFilePath);
                        if (!pluginDirectory.Exists)
                            pluginDirectory.Create();

                        string bufPath = FilePath;
                        FilePath = CopyFilePath + "\\(copy)" + FilePath.Substring(FilePath.LastIndexOf("\\") + 1);

                        if (File.Exists(FilePath))
                            File.Delete(FilePath);

                        File.Copy(bufPath, FilePath);

                        byte[] Bytes;
                        using (FileStream pluginStream = new FileStream(FilePath, FileMode.Open))
                        {
                            Bytes = qPluginsList[NumberInList].Decode(pluginStream);
                        }

                        using (FileStream pluginStream = new FileStream(FilePath, FileMode.Create))
                        {
                            if (Serializator.FinalResult == "string")
                                using (StreamWriter WriteStream = new StreamWriter(pluginStream))
                                {
                                    WriteStream.Write(System.Text.Encoding.UTF8.GetString(Bytes));
                                }
                            else
                                pluginStream.Write(Bytes, 0, Bytes.Length);
                        }
                    }
                }

                using (FileStream newStream = new FileStream(FilePath, FileMode.OpenOrCreate))
                {
                    qEnterprisesList.Clear();
                    qEnterprisesList = (List<Enterprises>)Serializator.Deserialize(newStream);
                }

                if (DidCreateCopyFile)
                {
                    File.Delete(FilePath);
                }

                MessageBox.Show("Успешная загрузка!");
            }

            this.Close();
        }
    }
}
