using Entities;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Person entity
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Add a new country object to the data store
        /// </summary>
        /// <param name="person">Country object to add</param>
        /// <returns>Return the country object after adding it to the data store.</returns>
        Task<Country> AddCountry(Country country);

        /// <summary>
        /// Returns all countries in the data store
        /// </summary>
        /// <returns>All countries from the table</returns>
        Task<List<Country>> GetAllCountries();

        /// <summary>
        /// Return the country object based on the given country id otherwise it return null
        /// </summary>
        /// <param name="countryId">CountryId to search</param>
        /// <returns>Matching country or null</returns>
        Task<Country?> GetCountryByCountryId(Guid countryId);

        /// <summary>
        /// Return a country object based on the given country name
        /// </summary>
        /// <param name="countryName">Country name to search.</param>
        /// <returns>Matching country or null</returns>
        Task<Country?> GetCountryByCountryName(string countryName); 
    }
}
