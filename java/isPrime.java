public class isPrime
{
  public static boolean isprime(int n)
	{
		if(n % 2 == 0)
    {
      return false;
    }
      return true;
  }

    public static void main(String[] args)
      {
        System.out.println(isprime(11));
      }
}
