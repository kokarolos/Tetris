namespace Models.Concrete
{
    public sealed class Settings
    {
        public static int RefreshRate { get => 1000 / 10; }
        public static int RespawnRate { get => 1200 / 120; }
        public static int NumOfCells { get => 100; }
        public static int CellSize { get => 10; }
    }
}
