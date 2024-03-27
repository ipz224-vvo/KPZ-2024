namespace lab_1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Money? Price { get; set; }
        public double OccupiedCapacity { get; set; }
        public double Weight { get; set; }
        public string? Unit { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public DateTime DateOfEntry { get; set; }
    }
}
