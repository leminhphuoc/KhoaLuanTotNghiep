using Models.Model.Enum;

namespace Models.Model
{
    public class SearchItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public SearchItemType Type { get; set; }
    }
}
