using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/*
    Gracias a David de http://www.lanavajasuiza.net/comprobar-cif-nif-net-con-c-sharp/
*/

namespace U_DENTAL.BBDD.DATA
{
    public class CheckNif
    {
        const string c_NIFNIE = "TRWAGMYFPDXBNJZSQVHLCKE";
        const string c_CIF = "ABCDEFGHIJ";

        public static bool Check(string NIF, bool msg)
        {
            int lon = NIF.Trim().Length;
            int xlon = 0, numero = 0;
            string txtnum = string.Empty;
            NIF = NIF.Trim();
            short res = 0;

            if (lon != 9)
            {
                return true;//Si la longitud no es 9 Error
            }

            string CC = NIF.Substring(lon - 1, 1);
            if (Int16.TryParse(NIF.Substring(0, 1), out res)) //Si es un Nº el primer Carácter
            {
                xlon = lon - 1;
                txtnum = NIF.Substring(0, xlon);
                if (checkErrorNumber(xlon, txtnum, msg)) return true;
                numero = Convert.ToInt32(NIF.Substring(0, xlon));
                if (NIF_NIE(numero, CC, msg)) return true;
            }
            if (!Int16.TryParse(NIF.Substring(0, 1), out res)) //Si es una Letra el primer Carácter
            {
                string PC = NIF.Substring(0, 1);
                xlon = lon - 2;
                txtnum = NIF.Substring(1, xlon);
                if (checkErrorNumber(xlon, txtnum, msg)) return true;
                numero = Convert.ToInt32(NIF.Substring(1, xlon));
                char[] keys = { 'L', 'K', 'X', 'Y', 'M', 'Z' };
                if (PC.IndexOfAny(keys) == 0)
                {
                    if (PC == "Y") numero += 10000000;
                    if (PC == "Z") numero += 20000000; //!!!!!!
                    if (NIF_NIE(numero, CC, msg)) return true;
                }
                else
                    if (CIF(txtnum, CC, PC, msg)) return true;
            }
            return false;
        }

        private static bool CIF(string txtnum, string CC, string PC, bool msg)
        {
            int pares = 0, impares = 0, operando = 0;
            string letra = string.Empty;
            for (int i = 0; i < txtnum.Length; i++)
            {
                if ((((decimal)i + 1) / 2) - (int)((i + 1) / 2) == 0)//Pares
                    pares += Convert.ToInt32(txtnum.Substring(i, 1));
                else //Impares
                {
                    operando = Convert.ToInt32(txtnum.Substring(i, 1)) * 2;
                    operando = (int)((int)(operando / 10) + ((((decimal)operando / 10) - (int)(operando / 10)) * 10));
                    impares += operando;
                }
            }
            operando = pares + impares;
            operando = (int)((((decimal)operando / 10) - (int)(operando / 10)) * 10);
            operando = 10 - operando;
            if (operando == 0) operando = 10;
            char[] keys = { 'N', 'P', 'Q', 'R', 'S', 'W' };
            if (PC.IndexOfAny(keys) == 0)//Si es un Carácter
                letra = c_CIF.Substring(operando - 1, 1);
            else //Si es un Nº
            {
                letra = c_CIF.Substring(operando - 1, 1);
                int j = c_CIF.IndexOf(letra) + 1;
                if (j == 10) j = 0;
                letra = j.ToString();
            }
            if (letra != CC)
            {
                return true;
            }
            return false;
        }

        private static bool NIF_NIE(int numero, string CC, bool msg)
        {
            int modulo = numero - ((int)(numero / 23) * 23) + 1;
            if (c_NIFNIE.Substring(modulo - 1, 1) != CC)
            {
                return true;
            }
            return false;
        }

        private static bool checkErrorNumber(int xlon, string txtnum, bool msg)
        {
            short res = 0;
            for (int i = 0; i < xlon; i++)
            {
                if (!Int16.TryParse(txtnum.Substring(i, 1), out res))
                {
                    return true;
                }
            }
            return false;
        }

    }
}