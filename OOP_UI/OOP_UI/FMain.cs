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
    public partial class FMain : Form
    {

        public List<Enterprises> EnterprisesList = new List<Enterprises>()
        {
            new Fishing() { Name = "Артель рыболов «Гетеборг»", AmountOfWorkers = 50, Locations = "г. Брянск",
                            OnLand = boolean.False, OnWater = boolean.True, InOcean = boolean.False, 
                            InSea = boolean.False, InRiver = boolean.True, Fish = 10000
                          },

            new MiningEnterprise() { Name = "ТОО \"Оркен\"", AmountOfWorkers = 100, Locations = "Степногорск",
                                     OnLand = boolean.True, OnWater = boolean.False, Mine = boolean.False,
                                     Quarry = boolean.True, DurationOfMining = 1365, LevelOfDanger = 2,
                                   },

            new HydroPowerPlant() { Name = "Саяно-Шушенская ГЭС", AmountOfWorkers = 70, Locations = "Саяногорск", 
                                    OnLand = boolean.False, OnWater = boolean.True, PowerOfStation = 6400, 
                                    PowerOfWaterPressure = 194, TypeOfStation = HydroPowerPlant.Stations.Accumulating
                                  },

            new ThermalPowerPlant() { Name = "Сургутская ГРЭС-1", AmountOfWorkers = 65, Locations = "г. Сургут",
                                      LocalRawMaterial = boolean.False, DangerRawMaterial = boolean.True, 
                                      TypeOfFuel = ThermalPowerPlant.Fuels.NatureGas
                                    },

            new BakeryEnterprise() { Name = "ООО Уком", AmountOfWorkers = 53, Locations = "г. Новосибирск",
                                     ProductsWithFlour = boolean.True, ProductsWithMeat = boolean.False,
                                     ProductsWithMilk = boolean.False, ProductsWithSugar = boolean.True,
                                     LocalRawMaterial = boolean.False, DangerRawMaterial = boolean.False,
                                     AmountOfFlour = 120, Eggs = 300000, Milk = 700, Sail = 200,
                                     Sugar = 300, TypeOfFlour = BakeryEnterprise.Flours.Wheat, Water = 2 
                                   },

            new MeatProcessingPlant() { Name = "Перерабатывающий завод \"Витебск Мясокомбината\"", AmountOfWorkers = 15,
                                        Locations = "г. Витебск", LocalRawMaterial = boolean.True, DangerRawMaterial = boolean.False,
                                        ProductsWithFlour = boolean.False, ProductsWithMeat = boolean.True, 
                                        ProductsWithMilk = boolean.False, ProductsWithSugar = boolean.False,
                                        CannedFood = boolean.True, Sausages = boolean.True, Semis = boolean.True,
                                        LocalMeat = boolean.True, NeededMeat = 1000
                                      },

            new MeatCombine() { Name = "\"ОАО Витебск Мясокомбинат\"", AmountOfWorkers = 53, Locations = "г Витебск",
                                LocalRawMaterial = boolean.False, DangerRawMaterial = boolean.False,
                                ProductsWithFlour = boolean.False, ProductsWithMeat = boolean.True,
                                ProductsWithMilk = boolean.False, ProductsWithSugar = boolean.False,
                                AmountOfCattle = 400, AmountOfFreshMeat = 400, KeepingMeat = 700
                              },

            new MilkEnterprise() { Name = "\"ОАО Витебск Молоко\"", AmountOfWorkers = 34, Locations = "г. Витебск",
                                   LocalRawMaterial = boolean.False, DangerRawMaterial = boolean.False,
                                   ProductsWithFlour = boolean.False, ProductsWithMeat = boolean.False,
                                   ProductsWithMilk = boolean.True, ProductsWithSugar = boolean.True, 
                                 }

        };

        public List<Type> TypesList = new List<Type>()
        {
            typeof(Fishing),
            typeof(MiningEnterprise),
            typeof(HydroPowerPlant),
            typeof(ThermalPowerPlant),
            typeof(BakeryEnterprise),
            typeof(MeatProcessingPlant),
            typeof(MeatCombine),
            typeof(MilkEnterprise)
        };

        public int SelectedIndex;
        public Form FEdit;

        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            LVMain.MultiSelect = false;
            SelectedIndex = -1;

            foreach (var type in TypesList)
                CBTypes.Items.Add(type.ToString().Substring(7));

            CBTypes.SelectedIndex = 0;
            CBTypes.DropDownStyle = ComboBoxStyle.DropDownList;

            Redraw(LVMain, EnterprisesList);
        }

        public void Redraw(ListView listView, List<Enterprises> items)
        {
            listView.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                var LVItem = new ListViewItem();
                Type itemType = items[i].GetType();

                object Name;

                try
                {
                    var nameField = items[i].GetType().GetField("Name");
                    Name = nameField.GetValue(items[i]);
                }
                catch
                {
                    Name = "";
                }

                LVItem.Text = itemType.Name + " " + Name;
                listView.Items.Add(LVItem);
            }
        }

        private void BCreate_Click(object sender, EventArgs e)
        {
            /*Type type = Type.GetType("OOP_UI." + CBTypes.SelectedItem, false, true);
            object obj = Activator.CreateInstance(type);
            EnterprisesList.Add(obj);*/

            EnterprisesList.Add((Enterprises)(TypesList[CBTypes.SelectedIndex].GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes)));

            Form EForm = new ItemForm(EnterprisesList[EnterprisesList.Count - 1], EnterprisesList);
            EForm.StartPosition = FormStartPosition.CenterScreen;
            EForm.ShowDialog();
            EForm.Dispose();

            Redraw(LVMain, EnterprisesList);

            /*ListViewItem LVItem = LVMain.Items[(EnterprisesList.Count - 1)];
            if (LVItem != null)
            {
                LVMain.Focus();
                LVItem.Selected = true;
                BEdit.PerformClick();
            }*/ 
        }

        private void BEdit_Click(object sender, EventArgs e)
        {

            //получаем индекc выделенного пункта
            int itemNum;
            if (LVMain.SelectedIndices.Count != 0)
                itemNum = LVMain.SelectedIndices[0];
            else
                return;

            //Создаем форму редактирования обьекта
            Form EForm = new ItemForm(EnterprisesList[itemNum], EnterprisesList);
            EForm.StartPosition = FormStartPosition.CenterScreen;
            EForm.ShowDialog();
            EForm.Dispose();

            Redraw(LVMain, EnterprisesList);

/*            int SelectedIndex;

            if (LVMain.SelectedIndices.Count != 0)
                SelectedIndex = LVMain.SelectedIndices[0];
            else
                return;

            object item = EnterprisesList[SelectedIndex];

            FieldInfo[] ItemFields = item.GetType().GetFields();

            FEdit = new Form
            {
                Text = item.GetType().ToString(),
                Size = new System.Drawing.Size(300, 60 + 25 * (ItemFields.Length + 2))
            };

            for (int i = 0; i < ItemFields.Length; i++)
            {

                Label label = new Label
                {
                    Location = new Point(15, 25 * (i + 1)),
                    Width = string.Concat(ItemFields[i].FieldType.Name, " ", ItemFields[i].Name).Length * 7,
                    Text = string.Concat(ItemFields[i].FieldType.Name, " ", ItemFields[i].Name)
                };

                FEdit.Controls.Add(label);

                if (ItemFields[i].FieldType.IsPrimitive || (ItemFields[i].FieldType == typeof(string)))
                {
                    TextBox text = new TextBox()
                    {
                        Name = ItemFields[i].Name,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        Width = FEdit.Width - (label.Location.X + label.Width + 30),
                        Text = ItemFields[i].GetValue(item).ToString()
                    };
 
                    FEdit.Controls.Add(text);
                }
                else
                {
                    ComboBox combo = new ComboBox()
                    {
                        Name = ItemFields[i].Name,
                        Location = new Point(15 + label.Width, 25 * (i + 1)),
                        Width = FEdit.Width - (label.Location.X + label.Width + 30),
                        SelectionStart = 0,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                    };

                    foreach (var type in ItemFields[i].FieldType.GetEnumNames())
                        combo.Items.Add(type);

                    combo.SelectedIndex = 0;

                    FEdit.Controls.Add(combo);
                }
            }

            FEdit.ShowDialog();
            FEdit.Dispose();*/

        }

        private void Delete_Action(Enterprises DelObject, List<Enterprises> ObjectList)
        {
            //список объектов которые могут использовать удаляемый обьект
            var ownerList = ObjectList.Where(item => (item.GetType().GetFields().Where(field => (field.FieldType == DelObject.GetType()))).ToList().Count > 0);
            foreach (var owner in ownerList)
            {
                foreach (var field in owner.GetType().GetFields().Where(field => (field.FieldType == DelObject.GetType())).ToList())
                {
                    if (field.GetValue(owner) != null)
                    {
                        if (field.GetValue(owner).Equals(DelObject))
                        {
                            field.SetValue(owner, null);
                        }
                    }
                }
            }

            //Непосредственное удаление обьекта
            ObjectList.Remove(DelObject);
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if ((LVMain.SelectedIndices.Count != 0) && (LVMain.SelectedIndices[0] < EnterprisesList.Count))
            {
                int itemNum = LVMain.SelectedIndices[0];

                Delete_Action(EnterprisesList[itemNum], EnterprisesList);
            }
            Redraw(LVMain, EnterprisesList);
        }

    }
}
