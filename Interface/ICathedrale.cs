using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    interface ICathedrale
    {
        int Priere(string jour);
        void PrendreFeu(List<string> ouvriers_negligents);
        void AggrandirNef(int fonds_monetaires_eglise);
    }
}
