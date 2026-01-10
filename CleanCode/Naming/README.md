# Clean Code - Naming Conventions

## Purpose

Good naming is one of the most important aspects of clean code. Names should reveal intent, be searchable, and be pronounceable.

## Examples in This Directory

### Before and After Comparisons
- `NamingBad.cs` - Poor naming examples
- `NamingGood.cs` - Clean naming examples

## Principles

### 1. Use Intention-Revealing Names
Names should tell you why something exists, what it does, and how it's used.

**Bad:** `int d; // elapsed time in days`  
**Good:** `int elapsedTimeInDays;`

### 2. Avoid Disinformation
Don't use names that obscure meaning or suggest something incorrect.

**Bad:** `List<Account> accountList;` (what if it's not a List?)  
**Good:** `List<Account> accounts;`

### 3. Make Meaningful Distinctions
Don't add noise words or numbers to make names unique.

**Bad:** `Product productInfo; Product productData;`  
**Good:** `Product product; ProductSpecification specification;`

### 4. Use Pronounceable Names
If you can't pronounce it, you can't discuss it.

**Bad:** `DateTime genymdhms;`  
**Good:** `DateTime generationTimestamp;`

### 5. Use Searchable Names
Single-letter names and numeric constants are hard to find.

**Bad:** `if (s == 5)`  
**Good:** `if (status == StatusCode.Active)`

### 6. Class Names
Classes should be nouns or noun phrases.

**Good:** `Customer`, `WikiPage`, `Account`, `AddressParser`

### 7. Method Names
Methods should be verbs or verb phrases.

**Good:** `PostPayment()`, `DeletePage()`, `Save()`

## C# Naming Conventions

- **PascalCase**: Classes, methods, properties, public fields
- **camelCase**: Local variables, parameters, private fields
- **_camelCase**: Private fields (with underscore prefix)
- **UPPER_CASE**: Constants

## Key Takeaways

- Spend time choosing good names
- Rename when you find better names
- Names should make code self-documenting
- Avoid abbreviations unless universally known
