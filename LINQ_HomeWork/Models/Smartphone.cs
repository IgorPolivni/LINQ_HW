

namespace LINQ_HomeWork.DataClasses
{
    public class Smartphone : Product
    {
        public string Model { get; set; }
        public int MemoryCapacity { get; set; }
        public string Processor { get; set; }
        public int CoreNumber { get; set; }
        public string Color { get; set; }

        public int RAMamount { get; set; }

        public override string ToString()
        {
            return $"Модель: {Model}\nКатегория: {Category.Name}\nЦена: {Price}" +
                $"\nПроизводитель: {Producer}\nДата произведения: {dateProduction}\n" +
                $"Объем памяти: {MemoryCapacity}\nПроцессор: {Processor}\nОбъем оперативной памяти: {RAMamount}";
        }


    }


}
