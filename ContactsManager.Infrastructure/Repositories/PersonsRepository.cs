using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PersonsRepository> _logger;
        public PersonsRepository(ApplicationDbContext db, ILogger<PersonsRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Person> AddPerson(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeletePersonByPersonID(Guid personID)
        {
            _db.Persons.RemoveRange(_db.Persons.Where(temp => temp.PersonID == personID));
            int deletedRow = await _db.SaveChangesAsync();
            return deletedRow > 0;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            _logger.LogInformation("GetAllPersons of PersonsRepository");
            return await _db.Persons.Include("Country").ToListAsync();
        }

        public async Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate)
        {
            _logger.LogInformation("GetFilteredPersons of PersonsRepository");
            return await _db.Persons.Include("Country").Where(predicate).ToListAsync();
        }

        public async Task<Person?> GetPersonByPersonId(Guid personID)
        {
            return await _db.Persons.Include("Country").FirstOrDefaultAsync(temp => temp.PersonID == personID);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            Person? mactchingPerson = await _db.Persons.FirstOrDefaultAsync(temp => temp.PersonID == person.PersonID);

            if (mactchingPerson == null)
            {
                return person;
            }

            mactchingPerson.PersonName = person.PersonName;
            mactchingPerson.Email = person.Email;
            mactchingPerson.DateOfBirth = person.DateOfBirth;
            mactchingPerson.Gender = person.Gender;
            mactchingPerson.CountryID = person.CountryID;
            mactchingPerson.Address = person.Address;
            mactchingPerson.ReceiveNewsLetters = person.ReceiveNewsLetters;

            int countUpdated = await _db.SaveChangesAsync();

            return mactchingPerson;
        }
    }
}
