/*********************************************************************
Purpose/Description: Implement a BST class with acompaning methods
Author’s Panther ID: 4100948
Certification:
I hereby certify that this work is my own and none of it is the work of
any other person.
********************************************************************/

package BinarySearchTree;

public class BinarySearchTree {
    
    
    private BinarySearchTreeNode root;
    

             

    public int keySum() {
        //See helper method
        return keySumHelper(root);
    }

    private int keySumHelper(BinarySearchTreeNode node) {
        //recursively traverse left and right node 
        //adding all values + root value
        int totalSum, leftSum, rightSum;
        if (node == null){
            totalSum =0;
            return totalSum;
        }
        else
        {
            leftSum = keySumHelper(node.left);
            rightSum = keySumHelper(node.right);
            
            totalSum = node.key + leftSum + rightSum;
        }
        return totalSum;
    }

    public void deleteMin() {
            //See helper method deleteMinHelper
            //Finds the parent node of the smallest node
            //Check if the smallest node has a right child
            //if it has right child set the parent left child
            //(the min value) to the min value effectively 
            //deleting smallest child
            //otherwise set smallest node to null
        
        
	        
            //Check if the root is not null
            //Check if root has right child
            //Check if the root is also the smallest value
            //if so set the the child to be the root
            //"effectively deleting the root deleting the root"
        BinarySearchTreeNode smallestNode = deleteMinHelper(root);

            if(root != null && root.right != null)
              if(root.key == smallestNode.key)
                root = root.right;
        
	//Uses findParentMethod to be able to refenrence what 
	//Will be deleted
        BinarySearchTreeNode parent = findParent(smallestNode.key);

        else if(smallestNode.right == null){
            parent.left = null;
        }else if (smallestNode.right != null){
            parent.left = smallestNode.right;
        }
        
        
            
    }

    public BinarySearchTreeNode deleteMinHelper(BinarySearchTreeNode node) {
        //While the node.left exist 
        //keep moving left until you hit a leaf
        //returns the leaf
        BinarySearchTreeNode current = node;
        while (current.left != null) {
            current = current.left;
        }
        return current;
    }
    
    public void printTree() {
        printTreeHelper(root);
    }

    private void printTreeHelper(BinarySearchTreeNode root) {
        if (root != null) {
            //Uses INorder to traverser left subtree
            //Visits the roots than traverse right subtree  
            printTreeHelper(root.left);
            System.out.print(root.key + " ");
            printTreeHelper(root.right);
        }
    }

    public void postOrder() {
        //see helper method
        postOrderHelper(root);
    }

    private void postOrderHelper(BinarySearchTreeNode root) {
        if (root != null) {
            //Uses PostOrder to traverser left subtree
            // than traverse right subtree
            //than visit root. Left-Right-Root
            postOrderHelper(root.left);
            postOrderHelper(root.right);
            System.out.print(root.key + " ");
        }
    }
    
    public BinarySearchTreeNode findParent(int key)
    {
        return findParentHelper(root, null, key);
    }
    
    private BinarySearchTreeNode 
        findParentHelper(BinarySearchTreeNode node, BinarySearchTreeNode parent, int key)
        {
            if(node == null){
                return null;
            }else if( node.key != key)
            {
                parent = findParentHelper(node.left, node, key);
                if( parent == null)
                {
                    parent = findParentHelper(node.right, node, key);
                }
            }
            return parent;
        }

   
    //INTERNAL NODE CLASS W/O METHODS
    
    private class BinarySearchTreeNode {

        public int key;
        public BinarySearchTreeNode left;
        public BinarySearchTreeNode right;
        

        
    }//Node class ends

    
}
