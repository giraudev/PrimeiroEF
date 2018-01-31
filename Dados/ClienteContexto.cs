using Microsoft.EntityFrameworkCore;
using PrimeiroEF.Models;

/*CONTEXTO é usado por projeto, o que muda é o parâmetro <parametro>
Podemos considerar as tabelas como "objeto".*/
namespace PrimeiroEF.Dados
{
    //importar DbContext(classe pai)
    public class ClienteContexto : DbContext
    {
        /* criando o construtor:
        passagem de argumento: DbContextOptions, tipando com <ClienteContexto> variavel = options
        colando os :base, referencia a herança da classe pai
        ou seja, classecontexto vai se "contextualizar" olhando a classe pai, usando as opções disponiveis
        */
        public ClienteContexto(DbContextOptions<ClienteContexto> options) : base(options)
        {

        }

        /*DbSet usado para setar/gravar no banco de dados virtual */
        public DbSet<Cliente> ClienteNaBase { get; set; }

    }
}