using TheOmenDen.Shared.Interfaces.Models;
using IEntityKey = TheOmenDen.Shared.Interfaces.Models.IEntityKey;
using IEntity = TheOmenDen.Shared.Interfaces.Models.IEntity;
namespace TheOmenDen.Shared.Interfaces.Accessors;

/// <summary>
/// Defines asynchronous streaming methods to allow retrieval of entities matching a supplied key
/// </summary>
/// <typeparam name="TResult">The result(s) of the operation</typeparam>
/// <typeparam name="TKey">The key used for retrieving the resulting entity returned</typeparam>
public interface IKeyedAsyncStreamAccessor<in TKey, out TResult>
    where TKey : IEntityKey
    where TResult : IEntity, IEntity<TResult>
{
    /// <summary>
    /// A relatively stable retrieval operation meant to provide the caller with a per-entity result based on the provided <paramref name="key"/>
    /// </summary>
    /// <param name="key">The provided key to search under</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the coupling between (<typeparamref name="TResult"/> and <typeparamref name="TEntity"/>) allowing for further processing and error handling per response</returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<TResult> GetAllAsyncStream(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// A relatively stable retrieval operation meant to provide the caller with a per-entity result based on the provided list of <paramref name="keys"/>
    /// </summary>
    /// <param name="keys">The provided keys to search under</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>An asynchronous stream of the coupling between (<typeparamref name="TResult"/> and <typeparamref name="TEntity"/>) allowing for further processing and error handling per response</returns>
    /// <remarks><typeparamref name="TResult" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<TResult> GetAllThatMatchKeysAsyncStream(IEnumerable<TKey> keys, CancellationToken cancellationToken = new());
}
