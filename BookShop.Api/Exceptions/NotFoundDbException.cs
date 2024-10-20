namespace BookShop.Api.Exceptions
{
    public class NotFoundDbException : Exception
    {
        public NotFoundDbException() : base()
        {
        }

        public NotFoundDbException(string? message) : base(message)
        {
        }

        public NotFoundDbException(string? message, Exception? innerException) : base(message, innerException)
        {            
        }
    }
}
