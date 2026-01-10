# Factory Pattern

## Definition

The Factory Pattern defines an interface for creating objects, but lets subclasses or implementing classes decide which class to instantiate. It encapsulates object creation logic.

## The Problem

- Creating objects directly using `new` keyword couples code to specific classes
- Complex object creation logic scattered throughout the codebase
- Difficult to add new types without modifying existing code
- Hard to test when you need to create different variants

## The Solution

Create a factory class or method that encapsulates the object creation logic. Clients request objects from the factory without knowing the concrete classes being instantiated.

## Examples in This Directory

### Simple Factory
`PaymentProcessorFactory.cs` - Creates payment processors based on payment type

### Factory Method Pattern
- `ShippingCalculator.cs` - Abstract base class with factory method
- `DomesticShippingCalculator.cs` - Creates domestic shipping strategies
- `InternationalShippingCalculator.cs` - Creates international shipping strategies

## Benefits

- **Decouples client code** from concrete classes
- **Centralizes creation logic** in one place
- **Easy to extend** with new types
- **Follows Open/Closed Principle** - open for extension, closed for modification
- **Easier testing** with mock objects

## Key Takeaways

- Use when object creation is complex or conditional
- Helps maintain Single Responsibility Principle
- Client code depends on abstractions, not concrete classes
- Makes it easy to introduce new types
