namespace RealEstate.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string BannerImage { get; set; }
        public string OverviewTitle { get; set; }
        public string Description { get; set; }
        public string OverviewImage { get; set; }
        public string Youtube { get; set; }
        public string MasterTitle { get; set; }
        public string MasterDescription { get; set; }
        public string AmentiesTitle { get; set; }
        public string AmentiesDescription { get; set; }
        public string SpecificationsTitle { get; set; }
        public string SpecificationsDescription { get; set; }
        public string LocationHighlightsTitle { get; set; }
        public string LocationHighlightsDescription { get; set; }
        public string OtherDetails { get; set; }
        public string AppId { get; set; }
    }
}
