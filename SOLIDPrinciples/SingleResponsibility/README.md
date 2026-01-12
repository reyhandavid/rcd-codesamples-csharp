# Single Responsibility Principle (SRP)

## Definition

A class should have only one reason to change. Each class should have a single, well-defined responsibility.

## The Problem

When a class has multiple responsibilities, changes to one responsibility can affect or break the other responsibilities. This makes the code fragile and harder to maintain.

## The Solution

Separate concerns into different classes, each with a single, clear responsibility.

## Examples in This Directory

### Before: Violation of SRP
`UserServiceBad.cs` - A class that handles too many responsibilities:
- User validation
- User persistence
- Email notifications
- Logging

### After: Following SRP
Multiple classes, each with a single responsibility:
- `User.cs` - User entity
- `UserValidator.cs` - User validation logic
- `UserRepository.cs` - User persistence
- `EmailService.cs` - Email notifications
- `UserService.cs` - Orchestrates user operations

## Benefits

- **Easier to understand**: Each class has a clear, focused purpose
- **Easier to test**: Smaller, focused classes are simpler to unit test
- **Easier to maintain**: Changes are localized to single classes
- **Better reusability**: Single-purpose classes can be reused in different contexts
- **Reduced coupling**: Classes depend on fewer things

## Key Takeaways

- One class, one responsibility
- If you use "and" to describe what a class does, it probably violates SRP
- Think about reasons to change - each reason should belong to a different class
