using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LagerverwaltungWH.Web.Models;
using LagerverwaltungWH.Web.Repositories;
using LagerverwaltungWH.Web.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Web
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IGeschäftsfallRepo _geschäftsfallRepo;

        public IGeschäftsfallRepo GeschäftsfallRepo
        {
            get
            {
                if (_geschäftsfallRepo == null) _geschäftsfallRepo = new GeschäftsfallRepo(_dbContext);
                return _geschäftsfallRepo;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}