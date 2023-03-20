using System.Linq.Expressions;
using TheOmenDen.Shared.Specifications;

namespace TheOmenDen.Shared.Interfaces.Accessors;
/// <summary>
/// Defines methods for retrieving entities of  Type <typeparamref name="T"/> as a stream of data
/// </summary>
/// <typeparam name="T">The underlying type to return</typeparam>
/// <remarks>Only defines READ methods that must be iterated over with <c>await foreach()</c></remarks>
public interface IAsyncStreamAccessor<T>
{
    /// <summary>
    /// Retrieves all entities of type <typeparam name="T"></typeparam> from their respective tables in the database
    /// </summary>    
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the entities (<see cref="IAsyncEnumerable{T}"/>) of type <typeparamref name="T"/></returns>
    IAsyncEnumerable<T> GetAllAsAsyncStream(CancellationToken cancellationToken = new());
    /// <summary>
    /// Retrieves all entities of type <typeparam name="T"></typeparam> that match the given <param name="predicate"></param>
    /// </summary>
    /// <param name="predicate">A list of conditions to match against</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the entities (<see cref="IAsyncEnumerable{T}"/>) of type <typeparamref name="T"/></returns>
    IAsyncEnumerable<T> GetAllThatMatchAsAsyncStream(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = new());
    /// <summary>
    /// Retrieves all entities of type <typeparam name="T"></typeparam> that satisfy the given <param name="specification"></param>
    /// </summary>
    /// <param name="specification">The specification that we're trying to satisfy</param>
    /// <param name="cancellationToken"></param>
    /// <returns>An asynchronous stream of the entities (<see cref="IAsyncEnumerable{T}"/>) of type <typeparamref name="T"/></returns>
    IAsyncEnumerable<T> GetAllThatMatchAsAsyncStream(Specification<T>  specification, CancellationToken cancellationToken = new());
}