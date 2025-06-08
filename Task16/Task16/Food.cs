namespace Task16
{
    public struct Food
    {

        int weight;
        public int Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть положительным");

                weight = value;
            }
        }

        double calorie;
        public double Calorie
        {
            get => calorie;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть положительным");

                calorie = Math.Round(value,1) ;
            }
        }

        public double Value => Weight * Calorie / 100;

        public Food(int weight, double calorie) : this()
        {
            Weight = weight;
            Calorie = calorie;
        }

        public override string ToString() => $"{Weight} г калорийности {Calorie} Ккал/100 г";

        public override bool Equals(object obj)
        {
            if (obj is Food)
                return (Weight == ((Food)obj).Weight)&&(Calorie == ((Food)obj).Calorie);

            throw new ArgumentException("Объект для сравнения не является продуктом питания");
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Food x, Food y) => x.Equals(y);
        public static bool operator !=(Food x, Food y) => !x.Equals(y);
        public static Food operator +(Food x, Food y)
        {
            if (!x.Calorie.Equals(y.Calorie))
                throw new InvalidOperationException("Нельзя складывать продукты с разной калорийностью");

            return new Food(x.Weight + y.Weight, x.Calorie);
        }
        public static Food operator -(Food x, Food y)
        {
            if (!x.Calorie.Equals(y.Calorie))
                throw new InvalidOperationException("Нельзя вычитать продукты с разной калорийностью");
            
            if (x.Weight <= y.Weight)
                throw new InvalidOperationException("Вес уменьшаемого продукта должен быть больше");

            return new Food(x.Weight - y.Weight, x.Calorie);
        }

    }
}
