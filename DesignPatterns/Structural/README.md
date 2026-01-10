# Structural Patterns

## Overview

Structural patterns explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient.

## Patterns in This Directory

### Adapter Pattern
`Adapter.cs` - Allows incompatible interfaces to work together

**Use when:**
- You want to use an existing class with an incompatible interface
- You need to integrate third-party libraries
- You want to create reusable classes that work with unrelated classes

**Benefits:**
- Integrates incompatible interfaces
- Increases reusability of existing code
- Follows Single Responsibility Principle
- Follows Open/Closed Principle

### Decorator Pattern
`Decorator.cs` - Adds new functionality to objects dynamically

**Use when:**
- You need to add responsibilities to objects dynamically
- Extension by subclassing is impractical
- You want to add features in a mix-and-match fashion

**Benefits:**
- More flexible than inheritance
- Avoids feature-laden classes high up in the hierarchy
- Responsibilities can be added/removed at runtime
- Follows Single Responsibility Principle
- Follows Open/Closed Principle

## Key Concepts

### Composition Over Inheritance
Both patterns demonstrate the principle of favoring object composition over class inheritance:
- **Adapter**: Wraps an object to convert its interface
- **Decorator**: Wraps an object to add new behavior

### Flexibility
These patterns provide flexibility in how objects work together:
- Adapter makes incompatible things work
- Decorator enhances functionality without changing the original

## Common Use Cases

**Adapter:**
- Payment gateway integration
- Database driver wrappers
- Legacy system integration
- Third-party API integration

**Decorator:**
- UI component enhancement
- Stream processing (BufferedStream, GZipStream)
- Notification systems with multiple channels
- Adding features to existing objects at runtime
