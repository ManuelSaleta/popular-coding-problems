public class bucketSort {

    public static void main(String[] args) {
        int[] in = {9,8,7,6,5,4,3,2,1,11};
        sort(in);
        
        }

        
    public static void sort(int[] unsort)
    {
        //bucket has len  of largest num, +1 accounts for the last place
        int[] bucket = new int[max(unsort) +1];
        String[] sorted = new String[unsort.length];
        int ind = 0;
        
        for(int i =0; i < unsort.length; i++)
            bucket[unsort[i]]++; //adds +1 to bucket 
        
        for (int i=0; i < bucket.length; i++)
        {
            
            while(bucket[i] > 0)
            {
                sorted[ind] = i + " ";
                ind++;//increase index for sorted arr
                bucket[i]--;//decrease bucket
            }
        }
        //prints sorted values
        for(String val : sorted)
            System.out.print(val);
    }
    
//    public static void bucketSort(int[] unsorted) {
//        int[] nucket = new int[max(unsorted)];
//        String[] sorted = new String[max(unsorted)];
//        //ArrayList <Integer> mytally = new ArrayList<>(max(unsorted));
//        int min = min(unsorted);
//        int max = max(unsorted);
//        
//
//        for (int i = 0; i < sorted.length; i++) {
//            sorted[i] = "";//Adds empty string to replace null pointer
//            nucket[unsorted[i]] += 1;
//            
//        }//loop1
//
//        for (int i = 0; i < sorted.length; i++) {
//            //while Tally is not empty add the integer value to sorted array
//            // decrease nucket and print sorted array
//            while (nucket[i] > 0) {
//                sorted[i] += i + ", ";
//                nucket[i]--;
//            }
//            
//            System.out.print(sorted[i]);
//        }//loop2
//    }//f
    
    private static int max(int[] arr)
    {
        int max =0;
        for (int num : arr)
         if( num > max)
             max = num;
        return max;
    }
    
    private static int min(int[] arr)
    {
        int min =0;
        for (int num : arr)
         if( num <= min)
             min = num;
        return min;
    }
}
