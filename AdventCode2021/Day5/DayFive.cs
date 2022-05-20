namespace AdventCode2021.Day5 {
    class DayFive {
        static void Main(string[] args) {

            Points points = new Points(@"C:\Users\nrt\source\repos\AdventCode2021\AdventCode2021\resources\input5.txt");
            points.ProcessPoints();

            Console.WriteLine(points.CountIntersections());

        }
    }
}