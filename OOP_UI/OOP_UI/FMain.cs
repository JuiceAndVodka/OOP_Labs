using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using PluginInterface;

namespace OOP_UI
{
    public partial class FMain : Form
    {

        //список создаваемых предприятий
        public List<Enterprises> EnterprisesList = new List<Enterprises>()
        {
            new Fishing() { Name = "Артель рыболов «Гетеборг»", AmountOfWorkers = 50, Locations = "г. Брянск",
                            OnLand = false, OnWater = true, InOcean = false, 
                            InSea = false, InRiver = true, Fish = 10000
                          },

            new MiningEnterprise() { Name = "ТОО \"Оркен\"", AmountOfWorkers = 100, Locations = "Степногорск",
                                     OnLand = true, OnWater = false, Mine = false,
                                     Quarry = true, DurationOfMining = 1365, LevelOfDanger = 2,
                                   },

            new HydroPowerPlant() { Name = "Саяно-Шушенская ГЭС", AmountOfWorkers = 70, Locations = "Саяногорск",
                                    OnLand = false, OnWater = true, PowerOfStation = 6400, 
                                    PowerOfWaterPressure = 194, TypeOfStation = HydroPowerPlant.Stations.Accumulating
                                  },

            new ThermalPowerPlant() { Name = "Сургутская ГРЭС-1", AmountOfWorkers = 65, Locations = "г. Сургут", 
                                      LocalRawMaterial = false, DangerRawMaterial = true, 
                                      TypeOfFuel = ThermalPowerPlant.Fuels.NatureGas
                                    },

            new BakeryEnterprise() { Name = "ООО Уком", AmountOfWorkers = 53, Locations = "г. Новосибирск",
                                     ProductsWithFlour = true, ProductsWithMeat = true,
                                     ProductsWithMilk = false, ProductsWithSugar = true,
                                     LocalRawMaterial = false, DangerRawMaterial = false,
                                     AmountOfFlour = 120, Eggs = 300000, Milk = 700, Sail = 200,
                                     Sugar = 300, TypeOfFlour = BakeryEnterprise.Flours.Wheat, Water = 2 
                                   },

            new MeatProcessingPlant() { Name = "Перерабатывающий завод \"Витебск Мясокомбината\"", AmountOfWorkers = 15,
                                        Locations = "г. Витебск", LocalRawMaterial = true, DangerRawMaterial = false,
                                        ProductsWithFlour = false, ProductsWithMeat = true, 
                                        ProductsWithMilk = false, ProductsWithSugar = false,
                                        CannedFood = true, Sausages = true, Semis = true,
                                        LocalMeat = true, NeededMeat = 1000
                                      },

            new MeatCombine() { Name = "\"ОАО Витебск Мясокомбинат\"", AmountOfWorkers = 53, Locations = "г. Витебск",
                                LocalRawMaterial = false, DangerRawMaterial = false,
                                ProductsWithFlour = false, ProductsWithMeat = true,
                                ProductsWithMilk = false, ProductsWithSugar = false,
                                AmountOfCattle = 400, AmountOfFreshMeat = 400, KeepingMeat = 700
                              },

            new MilkEnterprise() { Name = "\"ОАО Витебск Молоко\"", AmountOfWorkers = 34, Locations = "г. Витебск",
                                   LocalRawMaterial = false, DangerRawMaterial = false,
                                   ProductsWithFlour = false, ProductsWithMeat = false,
                                   ProductsWithMilk = true, ProductsWithSugar = true, 
                                 }

        };

        //список типов каждого предприятия
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

        public List<IPlugin> PluginsList = new List<IPlugin>();

        public int SelectedIndex;
        public Form FEdit;

        public FMain()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void FMain_Load(object sender, EventArgs e)
        {
            LVMain.MultiSelect = false;
            SelectedIndex = -1;

            foreach (var type in TypesList)
                CBTypes.Items.Add(type.ToString().Substring(7));

            CBTypes.SelectedIndex = 0;
            CBTypes.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadPlugins();

            Redraw(LVMain, EnterprisesList);
        }

        //перерисовка списка
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

        //создание нового предприятия
        private void BCreate_Click(object sender, EventArgs e)
        {
            Enterprises newObject = (Enterprises) Activator.CreateInstance(TypesList[CBTypes.SelectedIndex]);
            EnterprisesList.Add(newObject);

            Form EForm = new ItemForm(newObject, EnterprisesList);
            EForm.StartPosition = FormStartPosition.CenterScreen;
            EForm.ShowDialog();
            EForm.Dispose();

            Redraw(LVMain, EnterprisesList);
        }

        //редактирование выбранного предприятия
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

        //удаление выбранного предприятия
        private void BDelete_Click(object sender, EventArgs e)
        {
            if ((LVMain.SelectedIndices.Count != 0) && (LVMain.SelectedIndices[0] < EnterprisesList.Count))
            {
                int itemNum = LVMain.SelectedIndices[0];

                Delete_Action(EnterprisesList[itemNum], EnterprisesList);
            }
            Redraw(LVMain, EnterprisesList);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeOfFile fTypeOfFile = new TypeOfFile(EnterprisesList, PluginsList, "save");
            this.Hide();
            fTypeOfFile.ShowDialog();
            fTypeOfFile.Dispose();
            this.Show();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            TypeOfFile fTypeOfFile = new TypeOfFile(EnterprisesList, PluginsList, "load");
            this.Hide();
            fTypeOfFile.ShowDialog();
            EnterprisesList = fTypeOfFile.TheValue;
            fTypeOfFile.Dispose();
            Redraw(LVMain, EnterprisesList);
            this.Show();
        }

        private void LoadPlugins()
        {
            string pluginPath = Path.Combine(Directory.GetCurrentDirectory(),"Plugins");

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            //Берем из директории все файлы с расширением .dll      
            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                if (file != (pluginPath + "\\" + "PluginInterface.dll"))
                {
                    //Загружаем сборку
                    Assembly asm = Assembly.LoadFrom(file);
                    //Ищем типы, имплементирующие наш интерфейс IPlugin
                    var types = asm.GetTypes().
                                    Where(t => t.GetInterfaces().
                                    Where(i => i.FullName == typeof(IPlugin).FullName).Any());

                    //Заполняем экземплярами полученных типов коллекцию плагинов
                    foreach (var type in types)
                    {
                        var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                        PluginsList.Add(plugin);
                    }
                }
            }
        }

    }
}
