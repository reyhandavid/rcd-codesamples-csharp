# Open/Closed Principle (OCP)

## Definition

Software entities (classes, modules, functions) should be **open for extension** but **closed for modification**.

## The Problem

When you need to add new functionality, you shouldn't have to modify existing, tested code. Modifying existing code:
- Risks introducing bugs
- Requires retesting everything
- Violates the stability of the codebase

## The Solution

Design your code so that new functionality can be added by extending existing code (through inheritance, interfaces, or composition) rather than modifying it.

## Examples in This Directory

### Before: Violation of OCP
`DiscountCalculatorBad.cs` - Must be modified every time a new discount type is added

### After: Following OCP
- `IDiscountStrategy.cs` - Interface for discount strategies
- `RegularCustomerDiscount.cs` - Regular customer discount implementation
- `VipCustomerDiscount.cs` - VIP customer discount implementation
- `SeasonalDiscount.cs` - Seasonal discount implementation
- `DiscountCalculator.cs` - Calculator that uses strategies without modification

## Benefits

- **Reduced risk**: Existing, tested code remains unchanged
- **Easier to add features**: New functionality through new classes
- **Better stability**: Core system stays stable while being extensible
- **Easier testing**: New features can be tested independently

## Key Takeaways

- Use abstractions (interfaces/abstract classes) to allow extension
- New features should be added through new classes, not by modifying existing ones
- Rely on polymorphism and dependency injection
- Think "plug-in" architecture
