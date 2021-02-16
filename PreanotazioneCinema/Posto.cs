using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreanotazioneCinema
{
    class Posto
    {
        private int _numero;
        private bool _occupato=false;
        
        public Posto(int numero,bool occupato)
        {
            Numero = numero;
        }
        
        public int Numero 
        {
            get
            {
                return _numero;
            }
            set 
            {
                if (value > 0)
                    _numero = value;
                else
                    throw new Exception();
            }
        }
        public bool Occupato
        {
            get
            {
                return _occupato;
            }
            set
            {
                if (!value==false)
                    throw new Exception();               
                else
                    _occupato = value;

            }
        }

    }
}
