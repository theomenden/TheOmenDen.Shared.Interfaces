using TheOmenDen.Shared.Utilities;

namespace TheOmenDen.Shared.Interfaces.Services;

/// <summary>
/// <para>The purpose of this interface is to provide a way for randomizing elements by utilizing the <see cref="ThreadSafeRandom"/></para>
/// <inheritdoc cref="IDisposable"/>
/// <inheritdoc cref="IAsyncDisposable"/>
/// </summary>
public interface IRandomizerService<T>: IEnumerable<T>, IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Randomizes the provided <paramref name="source"/>
    /// </summary>
    /// <param name="source">Provided (assumed) ordered enumerable</param>
    /// <returns>A randomized copy of <paramref name="source"/></returns>
    IEnumerable<T> Randomize(IEnumerable<T> source);

    /// <summary>
    /// Using a pseudo-random provider (for example <see cref="ThreadSafeRandom"/> -
    /// </summary>
    /// <param name="source"></param>
    /// <param name="random"></param>
    /// <returns></returns>
    IEnumerable<T> Randomize(IEnumerable<T> source, Random random);
}
