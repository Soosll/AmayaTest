using System.Collections.Generic;

namespace Card
{
    public interface ITrueKeyGenerator
    {
        public string TrueKey { get; }
        public void Generate(List<string> keys);
    }
}