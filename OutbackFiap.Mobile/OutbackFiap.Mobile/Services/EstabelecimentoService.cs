using System.Collections.Generic;
using OutbackFiap.Mobile.Config;
using OutbackFiap.Mobile.Models;

namespace OutbackFiap.Mobile.Services
{
    public class EstabelecimentoService : BaseService<Estabelecimento>, IEstabelecimentoService
    {
        public EstabelecimentoService(IDbPathConfig dbPathConfig) : base(dbPathConfig)
        {
        }

        public override Estabelecimento GetById(int id)
        {
            return this.FindWithQuery("SELECT * FROM Estabelecimento Where Id=?", id);
        }

        public void AtualizarCapacidade(int id, Ocupacao ocupacao)
        {
            var estab = this.GetById(id);
            estab.Ocupacao = ocupacao;
            this.Update(estab);
        }

        public IEnumerable<Estabelecimento> Search(string searchValue)
        {
            IEnumerable<Estabelecimento> estabelecimentos;
            if (string.IsNullOrEmpty(searchValue))
            {
                estabelecimentos = this.DeferredQuery("SELECT * FROM Estabelecimento");
            }
            else
            {
                estabelecimentos = this.DeferredQuery($"SELECT * FROM Estabelecimento Where Unidade LIKE '%{searchValue}%' OR Cidade LIKE '%{searchValue}%' OR Endereco LIKE '%{searchValue}%'");
            }

            return estabelecimentos;
        }
    }
}
