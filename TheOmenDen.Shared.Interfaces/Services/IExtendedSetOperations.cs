namespace TheOmenDen.Shared.Interfaces.Services;
public interface IExtendedSetOperations<T>: IEnumerable<T>
{
    /// <summary>
    /// Allows a pseudo-random provider to randomize the provided <paramref name="source"/> for a given amount of <paramref name="permutations"/>.
    /// </summary>
    /// <param name="source">The source enumerable</param>
    /// <param name="permutations"></param>
    /// <returns>>A randomized copy of <paramref name="source"/></returns>
    IEnumerable<T> Permute(IEnumerable<T> source, Int32 permutations);
    /// <summary>
    /// Applies a logical reflection to the given <paramref name="source"/> set
    /// </summary>
    /// <param name="source">The set we wish to reflect</param>
    /// <returns>The reflected Enumerable</returns>
    IEnumerable<T> Reflect(IEnumerable<T> source);
    /// <summary>
    /// Applies a predefined Identity operation to the provided <paramref name="source"/>
    /// </summary>
    /// <param name="source"></param>
    /// <returns>The <paramref name="source" /> unchanged</returns>
    IEnumerable<T> Identity(IEnumerable<T> source);
    /// <summary>
    /// Applies the logical DeMorgan Laws to the provided <paramref name="setA"/> and <paramref name="setB"/> 
    /// </summary>
    /// <param name="setA">The first set</param>
    /// <param name="setB">The second set</param>
    /// <returns>The result from the Operation in an <see cref="IEnumerable{T}"/></returns>
    IEnumerable<T> DeMorgan(IEnumerable<T> setA, IEnumerable<T> setB);
}
