using System.Collections.Generic;
using Services;

namespace Card
{
    public class TrueKeyGenerator : ITrueKeyGenerator
    {
        private readonly ITrueKeysRemindService _keysRemindService;
        public string TrueKey { get; private set; }

        public TrueKeyGenerator(ITrueKeysRemindService keysRemindService) =>
            _keysRemindService = keysRemindService;

        public void Generate(List<string> keys)
        {
            var tempKeys = new List<string>();

            foreach (var key in keys)
            {
                tempKeys.Add(key);
            }

            for (int i = 0; i < tempKeys.Count; i++)
            {
                var currentKey = tempKeys[i];

                if (_keysRemindService.GetChosenKeys().Contains(currentKey))
                {
                    tempKeys.Remove(currentKey);
                    continue;
                }

                TrueKey = currentKey;
            }

            _keysRemindService.Add(TrueKey);
        }
    }
}