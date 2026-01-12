# Liskov Substitution Principle (LSP)

## Definition

Objects of a superclass should be replaceable with objects of its subclasses without breaking the application. Derived classes must be substitutable for their base classes.

## The Problem

When derived classes don't properly implement the behavior of their base class:
- Code that works with the base class breaks when using derived classes
- Violates the contract established by the base class
- Forces clients to know about specific derived types
- Leads to brittle code with type checking

## The Solution

Ensure derived classes extend base class behavior without changing expected behavior. Derived classes should honor the contract of the base class.

## Examples in This Directory

### Before: Violation of LSP
`BirdBad.cs` - Penguin can't fly, breaking the Bird contract

### After: Following LSP
- `Bird.cs` - Base class with common bird behavior
- `FlyingBird.cs` - Abstract class for birds that can fly
- `Sparrow.cs` - Flying bird implementation
- `Penguin.cs` - Non-flying bird that doesn't violate LSP

## Benefits

- **Polymorphism works correctly**: Can use derived types interchangeably
- **Reliable behavior**: Derived classes honor base class contracts
- **Less type checking**: No need for `is` or `as` operators
- **Better inheritance hierarchies**: More logical class structures

## Key Takeaways

- Derived classes should strengthen, not weaken, base class contracts
- If you need to check the type, you probably violated LSP
- Prefer composition over inheritance when behavior differs significantly
- "Is-a" relationship must be behavioral, not just conceptual
