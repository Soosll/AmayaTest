using System.Collections.Generic;

namespace Services
{
    public class TrueKeysRemindService : ITrueKeysRemindService
    {
        private List<string> _chosenTrueKeys = new List<string>();

        public void Add(string key) => 
            _chosenTrueKeys.Add(key);

        public List<string> GetChosenKeys() => 
            _chosenTrueKeys;

        public void Clear() => 
            _chosenTrueKeys.Clear();
    }
}