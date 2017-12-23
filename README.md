# mediatr-crm

Reference project for using: Mediatr, Web API, .NET Core 2.0

## Command Query vs Repository

Both Command Query and Repository address the Abstracting data and business logic in a way that helps to simplify unit testing.

There is a detailed blog post [here](https://cuttingedge.it/blogs/steven/pivot/entry.php?id=92).

## Repository Implemention

1. Create an IRepository<T> for each entity
1. Add methods to the each repository file as needed

```csharp
public interface IContactRepository {
    IEnumerable<Contact> GetAll();
    Contact GetById(string id);
}
```

## Typical Repository Pitfalls

### Large Files

In a team environment, larges files result in choke points during development. Devs must spend time resolving code conflicts and merging code. More merges increases the chances of losing code.

To avoid this, generally code files should not exceed about 400 lines

### DRY: Don't Repeat Yourself

Often, repository methods are a duplicate of Web API calls. So, why use a repository?

> Sometimes, you get to share methods in repositories among multiple API calls.

```csharp
// UserController.cs
public class UserController {
    readonly IUserRepository userRepository;

    UserController(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public Task<Contact> Get(string id) {
        return this.userRepository.Get(id);
    }
}

// IUserRepository.cs
public interface IUserRepository {
    User Get(string id);
}
```

### Fat Repositories

Usually, pretty quickly, devs will dump many methods/scenarios into a repository. The end result is a large, difficult-to maintain file.

### Confusion: Where does this go?

Scenario: I need to add an API to associate users with managers. Should I put the method in IUserRepository or IManagerRepository? Or make a new repository or service

### Cross Entity Concerns

Scenario: My API call requires queries against `User`, `Permission`, `Order`, and `OrderLine` entities. How do I handle this?

Generally, this ends up being handed in the API controller. Now you have business logic scattered throughout multiple layers of the API. And you end up with a Fat controller file with complex constructor.

> A complex contructor results in brittle unit tests!

```csharp
public class OrderController {
    readonly IUserRepository userRepository;
    readonly IOrderRepository orderRepository;
    readonly IOrderLineRepository orderLineRepository;
    readonly IPermissionRepository permissionRepository;

    UserController(
        IUserRepository userRepository,
        IOrderRepository IOrderRepository,
        IOrderLineRepository orderLineRepository,
        IPermissionRepository permissionRepository
        ) {
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
        this.orderLineRepository = orderLineRepository;
        this.permissionRepository = permissionRepository;
    }
}
```

### Ceremony

Most frameworks require some sort of wiring up and/or configuration of components.

For a Repository Pattern implementation, there are at least these steps (generally, there are more):

```csharp
/**
  *
  * ADD NEW REPOSITORY
  */

// 1. Add a new interface
public interface IMyRepository {
	// contracts
}

// 2. Add a implementation
public class MyRepository {
	// implementations
}

// 3. Wire up in DI in the application
services.AddScoped<IMyRepository, MyRepository>();

// 4. Inject into controller(s)

// 5. Unit tests are now broken. Therefor, update unit tests and add mocks for IMyRepository where needed.

/**
  * Add an new repository action
  */
// 1. Add contract in repository interface
// 2. Implement method
// 3. Add unit tests
```

2. Add a new implementation: `MyRepository`
3. Wire up in DI container

## Command Query Object Pattern and Mediatr

With Command Query Object pattern, `Requests` are defined and `Request Handlers` response to the request.

### Concerns

What does code look like for the following:

* Security?
* Validation?
* Exception Handling?
* Ease of use?
* Logging?
* Analytics?
* Testability?
* Pagination?
* Queryability?
* Patch support?
