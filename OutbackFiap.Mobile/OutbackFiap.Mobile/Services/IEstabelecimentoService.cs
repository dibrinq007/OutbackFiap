using System;
using System.Collections.Generic;
using System.Text;
using OutbackFiap.Mobile.Models;

namespace OutbackFiap.Mobile.Services
{
    public interface IEstabelecimentoService : IService<Estabelecimento>
    {
        void AtualizarCapacidade(int id, Ocupacao ocupacao);
        IEnumerable<Estabelecimento> Search(string searchValue);
    }
}
