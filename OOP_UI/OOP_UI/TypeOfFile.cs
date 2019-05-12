using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_UI
{
    public partial class TypeOfFile : Form
    {
        string WhatAction;
        private List<Enterprises> qEnterprisesList;
        public List<Enterprises> TheValue { get { return qEnterprisesList; } }

        public TypeOfFile(List<Enterprises> pEnterprisesList, string action)
        {
            InitializeComponent();

            WhatAction = action;
            qEnterprisesList = pEnterprisesList;

            CBType.DropDownStyle = ComboBoxStyle.DropDownList;

            CBType.Items.Add("Binary file");
            CBType.Items.Add("JSON file");
            CBType.Items.Add("Text file");

            CBType.SelectedIndex = 0;
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            string FileType = CBType.SelectedItem.ToString();

            string FileExtension = "";

            switch (FileType)
            {
                case "Binary file":
                    FileExtension = "bin";
                    break;

                case "JSON file":
                    FileExtension = "json";
                    break;

                case "Text file":
                    FileExtension = "txt";
                    break;
            }

            string FilePath = "";

            if (WhatAction == "save")
            {
                SaveDialog.DefaultExt = FileExtension;
                SaveDialog.AddExtension = true;
                SaveDialog.Filter = FileType + " (*." + FileExtension + ")|*." + FileExtension;
                SaveDialog.InitialDirectory = "D:\\";

                if (SaveDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                FilePath = SaveDialog.FileName;
            }
            else
            {
                OpenDialog.DefaultExt = FileExtension;
                OpenDialog.AddExtension = true;
                OpenDialog.Filter = FileType + " (*." + FileExtension + ")|*." + FileExtension;
                OpenDialog.InitialDirectory = "D:\\";

                if (OpenDialog.ShowDialog() == DialogResult.Cancel)
                    return;

               FilePath = OpenDialog.FileName;
            }

            switch (FileType)
            {
                case "Binary file":
                    if (WhatAction == "save")
                    {
                        BinarySerialization.WriteToBinaryFile<List<Enterprises>>(FilePath, qEnterprisesList);
                    }
                    else
                    {
                        qEnterprisesList.Clear();
                        qEnterprisesList = BinarySerialization.ReadFromBinaryFile<List<Enterprises>>(FilePath);
                    }
                    break;

                case "JSON file":
                    if (WhatAction == "save")
                    {
                        JsonSerialization.WriteToJsonFile(FilePath, qEnterprisesList);
                    }
                    else
                    {
                        qEnterprisesList.Clear();
                        qEnterprisesList = JsonSerialization.ReadFromJsonFile<List<Enterprises>>(FilePath);
                    }
                    break;

                case "Text file":
                    if (WhatAction == "save")
                    {
                        TextSerialization.StartWriting<List<Enterprises>>(FilePath, qEnterprisesList);
                    }
                    else
                    {
                        qEnterprisesList.Clear();
                        qEnterprisesList = TextSerialization.StartGetting<List<Enterprises>>(FilePath);
                    }
                    break;
            }

            this.Close();
        }
    }
}
