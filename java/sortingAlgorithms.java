public class sortingAlgorithms
{
  public static void main(String[] args)
  {
    int[] arr = {9,8,7,6,5,4,3,2,1,0,10};
    //int[] arr2 = arr;
    selectionSorting(arr);
    for (int i =0; i <= arr.length-1; i++)
      System.out.print(arr[i] + " ");
    System.out.println("\n");
    int[] arr2 = {9,8,7,6,5,4,3,2,1};
    mySelection(arr2);
    insertionSort(arr2);

    arr = new int[] {10,9,8,7};
    myInsertion(arr);
  }

  public static void mySelection(int[] arr)
  {
    int min;
    for (int i =0; i < arr.length -1; i++)
    {
      min  = i;
      for (int j =i +1; j < arr.length; j++)//J is one place infront of J
      {
        if (arr[min] > arr[j])
        {
          min = j;
        }
      }
      int temp = arr[i];//Gets value to be swapped
      arr[i] = arr[min];//value at index gets gets value of true min
      arr[min] = temp;// puts swapped value were old min was
    }
    for(int i =1 ; i < arr.length; i++)
      System.out.print(arr[i]);
  }
  //Create and practice different sorting techniques

  //Worst Case running time is O(N^2)
  //Best case running time O(N^2)
  //Average case running time is O(N^2)
  public static void selectionSorting(int[] unsorted)
  {
    int min;
    for (int i =0; i < unsorted.length-1; i++)
    {
      min = i;
      for (int j = i+1; j < unsorted.length; j++)
      {
        if(unsorted[j] < unsorted[min])//Min value is greater than other value
          min = j;
      }
      int temp = unsorted[i];
      unsorted[i] = unsorted[min];
      unsorted[min] = temp;
      }

  }

  public static void myInsertion(int[] arr)
  {
    int value , index;
    for (int i =1; i < arr.length; i++)
    {
      value = arr[i];// whatever value at index
      index =i;//becomes index
      while(index > 0 && arr[index -1] > value)
      {
        arr[index] = arr[index -1];//swap when b > a
        index--;//decrease counter
      }
      arr[index]= value;//put the next value and check while again
    }
    for(int i =0; i <= arr.length -1; i++)
      System.out.print(arr[i] + "");
  }

  public static void insertionSort(int[] unsorted)
  {
    //best case running O(N) -- input  is sorted
    //average and worst case O(N^2)
    int value, hole;
    for (int i =1; i < unsorted.length; i++)
    {
      value = unsorted[i];//whatever value is at i
      hole = i; //hole is index
      //while index is great than zero AND
      //and value at[index -1] is greater than value at[index]
      //b > a
      while(hole > 0 && unsorted[hole -1] > value)
      {
        // swap a, b to reflect a > b
        unsorted[hole] = unsorted[hole -1];
        hole--;
      }
        unsorted[hole] = value;
    }
    for (int i =0; i < unsorted.length; i++)
      System.out.print(unsorted[i] + " ");
  }

  // public static void shellSort(int[] unsorted)
  // {
  //   int gap = unsorted.length / 2 ;
  //   if (gap % 2 == 0)
  //     gap++;
  //   for (; gap > 0; gap = gap/2)
  //   {
  //     for (int i = gap; i < unsorted.length; i++)
  //     {
  //       Comparable temp = unsorted[i];
  //       int j = i;
  //       for (; j >= gap && temp.compareTo(unsorted[j - gap]) < 0 ; j -= gap)
  //       {
  //         unsorted[j] = unsorted[j - gap];
  //       }
  //       unsorted[j] = temp;
  //     }
  //   }
  // }
}//class ends
