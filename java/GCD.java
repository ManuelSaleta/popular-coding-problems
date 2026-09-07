public class GCD
{
  public static int findGCD(int x,int y)
  {
    if( y == 0)
      return x;
    else
      return findGCD(y, x % y);
  }


  public static void main(String[] args)
  {
    System.out.println(findGCD(10,5));

    System.out.println(hash("100",10));
  }
}
