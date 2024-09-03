using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Person entity
    /// </summary>
    public interface IPersonsRepository
    {
        /// <summary>
        /// Add person object to data store.
        /// </summary>
        /// <param name="person">Person object to add.</param>
        /// <returns>Return the person object after adding it to the table</returns>
        Task<Person> AddPerson(Person person);

        /// <summary>
        /// Return all persons in the data store
        /// </summary>
        /// <returns>List of person objects from table.</returns>
        Task<List<Person>> GetAllPersons();

        /// <summary>
        /// Return a person object based on the given person id.
        /// </summary>
        /// <param name="personID">PersonID (guid) to search</param>
        /// <returns>A person object or null</returns>
        Task<Person?> GetPersonByPersonId(Guid personID);

        /// <summary>
        /// Return all the person objects based on the given expression
        /// </summary>
        /// <param name="">LINQ expression to check</param>
        /// <returns>All matching person with given condition.</returns>
        Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate);

        /// <summary>
        /// Delete a person object based on the person id.
        /// </summary>
        /// <param name="personID">Person ID (guid) to search</param>
        /// <returns>Returns true, if the deletion is successfull; otherwise false</returns>
        Task<bool> DeletePersonByPersonID(Guid personID);

        /// <summary>
        /// Update a person object (person name and other details) based on the given person id.
        /// </summary>
        /// <param name="person">Person object to update.</param>
        /// <returns>Return the updated person object.</returns>
        Task<Person> UpdatePerson(Person person);
    }
}
