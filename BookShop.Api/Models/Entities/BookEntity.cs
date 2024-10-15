namespace BookShop.Api.Models.Entities
{
    public class BookEntity
    {
        public const int TITLE_LENGTH_MIN = 3;
        public const int TITLE_LENGTH_MAX = 50;
        public const int DESCRIPTION_LENGTH_MIN = 0;
        public const int DESCRIPTION_LENGTH_MAX = 250;

        public Guid? Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

        public BookEntity(Guid? id, string title, string description, int price)
        {
            if (title.Length < TITLE_LENGTH_MIN || title.Length > TITLE_LENGTH_MAX)
            {
                throw new Exception($"Book title length is not in range [{TITLE_LENGTH_MIN}, {TITLE_LENGTH_MAX}]");
            }

            if (description.Length < DESCRIPTION_LENGTH_MIN || description.Length > DESCRIPTION_LENGTH_MAX)
            {
                throw new Exception($"Book description length is not in range [{DESCRIPTION_LENGTH_MIN}, {DESCRIPTION_LENGTH_MAX}]");
            }

            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
    }
}
