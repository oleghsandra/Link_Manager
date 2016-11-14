using System;
using LinkManager.Common.Entities;

namespace LinkManager.UI.Models
{
    public class LinkModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int OwnerId { get; set; }
        public bool IsFavorite { get; set; }
        public LinkTypeModel Type { get; set; }
        public DateTime CreationDateString { get; set; }

        public static explicit operator LinkEntity(LinkModel linkModel)
        {
            return new LinkEntity()
            {
                Id = linkModel.Id,
                Title = linkModel.Title,
                Url = linkModel.Url,
                OwnerId = linkModel.OwnerId,
                IsFavorite = linkModel.IsFavorite,
                Type = (LinkTypeEntity)linkModel.Type
            };
        }

        public static explicit operator LinkModel(LinkEntity linkEntity)
        {
            return new LinkModel()
            {
                Id = linkEntity.Id,
                Title = linkEntity.Title,
                Url = linkEntity.Url,
                OwnerId = linkEntity.OwnerId,
                IsFavorite = linkEntity.IsFavorite,
                Type = (LinkTypeModel)linkEntity.Type
            };
        }
    }
}