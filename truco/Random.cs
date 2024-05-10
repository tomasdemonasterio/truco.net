namespace RandomNS
{
    /// <summary>
    /// Provides helper methods for generating random numbers.
    /// </summary>
    public static class RandomHelper
    {
        private static Random Random { get; } = new();

        /// <summary>
        /// Generates a random index between 0 (inclusive) and the specified maximum value (exclusive).
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random index to generate.</param>
        /// <returns>A random index between 0 (inclusive) and <paramref name="maxValue"/> (exclusive).</returns>
        public static int GetRandomIndex(int maxValue)
        {
            lock (Random) // Ensures thread-safe access to the random number generator in multi-threaded environments
            {
                return Random.Next(0, maxValue);
            }
        }
    }
}
