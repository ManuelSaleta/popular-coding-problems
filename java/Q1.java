/*********************************************************************
Purpose/Description: Create an algorithm that will use a key value to determine
                     the last remainder value in a collection.
Author’s Panther ID: 4100948
Certification:
I hereby certify that this work is my own and none of it is the work of
any other person.
********************************************************************/

public class  Q1
{
  //T(N) = N-1 because you visit every element minus the survivor
  //complexity is O(N)

  public static int lastMan(int[] arr, int len, int key)
  {
    if(len == 1)//If population is one return that element
      return arr[0];
    else
      //Use modulo to "circulate around" the array
      //decreases the len by every visited element
      //Where every visited element is considered "dead"
      return arr[((key -1 + lastMan(arr,len -1, key)) % len)];
  }

   public static void main(String[] args) {

    int[] arr = {1,2,3,4,5};
    int n = 5;
    int k = 2;

    System.out.println(lastMan(arr,n,k));
  }
}
