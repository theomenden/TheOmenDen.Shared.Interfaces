namespace TheOmenDen.Shared.Interfaces.Repositories;
/// <summary>
/// <para>This interface aims to define the basic Create, Update, and Delete functionality for entities within the domain</para>
/// <para> By manipulating our results from a given store, a return <see cref="ValueTuple{T1, T2}"/> is possible to reflect the changes that were made</para>
/// <para>This allows for further processing and error handling based on the results, without needing to throw exceptions</para>    
/// <inheritdoc cref="IEnumerable{T}"/>
/// <inheritdoc cref="IAsyncEnumerable{T}"/>
/// </summary>
/// <typeparam name="TKey">The key object that we are looking for, must implement <see cref="IEntityKey"/></typeparam>
/// <typeparam name="TValue">The value that we want to operate over</typeparam>
/// <typeparam name="TResultingValue">The result object we aim to have returned to the caller - for example, a <see cref="bool"/> to indicate a success/fail</typeparam>
/// <remarks>Not meant to be compatible with <see cref="IDataOperations{T, TResult}"/></remarks>
public interface IKeyedDataOperations<in TKey, in TValue, TResultingValue> : IEnumerable<TResultingValue>, IAsyncEnumerable<TResultingValue>
  where TKey : IEntityKey
{       
    /// <summary>
    /// An attempt at a relatively stable insertion operation that respects the given <paramref name="key"/>, and allows for underlying <paramref name="manipulativeValues"/> to be distinguished from the originating key.
    /// </summary>
    /// <param name="key">The key object that we are aiming to check against</param>
    /// <param name="manipulativeValues">The values we're aiming to provide with the key</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A result of the operation <typeparamref name="TResultingValue"/></returns>
    /// <remarks><typeparamref name="TResultingValue" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    Task<TResultingValue> AddAsync(TKey key, TValue manipulativeValues, CancellationToken cancellationToken = new());

    /// <summary>
    /// An attempt at a relatively stable update operation that respects the given <paramref name="key"/>, and allows for underlying <paramref name="manipulativeValues"/> to be distinguished from the originating key.
    /// </summary>
    /// <param name="key">The key object that we are aiming to check against</param>
    /// <param name="manipulativeValues">The values we're aiming to provide with the key</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>A result of the operation <typeparamref name="TResultingValue"/></returns>
    /// <remarks><typeparamref name="TResultingValue" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    Task<TResultingValue> UpdateAsync(TKey key, TValue manipulativeValues, CancellationToken cancellationToken = new());

    /// <summary>
    /// An attempt at a relatively stable update operation that respects the provided <paramref name="keys"/> and allows for logic to take place with the underlying <paramref name="manipulativeValues"/> to be distinguished from the originating keys.
    /// </summary>
    /// <param name="keys">The key objects we are aiming to remove</param>
    /// <param name="manipulativeValues">The values we'd like to update in the objects that are referenced by the provided <paramref name="keys"/></param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns><see cref="IAsyncEnumerable{T}"/>: A streaming result of the operation <typeparamref name="TResultingValue"/></returns>
    /// <remarks><typeparamref name="TResultingValue" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<TResultingValue> UpdateAsyncStream(IEnumerable<TKey> keys, IEnumerable<TValue> manipulativeValues, CancellationToken cancellationToken = new());

    /// <summary>
    /// An attempt at a relatively stable deletion operation that respects the given <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key object that we are aiming to check against</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns>The result of the operation <typeparamref name="TResultingValue"/></returns>
    /// <remarks><typeparamref name="TResultingValue" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    Task<TResultingValue> DeleteAsync(TKey key, CancellationToken cancellationToken = new());

    /// <summary>
    /// An attempt at a relatively stable deletion operation that aims to eliminate entities that match the provided <paramref name="keys"/>, and still allow individual error/logical handlings on the calling side
    /// </summary>
    /// <param name="keys">THe key objects we are aiming to remove</param>
    /// <param name="cancellationToken"><inheritdoc cref="CancellationToken"/></param>
    /// <returns><see cref="IAsyncEnumerable{T}"/>: A streaming result of the operation <typeparamref name="TResultingValue"/></returns>
    /// <remarks><typeparamref name="TResultingValue" /> will typically be a <see cref="Boolean"/> value, returning <see langword="true"/> on success, and <see langword="false"/> otherwise</remarks>
    IAsyncEnumerable<TResultingValue> DeleteAsyncStream(IEnumerable<TKey> keys, CancellationToken cancellationToken = new());
}