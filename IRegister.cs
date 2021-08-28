using System;

namespace Procesor_Intel_8086_3
{
    public interface IRegister
    {
        public const string avaliableSymbols = "0123456789ABCDEF";

        public string Value { get; set; }
        public string Name { get; }
        public int Length { get; }

        public void Swap(IRegister register)
        {
            string temp = Value;
            Value = register.Value;
            register.Value = temp;
        }
        public void Move(IRegister register)
        {
            Value = register.Value;
        }


        public void CheckValue(string value)
        {
            value = value.ToUpper().Trim();
            if (value.Length > Length)
            {
                throw new ArgumentException("Input value is too long!");
            }
            if (value.Length < Length)
            {
                throw new ArgumentException("Input value is too short!");
            }
            
            foreach(char c in value)
            {
                if (!avaliableSymbols.Contains(c))
                {
                    throw new ArgumentException("Input value contains not avaliable symbols! Please use only \"0123456789ABCDEF\"");
                }
            }
        }
    }
}
