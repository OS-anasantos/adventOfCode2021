using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2021 {
    public class Submarine {
        public int HorizontalPosition { get; set; }
        public int DepthPosition { get; set; }

        public int Aim { get; set; }

        public Submarine() {
            this.HorizontalPosition = 0;
            this.DepthPosition = 0;
            this.Aim = 0;
        }

        private void GoForward(int units) {
            this.HorizontalPosition += units;
            this.DepthPosition += (this.Aim * units);
        }

        private void GoDown(int units) {
            this.Aim += units;
        }

        private void GoUp(int units) {
            this.Aim -= units;
        }

        public void FollowDirections(string direction) {
            int units = Int32.Parse(direction.Substring(direction.Length - 1, 1));

            switch (direction.Substring(0, 1)) {
                case "f":
                    GoForward(units);
                    break;
                case "u":
                    GoUp(units);
                    break;
                case "d":
                    GoDown(units);
                    break;

            }
        }
    }
}
