namespace TheOmenDen.Shared.Interfaces.Accessors;
/// <summary>
/// Defines a set of methods for retrieving an entity by a provided key
/// </summary>
/// <typeparam name="TKey">The key to search with</typeparam>
/// <typeparam name="TResult">The operation result</typeparam>
public interface IKeyedAccessor<in TKey, TResult>
    where TKey : IEntityKey
    where TResult : IEntity, IEntity<TResult>
{
    /// <summary>
    /// Returns a single <typeparamref name="TResult"/> based off of the provided <typeparamref name="TKey"/> <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A <typeparamref name="TResult"/></returns>
    ValueTask<TResult> GetByKeyAsync(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// Returns a collection of <typeparamref name="TResult"/>s that match the specified properties given by the <typeparamref name="TKey"/>  <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A <typeparamref name="TResult"/></returns>
    ValueTask<IEnumerable<TResult>> GetAllAsync(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// Returns a collection of <typeparamref name="TResult"/> that match the specified properties given by the provided set of <typeparamref name="TKey"/>  <paramref name="keys"/>
    /// </summary>
    /// <param name="keys">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A <typeparamref name="TResult"/></returns>
    ValueTask<IEnumerable<TResult>> GetAllThatMatchKeysAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = new());
}