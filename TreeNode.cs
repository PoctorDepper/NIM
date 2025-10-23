namespace NIM;

public class TreeNode
{
    public int player = 1; //im thinking it will be 1 or 2 for players 3 for ai
    public List<TreeNode> children;
    public int[] piles;

    public TreeNode(int player, int[] piles)
    {
        this.player = player; //update player for this node should change per node
        this.piles = piles; //current state of piles. So this should be a copy not a reference
        children = new List<TreeNode>();
    }
}