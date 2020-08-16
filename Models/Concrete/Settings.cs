namespace Models.Concrete
{
    public sealed class Settings
    {
        public static int RefreshRate { get => 15000; }
        public static int RespawnRate { get => 1000; }
        public static int NumOfCells { get => 100; }
        public static int CellSize { get => 25; }
        public static int Speed { get => 1500; }
        public static int ShapeWidth { get => 25; }
        public static int ShapeHeight { get => 25; }
    }
}
