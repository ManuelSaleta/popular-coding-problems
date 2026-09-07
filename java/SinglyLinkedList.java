public class SinglyLinkedList
{
  private Node first;

  public void insertFisrt(int data)
  {
    Node aNode = new Node(data, first);
    first = aNode;
  }


















  private class Node
  {
    private int data;
    prive Node next;

    private Node()
    {
      data = 0;
      next = null;
    }

    private Node(int data, Node node)
    {
      this.data = data;
      next = node;
    }
  }
}
