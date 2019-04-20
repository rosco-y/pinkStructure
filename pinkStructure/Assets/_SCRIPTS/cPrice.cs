using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._SCRIPTS
{
    class cPrice
    {
        decimal _price;
        public cPrice()
        {
            _price = (decimal)1.25;
        }
        ~cPrice()
        {

        }

        public override string ToString()
        {
            return $"{_price:C}";
        }

        public void NewPrice()
        {
            _price += (decimal)1.0;
        }
    }
}
