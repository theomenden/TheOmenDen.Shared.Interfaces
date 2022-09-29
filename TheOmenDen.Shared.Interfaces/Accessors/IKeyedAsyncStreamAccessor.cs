namespace TheOmenDen.Shared.Interfaces.Accessors;

/// <summary>
/// Defines asynchronous streaming methods to allow retrieval of entities matching a supplied key
/// </summary>
/// <typeparam name="TResult">The result of the operation</typeparam>
/// <typeparam name="TEntity">The entity returned</typeparam>
public interface IKeyedAsyncStreamAccessor<TResult, TEntity>
{
    /// <summary>
    /// A relatively stable retrieval operation meant to provide the caller with a per-entity result based on the provided <paramref name="key"/>
    /// </summary>
    /// <typeparam name="TKey">The type of key we will be using</typeparam>
    /// <param name="key">The provided key to search under</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the coupling between (<typeparamref name="TResult"/> and <typeparamref name="TEntity"/>) allowing for further processing and error handling per response</returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<(TResult Result, TEntity Entity)> GetAllAsyncStream<TKey>(TKey key, CancellationToken cancellationToken = new())
        where TKey : IEntityKey;

    /// <summary>
    /// A relatively stable retrieval operation meant to provide the caller with a per-entity result based on the provided list of <paramref name="keys"/>
    /// </summary>
    /// <typeparam name="TKey">The type of key we will be using</typeparam>
    /// <param name="keys">The provided keys to search under</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the coupling between (<typeparamref name="TResult"/> and <typeparamref name="TEntity"/>) allowing for further processing and error handling per response</returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<(TResult Result, TEntity Entity)> GetAllThatMatchKeysAsyncStream<TKey>(IEnumerable<TKey> keys, CancellationToken cancellationToken = new())
        where TKey : IEntityKey;
}
