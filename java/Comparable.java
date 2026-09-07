public class Comparable
{
    public static Comparable comparableFindMax(Comparable[] arr)
    {
      int maxIndex = 0;
      for (int i =0; i < arr.length; i++)
          if(arr[i].compareTo(arr[maxIndex]) > 0)
              maxIndex =i;
      return arr[maxIndex];
    }




    public static <AnyType extends Comparable <! super AnyType>>
                  void inserstion(AnyType[] arr)
                  {
                    int j;
                    for (int p =1; p < arr.length; p++)
                    {
                      AnyType temp = arr[p];
                      for(j = p; j > 0; j--)
                        if (temp.compareTo(arr[ j -1]) > 0)
                          break;
                        else
                          arr[j] = arr[j -1];
                      a[j] = temp;
                    }
                  }
}
