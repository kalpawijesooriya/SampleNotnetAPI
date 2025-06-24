using System;
namespace OnlineStore.Api.Services
{
	public class Myservice : IMyservice
    {
        int number = 0;
		public Myservice()
		{
		
        }

        public int IncreseByOne()
        {
            return number++;
        }
    }
}

