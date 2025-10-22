namespace NIM;

public class GameBoard
{
    public int[] Piles { get; private set; }

    public GameBoard(int pileCount, int pileSize)
    {
        Piles = new int[pileCount];
        for (int pile = 0; pile < pileCount; ++pile)
        {
            Piles[pile] = pileSize;
        }
    }

    public bool PlayMove(int pile, int amount)
    {
        if (pile >= Piles.Length || amount > Piles[pile]) return false;
        Piles[pile] -= amount;
        return true;
    }

    override public string ToString()
    {
        string result = "";

        for (var pile = 0; pile < Piles.Length; ++pile)
        {
            result += $"{pile}: {Piles[pile]}\n";
        }

        return result;
    }
}