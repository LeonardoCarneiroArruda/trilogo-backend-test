using System;

namespace Domain
{
    public class Ticket : DomainBase
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
    }
}
