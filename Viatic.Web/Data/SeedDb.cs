using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viatic.Web.Data.Entities;

namespace Viatic.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTripAsync();
        }

        private async Task CheckTripAsync()
        {
            if (_dataContext.Trips.Any())
            {
                return;
            }
            _dataContext.Trips.Add(new TripEntity
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                City = "Medellin",
                Description = "Compra computadores",
                Expenses = new List<ExpenseEntity>
                        {
                            new ExpenseEntity
                            {
                                Date = DateTime.UtcNow,
                                Value = 125000,
                                ExpenseTypes = new List<ExpenseTypeEntity>
                                    {
                                        new ExpenseTypeEntity
                                        {
                                            Type= "Alimentacion"
                                        }
                                    }
                            },
                            new ExpenseEntity
                            {
                                Date = DateTime.UtcNow,
                                Value = 225000,
                                ExpenseTypes = new List<ExpenseTypeEntity>
                                    {
                                        new ExpenseTypeEntity
                                        {
                                            Type= "Representacion"
                                        }
                                    }
                            }
                        }
            });

            _dataContext.Trips.Add(new TripEntity
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                City = "Cali",
                Description = "Adquisicion mano de obra",
                Expenses = new List<ExpenseEntity>
                        {
                            new ExpenseEntity
                            {
                                Date = DateTime.UtcNow,
                                Value = 150000,
                                ExpenseTypes = new List<ExpenseTypeEntity>
                                    {
                                        new ExpenseTypeEntity
                                        {
                                            Type= "Alimentacion"
                                        }
                                    }
                            },
                            new ExpenseEntity
                            {
                                Date = DateTime.UtcNow,
                                Value = 175000,
                                ExpenseTypes = new List<ExpenseTypeEntity>
                                    {
                                        new ExpenseTypeEntity
                                        {
                                            Type= "Hospedaje"
                                        }
                                    }
                            }
                        }
            });

            await _dataContext.SaveChangesAsync();
        }
    }
}
