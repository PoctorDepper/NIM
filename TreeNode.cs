namespace NIM;

public class Node
{
    public int player = 1; //im thinking it will be 1 or 2 for players 3 for ai
    public List<Node> children;
    public int[] piles;
    
    public Node(int player, int[] piles)
    {
        this.player = player; //update player for this node should change per node
        this.piles = piles; //current state of piles. So this should be a copy not a reference
        children = new List<Node>();
    }
}

public class Tree
{
    public static void addChild(Node parent, Node child)
    {
        parent.children.Add(child);
    }
}