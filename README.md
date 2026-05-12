# Dot-Net-training-self

A self-paced **.NET / C# training** repository containing runnable code examples organised by topic. Each module is a standalone console application you can build and run independently.

## Repository Structure

```
DotNetTraining.sln
└── src/
    ├── 01_CSharpBasics/       Module 1 – C# language fundamentals
    ├── 02_OOPConcepts/        Module 2 – Object-Oriented Programming
    ├── 03_Collections/        Module 3 – Collections & LINQ
    ├── 04_ExceptionHandling/  Module 4 – Exception handling
    └── 05_AsyncAwait/         Module 5 – Async / Await programming
```

## Prerequisites

| Tool | Version |
|------|---------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 8.0 or later |

Verify your installation:

```bash
dotnet --version
```

## Quick Start

Clone the repository and run any module:

```bash
git clone https://github.com/Sasidham84/Dot-Net-training-self.git
cd Dot-Net-training-self

# Build the entire solution
dotnet build DotNetTraining.slnx

# Run a specific module
dotnet run --project src/01_CSharpBasics
dotnet run --project src/02_OOPConcepts
dotnet run --project src/03_Collections
dotnet run --project src/04_ExceptionHandling
dotnet run --project src/05_AsyncAwait
```

---

## Modules

### Module 1 – C# Basics (`src/01_CSharpBasics`)

Core language fundamentals every .NET developer needs to know.

| Topic | Highlights |
|-------|-----------|
| Variables & data types | `int`, `double`, `bool`, `char`, `string` |
| Type inference | `var` keyword |
| Constants | `const` keyword |
| Nullable types | `int?`, null-coalescing `??` |
| Operators | Arithmetic, comparison, logical |
| Strings | Interpolation `$"..."`, verbatim `@"..."`, common methods |
| Control flow | `if/else`, `switch` expression (C# 8+) |
| Loops | `for`, `while`, `do/while`, `foreach` |
| Methods | Parameters, return values, optional/named params |
| Tuples | Multiple return values with named elements |

---

### Module 2 – OOP Concepts (`src/02_OOPConcepts`)

Object-oriented design patterns and C# type system.

| Topic | Highlights |
|-------|-----------|
| Classes & objects | Fields, properties, constructors |
| Inheritance | `base` keyword, method overriding |
| Polymorphism | Virtual/override methods, runtime dispatch |
| Interfaces | `interface`, multiple implementation |
| Abstract classes | `abstract` keyword, template method pattern |
| Static members | Static properties, factory-style counters |
| Records | Immutable value types, `with` expression (C# 9+) |

---

### Module 3 – Collections & LINQ (`src/03_Collections`)

Working with data structures and querying collections.

| Topic | Highlights |
|-------|-----------|
| Arrays | 1D & 2D arrays, `Array.Sort`, aggregates |
| `List<T>` | Add, Insert, Remove, Contains |
| `Dictionary<K,V>` | CRUD, `TryGetValue` |
| `HashSet<T>` | Union, Intersection, Difference |
| `Queue<T>` / `Stack<T>` | FIFO and LIFO patterns |
| LINQ (method syntax) | `Where`, `Select`, `OrderBy`, `GroupBy` |
| LINQ aggregates | `Sum`, `Max`, `Average`, `Any`, `All`, `First` |

---

### Module 4 – Exception Handling (`src/04_ExceptionHandling`)

Robust error handling strategies in C#.

| Topic | Highlights |
|-------|-----------|
| try / catch / finally | Basic exception handling |
| Multiple catch blocks | Ordered from specific to general |
| Custom exceptions | Extending `Exception`, custom properties |
| Exception filters | `catch (Ex ex) when (condition)` |
| Re-throwing | `throw;` preserves original stack trace |
| `IDisposable` / `using` | Deterministic resource cleanup |

---

### Module 5 – Async / Await (`src/05_AsyncAwait`)

Writing non-blocking, concurrent code with the Task-based Asynchronous Pattern (TAP).

| Topic | Highlights |
|-------|-----------|
| `async` / `await` basics | `Task`, `Task<T>`, awaiting |
| `Task.WhenAll` | Parallel execution, waiting for all tasks |
| `Task.WhenAny` | First-completed pattern |
| `CancellationToken` | Cooperative cancellation with timeouts |
| `IAsyncEnumerable<T>` | Async streams with `await foreach` |
| Async exception handling | try/catch around awaited calls |

---

## Learning Path

Work through the modules in order for a structured learning experience:

1. **C# Basics** → get comfortable with the language
2. **OOP Concepts** → learn to model real-world problems
3. **Collections & LINQ** → master data manipulation
4. **Exception Handling** → write robust, production-quality code
5. **Async / Await** → build responsive, scalable applications

## Running Tests

Each project can be verified by simply running it and observing the console output. All examples are self-contained and produce deterministic output.

```bash
dotnet run --project src/01_CSharpBasics
```

## Contributing

Feel free to open issues or pull requests to add more modules (e.g., Generics, Delegates & Events, Dependency Injection, Entity Framework, etc.).