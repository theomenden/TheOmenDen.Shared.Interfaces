namespace TheOmenDen.Shared.Interfaces.Accessors;
/// <summary>
/// Defines a set of methods for retrieving an entity by a provided key
/// </summary>
/// <typeparam name="TKey">The key to search with</typeparam>
/// <typeparam name="TResult">The operation result</typeparam>
/// <typeparam name="TEntity">The entity we want to return</typeparam>
public interface IKeyedAccessor<in TKey, TResult, TEntity> where TKey : IEntityKey
{
    /// <summary>
    /// Returns a single <typeparamref name="TEntity"/> based off of the provided <typeparamref name="TKey"/> <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A coupling of the <typeparamref name="TResult"/> and <typeparamref name="TKey"/></returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    ValueTask<(TResult Result , TEntity Entity)> GetByKeyAsync(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// Returns a collection of <typeparamref name="TEntity"/>s that match the specified properties given by the <typeparamref name="TKey"/>  <paramref name="key"/>
    /// </summary>
    /// <param name="key">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A coupling of the <typeparamref name="TResult"/> and <typeparamref name="TKey"/></returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    ValueTask<(TResult Result, IEnumerable<TEntity> Entities)> GetAllAsync(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// Returns a collection of <typeparamref name="TEntity"/> that match the specified properties given by the provided set of <typeparamref name="TKey"/>  <paramref name="keys"/>
    /// </summary>
    /// <param name="keys">The key we're using</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A coupling of the <typeparamref name="TResult"/> and <typeparamref name="TKey"/></returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    ValueTask<(TResult Result, IEnumerable<TEntity> Entities)> GetAllThatMatchKeysAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = new());
}