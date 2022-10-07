namespace TheOmenDen.Shared.Interfaces.Accessors;

/// <summary>
/// <para>Contains method signatures for retrieving random entites from a given source.</para>
/// <para>We aim to use some sort of mechanism for randomization such as the ones provided by <see href="https://www.nuget.org/packages/TheOmenDen.Shared">The Omen Den's Shared Library</see></para>
/// </summary>
public interface IRandomDataAccessor
{
    /// <summary>
    /// Retrieve an entity at random from a particular set of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type we're working with</typeparam>
    /// <returns>A single <typeparamref name="T"/></returns>
    T GetRandomEntity<T>();

    /// <summary>
    /// Retrieve an entity at random from a particular set of <typeparamref name="T"/> - asynchronously
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Task{TResult}"/>: A single <typeparamref name="T"/></returns>
    Task<T> GetRandomEntityAsync<T>(CancellationToken cancellationToken = new());

    /// <summary>
    /// Retrive a subset of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entites we want to populate randomly</param>
    /// <returns></returns>
    IEnumerable<T> GetRandomEntities<T>(int numberOfEntitiesToRetrieve);

    /// <summary>
    /// Retrieves a subset of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entites we want to populate randomly</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="Task{TResult}"/>: <see cref="IEnumerable{T}"/> of <typeparamref name="T"/></returns>

    Task<IEnumerable<T>> GetRandomEntitiesAsync<T>(int numberOfEntitiesToRetrieve, CancellationToken cancellationToken = new());

    /// <summary>
    /// Retrieves a subset stream of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entities we want to populate randomly</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="IAsyncEnumerable{T}"/>: of <typeparamref name="T"/></returns>
    IAsyncEnumerable<T> GetRandomEntityStreamAsync<T>(int numberOfEntitiesToRetrieve, CancellationToken cancellationToken = new());
}