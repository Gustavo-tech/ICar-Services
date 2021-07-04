using ICar.Infrastructure.Database.Models.Enums.Car;
using System;

namespace ICar.Infrastructure.Database.Converter
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

        public static Color ConvertStringToColor(string color)
        {
            switch (color)
            {
                case "White":
                    return Color.White;
                case "Black":
                    return Color.Black;
                case "Gray":
                    return Color.Gray;

                case "Red":
                    return Color.Red;

                case "Blue":
                    return Color.Blue;

                case "Yellow":
                    return Color.Yellow;

                case "Pink":
                    return Color.Pink;

                case "Green":
                    return Color.Green;

                case "Purple":
                    return Color.Purple;

                case "Orange":
                    return Color.Orange;

                default:
                    throw new NotImplementedException();
            }
        }

        public static string ConvertColorToString(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return "White";
                case Color.Black:
                    return "Black";
                case Color.Gray:
                    return "Gray";

                case Color.Red:
                    return "Red";

                case Color.Blue:
                    return "Blue";

                case Color.Yellow:
                    return "Yellow";

                case Color.Pink:
                    return "Pink";

                case Color.Green:
                    return "Green";

                case Color.Purple:
                    return "Purple";

                case Color.Orange:
                    return "Orange";

                default:
                    return string.Empty;
            }
        }

        public static TypeOfExchange ConvertStringToTypeOfExchange(string typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case "aut":
                    return TypeOfExchange.Automatic;
                case "man":
                    return TypeOfExchange.Manual;
                default:
                    return TypeOfExchange.Manual;
            }
        }

        public static string ConvertTypeOfExchangeToString(TypeOfExchange typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case TypeOfExchange.Automatic:
                    return "aut";
                case TypeOfExchange.Manual:
                    return "man";
                default:
                    return "man";
            }
        }

        public static GasolineType ConvertStringToGasolineType(string gasolineType)
        {
            gasolineType = gasolineType.ToLower();
            switch (gasolineType)
            {
                case "gas":
                    return GasolineType.Gasoline;
                case "ele":
                    return GasolineType.Eletric;
                case "gad":
                    return GasolineType.GasolineAndDiesel;
                case "die":
                    return GasolineType.Diesel;
                default:
                    return GasolineType.GasolineAndDiesel;
            }
        }

        public static string ConvertGasolineTypeToString(GasolineType gasolineType)
        {
            switch (gasolineType)
            {
                case GasolineType.Diesel:
                    return "Die";
                case GasolineType.Gasoline:
                    return "Gas";
                case GasolineType.Eletric:
                    return "Ele";
                case GasolineType.GasolineAndDiesel:
                    return "GAD";
                default:
                    return "GAD";
            }
        }
    }
}
