namespace NIM;

public class GameBoard(int pileCount, int pileSize)
{
    /// <summary>
    /// The state of the piles in the game at the current moment.
    /// </summary>
    public List<int> Piles { get; } = Enumerable.Repeat(pileSize, pileCount).ToList();

    /// <summary>
    /// A property tracking the emptiness of piles on the board.
    /// </summary>
    /// <returns><c>true</c> when all the piles are empty on the board, signifying a win condition.</returns>
    public bool IsEmpty => Piles.All(pile => pile == 0);

    /// <summary>
    /// Plays a move on the current board, regardless of the player who played it.
    /// </summary>
    /// <param name="pile">Which pile to pick from.</param>
    /// <param name="amount">How much to pick off of the selected pile.</param>
    /// <returns><c>true</c> if the move was valid.</returns>
    public bool PlayMove(int pile, int amount)
    {
        if (pile < 0 || pile >= Piles.Count || amount > Piles[pile] || amount < 1) return false;
        Piles[pile] -= amount;
        return true;
    }

    public int GetNimSum()
    {
        int nimsum = 0;
        foreach(int i in Piles)
        {
            nimsum = nimsum ^ i;
        }
        return nimsum;
    }

    /// <summary>
    /// Displays the game board as rows of piles with the value of that pile to the right of the index.
    /// </summary>
    /// <returns>The formatted string.</returns>
    public override string ToString()
    {
        string result = "";

        for (var pile = 0; pile < Piles.Count; ++pile)
        {
            result += $"{pile}: {Piles[pile]}\n";
        }

        return result;
    }
}