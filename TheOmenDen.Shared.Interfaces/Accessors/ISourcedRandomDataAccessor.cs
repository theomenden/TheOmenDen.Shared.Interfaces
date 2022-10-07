namespace TheOmenDen.Shared.Interfaces.Accessors;

/// <summary>
/// <para>Contains method signatures for retrieving random entites from a provided source.</para>
/// <para>We aim to use some sort of mechanism for randomization such as the ones provided by <see href="https://www.nuget.org/packages/TheOmenDen.Shared">The Omen Den's Shared Library</see></para>
/// </summary>
/// <remarks>Note: The difference between this set of methods, and the ones defined in <see cref="IRandomDataAccessor"/> is the inclusion of a source enumerable/collection here. Thus the caller must provide the source instead of generating it.</remarks>
public interface ISourcedRandomDataAccessor
{

    /// <summary>
    /// Retrieve an entity at random from the provided <paramref name="source"/> set of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type we're working with</typeparam>
    /// <param name="source"> The source enumerable</param>
    /// <returns>A single <typeparamref name="T"/></returns>
    T GetRandomEntity<T>(IEnumerable<T> source);

    /// <summary>
    /// Retrieve an entity at random from the provided <paramref name="source"/> set of <typeparamref name="T"/> - asynchronously
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source enumerable</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A <see cref="Task{TResult}"/>: A single <typeparamref name="T"/></returns>
    Task<T> GetRandomEntityAsync<T>(IEnumerable<T> source, CancellationToken cancellationToken = new());

    /// <summary>
    /// Retrive a subset of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities from the given <paramref name="source"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entites we want to populate randomly</param>
    /// <param name="source">The supplied superset</param>
    /// <returns></returns>
    IEnumerable<T> GetRandomEntities<T>(int numberOfEntitiesToRetrieve, IEnumerable<T> source);


    /// <summary>
    /// Retrive a subset of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities from the given <paramref name="source"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entites we want to populate randomly</param>
    /// <param name="source">The supplied superset</param>
    /// <returns><see cref="Task{TResult}"/>: <see cref="IEnumerable{T}"/> of <typeparamref name="T"/></returns>
    Task<IEnumerable<T>> GetRandomEntitiesAsync<T>(int numberOfEntitiesToRetrieve, IEnumerable<T> source, CancellationToken cancellationToken);


    /// <summary>
    /// Retrieves a subset stream of size <paramref name="numberOfEntitiesToRetrieve"/> of random <typeparamref name="T"/> entities from the provided <paramref name="source"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numberOfEntitiesToRetrieve">The number of entities we want to populate randomly</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="IAsyncEnumerable{T}"/>: of <typeparamref name="T"/></returns>
    IAsyncEnumerable<T> GetRandomEntityStreamAsync<T>(int numberOfEntitiesToRetrieve, IAsyncEnumerable<T> source, CancellationToken cancellationToken = new());

}
