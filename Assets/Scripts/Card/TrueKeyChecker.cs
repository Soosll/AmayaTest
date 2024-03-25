namespace Card
{
    public class TrueKeyChecker
    {
        private readonly ITrueKeyGenerator _keyGenerator;

        public TrueKeyChecker(ITrueKeyGenerator keyGenerator) => 
            _keyGenerator = keyGenerator;

        public bool Check(string value) => 
            _keyGenerator.TrueKey == value;
    }
}