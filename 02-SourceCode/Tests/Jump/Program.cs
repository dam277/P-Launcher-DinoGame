using Jump;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        Game game = new Game();
        game.PlaceBall();
        game.Play();

        Console.ReadLine();
    }
}
