using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using back_end.Services;
using back_end.Models;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {

        private PessoasService _pessoasService;
        public PessoasController(PessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet]
        public IActionResult BuscarPessoas()
        {
            var response = _pessoasService.BuscarPessoasService();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CadastrarPessoas([FromBody] PessoaModel pessoaModel)
        {
            var response = _pessoasService.CadastrarPessoaService(pessoaModel);

            if(response == false)
            {
                return BadRequest("Algum dado foi incorreto");
            }
            else
            {
                return Ok();
            }
        }
    }
}