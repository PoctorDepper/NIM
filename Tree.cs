namespace NIM;

public class Tree(int player, List<int> piles)
{
    /// <summary>
    /// The root node for this <c>Tree</c> object.
    /// </summary>
    public Node Root { get; } = new(player, piles);

    /// <summary>
    /// Determines the best move based off of the highest minimax value.
    /// </summary>
    /// <returns>the pile to take from, the amount to take</returns>
    public (int, int) GetBestMove()
    {
        Root.Children.Sort((a, b) => a.MinimaxScore > b.MinimaxScore ? -1 : 1);
        var bestMove = Root.Children[0];

        for (int pile = 0; pile < Root.Piles.Count; pile++)
        {
            if (Root.Piles[pile] == bestMove.Piles[pile]) continue;
            return (pile, Root.Piles[pile] - bestMove.Piles[pile]);
        }

        return (-1, -1);
    }
}

public class Node
{
    /// <summary>
    /// The player in which this node is for.
    /// </summary>
    public int Player { get; init; }

    /// <summary>
    /// The current state of the piles.
    /// </summary>
    public List<int> Piles { get; init; }

    /// <summary>
    /// The likelihood of this <c>Player</c> to win.
    /// </summary>
    /// <value>Positive for this <c>Player</c>, negative for the opponent.</value>
    public int MinimaxScore { get; init; }

    /// <summary>
    /// This node's children nodes. Should represent possible moves.
    /// </summary>
    public List<Node> Children { get; private set; } = [];

    /// <summary>
    /// Constructs a node and all of it's children until all piles are empty
    /// </summary>
    /// <param name="player">The player this node is for</param>
    /// <param name="piles"></param>
    public Node(int player, List<int> piles)
    {
        Player = player;
        Piles = new List<int>(piles);

        // Creates a scenario for each pile and each possible amount to take.
        for (int pile = 0; pile < Piles.Count; pile++)
        {
            if(Piles[pile] <= 0) continue;

            for (int amount = 1; amount <= Piles[pile]; amount++)
            {
                var copyPiles = new List<int>(Piles);
                copyPiles[pile] -= amount;
                AddChild((player + 1) % 2, copyPiles);
            }
        }

        // Basically, I just hard set COM to 1 (the second player)
        if (piles.All(i => i == 0))
        {
            // If all piles are zero, and it's COM's turn, they have lost, resulting in -1
            MinimaxScore = player == 1 ? -1 : 1;
        }
        else
        {
            MinimaxScore = Children.Sum(c => c.MinimaxScore);
        }
    }

    /// <summary>
    /// Adds a child to this node using a node.
    /// </summary>
    /// <param name="node">The node to add</param>
    public void AddChild(Node node)
    {
        Children.Add(node);
    }

    /// <summary>
    /// Adds a child to this node using a board state.
    /// </summary>
    /// <param name="player">The player this node is for (required for accurate minimax values)</param>
    /// <param name="piles">The pile state of the board</param>
    public void AddChild(int player, List<int> piles)
    {
        AddChild(new Node(player, piles));
    }
}