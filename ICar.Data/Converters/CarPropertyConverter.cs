namespace ICar.Data.Converter
{
    public static class CarPropertyConverter
    {
        public static bool ConvertByteToBool(byte value)
        {
            return value == 1;
        }

        public static int ConvertBoolToBit(bool value)
        {
            int convertedDigit = value ? 1 : 0;
            return convertedDigit;
        }
    }
}
