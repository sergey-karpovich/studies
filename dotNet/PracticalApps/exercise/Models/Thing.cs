namespace exercise.Models
{
    public class Thing
    {
        public Thing( int inner=1)
        {
            this.inner=inner;
            PrimeFactors(inner);
        }
        public int? inner{get;set;}
        public string exit{get;set;}
        public void PrimeFactors(int num)
        {            
            if(num==1)
                exit= "1";
            for(int i=2;i<=num;)
            {
                if (num %i==0)
                {
                    exit+=i+(i==num?"":"*");
                    num=num/i;
                }
                else
                {                
                    i++;
                }
            }
            exit.ToString();
        }
    }
}