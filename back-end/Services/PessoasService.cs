using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models;
using back_end.Repositories;

namespace back_end.Services
{
    public class PessoasService
    {
        private PessoasRepository _pessoasRepository;
        public PessoasService(PessoasRepository pessoasRepository)
        {
            _pessoasRepository = pessoasRepository;
        }

        public List<PessoaModel>? BuscarPessoasService()
        {
            var response = _pessoasRepository.BuscarPessoasRepository();

            return response;
        }

        public bool CadastrarPessoaService(PessoaModel pessoaModel)
        {
            var response = _pessoasRepository.CadastrarPessoaRepository(pessoaModel);

            return response;
        }
    }
}