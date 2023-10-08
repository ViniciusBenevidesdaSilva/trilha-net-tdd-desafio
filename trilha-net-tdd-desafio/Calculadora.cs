using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trilha_net_tdd_desafio
{
    public class Calculadora
    {
        private List<string> _listaHistorico;
        private string _data;

        public Calculadora(string data)
        {
            _listaHistorico = new List<string>();
            _data = data;
        }

        private int InsereHistoricoERetornaResultado(int resultado)
        {
            _listaHistorico.Insert(0, $"Res: {resultado} - Data: {_data}");           
            return resultado;
        }

        public int Somar(int val1, int val2)
        {
            int resultado = val1 + val2;
            return InsereHistoricoERetornaResultado(resultado);
        }

        public int Subtrair(int val1, int val2)
        {
            int resultado = val1 - val2;
            return InsereHistoricoERetornaResultado(resultado);
        }

        public int Multiplicar(int val1, int val2)
        {
            int resultado = val1 * val2;
            return InsereHistoricoERetornaResultado(resultado);
        }

        public int Dividir(int val1, int val2)
        {
            int resultado = val1 / val2;
            return InsereHistoricoERetornaResultado(resultado);
        }

        public List<string> Historico()
        {
            return _listaHistorico.Take(3).ToList();
        }

    }
}
