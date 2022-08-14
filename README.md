# TheOmenDen Shared Interfaces

## A collection of interfaces present in The Omen Den's applications

### Below are descriptions to the best of my ability for what each section in the namespaces defines.

## 1. Accessors
- `IAccessor`
  - Allows for simple access to read only methods defined across an entity.
  - Works for Database entities, and other areas where you need to limit to **_read only methods_**.
- `IAsyncStreamAccessor`
  - ALlows for asynchronous streaming access to read only methods defined across an entity.
  - Allows for `await foreach` by way of returning an `IAsyncEnumerable`.
- `IKeyedAccessor`
  - Allows for a bit more complicated access to read only methods defined across an entity.
  - Working with `IEntityKey` as the prevealent key to allow for searching across conditions.
  - Methods defined here return a `Tuple` combination of the **Result** and the corresponding entities retrieved.
    - The result specified is a boolean indicating whether the underlying operation was successful `True` on success, otherwise `False`.
    - This is to hopefully guide the implementation away from throwing an exception when the operation is unsuccessful. 
- `IKeyedAsyncStreamAccessor`
  - Similar to the `IKeyedAccessor` but returns only the`IAsyncEnumerable` stream
  - Allows for streaming access to read only methods defined across an keyed entities, and returns matches for the provided key. 
## 2. Repositories
- `IRepository`
  - A covariant interface that requires the implementation to also implement `IEnumerable`.
  - Defines methods for Adding/Creating, Updating, and Deleting entties with `CancellationToken` support on asynchronous methods.
  - This will allow for accessing the underlying methods of the repository with `System.Linq` as well as `foreach` loops.
- `IStreamingRepository`
  - A covariant interface that requires the implementation to also implement `IAsyncEnumerable`.
  - Defines methods for Adding/Creating, Updating, and Deleting entties with `CancellationToken` support on asynchronous methods.
  - This will allow for asynchronous streaming access of the underlying methods via `System.Linq.Async` as well as `await foreach` loops.
- `IDataOperations`
  - A combination interface that contains the methods defined in both `IRepository` and `IStreamingRepository`.
  - Defines methods for Adding/Creating, Updating, and Deleting entties with `CancellationToken` support on asynchronous methods.
  - This allows for a flexible approach to methods within the implementation to incorporate traditional methods, as well as asynchronous streaming.
- `IKeyedDataOperations`
  - A combination interface that contains the methods defined in both `IRepository` and `IStreamingRepository`.
    - To better distinguish between `IDataOperations` and `IKeyedDataOperations`.
      1. There's the additional **_constrained_** generic parameter `TKey` which requires that the key be provided during construction of an implementation, as well as be of type `IEntityKey`.
      2. This is intentional since we should be approaching these methods with relative caution, and capture the intent, and rational for object manipulation.   
  - Defines methods for Adding/Creating, Updating, and Deleting entties with `CancellationToken` support on asynchronous methods.
  - A mjaor difference between this interface and `IDataOperations` is that the results of each method to implement requires a return value. of `Tuple{TResult, TEntity}` 
    -  `TResult` is typically a boolean, but could signify any sort of indicator of the success or failure of the operation.
    -  This was done to hopefully discourage exception throwing in the implementations and define a "peaceful" approach to handling failures.
    -  This approach does present a tighter coupling between the results of the operation and the Entity(or entities) returned.
## 3. Models
- `IUser`
  - A simple interface to mark the definition of a `user`.
    - `Id` - a GUID/UUID that allows for easy storage and retrieval of user information.
    - `Email` - an individual's email address.
    - `Name` - the name of the user.
    - `IsAuthenticated` - indicates whether the user is authenticated.
    - `Key` - the key associated with the user (integer based).
- `ITenant`
  - A representation of the container for organization/business items, logic, and information.
    - `Id` - a GUID/UUID that allows for easy storage and retrieval of tenant information.
    - `Code` - The code associated with the tenant.
    - `Name` - the name of the tenant.
    - `Key` - the key associated with the tenant (integer based).
- `IEntityKey`
  - Provides a generic interpretation to help distinguish entities from each other.
    - `Id` - a GUID/UUID that allows for easy storage and retrieval.
    - `CreatedAt` - a timestamp marking the entity's creation.
    - `ITenant` - The Tenant that entity is associated with.
    - `IUser` - the originator/creator of the entity.  
- `IEntity`
  - A simple marker interface that provides an implementation with a way to define a unique `IEntityKey` on an Entity.
    - `IEntityKey` the unique key associated with the entity.
## 4. Services
- `IApiService` and `IApiService<T>`
  - `IApiService` is an empty interface.
    - This was done for ease of implementation when it came to dependency injection in implementations with `Scrutor`.
  - `IApiService<T>` contains CRUD methods that can be used to retrieve and alter information via an external API.
    - CRUD methods are defined to `GET`, `POST`, `PUT`, `DELETE` and all provide `CancellationToken` support.
 - `IStreamingApiService` and `IStreamingApiService<T>`
   - `IStreamingApiService` is an empty interface.
     - This was done for ease of implementation when it came to dependency injection in implementations with `Scrutor`.
   - `IstreamingApiService<T>`- Defines two different methods of retrieving results from an external API. These methods do allow for `CancellationToken` support.
     - `StreamApiResultsAsync` - Returns an `IASyncEnumerable<ApiResponse>`.
       - `ApiResponse` - from TheOmenDen.Shared project. 
       - This was done to allow for failure of individual objects contained in the response body, while still allowing for streaming of the results.
       - Enumerate with `await foreach`
     - `EnumerateApiResultsAsync` - Returns a `Task<ApiResponse<IEnumerable<T>>>`
       - This will retrieve the results from the api whiel the header content is read, and before the entire result set is read.
       - This was done to provide an easy implementation and encourage the use of the `System.Text.Json JsonSerializer`'s ability to read through streams.
## ToDos
  - Define more constructive interfaces
  - Refine the use cases of currently defined interfaces
  - Improve the functionality and performance of interfaces
  - Provide ways for source generators to be used
