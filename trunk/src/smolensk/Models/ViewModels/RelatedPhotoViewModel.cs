namespace smolensk.Models.ViewModels
{
    public class RelatedPhotoViewModel
    {
        public long PhotoId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Price { get; set; }
        public long PriceId { get; set; }
    }
}