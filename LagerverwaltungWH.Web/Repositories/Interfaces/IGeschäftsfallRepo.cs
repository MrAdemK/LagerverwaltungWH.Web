using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerverwaltungWH.Model.DatabaseModels;
using LagerverwaltungWH.Model.ViewModels;

namespace LagerverwaltungWH.Web.Repositories.Interfaces
{
    public interface IGeschäftsfallRepo
    {
        Task<List<GeschäftsfallIndexVM>> GetGeschäftsfallInfo(string searching);
        Task<List<GeschäftsfallListVM>> GetGeschäftsfallList(int? id);
        Task<Geschäftsfall> GetGeschäftsfallById(int? id);
        Task<Lagerartikel> GetAllLagerArtikelById(int? id);
        Task<Lagerbewegung> GetAllLagerBewegungById(int? id);

        void InsertGeschäftsfall(Geschäftsfall geschäftsfall);
        void UpdateGeschäftsfall(Geschäftsfall geschäftsfall);
        void DeleteGeschäftsfall(Geschäftsfall geschäftsfall);

        Task<IEnumerable> DropdownLagerartikel();
        Task<IEnumerable> DropdownVorgang();
        Task<IEnumerable> DropdownLagerbewegung();
    }
}
