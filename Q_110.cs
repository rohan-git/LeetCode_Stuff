/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{    
    public bool IsBalanced(TreeNode root) 
    {                
        if(root == null) return true;
        
        int level = 0;
        return (Math.Abs(height(root.left, level) - height(root.right, level)) < 2) && IsBalanced(root.left) && IsBalanced(root.right);
        
    }
    
    public int height(TreeNode root,int level)
    {
        if(root == null) return 0;
        
        int leftHeight = height(root.left, level + 1); // dfs style, keep going left
        int rightHeight = height(root.right, level + 1); // keep going right
        
        //Console.WriteLine("level:: " + leftHeight);
        //Console.WriteLine("left: " + leftHeight);
        //Console.WriteLine("right: " + rightHeight);
        
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
}