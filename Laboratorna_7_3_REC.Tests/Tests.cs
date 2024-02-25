using NUnit.Framework;
using System.IO;

namespace Laboratorna_7_3_REC.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestInput()
        {
            int rowCount = 2;
            int colCount = 3;
            int[][] expectedMatrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
            string input = "1\n2\n3\n4\n5\n6\n";

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                int[][] actualMatrix = new int[rowCount][];
                for (int i = 0; i < rowCount; i++)
                    actualMatrix[i] = new int[colCount];

                Program.Input(actualMatrix, rowCount, colCount, 0, 0);

                CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
            }
        }

        [Test]
        public void TestSortColumnsByCharacteristic()
        {
            int rowCount = 3;
            int colCount = 3;
            int[][] matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, -1, 2 }, new int[] { 3, 2, 1 } };
            int[][] expectedMatrix = new int[][] { new int[] { 1, 3, 2 }, new int[] { 3, 2, -1 }, new int[] { 3, 1, 2 } };

            Program.SortColumnsByCharacteristic(matrix, rowCount, colCount, 0);

            Assert.AreEqual(expectedMatrix, matrix);
        }

        [Test]
        public void TestSumOfColumnsWithNegativeElement()
        {
            int rowCount = 3;
            int colCount = 3;
            int[][] matrix = new int[][] { new int[] { 1, -1, 1 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int expectedSum = -1 + 5 + 8;

            int actualSum = Program.SumOfColumnsWithNegativeElement(matrix, rowCount, colCount, 0, 0);

            Assert.AreEqual(expectedSum, actualSum);
        }

        [Test]
        public void TestPrint()
        {
            int rowCount = 2;
            int colCount = 3;
            int[][] matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Print(matrix, rowCount, colCount, 0, 0);
                string printedOutput = sw.ToString();

                string expectedOutput = "   1   2   3\n   4   5   6\n";
                Assert.AreEqual(expectedOutput, printedOutput);
            }
        }

    }
}
