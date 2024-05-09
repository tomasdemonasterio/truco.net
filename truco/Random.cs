namespace RandomNS
{
    public static class RandomHelper
    {
        private static Random Random { get; } = new();

        public static int GetRandomIndex(int maxValue)
        {
            lock (Random) // Asegura que el acceso al generador de números aleatorios sea seguro en entornos multiproceso
            {
                return Random.Next(0, maxValue);
            }
        }
    }
}
