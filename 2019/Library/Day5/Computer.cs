using System;

namespace Library.Day5
{

    public class Computer
    {
         private int _programCounter = 0;
        private int[] _program;
        private Func<int> _input;
        private Action<int> _output;

        public Computer(Func<int> input, Action<int> output, params int[] program)
        {
            this._program = program;
            this._input = input;
            this._output = output;
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
            var instruction = _program[_programCounter];
            
            bool param3PosMode = true;
            bool param2PosMode = true;
            bool param1PosMode = true;

            // is 3rd param mode set?
            if(instruction > 10000)
            {
                instruction -= 10000;
                param3PosMode = false;
            }
            // is 2nd param mode set?
            if(instruction > 1000)
            {
                instruction -= 1000;
                param2PosMode = false;
            }
            // is 1st param mode set?
            if(instruction > 100)
            {
                instruction -= 100;
                param1PosMode = false;
            }


            switch ((OpCode)instruction)
            {
                case OpCode.Add:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];

                    int addressResult = _program[_programCounter + 3];

                    _program[addressResult] = operandA + operandB;
                    _programCounter += 4;
                }
                break;

                case OpCode.Multiply:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];

                    int addressResult = _program[_programCounter + 3];

                    _program[addressResult] = operandA * operandB;
                    _programCounter += 4;
                }
                break;

                case OpCode.StoreAddress:
                {
                    if(param1PosMode)
                    {
                        int address = _program[_programCounter + 1];
                        _program[address] = this._input();
                    }
                    else
                    {
                        throw new Exception("store at value");
                    }
                    _programCounter += 2;
                }
                break;

                case OpCode.LoadAddress:
                {
                    if(param1PosMode)
                    {
                        int val = _program[_program[_programCounter + 1]];
                        this._output(val);
                    }
                    else
                    {
                        int val = _program[_programCounter + 1];
                        this._output(val);
                    }
                    _programCounter += 2;
                }
                break;

                case OpCode.JmpIfTrue:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];

                    if(operandA != 0)
                    {
                        _programCounter = operandB;
                    }
                    else
                    {
                        _programCounter += 3;
                    }
                }
                break;

                case OpCode.JmpIfFalse:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];

                    if(operandA == 0)
                    {
                        _programCounter = operandB;
                    }
                    else
                    {
                        _programCounter += 3;
                    }
                }
                break;

                case OpCode.LessThan:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];
                    int addressC = /*param3PosMode ? _program[_program[_programCounter + 3]] :*/ _program[_programCounter + 3];

                    if(operandA < operandB)
                    {
                        _program[addressC] = 1;
                    }
                    else
                    {
                        _program[addressC] = 0;                        
                    }
                    _programCounter += 4;
                }
                break;

                case OpCode.Equals:
                {
                    int operandA = param1PosMode ? _program[_program[_programCounter + 1]] : _program[_programCounter + 1];
                    int operandB = param2PosMode ? _program[_program[_programCounter + 2]] : _program[_programCounter + 2];
                    int addressC = /*param3PosMode ? _program[_program[_programCounter + 3]] :*/ _program[_programCounter + 3];

                    if(operandA == operandB)
                    {
                        _program[addressC] = 1;
                    }
                    else
                    {
                        _program[addressC] = 0;                        
                    }
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

    internal enum OpCode
    {
        Add = 1,
        Multiply = 2,
        StoreAddress = 3,
        LoadAddress = 4,

        JmpIfTrue = 5,
        JmpIfFalse = 6,
        LessThan = 7,
        Equals = 8,

        Halt = 99
    }
}