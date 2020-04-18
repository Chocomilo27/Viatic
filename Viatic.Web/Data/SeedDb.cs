using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Helpers;
using Viatic.Common.Enums;
using Viatic.Web.Data.Entities;

namespace Viatic.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "jzuluaga55@gmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Admin);
            var employee1 = await CheckUserAsync("3030", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", UserType.Employee);
            var employee2 = await CheckUserAsync("4040", "Juan", "Zuluaga", "juanzuluaga2480@correo.itm.edu.co", "350 634 2747", "Calle Luna Calle Sol", UserType.Employee);
            await CheckTripAsync(employee1, employee2);
        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,          //We are seding email to both fields, because we want to asing the email for Username for every user.
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456"); // 123456 Password for every user.
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());

        }

        private async Task CheckTripAsync(
            UserEntity employee1,
            UserEntity employee2)
        {
            if (!_dataContext.Trips.Any())
            {
                _dataContext.Trips.Add(new TripEntity
                {
                    User = employee1,
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

                                },
                                new ExpenseEntity
                                {
                                    Date = DateTime.UtcNow,
                                    Value = 225000,

                                }
                            }
                });

                _dataContext.Trips.Add(new TripEntity
                {
                    User = employee2,
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

                                },
                                new ExpenseEntity
                                {
                                    Date = DateTime.UtcNow,
                                    Value = 175000,

                                }
                            }
                });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
