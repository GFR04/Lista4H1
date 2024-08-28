using Microsoft.AspNetCore.Mvc;
using System;
using Ultima_questão_da_lista.Models;

namespace Ultima_questão_da_lista.Controllers
{
    [ApiController]
    [Route("API/Pessoa")]
    public class PessoaController : ControllerBase
    {
        static List<Pessoa> pessoaList;
        [HttpPost]
        [Route("CriarPessoa")]
        public IActionResult CriarPessoa(Pessoa _pessoa)
        {
            pessoaList.Add (_pessoa);
            return Ok();
        }
        [HttpPut]
        [Route("AtualizarPessoa")]
        public IActionResult AtualizarPessoa(string cpf, Pessoa AttPessoa)
        {
           Pessoa? PessoaAtualizar = pessoaList.Where(a => a.CPF == cpf).FirstOrDefault();
            if (PessoaAtualizar == null)
            {
                return BadRequest("Essa pessoa não foi encontrada");
            }
            PessoaAtualizar.Nome = AttPessoa.Nome;
            PessoaAtualizar.Peso = AttPessoa.Peso;
            PessoaAtualizar.Altura = AttPessoa.Altura;
            return Ok("Os dados de cadastro foram atualizados");
    }
        [HttpDelete]
        [Route("DeletarPessoa")]
        public IActionResult DeletarPessoa(string cpf)
        {
            Pessoa? PessoaRemover = pessoaList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (PessoaRemover == null) 
            {
                return BadRequest("Pessoa não encontrada");
            }
            pessoaList.Remove(PessoaRemover);
            return Ok("Pessoa Removida");
        }
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(pessoaList);
        }
        [HttpGet]
        [Route("BuscarCPF")]
        public IActionResult BuscarCPF(string cpf)
        {
            Pessoa? BuscarPessoa = pessoaList.Where(a => a.CPF == cpf).FirstOrDefault();
            if (BuscarPessoa is null)
            {
                return BadRequest("Pessoa não encontrada");
            }
            return Ok(BuscarPessoa);
        }
        [HttpGet]
        [Route("IMCbom")]
        public IActionResult IMCbom ()
        {
            return Ok( pessoaList.Where(pessoa => pessoa.IMC() >= 18.5 && pessoa.IMC() <= 24.9));

        }
        [HttpGet]
        [Route("SearchPersonByName/{name}")]
        public IActionResult SearchPersonByName(string nome)
        {
            Pessoa? personFound = pessoaList.Where(a => a.Nome == nome).FirstOrDefault();

            if (personFound is null)
            {
                return BadRequest("This person not exist!");
            }

            return Ok(personFound);
        }
    }
}
