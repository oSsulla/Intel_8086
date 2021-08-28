using System;

namespace Procesor_Intel_8086_3
{
    public class Register : IRegister
    {

        public SubRegister LowRegister;
        public SubRegister HighRegister;

        public Register(string name)
        {
            name = name.ToUpper();
            Name = name + "X";
            LowRegister = new SubRegister($"{name}L", this);
            HighRegister = new SubRegister($"{name}H", this);
        }

        public string Name { get; }
        public string Value { get => HighRegister.Value + LowRegister.Value; set => Set(value); }
        public int Length => 4;

        public void Reset()
        {
            LowRegister.Value = "00";
            HighRegister.Value = "00";
        }

        public void Random()
        {
            LowRegister.Value = $"{GetRandomSymbol()}{GetRandomSymbol()}";
            HighRegister.Value = $"{GetRandomSymbol()}{GetRandomSymbol()}";
        }

        public void Set(string value) {
            value = value.ToUpper().Trim();
            LowRegister.Value = value.Substring(2, 2);
            HighRegister.Value = value.Substring(0, 2);
        }

        private char GetRandomSymbol()
        {
            return IRegister.avaliableSymbols[new Random().Next(0, IRegister.avaliableSymbols.Length)];
        }

    }
}
