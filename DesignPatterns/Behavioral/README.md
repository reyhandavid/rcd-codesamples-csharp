# Strategy Pattern

## Definition

The Strategy Pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## The Problem

- Hard-coded algorithms in classes make them inflexible
- Difficult to add new algorithms without modifying existing code
- Code duplication when similar algorithms exist
- Can't easily switch algorithms at runtime

## The Solution

Extract algorithms into separate strategy classes that implement a common interface. The context class uses a strategy object and can switch strategies at runtime.

## Examples in This Directory

- `ISortingStrategy.cs` - Common interface for sorting algorithms
- `QuickSortStrategy.cs` - Quick sort implementation
- `MergeSortStrategy.cs` - Merge sort implementation
- `BubbleSortStrategy.cs` - Bubble sort implementation
- `DataSorter.cs` - Context that uses strategies

## Benefits

- **Flexibility**: Easy to add new algorithms
- **Runtime switching**: Can change algorithms on the fly
- **Eliminates conditionals**: No need for switch/if statements
- **Testability**: Each algorithm can be tested independently
- **Single Responsibility**: Each algorithm in its own class

## Key Takeaways

- Use when you have multiple ways of doing the same thing
- Prefer composition over inheritance
- Clients choose which strategy to use
- Follows Open/Closed Principle
