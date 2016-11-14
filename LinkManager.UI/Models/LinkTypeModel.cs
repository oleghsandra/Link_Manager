using LinkManager.Common.Entities;

namespace LinkManager.UI.Models
{
    public class LinkTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator LinkTypeEntity(LinkTypeModel linkTypeModel)
        {
            return new LinkTypeEntity()
            {
                Id = linkTypeModel.Id,
                Name = linkTypeModel.Name
            };
        }

        public static explicit operator LinkTypeModel(LinkTypeEntity linkTypeEntity)
        {
            return new LinkTypeModel()
            {
                Id = linkTypeEntity.Id,
                Name = linkTypeEntity.Name
            };
        }
    }
}