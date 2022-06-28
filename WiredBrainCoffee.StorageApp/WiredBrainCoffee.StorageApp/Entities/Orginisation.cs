namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Orginisation : EntityBase
    {
        public string? Name { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
