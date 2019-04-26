using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_UI
{

    public enum boolean { None = 0, True = 1, False = 2 }

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

    public class ExtractiveEnterprise : Enterprises
    {
        [Info("Добыча на земле")]
        public boolean OnLand;

        [Info("Добыча на воде")]
        public boolean OnWater;

        public ExtractiveEnterprise()
        {
            OnLand = boolean.True;
            OnWater = boolean.None;
        }
    }

    [Info("Предприятие по ловле рыбы")]
    public class Fishing : ExtractiveEnterprise
    {
        [Info("Имеется ли добыча в реках")]
        public boolean InRiver;

        [Info("Имеется ли добыча в море")]
        public boolean InSea;

        [Info("Имеется ли добыча в океане")]
        public boolean InOcean;

        [Info("Имеющаяся рыба ( в кг )")]
        public int Fish;

        [Info("Виды добываемой рыбы")]
        public string TypesOfFish;

        public Fishing()
        {
            InRiver = boolean.False;
            InSea = boolean.True;
            InOcean = boolean.True;
            Fish = 1000000; // в кг
            TypesOfFish = "Herring, Cod, Catfish, Flounder, Roach";
        }

    }

    [Info("Горнодобывающее предприятие")]
    public class MiningEnterprise : ExtractiveEnterprise
    {
        [Info("Шахтовая добыча")]
        public boolean Mine;

        [Info("Карьерная добыча")]
        public boolean Quarry;

        [Info("Виды добываемой руды")]
        public string TypesOfMining;

        [Info("Продолжительность добывания ( в днях )")]
        public int DurationOfMining;

        [Info("Уровень опасности ( от 1 до 10 )")]
        public int LevelOfDanger;

        public MiningEnterprise()
        {
            Mine = boolean.True;
            Quarry = boolean.False;
            TypesOfMining = "Gold, Silver, Iron, Titanium";
            DurationOfMining = 3200; // в днях
            LevelOfDanger = 4; // по 10-й шкале
        }
    }

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

    public class ManufacturingEnterprise : Enterprises
    {
        [Info("Используется локальное сырьё")]
        public boolean LocalRawMaterial;

        [Info("Работает с опасным сырьём")]
        public boolean DangerRawMaterial;

        public ManufacturingEnterprise()
        {
            LocalRawMaterial = boolean.True;
            DangerRawMaterial = boolean.False;
        }
    }

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

    public class FoodEnterprise : ManufacturingEnterprise
    {
        [Info("Продукты из мяса")]
        public boolean ProductsWithMeat;

        [Info("Продукты из молока")]
        public boolean ProductsWithMilk;

        [Info("Продукты с сахаром")]
        public boolean ProductsWithSugar;

        [Info("Продукты из муки")]
        public boolean ProductsWithFlour;

        public FoodEnterprise()
        {
            ProductsWithMeat = boolean.False;
            ProductsWithMilk = boolean.False;
            ProductsWithSugar = boolean.True;
            ProductsWithFlour = boolean.False;
        }
    }

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

    [Info("Мясоперерабатывающий завод")]
    public class MeatProcessingPlant : FoodEnterprise
    {
        [Info("Мясо добывается рядом")]
        public boolean LocalMeat;

        [Info("Количество нужного мяса ( в кг )")]
        public int NeededMeat;

        [Info("Производят ли колбасы")]
        public boolean Sausages;

        [Info("Производят ли полуфабрикаты")]
        public boolean Semis;

        [Info("Производят ли консервы")]
        public boolean CannedFood;

        public MeatProcessingPlant()
        {
            LocalMeat = boolean.True;
            NeededMeat = 1000; // в кг
            Sausages = boolean.True;
            Semis = boolean.True;
            CannedFood = boolean.False;
        }
    }

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
