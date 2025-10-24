// Top-level entry point

using NIM;


// Initialize the board
int piles, pileSize;
do
{
    Console.Write("Enter a number of piles: ");
} while (!int.TryParse(Console.ReadLine(), out piles) || piles <= 0);

do
{
    Console.Write("Enter a pile size: ");
} while (!int.TryParse(Console.ReadLine(), out pileSize) || pileSize <= 0);

GameBoard board = new(piles, pileSize);

//Query for human opponent
bool humanOpponent = true;
string? humanOpponentString = "";
while(!humanOpponentString.ToUpper().Equals("Y") && !humanOpponentString.ToUpper().Equals("N"))
{
    Console.Write("2P Game? (Y/N)");
    humanOpponentString = Console.ReadLine();
}
humanOpponent = humanOpponentString.ToUpper() == "Y";


// Begin play
int player = -1;
while (!board.IsEmpty)
{
    Console.WriteLine(board.ToString());
    Console.WriteLine(board.GetNimSum());
    player = ++player % 2;

    // Take human input (i.e. require console input)
    if (player == 0 || humanOpponent)
    {
        Console.WriteLine($"Your turn, Player {player + 1}!");

        int pile, amount;
        do
        {
            do
            {
                Console.Write("Choose a pile: ");
            } while (!int.TryParse(Console.ReadLine(), out pile));

            do
            {
                Console.Write("Choose an amount to remove: ");
            } while (!int.TryParse(Console.ReadLine(), out amount));
        } while (!board.PlayMove(pile, amount));

        continue;
    }

    // TODO implement the AI and the minimax algorithm
    // TODO display what move the AI took
}

// Output who won.
Console.WriteLine();
Console.WriteLine(humanOpponent ? $"Congratulations Player {player + 1}! You have won!" :
    player == 0 ? "You have won!" : "You have lost!");

return 0;