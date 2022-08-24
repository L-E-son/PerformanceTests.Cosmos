using System;

namespace PerformanceTests.Cosmos
{
    public static class FixedSizeStringGenerator
    {
        private static readonly Random _random = new Random();

        public static string GetStringOfSize(int sizeInBytes)
        {
            Span<char> span = new char[sizeInBytes];

            for (var i = 0; i < sizeInBytes; i++)
            {
                span[i] = GetRandomOneByteCharacter();
            }

            return new string(span);
        }

        private static char GetRandomOneByteCharacter()
        {
            // Return an semi-random ASCII character
            return (char)_random.Next(33, 126);
        }
    }
}
