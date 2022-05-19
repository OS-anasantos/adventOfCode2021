namespace AdventCode2021 {
    class DayFour {
        static void Main(string[] args) {

            Bingo bingo = new Bingo(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021\resources\input4.txt");

            int res = bingo.LastBingo();
            Console.WriteLine(res);
        }
    }
}