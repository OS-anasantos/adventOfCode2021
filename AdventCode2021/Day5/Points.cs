using System.Collections;

namespace AdventCode2021.Day5 {
    public class Points {

        String[] FileInput;
        int MaxX = 0;
        int MaxY = 0;

        public Dictionary<String, int> Map { get; }

        private delegate Boolean LineDelagate(int s1, int s2);

        public Points(String path) {
            FileInput = File.ReadAllLines(path);
            Map = new Dictionary<String, int>();
        }

        /// <summary>
        /// Adds all points in the file input
        /// </summary>
        public void ProcessPoints() {

            foreach (String line in FileInput) {
                String[] coords = line.Split(" -> ");

                int[] x1y1 = ConvertToInt(coords[0]);
                int[] x2y2 = ConvertToInt(coords[1]);

                int xMax = Math.Max(x1y1[0], x2y2[0]);
                if (xMax > MaxX) {
                    MaxX = xMax;
                }

                int yMax = Math.Max(x1y1[1], x2y2[1]);
                if (yMax > MaxY) {
                    MaxY = yMax;
                }

                if (IsLineHorizontalOrVertical(x1y1, x2y2)) {
                    AddLinePoints(x1y1, x2y2);
                } else {
                    AddDiagonalPoints(x1y1, x2y2);
                }

            }

        }

        /// <summary>
        /// Adds points associated with a diagonal line
        /// </summary>
        /// <param name="x1y1">Initial point</param>
        /// <param name="x2y2">End point</param>
        public void AddDiagonalPoints(int[] x1y1, int[] x2y2) {

            int x1 = x1y1[0];
            int y1 = x1y1[1];
            int x2 = x2y2[0];
            int y2 = x2y2[1];

            String point;
            if (x1 == y1 && x2 == y2) {
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++) {
                    point = $"{x},{x}";
                    AddToMap(point);
                }

            } else if (x1 <= x2 && y1 >= y2) {
                for (int x = x1, y = y1; x <= x2; x++, y--) {
                    point = $"{x},{y}";
                    AddToMap(point);
                }
            } else if (x1 <= x2 && y1 <= y2){
                for (int x = x1, y = y1; x <= x2; x++, y++) {
                    point = $"{x},{y}";
                    AddToMap(point);
                }
            } else if (x1 >= x2 && y1 <= y2) {
                for (int x = x1, y = y1; x >= x2; x--, y++) {
                    point = $"{x},{y}";
                    AddToMap(point);
                }
            } else {
                for (int x = x1, y = y1; x >= x2; x--, y--) {
                    point = $"{x},{y}";
                    AddToMap(point);
                }
            }
            
        }

        /// <summary>
        /// Adds all the points associated with the line
        /// </summary>
        public void AddLinePoints(int[] x1y1, int[] x2y2) {

            if (x1y1[0] == x2y2[0]) {
                for (int i = Math.Min(x1y1[1], x2y2[1]); i <= Math.Max(x1y1[1], x2y2[1]); i++) {
                    String point = $"{x1y1[0]},{i}";
                    AddToMap(point);
                }
            } else {
                for (int i = Math.Min(x1y1[0], x2y2[0]); i <= Math.Max(x1y1[0], x2y2[0]); i++) {
                    String point = $"{i},{x1y1[1]}";
                    AddToMap(point);
                }
            }

        }

        /// <summary>
        /// Adds point to the map of Intersections
        /// </summary>
        /// <param name="point">Point</param>
        private void AddToMap(String point) {
            if (Map.ContainsKey(point)) {
                Map[point] += 1;
            } else {
                Map.Add(point, 0);
            }
        }

        /// <summary>
        /// Counts how many lines intersect
        /// </summary>
        /// <returns>How many intersections there are</returns>
        public int CountIntersections() {
            var intersections = Map.Where(p => p.Value > 0).ToList();
            return intersections.Count;
        }

        /// <summary>
        /// Determines if the line is horizontal orVertical
        /// </summary>
        /// <param name="coords1">Line coordenates x1, y1</param>
        /// <param name="coords2">Line coordenates x2, y2</param>
        /// <returns>True if it is, false otherwise</returns>
        public bool IsLineHorizontalOrVertical(int[] coords1, int[] coords2) {
            return coords1[0] == coords2[0] || coords1[1] == coords2[1];
        }

        /// <summary>
        /// Converts a string array into an integer array
        /// </summary>
        /// <param name="array">String array</param>
        /// <returns>Integer array</returns>
        private static int[] ConvertToInt(string array) {
            return Array.ConvertAll(array.Split(","),
                            delegate (string s) { return int.Parse(s); });
        }

        public void Draw() {

            String[,] board = new String[MaxY+1, MaxX+1];

            foreach (String point in Map.Keys) { 
                int[] coords = ConvertToInt(point);

                int x = coords[0];
                int y = coords[1];

                board[y, x] = (Map[point] + 1).ToString();
            }

            for (int y = 0; y <= MaxY; y++) {
                String line = String.Empty;
                for (int x = 0; x <= MaxX; x++) {
                    if (String.IsNullOrEmpty(board[y, x])) {
                        line += ".";
                    } else {
                        line += (board[y, x]);
                    }
                }

                Console.WriteLine(line);
            }
        }
    }
}
