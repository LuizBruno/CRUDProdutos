using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProdutos
{
    class CRUDProdutosBLL
    {
        public static void validaCodigoProd()
        {
            Erro.setErro(false);
            if (CRUDProdutos.getCodigoProd().Equals(""))
            {
                Erro.setMsg("O codigo está vazio!");
                return;
            }
        }

        public static void validaCodigoEst()
        {
            Erro.setErro(false);
            if (CRUDProdutos.getCodigoEst().Equals(""))
            {
                Erro.setMsg("O codigo está vazio!");
            }
        }

        public static void validaDadosProduto()
        {
            Erro.setErro(false);
            if (CRUDProdutos.getNome().Equals(""))
            {
                Erro.setMsg("O nome é obrigatorio!");
                return;
            }
            if (CRUDProdutos.getFabricante().Equals(""))
            {
                Erro.setMsg("O fabricante é obrigatoria!");
                return;
            }
            if (CRUDProdutos.getValor().Equals(""))
            {
                Erro.setMsg("O valor é obrigatorio!");
                return;
            }       
            try
            {
                float.Parse(CRUDProdutos.getValor());
            }
            catch
            {
                Erro.setMsg("Valor inválido!");
                return;
            }                    
        }
        public static void validaDadosEstoque()
        {
            Erro.setErro(false);
            if (CRUDProdutos.getQuantidade().Equals(""))
            {
                Erro.setMsg("A quantidade é obrigatoria!");
                return;
            }            
            try
            {
                int.Parse(CRUDProdutos.getQuantidade());
            }
            catch
            {
                Erro.setMsg("Valor invalido");
                return;
            }
        }
    }
}
