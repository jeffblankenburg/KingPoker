﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KingPoker
{
    public class ClosingHandCardToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //BothHands h = value as BothHands;
            //int place = Int32.Parse(parameter.ToString());

            //string x = String.Empty;
            //switch (h.GameType)
            //{
            //    case "DEUCESWILD":
            //    case "DOUBLEBONUSDEUCESWILD":
            //    case "DEUCESWILDBONUSPOKER":
            //        if (h.ClosingHand.Cards[place].Value.Number == 2) x = "w";
            //        break;
            //}

            //string imagepath = "Assets/cards/" + h.ClosingHand.Cards[place].Suit.ID.ToString() + h.ClosingHand.Cards[place].Value.Number.ToString() + x.ToString() + ".png";
            //return imagepath;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
