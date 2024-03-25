using System.Collections.Generic;

namespace Services
{
    public interface ITrueKeysRemindService
    {
        public void Add(string key);
        public List<string> GetChosenKeys();
        public void Clear();
    }
}