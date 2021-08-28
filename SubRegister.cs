using System;

namespace Procesor_Intel_8086_3
{
    public class SubRegister : IRegister
    {
        private string _value = "00";

        public string Value { get => _value; set => SetValue(value); }

        private void SetValue(string value)
        {
            _value = value.ToUpper().Trim();
        }

        public string Name { get; }

        public Register ParentRegister { get; }

        public int Length => 2;

        public SubRegister(string name, Register parentRegister)
        {
            Name = name;
            ParentRegister = parentRegister;
        }
    }
}
