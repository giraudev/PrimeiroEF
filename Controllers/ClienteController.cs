using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroEF.Dados;
using PrimeiroEF.Models;

namespace PrimeiroEF.Controllers
{
    //colocar a rota
    [Route("api/[controller]")]
    //"herdar" controller
    public class ClienteController : Controller
    {
        Cliente cliente = new Cliente();

        /*disponibilizar o contexto, sem setar nada para dentro dele, sem atribuir valores a ele
        será usado com uma CONSTANTE, por isso p readonly (somente leitura)*/
        readonly ClienteContexto contexto;

        public ClienteController(ClienteContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        //o retorno será de vários clientes, por isso o IEnumerable
        public IEnumerable<Cliente> Listar()
        {
            //o equivalente ao SELECT do banco de dados
            return contexto.ClienteNaBase.ToList();
        }

        [HttpGet("{id}")]
        //o retorno será apenas 1 cliente
        public Cliente Listar(int id)
        {
            //especificando 1 individuo, por isso o FirstOrDefault
            return contexto.ClienteNaBase.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        //usando void, para nao ter retorno, normalmente podemos usar IActionResult
        public void Cadastrar([FromBody]Cliente cli)
        {
            //adicionando
            contexto.ClienteNaBase.Add(cli);
            //salvando
            contexto.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Cliente cliente)
        {

            if (cliente == null || cliente.Id != id)
            {
                return BadRequest();
            }

            var cli = contexto.ClienteNaBase.FirstOrDefault(x=>x.Id==id);
            if(cli==null)
            return NotFound();

            cli.Id = cliente.Id;
            cli.Nome = cliente.Nome;
            cli.Email = cliente.Email;
            cli.Idade = cliente.Idade;
            cli.DataCadastro = cliente.DataCadastro;

            contexto.ClienteNaBase.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs>0)
            return Ok();
            else
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var Cliente = contexto.ClienteNaBase.Where(x=>x.Id==id).FirstOrDefault();
            if(cliente == null){
                return NotFound();
            }
            contexto.ClienteNaBase.Remove(cliente);
            int rs = contexto.SaveChanges();
            if(rs>0)
            return Ok();
            else
            return BadRequest();
        }


    }
}