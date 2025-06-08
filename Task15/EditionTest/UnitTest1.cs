using NUnit.Framework;
using Task13;
using Task14;

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
    [TestFixture]
    public class ScientificEditionTests
    {
        [Test]
        public void GetInfo_ContainsBaseAndScientificFields()
        {
            var edition = new ScientificEdition(
                "Механика", "Иванов", 2018, "Наука", 101, EditionStatus.ReadingRoom, 1500f,
                "Физика", "Учебник по основам механики"
            );

            var info = edition.GetInfo();

            Assert.That(info.Length, Is.EqualTo(9));
            Assert.That(info[7], Is.EqualTo("Область науки и техники: Физика"));
            Assert.That(info[8], Is.EqualTo("Аннотация: Учебник по основам механики"));
        }
    }

    [TestFixture]
    public class FictionEditionTests
    {
        [Test]
        public void GetInfo_ContainsFictionFields()
        {
            var edition = new FictionEdition(
                "Преступление и наказание", "Достоевский", 1866, "Русская классика", 200,
                EditionStatus.AtHome, 500f, "Роман", "Русский", "Проза"
            );

            var info = edition.GetInfo();

            Assert.That(info.Length, Is.EqualTo(10));
            Assert.That(info[7], Is.EqualTo("Жанр: Роман"));
            Assert.That(info[8], Is.EqualTo("Язык произведения: Русский"));
            Assert.That(info[9], Is.EqualTo("Вид произведения: Проза"));
        }
    }

    [TestFixture]
    public class PeriodicalEditionTests
    {
        [Test]
        public void GetInfo_ContainsPeriodicalFields()
        {
            var edition = new PeriodicalEdition(
                "Наука и жизнь", "Редакция", 2024, "Журнал", 300, EditionStatus.InStorage, 99f,
                "Ежемесячно", "Журнал"
            );

            var info = edition.GetInfo();

            Assert.That(info.Length, Is.EqualTo(9));
            Assert.That(info[7], Is.EqualTo("Период выхода: Ежемесячно"));
            Assert.That(info[8], Is.EqualTo("Вид периодики: Журнал"));
        }
    }

    [TestFixture]
    public class DepartmentTests
    {
        Department department;
        Edition[] editions;

        [SetUp]
        public void Setup()
        {
            var fiction = new FictionEdition("Война и мир", "Толстой Л.Н.", 1869, "Москва", 101,
                EditionStatus.InStorage, 1000, "Роман", "Русский", "Проза");

            var science = new ScientificEdition("Квантовая физика", "Иванов И.И., Сидоров С.С.", 2005, "Наука", 102,
                EditionStatus.ReadingRoom, 1500, "Физика", "Введение в квантовую механику");

            var periodical = new PeriodicalEdition("Наука и жизнь", "Редакция", 2023, "Журнал", 103,
                EditionStatus.InStorage, 200, "Ежемесячно", "Научно-популярный журнал");

            editions = new Edition[] { fiction, science, periodical, fiction };

            department = new Department("Общий отдел", editions);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(department.Name, Is.EqualTo("Общий отдел"));

            foreach (var edition in editions.Distinct())
            {
                var matching = department.Where(e => e == edition).ToList();
                Assert.That(matching.Count, Is.EqualTo(1), $"Duplicate entry: {edition.Title}");
            }
        }

        [Test]
        public void CountTest()
        {
            Assert.That(department.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerableTest()
        {
            var actual = department.ToList();
            var expected = editions.Distinct().ToList();

            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            foreach (var edition in expected)
                Assert.That(actual.Contains(edition));
        }
    }
}