using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EKay.Clases
{
    public enum TiposDoc
    {
        Pagaré,
        Prestamo,
        [Description("Poder Notarial")]
        PoderNotarial,
        [Description("Contrato De Compraventa")]
        ContratoDeCompraventa,
        [Description("Cartilla Militar")]
        CartillaMilitar,
        [Description("Acta de Nacimiento")]
        ActaDeNacimiento,


    }
}
