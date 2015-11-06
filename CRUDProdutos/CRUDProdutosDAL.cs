using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDProdutos
{
    class CRUDProdutosDAL
    {
        private static String strConexao = "Data Source=.\\SQLEXPRESS; Initial Catalog = Produtos; Integrated Security=True;";
        private static SqlConnection conn = new SqlConnection(strConexao);
        private static SqlCommand strSQL;
        private static SqlDataReader result;

        public static void conecta()
        {
            conn.Open();
        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void alterarProduto()
        {
            conecta();
            strSQL = new SqlCommand("stpAlterarProduto", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoProd());
            strSQL.Parameters.AddWithValue("@nome", CRUDProdutos.getNome());
            strSQL.Parameters.AddWithValue("@fabricante", CRUDProdutos.getFabricante());
            strSQL.Parameters.AddWithValue("@valor", CRUDProdutos.getValor());            
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally {
                desconecta();
            }
        }

        public static void deletarProduto()
        {
            conecta();
            strSQL = new SqlCommand("stpDeletarProduto", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoProd());
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }
        }

        public static void inserirProduto()
        {
            conecta();
            strSQL = new SqlCommand("stpInserirProduto", conn);
            strSQL.Parameters.AddWithValue("@nome", CRUDProdutos.getNome());
            strSQL.Parameters.AddWithValue("@fabricante", CRUDProdutos.getFabricante());
            strSQL.Parameters.AddWithValue("@valor", CRUDProdutos.getValor());            
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }
        }

        public static void consultarProduto()
        {
            conecta();
            strSQL = new SqlCommand("stpConsultarProduto", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoProd());
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                result = strSQL.ExecuteReader();
                Erro.setErro(false);
                if (result.Read())
                {
                    CRUDProdutos.setCodigoProd(result[0].ToString());
                    CRUDProdutos.setNome(result[1].ToString());
                    CRUDProdutos.setFabricante(result[2].ToString());
                    CRUDProdutos.setValor(result[3].ToString());
                }
                else
                {
                    Erro.setMsg("Produto nao cadastrado");
                    return;
                }
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }
        }

        public static void alterarEstoque()
        {
            conecta();
            strSQL = new SqlCommand("stpAlterarEstoque", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoEst());
            strSQL.Parameters.AddWithValue("@codigoprod", CRUDProdutos.getCodigoProd());            
            strSQL.Parameters.AddWithValue("@quantidade", CRUDProdutos.getQuantidade());            
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }

        }

        public static void deletarEstoque()
        {
            conecta();
            strSQL = new SqlCommand("stpDeletarEstoque", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoEst());
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }

        }

        public static void inserirEstoque()
        {
            conecta();
            strSQL = new SqlCommand("stpInserirEstoque", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoProd());
            strSQL.Parameters.AddWithValue("@quantidade", CRUDProdutos.getQuantidade());
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch
            {
                Erro.setMsg("Não há produto cadastrado com esse codigo");
                return;
            }
            finally
            {
                desconecta();
            }
        }

        public static void consultarEstoque()
        {
            conecta();
            strSQL = new SqlCommand("stpConsultarEstoque", conn);
            strSQL.Parameters.AddWithValue("@codigo", CRUDProdutos.getCodigoEst());
            strSQL.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                result = strSQL.ExecuteReader();
                Erro.setErro(false);
                if (result.Read())
                {
                    CRUDProdutos.setCodigoEst(result[0].ToString());
                    CRUDProdutos.setCodigoProd(result[1].ToString());
                    CRUDProdutos.setQuantidade(result[2].ToString());
                }
                else
                {
                    Erro.setMsg("Produto nao cadastrado em estoque");
                    return;
                }
            }
            catch (Exception e)
            {
                Erro.setMsg("Erro: " + e);
                return;
            }
            finally
            {
                desconecta();
            }
        }
    }
}
