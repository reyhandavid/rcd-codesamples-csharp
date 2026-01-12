# Clean Code - Error Handling

## Purpose

Proper error handling makes code robust and maintainable. Errors should be handled gracefully without obscuring the logic.

## Examples in This Directory

### Before and After Comparisons
- `ErrorHandlingBad.cs` - Poor error handling examples
- `ErrorHandlingGood.cs` - Clean error handling examples

## Principles

### 1. Use Exceptions Rather Than Return Codes
Exceptions separate error handling from the main logic.

**Bad:** Return codes mixed with business logic  
**Good:** Try-catch blocks that handle exceptions

### 2. Provide Context with Exceptions
Include enough information to determine the source and location of an error.

### 3. Define Exception Classes Based on Caller's Needs
Create custom exceptions that are meaningful to the caller.

### 4. Don't Return Null
Returning null forces callers to check for null, leading to null reference errors.

**Bad:** `return null;`  
**Good:** Return empty collections, use Null Object pattern, or throw exceptions

### 5. Don't Pass Null
Passing null to methods can cause null reference exceptions.

### 6. Use Specific Exception Types
Catch specific exceptions rather than generic Exception class when possible.

### 7. Clean Up Resources
Use `using` statements or try-finally blocks to ensure resources are properly disposed.

## Benefits

- **Reliability**: Errors don't cause crashes
- **Debuggability**: Clear error messages help diagnose issues
- **Maintainability**: Error handling doesn't obscure business logic
- **User Experience**: Graceful error messages instead of crashes

## Key Takeaways

- Don't ignore exceptions
- Log errors appropriately
- Fail fast when appropriate
- Use custom exceptions for domain-specific errors
- Keep error handling separate from business logic
