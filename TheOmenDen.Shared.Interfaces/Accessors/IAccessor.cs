using System.Linq.Expressions;
using TheOmenDen.Shared.Specifications;

namespace TheOmenDen.Shared.Interfaces.Accessors;
/// <summary>
/// Defines methods for retrieving entities
/// </summary>
/// <typeparam name="TResponse">The type of entity we are returning</typeparam>
/// <remarks>Only defines READ methods</remarks>
public interface IAccessor<TResponse>
{
    /// <summary>
    /// Returns all <typeparamref name="TResponse"/> entities from the source
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>An Enumerable of the entities</returns>
    Task<IEnumerable<TResponse>> GetAllAsync(CancellationToken cancellationToken = new());
    /// <summary>
    /// Returns all <typeparamref name="TResponse"/> entities from the source that match the given <paramref name="predicate"/> 
    /// </summary>
    /// <param name="predicate">The supplied condition to match against, compiling down to a <see cref="Expression{Delegate}"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="Task{TResponse}"/> : An Enumerable of the matching Entities</returns>
    Task<IEnumerable<TResponse>> GetAllThatMatchAsync(Expression<Func<TResponse, bool>> predicate, CancellationToken cancellationToken = new());
    /// <summary>
    /// Returns all the <typeparamref name="TResponse"/> entities from the source that satisfy the given <param name="specification" />
    /// </summary>
    /// <param name="specification">The supplied specification to filter against</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="Task{TResponse}"/> : An Enumerable of the matching Entities</returns>
    Task<IEnumerable<TResponse>> GetAllThatMatchAsync(Specification<TResponse>  specification, CancellationToken cancellationToken = new());
}