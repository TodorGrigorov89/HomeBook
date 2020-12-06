namespace HomeBook.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var users =
                await this.usersRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();

            return users;
        }
    }
}
