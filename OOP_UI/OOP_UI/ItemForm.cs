using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace OOP_UI
{
    public partial class ItemForm : Form
    {
        private Enterprises pEnterprise;
        private List<Enterprises> pEnterprisesList;

        const int formWidth = 500;
        const int formMinHeight = 60;
        const int fieldHeight = 25;

        const int paddingLeft = 15;
        const int paddingUp = 25;

        const int SpaceBetweenLabelAndBox = 30;

        public ItemForm(Enterprises Enterprise, List<Enterprises> EnterprisesList)
        {
            //список всех полей объекта
            FieldInfo[] fields = Enterprise.GetType().GetFields(); ;

            //получение имени формы
            string fieldName = Enterprise.GetType().ToString();

            //если у экземляра класса имеется атрибут с названием, то форма будет иметь соответствующее имя
            object[] attributes = Enterprise.GetType().GetCustomAttributes(typeof(InfoAttribute), true);
            if (attributes.Length != 0)
            {
                InfoAttribute myAttr = (InfoAttribute)attributes[0];
                fieldName = myAttr.Name;
            }

            //создание пустой формы для редактирования полей
            base.Text = fieldName;
            base.Size = new System.Drawing.Size(formWidth, formMinHeight + fieldHeight * (fields.Length + 2));
            base.MaximizeBox = false;

            //создание полей
            for (int i = 0; i < fields.Length; i++)
            {
                //получение имени для Label
                fieldName = fields[i].GetType().ToString();

                //если у поля имеется атрибут с названием, то форма будет иметь соответствующее имя 
                attributes = fields[i].GetCustomAttributes(typeof(InfoAttribute), true);
                if (attributes.Length != 0)
                {
                    InfoAttribute myAttr = (InfoAttribute)attributes[0];
                    fieldName = myAttr.Name;
                }

                //надпись содержащая тип и имя поля
                Label label = new Label
                {
                    Location = new Point(paddingLeft, paddingUp * (i + 1)),
                    Width = base.Width / 2,
                    //Text = string.Concat(fields[i].Name, " - ", fields[i].FieldType.Name, ": ")
                    Text = fieldName
                };

                base.Controls.Add(label);

                //Создание для стандартных типов значений текстовых полей ввода, и их заполнение
                if (((fields[i].FieldType.IsPrimitive) && (!fields[i].FieldType.IsEnum))
                  || (fields[i].FieldType == typeof(string)))
                {
                    base.Controls.Add(MakeTextBox(fields, Enterprise, label, i));
                }

                //Создание выпадающих списков для перечислимых типов
                else if (fields[i].FieldType.IsEnum)
                {
                    base.Controls.Add(MakeEnumBox(fields, Enterprise, label, i));
                }

                //Создание выпадающих списков для вложенных членов
                else if ((!fields[i].FieldType.IsPrimitive) && (!fields[i].FieldType.IsEnum) && (!(fields[i].FieldType == typeof(string))))
                {
                    base.Controls.Add(MakeObjectBox(fields, Enterprise, EnterprisesList, label, i));
                }
            }

            //кнопка сохранения
            Button SaveBut = new Button
            {
                Name = "SaveBut",
                Text = "Save",
                Location = new Point(base.Width / 2 - (base.Width / 8), (fields.Length + 1) * (fieldHeight + 1)),
                Width = base.Width / 4,
                DialogResult = DialogResult.OK,
            };

            pEnterprise = Enterprise;
            pEnterprisesList = EnterprisesList;
            SaveBut.Click += SaveAction;

            base.Controls.Add(SaveBut);

        }

        private TextBox MakeTextBox(FieldInfo[] qfields, Enterprises qEnterprise, Label qlabel, int i)
        {
            TextBox textBox = new TextBox
            {
                Name = qfields[i].Name,
                Location = new Point(paddingLeft + qlabel.Width, fieldHeight * (i + 1)),
                Width = base.Width - (qlabel.Location.X + qlabel.Width + SpaceBetweenLabelAndBox),
                Text = qfields[i].GetValue(qEnterprise).ToString()
            };

            return textBox;
        }

        private ComboBox MakeEnumBox(FieldInfo[] qfields, Enterprises qEnterprise, Label qlabel, int i)
        {
            ComboBox comboBox = new ComboBox
            {
                Name = qfields[i].Name,
                SelectionStart = 0,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(paddingLeft + qlabel.Width, fieldHeight * (i + 1)),
                Width = base.Width - (qlabel.Location.X + qlabel.Width + SpaceBetweenLabelAndBox)
            };

            comboBox.Items.AddRange(qfields[i].FieldType.GetEnumNames());
            comboBox.SelectedIndex = (int)(qfields[i].GetValue(qEnterprise));

            return comboBox;
        }

        private ComboBox MakeObjectBox(FieldInfo[] qfields, Enterprises qEnterprise, List<Enterprises> qEnterprisesList, Label qlabel, int i)
        {
            ComboBox comboBox = new ComboBox
            {
                Name = qfields[i].Name,
                SelectionStart = 0,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(paddingLeft + qlabel.Width, fieldHeight * (i + 1)),
                Width = base.Width - (qlabel.Location.X + qlabel.Width + SpaceBetweenLabelAndBox)
            };

            //список объектов удовлетворяющих типу поля
            List<Enterprises> SuitableItems = qEnterprisesList.Where(WField => (WField.GetType() == qfields[i].FieldType)).ToList();

            //заполнение списка
            for (int j = 0; j < SuitableItems.Count; j++)
            {
                var EnterpriseField = SuitableItems[j].GetType().GetField("Name");
                if (EnterpriseField != null)
                    comboBox.Items.Add(EnterpriseField.GetValue(SuitableItems[j]));
            }

            //Установка связанного обьекта
            var buf = qfields[i].GetValue(qEnterprise);
            int index = -1;

            if (buf != null)
            {
                for (int j = 0; j < SuitableItems.Count; j++)
                {
                    if (buf.Equals(SuitableItems[j]))
                    {
                        index = j; break;
                    }
                }
                comboBox.SelectedIndex = index;
            }

            return comboBox;
        }

        //сохранение значений полей обьекта
        private void SaveAction(Object sender, EventArgs e)
        {
            if ((pEnterprise == null) || (pEnterprisesList == null))
                return;

            FieldInfo[] fields = pEnterprise.GetType().GetFields();

            //Сохранение значений чекбоксов
            foreach (var control in base.Controls.OfType<CheckBox>().ToList())
            {
                FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                FI.SetValue(pEnterprise, Convert.ChangeType(control.Checked, FI.FieldType));
            }
            //Преобразование текста в значение
            foreach (var control in base.Controls.OfType<TextBox>().ToList())
            {
                if (fields.ToList().Where(field => field.Name == control.Name).Count() != 0)
                {
                    FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                    var FIValye = FI.GetValue(pEnterprise);
                    try
                    {
                        FI.SetValue(pEnterprise, Convert.ChangeType(control.Text, FI.FieldType));
                    }
                    catch
                    {
                        //Восстанавливаем старое значение
                        FI.SetValue(pEnterprise, FIValye);
                        MessageBox.Show(FI.Name + " Error: field text value");
                    }
                }
            }

            //Сохранение значений выпадающих списков
            foreach (var control in base.Controls.OfType<ComboBox>().ToList())
            {
                if (fields.ToList().Where(field => field.Name == control.Name).Count() != 0)
                {
                    FieldInfo FI = fields.ToList().Where(field => field.Name == control.Name).First();
                    var FIValye = FI.GetValue(pEnterprise);

                    if (control.SelectedIndex == -1)
                        continue;

                    if (FI.FieldType.IsEnum)
                    {
                        try
                        {
                            FI.SetValue(pEnterprise, control.SelectedIndex);
                        }
                        catch
                        {
                            FI.SetValue(pEnterprise, FIValye);
                            MessageBox.Show(FI.Name + " Error: field enum value");
                        }
                    }
                    else
                    {
                        List<Enterprises> SuitableItems = pEnterprisesList.Where(sitem => (sitem.GetType() == FI.FieldType)).ToList();
                        try
                        {
                            FI.SetValue(pEnterprise, SuitableItems[control.SelectedIndex]);
                        }
                        catch
                        {
                            FI.SetValue(pEnterprise, FIValye);
                            MessageBox.Show(FI.Name + " Error: field Enterpriseect value");
                        }
                    }
                }
            }
        }
        
    }
}
