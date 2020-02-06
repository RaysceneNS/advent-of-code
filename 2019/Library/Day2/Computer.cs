using System;

namespace Library.Day2
{
    public class Computer
    {
        private int _programCounter = 0;
        private int[] _program;

        public Computer(int[] program)
        {
            this._program = program;
        }

        public int[] Program
        {
            get
            {
                return this._program;
            }
        }

        public void Run() 
        {
            bool ok = true;
            do
            {
                ok = Execute();
            }
            while (ok);
        }

        public bool Execute()
        {
            var instruction = (OpCode)_program[_programCounter];
            switch (instruction)
            {
                case OpCode.Add:
                    {
                        int addressA = _program[_programCounter + 1];
                        int addressB = _program[_programCounter + 2];
                        int addressResult = _program[_programCounter + 3];
                        int operandA = _program[addressA];
                        int operandB = _program[addressB];
                        _program[addressResult] = operandA + operandB;
                        _programCounter += 4;
                    }
                    break;
                case OpCode.Multiply:
                    {
                        int addressA = _program[_programCounter + 1];
                        int addressB = _program[_programCounter + 2];
                        int addressResult = _program[_programCounter + 3];
                        int operandA = _program[addressA];
                        int operandB = _program[addressB];
                        _program[addressResult] = operandA * operandB;
                        _programCounter += 4;
                    }
                    break;
                case OpCode.Halt:
                    return false;
                default:
                    throw new ArgumentException("Invalid instruction");
            }
            return true;
        }


    }
}
