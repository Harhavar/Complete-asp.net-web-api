namespace My_Books.PublisherException
{
    [Serializable]
    public class PublisherException : Exception
    {
        public string PubisherName { get; set; }
        public PublisherException() { }

        public PublisherException(string message) : base(message)
        {

        }
        public PublisherException(string message , Exception inner) : base(message, inner)
        {

        }
        public PublisherException(string message, string   PublisherName) : this(message)
        {
            PubisherName= PublisherName;
        }

        
    }
}
