namespace Services
{
    public class CompleteLevelsCalculateService : ICompleteLevelsCalculateService
    {
        private int _completeLevelsAmount;

        public void IncreaseAmount() => 
            _completeLevelsAmount++;

        public int GetAmount() => 
            _completeLevelsAmount;

        public void Clear() => 
            _completeLevelsAmount = 0;
    }
}