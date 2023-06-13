using LeetCodeRunner.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCodeRunner.Solutions.LeetCode
{
    internal class LeetCode1926NearestExitFromEntranceMaze : AbstractSolution<LeetCode1926NearestExitFromEntranceMaze.SolutionInput, int>
    {
        private struct Location
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public override int GetHashCode()
            {
                return Row ^ Col;
            }
        }

        private class PathStep
        {
            public Location Position { get; set; }
            public HashSet<Location> VisitedLocations { get; set; } = new HashSet<Location>();
        }

        public int NearestExit(char[][] maze, int[] entrance)
        {
            var mazeEntrance = new Location() { Row = entrance[0], Col = entrance[1] };
            int mazeTotalRows = maze.Length;
            int mazeTotalCols = maze[0].Length;

            Stack<PathStep> steps = new Stack<PathStep>();
            steps.Push(CreatePathStep(mazeEntrance));

            int minSteps = -1;

            while (steps.Count > 0)
            {
                var step = steps.Pop();

                if (IsExit(step, mazeTotalRows, mazeTotalCols, mazeEntrance))
                {
                    var numVisited = step.VisitedLocations.Count;
                    minSteps = minSteps == -1 ? numVisited : Math.Min(minSteps, numVisited);
                    continue;
                }

                step.VisitedLocations.Add(step.Position);

                bool keepOriginalPath = false;
                var upStep = CreateNextStep(step, maze, 0, -1, ref keepOriginalPath);
                if (upStep is not null)
                {
                    steps.Push(upStep);
                }
                var downStep = CreateNextStep(step, maze, 0, +1, ref keepOriginalPath);
                if (downStep is not null)
                {
                    steps.Push(downStep);
                }
                var leftStep = CreateNextStep(step, maze, -1, 0, ref keepOriginalPath);
                if (leftStep is not null)
                {
                    steps.Push(leftStep);
                }
                var rightStep = CreateNextStep(step, maze, +1, 0, ref keepOriginalPath);
                if (rightStep is not null)
                {
                    steps.Push(rightStep);
                }
            }

            return minSteps;
        }

        private PathStep? CreateNextStep(PathStep fromStep, char[][] maze, int rowUpdate, int colUpdate, ref bool keepOriginalPath)
        {
            var newCol = fromStep.Position.Col + colUpdate;
            var newRow = fromStep.Position.Row + rowUpdate;
            if (newRow < 0 || newCol < 0 || newRow == maze.Length || newCol == maze[0].Length)
            {
                // Out of border, there will be new new step
                return null;
            }

            if (maze[newRow][newCol] == '+')
            {
                // Is wall
                return null;
            }

            var newLocation = new Location() { Col = newCol, Row = newRow };
            if (fromStep.VisitedLocations.Contains(newLocation))
            {
                // Already visited
                return null;
            }
            var newPath= CreatePathStep(newLocation, fromStep, keepOriginalPath);
            if (keepOriginalPath == true)
            {
                keepOriginalPath = false;
            }
            return newPath;
        }

        private PathStep CreatePathStep(Location location, PathStep? parent = null, bool? keepOriginalPath = false)
        {
            var visitedLocations = keepOriginalPath == true
                ? parent?.VisitedLocations
                : parent?.VisitedLocations?.ToHashSet();

            return new PathStep()
            {
                Position = location,
                VisitedLocations = visitedLocations ?? new HashSet<Location>()
            };
        }

        private bool IsExit(PathStep step, int totalRows, int totalCols, Location mazeEntrance)
        {
            return !step.Position.Equals(mazeEntrance)
                && (step.Position.Row == 0 || step.Position.Col == 0
                    || step.Position.Row == totalRows - 1 || step.Position.Col == totalCols - 1);
        }


        // ************************************************************************************
        protected override IEnumerable<SolutionTestCase<SolutionInput, int>> GetTestCases()
        {
            return new SolutionTestCase<SolutionInput, int>[]
            {
                new SolutionTestCase<SolutionInput, int>()
                {
                    Input = new SolutionInput(
                        new char[][]
                        {
                            new char[] { '+', '.', '+', '+', '+', '+', '+' },
                            new char[] { '+','.','+','.','+','.','+' },
                            new char[] { '+','.','+','.','.','.','+' },
                            new char[] { '+', '.', '.', '.', '.', '.', '+' },
                            new char[] { '+', '+', '+', '+', '.', '+', '.' }
                        },
                        new int[] {0,1 }),
                    ExpectedResult = 7
                }
            };
        }

        #region Helpers & Input

        public record SolutionInput(char[][] maze, int[] entrance);

        protected override bool IsMatch(int v1, int v2) => v1 == v2;
        protected override int RunTestCase(SolutionInput data) => NearestExit(data.maze, data.entrance);

        #endregion
    }
}
