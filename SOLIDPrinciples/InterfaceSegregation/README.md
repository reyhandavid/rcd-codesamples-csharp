# Interface Segregation Principle (ISP)

## Definition

Clients should not be forced to depend on interfaces they do not use. Many specific interfaces are better than one general-purpose interface.

## The Problem

When interfaces are too large (fat interfaces):
- Classes are forced to implement methods they don't need
- Changes to the interface affect all implementing classes
- Harder to understand what a class actually does
- Violates Single Responsibility Principle

## The Solution

Split large interfaces into smaller, more specific interfaces. Classes can implement multiple small interfaces rather than one large one.

## Examples in This Directory

### Before: Violation of ISP
`IWorkerBad.cs` - Fat interface forcing all workers to implement all methods

### After: Following ISP
- `IWorkable.cs` - Interface for workers who can work
- `IEatable.cs` - Interface for workers who need to eat
- `ISleepable.cs` - Interface for workers who need to sleep
- `HumanWorker.cs` - Implements all interfaces
- `RobotWorker.cs` - Only implements IWorkable

## Benefits

- **Flexibility**: Classes only implement what they need
- **Easier maintenance**: Changes to one interface don't affect unrelated classes
- **Better code organization**: Clear separation of responsibilities
- **Easier testing**: Mock only the interfaces you need

## Key Takeaways

- Keep interfaces small and focused
- One interface per responsibility
- Clients should depend only on methods they use
- Prefer role interfaces over header interfaces
