namespace ProjectTemplate.DataAccess
{
    /// <summary>
    /// Abstract factory interface.
    /// </summary>
    public interface IDaoFactory
    {
        /// <summary>
        /// Gets a user data access object.
        /// </summary>
        IUserDao UserDao { get; }


        ////IProductDao ProductDao { get; }
    }
}