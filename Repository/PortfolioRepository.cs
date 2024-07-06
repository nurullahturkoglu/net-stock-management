using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Repository
{
    public class PortfolioRepository(ApplicationDbContext applicationDbContext) : IPortfolioRepository
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;

        public List<StockDto> GetStocks(AppUser appUser)
        {
            List<StockDto> portfolios = applicationDbContext.Portfolios
            .Where(p => p.AppUserId == appUser.Id)
            .Select(p => p.Stock.ToStockDto())
            .ToList();

            return portfolios;
        }
    }
}