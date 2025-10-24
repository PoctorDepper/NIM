namespace NIM;

public class TreeNode(int player, List<int> piles)
{
    /// <summary>
    /// The player in which this node is for.
    /// </summary>
    public int Player { get; set; } = player; // im thinking it will be 1 or 2 for players 3 for ai

    /// <summary>
    /// The current state of the piles.
    /// </summary>
    public List<int> Piles { get; set; } = piles; // Current state of piles. So this should be a copy not a reference

    /// <summary>
    /// The likelihood of this <c>Player</c> to win.
    /// </summary>
    /// <value>Positive for this <c>Player</c>, negative for the opponent.</value>
    public int MinimaxScore { get; set; }

    /// <summary>
    /// This node's children nodes.
    /// </summary>
    public List<TreeNode> Children { get; private set; } = [];
}