using Library.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.Tests
{
    [TestClass]
    public class TestDay2
    {
        [TestMethod]
        public void TestProgram()
        {
            int[] program = { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };

            var computer = new Computer(program);

            var result = computer.Execute();
            Assert.AreEqual(70, computer.Program[3]);
            Assert.AreEqual(true, result);

            result = computer.Execute();
            Assert.AreEqual(3500, computer.Program[0]);
            Assert.AreEqual(true, result);

            result = computer.Execute();
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestAssert()
        {
            int[] program = { 3, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };

            var computer = new Computer(program);

            Assert.ThrowsException<ArgumentException>(() => computer.Execute());
        }

        [TestMethod]
        public void Test1() 
        {
            int[] program = { 1, 0, 0, 0, 99 };
            var computer = new Computer(program);
            computer.Run();
            CollectionAssert.AreEqual(new int[]{ 2,0,0,0,99 }, computer.Program);
        }


        [TestMethod]
        public void TestInput() 
        {
            int[] program = { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 5, 19, 23, 2, 9, 23, 27, 1, 6, 27, 31, 1, 31, 9, 35, 2, 35, 10, 39, 1, 5, 39, 43, 2, 43, 9, 47, 1, 5, 47, 51, 1, 51, 5, 55, 1, 55, 9, 59, 2, 59, 13, 63, 1, 63, 9, 67, 1, 9, 67, 71, 2, 71, 10, 75, 1, 75, 6, 79, 2, 10, 79, 83, 1, 5, 83, 87, 2, 87, 10, 91, 1, 91, 5, 95, 1, 6, 95, 99, 2, 99, 13, 103, 1, 103, 6, 107, 1, 107, 5, 111, 2, 6, 111, 115, 1, 115, 13, 119, 1, 119, 2, 123, 1, 5, 123, 0, 99, 2, 0, 14, 0 }; 

            //replace position 1 with the value 12 and replace position 2 with the value 2.
            program[1] = 12;
            program[2] = 2;

            var computer = new Computer(program);
            computer.Run();
            Assert.AreEqual(3101844, computer.Program[0]);
        }


        [TestMethod]
        public void TestInputBrute()
        {
            for (int noun = 0; noun < 100; noun++) 
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    int[] program = { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 5, 19, 23, 2, 9, 23, 27, 1, 6, 27, 31, 1, 31, 9, 35, 2, 35, 10, 39, 1, 5, 39, 43, 2, 43, 9, 47, 1, 5, 47, 51, 1, 51, 5, 55, 1, 55, 9, 59, 2, 59, 13, 63, 1, 63, 9, 67, 1, 9, 67, 71, 2, 71, 10, 75, 1, 75, 6, 79, 2, 10, 79, 83, 1, 5, 83, 87, 2, 87, 10, 91, 1, 91, 5, 95, 1, 6, 95, 99, 2, 99, 13, 103, 1, 103, 6, 107, 1, 107, 5, 111, 2, 6, 111, 115, 1, 115, 13, 119, 1, 119, 2, 123, 1, 5, 123, 0, 99, 2, 0, 14, 0 }; ;

                    program[1] = noun;
                    program[2] = verb;

                    var computer = new Computer(program);
                    computer.Run();

                    if (computer.Program[0] == 19690720) 
                    {

                        Assert.AreEqual(84, noun);
                        Assert.AreEqual(78, verb);
                    }
                }
            }
        }
    }
}
