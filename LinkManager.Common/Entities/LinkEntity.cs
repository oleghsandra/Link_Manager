using System;

namespace LinkManager.Common.Entities
{
    public class LinkEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int OwnerId { get; set; }

        public bool IsFavorite { get; set; }

        public DateTime? CreationDate { get; set; }

        public LinkTypeEntity Type { get; set; }
    }
}
