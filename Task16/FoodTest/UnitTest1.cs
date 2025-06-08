using NUnit.Framework;
using System;
using Task16; 

namespace FoodStruct.UnitTests
{
    [TestFixture]
    public class FoodTests
    {
        [Test]
        public void ConstructorTest()
        {
            var food = new Food(150, 200);

            Assert.That(food.Weight, Is.EqualTo(150));
            Assert.That(food.Calorie, Is.EqualTo(200));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void WeightSet_NegativeOrZero_ThrowsArgumentException(int val)
        {
            var food = new Food();
            Assert.That(() => food.Weight = val, Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-50)]
        public void CalorieSet_NegativeOrZero_ThrowsArgumentException(double val)
        {
            var food = new Food();
            Assert.That(() => food.Calorie = val, Throws.ArgumentException);
        }

        [TestCase(100, 250.567, 250.6)]
        [TestCase(120, 135.444, 135.4)]
        public void CalorieSet_RoundsToOneDecimal(int weight, double inputCalorie, double expectedCalorie)
        {
            var food = new Food(weight, inputCalorie);
            Assert.That(food.Calorie, Is.EqualTo(expectedCalorie));
        }

        [TestCase(100, 250.0, 250.0)]
        [TestCase(150, 300.0, 450.0)]
        public void ValueTest(int weight, double calorie, double expected)
        {
            var food = new Food(weight, calorie);
            Assert.That(food.Value, Is.EqualTo(expected));
        }

        [TestCase(100, 250.0, "100 г калорийности 250  кал/100 г")]
        [TestCase(150, 123.4, "150 г калорийности 123,4  кал/100 г")]
        public void ToStringTest(int weight, double calorie, string expected)
        {
            var food = new Food(weight, calorie);
            Assert.That(food.ToString(), Is.EqualTo(expected));
        }

        [TestCase(100, 250.0, 100, 250.0, true)]
        [TestCase(150, 123.4, 150, 123.4, true)]
        [TestCase(100, 250.0, 100, 200.0, false)]
        [TestCase(120, 300.0, 100, 300.0, false)]
        public void Equals_TwoFoods_ExpectedResult(int w1, double c1, int w2, double c2, bool expected)
        {
            var f1 = new Food(w1, c1);
            var f2 = new Food(w2, c2);
            Assert.That(f1.Equals(f2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongType_ThrowsArgumentException()
        {
            var food = new Food(100, 200);
            var obj = new object();
            Assert.That(() => food.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCode_SameValue_SameHash()
        {
            var x = new Food(100, 250.0);
            var y = new Food(100, 250.0);
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new Food(100, 250.0);
            var y = new Food(100, 250.0);
            var z = new Food(120, 250.0);

            Assert.That(x == y, Is.True);
            Assert.That(x != z, Is.True);
            Assert.That(x == z, Is.False);
        }

        [Test]
        public void Addition_SameCalorie_AddsWeight()
        {
            var x = new Food(100, 250.0);
            var y = new Food(50, 250.0);
            var result = x + y;
            Assert.That(result.Weight, Is.EqualTo(150));
            Assert.That(result.Calorie, Is.EqualTo(250.0));
        }

        [Test]
        public void Addition_DifferentCalorie_ThrowsInvalidOperationException()
        {
            var x = new Food(100, 250.0);
            var y = new Food(50, 200.0);
            Assert.That(() => { var z = x + y; }, Throws.InvalidOperationException);
        }

        [Test]
        public void Subtraction_SameCalorie_SubtractsWeight()
        {
            var x = new Food(150, 250.0);
            var y = new Food(50, 250.0);
            var result = x - y;
            Assert.That(result.Weight, Is.EqualTo(100));
            Assert.That(result.Calorie, Is.EqualTo(250.0));
        }

        [Test]
        public void Subtraction_DifferentCalorie_ThrowsInvalidOperationException()
        {
            var x = new Food(150, 250.0);
            var y = new Food(50, 200.0);
            Assert.That(() => { var z = x - y; }, Throws.InvalidOperationException);
        }

        [Test]
        public void Subtraction_TooMuchWeight_ThrowsInvalidOperationException()
        {
            var x = new Food(50, 250.0);
            var y = new Food(60, 250.0);
            Assert.That(() => { var z = x - y; }, Throws.InvalidOperationException);
        }
    }
}
