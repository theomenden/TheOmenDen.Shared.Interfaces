namespace TheOmenDen.Shared.Interfaces.Services;
public interface IExtendedSetOperations<T>: IEnumerable<T>
{

    /// <summary>
    /// Allows a pseudo-random provder to randomize the provided <paramref name="source"/> for a given amount of <paramref name="permutations"/>.
    /// </summary>
    /// <param name="source">The source enumerable</param>
    /// <param name="permutations"></param>
    /// <returns>>A randomized copy of <paramref name="source"/></returns>
    IEnumerable<T> Permutate(IEnumerable<T> source, Int32 permutations);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    IEnumerable<T> Reflect(IEnumerable<T> source);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    IEnumerable<T> Identity(IEnumerable<T> source);

    IEnumerable<T> DeMorgan(IEnumerable<T> setA, IEnumerable<T> setB, Delegate operation);
}
