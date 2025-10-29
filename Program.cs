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

// Query for human opponent
bool humanOpponent = true;
string humanOpponentResponse;
do
{
    Console.Write("2P Game? (Y/N)");
    humanOpponentResponse = Console.ReadLine()!.ToUpper();
} while (!(humanOpponentResponse.Equals("Y") || humanOpponentResponse.Equals("N")));
if (humanOpponentResponse.Equals("N")) humanOpponent = false;

// Begin play
int player = -1;
while (!board.IsEmpty)
{
    player = ++player % 2;

    // Take human input (i.e. require console input)
    if (player == 0 || humanOpponent)
    {
        Console.WriteLine(board.ToString());
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
        Console.WriteLine();

        continue;
    }

    // Implement the AI and the minimax algorithm, as per specification
    // Minimax is surprisingly slow, as time complexity is O(piles ^ pile size)
    Tree npcTree = new Tree(1, board.Piles);
    var bestMove = npcTree.GetBestMove();
    board.PlayMove(bestMove.Item1, bestMove.Item2);

    // Optional TODO implement using NimSum

    // Display what move the AI took
    Console.WriteLine($"The COM took {bestMove.Item2} from pile {bestMove.Item2}!\n");
}

// Output who won.
Console.WriteLine();
Console.WriteLine(humanOpponent ? $"Congratulations Player {player + 1}! You have won!" :
    player == 0 ? "You have won!" : "You have lost!");

return 0;