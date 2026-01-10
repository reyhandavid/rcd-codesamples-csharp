namespace CleanCode.Naming.Bad
{
    /// <summary>
    /// BAD EXAMPLE: Poor naming makes code hard to understand
    /// </summary>
    public class NamingBad
    {
        // Bad: Single letter variable names
        private int d; // What is 'd'? Days? Distance? Data?
        private string s;
        
        // Bad: Non-descriptive names
        private List<string> list1;
        private int temp;
        private string data;
        
        // Bad: Abbreviations that aren't clear
        private int nbr;
        private string msg;
        private DateTime dt;
        
        // Bad: Hungarian notation (type in name)
        private string strName;
        private int intAge;
        
        // Bad: Noise words that don't add meaning
        public class ProductInfo { }
        public class ProductData { }
        
        // Bad: Not pronounceable
        private DateTime genymdhms; // generation year month day hour minute second
        
        // Bad: Method names that don't describe what they do
        public void DoIt(int x, int y)
        {
            // What does this do?
            var z = x + y;
        }
        
        // Bad: Magic numbers
        public bool CheckStatus(int s)
        {
            if (s == 5) // What is 5?
            {
                return true;
            }
            return false;
        }
        
        // Bad: Ambiguous boolean names
        public bool flag;
        public bool check;
        
        // Bad: Similar names that are hard to distinguish
        public void ProcessData(string data) { }
        public void ProcessDatas(string datas) { }
        public void ProcessData2(string data) { }
        
        // Bad: Inconsistent naming
        public void GetUser() { }
        public void FetchCustomer() { }
        public void RetrieveOrder() { }
        
        // All do the same thing but use different verbs!
    }
}
