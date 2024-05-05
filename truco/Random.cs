namespace RandomNS
{
    public static class RandomHelper
    {
        private static Random random = new Random();

        public static int GetRandomIndex(int maxValue)
        {
            lock(random) // Asegura que el acceso al generador de números aleatorios sea seguro en entornos multiproceso
            {
                return random.Next(0, maxValue);
            }
        }
    }
}
