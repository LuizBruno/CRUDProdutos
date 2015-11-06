using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProdutos
{
    class CRUDProdutos
    {
        private static string CodigoProd;
        private static string CodigoEst;
        private static string Nome;
        private static string Fabricante;
        private static string Valor;
        private static string Quantidade;             

        public static void setCodigoProd(string _codigoProd) { CodigoProd = _codigoProd; }
        public static void setCodigoEst(string _codigoEst) { CodigoEst = _codigoEst; }
        public static void setNome(string _nome) { Nome = _nome; }
        public static void setFabricante(string _fabricante) { Fabricante = _fabricante; }
        public static void setValor(string _valor) { Valor = _valor; }
        public static void setQuantidade(string _quantidade) { Quantidade = _quantidade; }
        
        public static string getCodigoProd() { return CodigoProd; }
        public static string getCodigoEst() { return CodigoEst; }
        public static string getNome() { return Nome; }
        public static string getFabricante() { return Fabricante; }
        public static string getValor() { return Valor; }
        public static string getQuantidade() { return Quantidade; }        
    }
}
