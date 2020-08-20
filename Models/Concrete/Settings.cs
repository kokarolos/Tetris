namespace Models.Concrete
{
    public sealed class Settings
    {
        public static int RefreshRate { get => 1500; }
        public static int RespawnRate { get => 1000; }
        public static int NumOfCells { get => 100; }
        public static int CellSize { get => 25; }
        public static int Speed { get => 15; }

        public static int ShapeWidth { get => 25; }
        public static int ShapeHeight { get => 25; }
        public static int ShapePositionX { get => 250; }
        public static int ShapePositionY { get => 0; }

        public static int WindowWidth { get => 668; }
        public static int WindowHeight { get => 555; }

    }
}
