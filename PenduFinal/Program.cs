namespace Pendu
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.Load();
            myGame.Update();
        }
    }
}
