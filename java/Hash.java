public class Hash{
  public static int hash(String key, int tableSize)
  {
    int hashVal =0;
    for(int i =0; i < key.lenth(); i++)
    {
        hashVal += key.CharAt(i);
    }

    return hashVal % tableSize;
  }

  public static void main(String[] args)
  {
    System.out.println(hash("10",10));
  }
}
