# Dependency Inversion Principle (DIP)

## Definition

- High-level modules should not depend on low-level modules. Both should depend on abstractions.
- Abstractions should not depend on details. Details should depend on abstractions.

## The Problem

When high-level business logic directly depends on low-level implementation details:
- Changes in low-level modules force changes in high-level modules
- Code becomes tightly coupled and hard to test
- Cannot easily swap implementations
- Difficult to mock dependencies for testing

## The Solution

Depend on interfaces or abstract classes instead of concrete implementations. Use dependency injection to provide the concrete implementations at runtime.

## Examples in This Directory

### Before: Violation of DIP
`OrderProcessorBad.cs` - Directly depends on concrete implementations like SqlDatabase and EmailSender

### After: Following DIP
- `IOrderRepository.cs` - Abstraction for data access
- `INotificationService.cs` - Abstraction for notifications
- `SqlOrderRepository.cs` - SQL implementation
- `EmailNotificationService.cs` - Email implementation
- `OrderProcessor.cs` - High-level logic depending only on abstractions

## Benefits

- **Loose coupling**: Components are independent and interchangeable
- **Easier testing**: Can inject mock implementations for unit tests
- **Flexibility**: Easy to swap implementations (e.g., SQL to NoSQL, Email to SMS)
- **Better separation of concerns**: Business logic separated from infrastructure

## Key Takeaways

- Program to an interface, not an implementation
- Use dependency injection to provide concrete implementations
- High-level policy should not depend on low-level details
- Both should depend on abstractions
