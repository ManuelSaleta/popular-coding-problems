public class Assignment_3
{
  public static void main(String[] args)
  {
    int[] in = {1,2,3,4,5,6,7,8,9,8,9};
    bucketSort(in);
  }


  /**
  Q.ONE
  Given an array on N integer numbers ( possible duplicates ) in range [1...k]
  Implement in Java an algorithm that preprocesses the input array in O(n + k)
  running time then returns how many integer numbers there are in the range
  [left...right] in O(1) running time for any given left and right  1 <= left
  <= right <= k
  **/
  public static void bucketSort(int[] unsorted)
  {
    int[] tally = new int[unsorted.length];
    String[] sorted = new String[unsorted.length];
    for(int i =0; i < unsorted.length; i++)
    {
      tally[unsorted[i]] += 1;// adds how many time an element appears in array
      //sorted[unsorted[i]] +=  unsorted[i] +", ";
    }

      for(int i =0; i < sorted.length; i++)
      {
        while(tally[i] > 0)//tally is not empty add the number to the sorted array and decrese the tally
        {
          sorted[i] += i +"";
          tally[i]--;
        }
        //System.out.print(sorted[i] + "   ");
        System.out.print(tally[i] + "   ");
      }

  }

}//class ends
