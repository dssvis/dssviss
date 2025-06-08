using System;

namespace Task13
{
    public class Edition
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public readonly int InventoryNumber;
        public EditionStatus Status { get; set; }
        public float Price { get; set; }

        public Edition(string title, string authors, int year, string publisher, int inventoryNumber, EditionStatus status, float price)
        {
            Title = title;
            Authors = authors;
            Year = year;
            Publisher = publisher;
            InventoryNumber = inventoryNumber;
            Status = status;
            Price = price;
        }

        public virtual string[] GetInfo()
        {
            return new string[]
            {
                $"Название: {Title}",
                $"Авторы: {Authors}",
                $"Год издания: {Year}",
                $"Издательство: {Publisher}",
                $"Инвентарный номер: {InventoryNumber}",
                $"Статус: {GetStatusName()}",
                $"Цена: {Price}"
            };
        }

        private string GetStatusName()
        {
            if (Status == EditionStatus.InStorage)
            {
                return "в хранилище";
            }
            else if (Status == EditionStatus.ReadingRoom)
            {
                return "в читальном зале";
            }
            else if (Status == EditionStatus.AtHome)
            {
                return "на руках";
            }
            else
            {
                return "неизвестно";
            }
        }
    }
}
