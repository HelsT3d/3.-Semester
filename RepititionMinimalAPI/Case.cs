namespace RepititionMinimalAPI
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationFound { get; set; }
        public DateOnly DateFound { get; set; }
        public bool IsClaimed { get; set; }

    }
}
