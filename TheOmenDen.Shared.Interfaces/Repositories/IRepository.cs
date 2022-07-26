namespace TheOmenDen.Shared.Interfaces.Repositories;

/// <summary>
/// <inheritdoc cref="IEnumerable{T}"/>
/// </summary>
/// <typeparam name="T">The type that we're exposing</typeparam>
public interface IRepository<out T> : IEnumerable<T>
{
}