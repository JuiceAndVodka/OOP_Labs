using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OOP_UI
{
    // bool? = Nullable<bool>
//    public enum boolean { None = 0, True = 1, False = 2 }

    [Serializable]
    [XmlInclude(typeof(ExtractiveEnterprise)), XmlInclude(typeof(ManufacturingEnterprise))]
    public class Enterprises
    {

        [Info("Именование предприятия")]
        public string Name;

        [Info("Местонахождение предприятия")]
        public string Locations;

        [Info("Количество рабочих у предприятия")]
        public int AmountOfWorkers;

        public Enterprises()
        {
            Name = "undefined";
            AmountOfWorkers = 200;
            Locations = "Planet \"Earth\"";
        }
    }

    [Serializable]
    [XmlInclude(typeof(Fishing)), XmlInclude(typeof(MiningEnterprise)), XmlInclude(typeof(HydroPowerPlant))]
    public class ExtractiveEnterprise : Enterprises
    {
        [Info("Добыча на земле")]
        public bool OnLand;

        [Info("Добыча на воде")]
        public bool OnWater;

        public ExtractiveEnterprise()
        {
            OnLand = true;
            OnWater = false;
        }
    }

    [Serializable]
    [Info("Предприятие по ловле рыбы")]
    public class Fishing : ExtractiveEnterprise
    {
        [Info("Имеется ли добыча в реках")]
        public bool InRiver;

        [Info("Имеется ли добыча в море")]
        public bool InSea;

        [Info("Имеется ли добыча в океане")]
        public bool InOcean;

        [Info("Имеющаяся рыба ( в кг )")]
        public int Fish;

        [Info("Виды добываемой рыбы")]
        public string TypesOfFish;

        public Fishing()
        {
            InRiver = false;
            InSea = true;
            InOcean = true;
            Fish = 1000000; // в кг
            TypesOfFish = "Herring, Cod, Catfish, Flounder, Roach";
        }

    }

    [Serializable]
    [Info("Горнодобывающее предприятие")]
    public class MiningEnterprise : ExtractiveEnterprise
    {
        [Info("Шахтовая добыча")]
        public bool Mine;

        [Info("Карьерная добыча")]
        public bool Quarry;

        [Info("Виды добываемой руды")]
        public string TypesOfMining;

        [Info("Продолжительность добывания ( в днях )")]
        public int DurationOfMining;

        [Info("Уровень опасности ( от 1 до 10 )")]
        public int LevelOfDanger;

        public MiningEnterprise()
        {
            Mine = true;
            Quarry = false;
            TypesOfMining = "Gold, Silver, Iron, Titanium";
            DurationOfMining = 3200; // в днях
            LevelOfDanger = 4; // по 10-й шкале
        }
    }

    [Serializable]
    [Info("Гидроэлектростанция")]
    public class HydroPowerPlant : ExtractiveEnterprise
    {
        public enum Stations { None = 0, Dam = 1, NearTheDam = 2, Derivational = 3, Accumulating = 4 }

        [Info("Мощность ГЭС ( в МВт )")]
        public int PowerOfStation;

        [Info("Напор воды ( в метрах )")]
        public int PowerOfWaterPressure;

        [Info("Тип станции")]
        public Stations TypeOfStation;

        public HydroPowerPlant()
        {
            PowerOfStation = 100; // в МВт
            PowerOfWaterPressure = 30; // в метрах
            TypeOfStation = Stations.NearTheDam;
        }
    }

    [Serializable]
    [XmlInclude(typeof(ThermalPowerPlant)), XmlInclude(typeof(FoodEnterprise))]
    public class ManufacturingEnterprise : Enterprises
    {
        [Info("Используется локальное сырьё")]
        public bool LocalRawMaterial;

        [Info("Работает с опасным сырьём")]
        public bool DangerRawMaterial;

        public ManufacturingEnterprise()
        {
            LocalRawMaterial = true;
            DangerRawMaterial = false;
        }
    }

    [Serializable]
    [Info("Теплоэлектростанция")]
    public class ThermalPowerPlant : ManufacturingEnterprise
    {
        public enum Fuels { None = 0, Oil = 1, Coal = 2, NatureGas = 3 }

        [Info("Имеющееся топливо ( в тоннах )")]
        public int AmountOfFuel;

        [Info("Тип используемого топлива")]
        public Fuels TypeOfFuel;

        public ThermalPowerPlant()
        {
            AmountOfFuel = 10; // в тоннах
            TypeOfFuel = Fuels.Oil;
        }

    }

    [Serializable]
    [XmlInclude(typeof(BakeryEnterprise)), XmlInclude(typeof(MeatProcessingPlant)), 
     XmlInclude(typeof(MeatCombine)), XmlInclude(typeof(MilkEnterprise))]
    public class FoodEnterprise : ManufacturingEnterprise
    {
        [Info("Продукты из мяса")]
        public bool ProductsWithMeat;

        [Info("Продукты из молока")]
        public bool ProductsWithMilk;

        [Info("Продукты с сахаром")]
        public bool ProductsWithSugar;

        [Info("Продукты из муки")]
        public bool ProductsWithFlour;

        public FoodEnterprise()
        {
            ProductsWithMeat = false;
            ProductsWithMilk = false;
            ProductsWithSugar = false;
            ProductsWithFlour = false;
        }
    }

    [Serializable]
    [Info("Хлебобулочное предприятие")]
    public class BakeryEnterprise : FoodEnterprise
    {
        public enum Flours { None = 0, Wheat = 1, Rye = 2, Oat = 3, Corn = 4, BuckWheat = 5 };

        [Info("Имеющаяся мука ( в тоннах )")]
        public int AmountOfFlour;

        [Info("Тип муки")]
        public Flours TypeOfFlour;

        [Info("Имеющийся сахар ( в кг )")]
        public int Sugar;

        [Info("Имеющаяся соль ( в кг )")]
        public int Sail;

        [Info("Имеющиеся яйца ( в штуках )")]
        public int Eggs;

        [Info("Имеющееся молоко ( в ru )")]
        public int Milk;

        [Info("Имеющаяся вода ( в тоннах )")]
        public int Water;

        public BakeryEnterprise()
        {
            AmountOfFlour = 100; // в тоннах
            TypeOfFlour = Flours.Wheat;
            Sugar = 1000; // в кг
            Sail = 1000; // в кг
            Eggs = 200000; // в штуках
            Milk = 500; // в тоннах
            Water = 10; // в тоннах
        }
    }

    [Serializable]
    [Info("Мясоперерабатывающий завод")]
    public class MeatProcessingPlant : FoodEnterprise
    {
        [Info("Мясо добывается рядом")]
        public bool LocalMeat;

        [Info("Количество нужного мяса ( в кг )")]
        public int NeededMeat;

        [Info("Производят ли колбасы")]
        public bool Sausages;

        [Info("Производят ли полуфабрикаты")]
        public bool Semis;

        [Info("Производят ли консервы")]
        public bool CannedFood;

        public MeatProcessingPlant()
        {
            LocalMeat = true;
            NeededMeat = 1000; // в кг
            Sausages = true;
            Semis = true;
            CannedFood = false;
        }
    }

    [Serializable]
    [Info("Мясокомбинат")]
    public class MeatCombine : FoodEnterprise
    {
        [Info("Имеющийся скот ( в кг )")]
        public int AmountOfCattle;

        [Info("Имеющееся свежее мясо ( в кг )")]
        public int AmountOfFreshMeat;

        [Info("Хранящееся свежее мясо")]
        public int KeepingMeat;

        [Info("Локальный перерабатывающий завод")]
        public MeatProcessingPlant MPP;

        public MeatCombine()
        {
            AmountOfCattle = 500; // в кг
            AmountOfFreshMeat = 500; // в кг
            KeepingMeat = 1000; // в кг
            MPP = null;
        }
    }

    [Serializable]
    [Info("Молочное предприятие")]
    public class MilkEnterprise : FoodEnterprise
    {
        [Info("Имеющееся сырое молоко ( в тоннах )")]
        public int RawMilk;

        [Info("Имеющиеся сливки ( в кг )")]
        public int Cream;

        [Info("Количество готовых продуктов ( в штуках )")]
        public int MilkProducts;

        [Info("Виды продукции")]
        public string TypesOfProducts;

        public MilkEnterprise()
        {
            RawMilk = 10; // в тоннах
            Cream = 100; // в кг
            MilkProducts = 300000; // в штуках
            TypesOfProducts = "Milk, Kefir, Butter, Ice-cream, Sour cream";
        }
    }

    //public List<Type> AllTypeObjList = Assembly.GetAssembly(typeof(UserClass)).GetTypes().Where(type =>
    // type.IsSubClassOf(typeof(UserClass))).ToList()

    /*public List<ICreator> CreatorList = new List<ICreator>()
    {
        new FishingCreator(),
        new MiningEnterpriseCreator(),
        new HydroPowerPlantCreator(),
        new ThermalPowerPlantCreator(),
        new BakeryEnterpriseCreator(),
        new MeatProcessingPlantCreator(),
        new MeatCombineCreator(),
        new MilkEnterpriseCreator()
    };*/

/*    public interface ICreator
    {
        object Create();
    }

    public class FishingCreator : ICreator
    {
        public object Create()
        {
            return new Fishing();
        }
    }

    public class MiningEnterpriseCreator : ICreator
    {
        public object Create()
        {
            return new MiningEnterprise();
        }
    }

    public class HydroPowerPlantCreator : ICreator
    {
        public object Create()
        {
            return new HydroPowerPlant();
        }
    }

    public class ThermalPowerPlantCreator : ICreator
    {
        public object Create()
        {
            return new ThermalPowerPlant();
        }
    }

    public class BakeryEnterpriseCreator : ICreator
    {
        public object Create()
        {
            return new BakeryEnterprise();
        }
    }

    public class MeatProcessingPlantCreator : ICreator
    {
        public object Create()
        {
            return new MeatProcessingPlant();
        }
    }

    public class MeatCombineCreator : ICreator
    {
        public object Create()
        {
            return new MeatCombine();
        }
    }

    public class MilkEnterpriseCreator : ICreator
    {
        public object Crete()
        {
            return new MilkEnterprise();
        }
    }
*/

}
