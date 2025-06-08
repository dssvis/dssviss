using NUnit.Framework;
using Task13;

namespace Task13.UnitTests
{
    [TestFixture]
    public class EditionUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var edition = CreateTestEdition();

            Assert.That(edition.Title, Is.EqualTo("Война и мир"));
            Assert.That(edition.Authors, Is.EqualTo("Лев Толстой"));
            Assert.That(edition.Year, Is.EqualTo(1869));
            Assert.That(edition.Publisher, Is.EqualTo("Альпа"));
            Assert.That(edition.InventoryNumber, Is.EqualTo(100));
            Assert.That(edition.Status, Is.EqualTo(EditionStatus.AtHome));
            Assert.That(edition.Price, Is.EqualTo(299.99f));
        }

        [Test]
        public void GetInfoTest()
        {
            var edition = CreateTestEdition();
            var info = edition.GetInfo();

            Assert.That(info.Length, Is.EqualTo(7));
            Assert.That(info[0], Is.EqualTo("Название: Война и мир"));
            Assert.That(info[1], Is.EqualTo("Авторы: Лев Толстой"));
            Assert.That(info[2], Is.EqualTo("Год издания: 1869"));
            Assert.That(info[3], Is.EqualTo("Издательство: Альпа"));
            Assert.That(info[4], Is.EqualTo("Инвентарный номер: 100"));
            Assert.That(info[5], Is.EqualTo("Статус: на руках"));
            Assert.That(info[6], Is.EqualTo("Цена: 299,99"));
        }

        private Edition CreateTestEdition()
        {
            return new Edition(
                "Война и мир",
                "Лев Толстой",
                1869,
                "Альпа",
                100,
                EditionStatus.AtHome,
                299.99f
            );
        }
    }
}