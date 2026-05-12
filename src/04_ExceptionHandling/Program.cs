// ============================================================
// Module 4: Exception Handling
// Topics: try/catch/finally, custom exceptions, exception
//         filters, when expressions, and best practices.
// ============================================================

Console.WriteLine("==============================");
Console.WriteLine("  Module 4: Exception Handling");
Console.WriteLine("==============================\n");

// --------------------------------------------------
// 1. Basic try / catch / finally
// --------------------------------------------------
Console.WriteLine("--- 1. Basic try/catch/finally ---");

try
{
    Console.WriteLine("Attempting division by zero...");
    int result = Divide(10, 0);
    Console.WriteLine($"Result: {result}"); // never reached
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Caught DivideByZeroException: {ex.Message}");
}
finally
{
    Console.WriteLine("Finally block always executes.\n");
}

// --------------------------------------------------
// 2. Multiple catch blocks
// --------------------------------------------------
Console.WriteLine("--- 2. Multiple catch blocks ---");

string[] inputs = { "42", "abc", null! };

foreach (string input in inputs)
{
    try
    {
        int parsed = int.Parse(input);
        Console.WriteLine($"Parsed: {parsed}");
    }
    catch (ArgumentNullException)
    {
        Console.WriteLine("Error: input was null.");
    }
    catch (FormatException)
    {
        Console.WriteLine($"Error: '{input}' is not a valid integer.");
    }
    catch (OverflowException ex)
    {
        Console.WriteLine($"Error: overflow – {ex.Message}");
    }
}
Console.WriteLine();

// --------------------------------------------------
// 3. Custom Exceptions
// --------------------------------------------------
Console.WriteLine("--- 3. Custom Exceptions ---");

try
{
    ProcessOrder(orderId: 0, quantity: -5);
}
catch (OrderValidationException ex)
{
    Console.WriteLine($"Order validation failed:");
    Console.WriteLine($"  Error code : {ex.ErrorCode}");
    Console.WriteLine($"  Message    : {ex.Message}\n");
}

try
{
    ProcessOrder(orderId: 101, quantity: -5);
}
catch (OrderValidationException ex)
{
    Console.WriteLine($"Order validation failed:");
    Console.WriteLine($"  Error code : {ex.ErrorCode}");
    Console.WriteLine($"  Message    : {ex.Message}\n");
}

// --------------------------------------------------
// 4. Exception Filters (when clause)
// --------------------------------------------------
Console.WriteLine("--- 4. Exception Filters (when) ---");

int[] codes = { 404, 500, 403 };

foreach (int code in codes)
{
    try
    {
        SimulateHttpRequest(code);
    }
    catch (HttpRequestException ex) when (ex.Message.Contains("404"))
    {
        Console.WriteLine($"[{code}] Handled: Resource not found.");
    }
    catch (HttpRequestException ex) when (ex.Message.Contains("500"))
    {
        Console.WriteLine($"[{code}] Handled: Server error – please retry.");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"[{code}] Unhandled HTTP error: {ex.Message}");
    }
}
Console.WriteLine();

// --------------------------------------------------
// 5. Re-throwing Exceptions
// --------------------------------------------------
Console.WriteLine("--- 5. Re-throwing ---");

try
{
    CallWithLogging(() => throw new InvalidOperationException("Something went wrong."));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught re-thrown exception: {ex.Message}\n");
}

// --------------------------------------------------
// 6. Using statement (resource cleanup)
// --------------------------------------------------
Console.WriteLine("--- 6. IDisposable / using ---");

using (var resource = new ManagedResource("DB Connection"))
{
    Console.WriteLine($"Using resource: {resource.Name}");
    resource.DoWork();
}
// Dispose() is called automatically here

// C# 8+ using declaration
using var resource2 = new ManagedResource("File Handle");
Console.WriteLine($"Using resource2: {resource2.Name}");
resource2.DoWork();
// resource2.Dispose() called at end of scope
Console.WriteLine();

// ============================================================
// Helper methods and custom types
// ============================================================

static int Divide(int numerator, int denominator)
{
    if (denominator == 0)
        throw new DivideByZeroException("Denominator cannot be zero.");
    return numerator / denominator;
}

static void ProcessOrder(int orderId, int quantity)
{
    if (orderId <= 0)
        throw new OrderValidationException("INVALID_ID", "Order ID must be a positive integer.");
    if (quantity <= 0)
        throw new OrderValidationException("INVALID_QTY", "Quantity must be greater than zero.");

    Console.WriteLine($"Order {orderId} processed successfully (qty={quantity}).");
}

static void SimulateHttpRequest(int statusCode)
{
    if (statusCode >= 400)
        throw new HttpRequestException($"HTTP {statusCode} error");
}

static void CallWithLogging(Action action)
{
    try
    {
        action();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[LOG] Exception caught in CallWithLogging: {ex.Message}");
        throw; // preserve original stack trace
    }
}

// ============================================================
// Custom exception class
// ============================================================

public class OrderValidationException : Exception
{
    public string ErrorCode { get; }

    public OrderValidationException(string errorCode, string message)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    public OrderValidationException(string errorCode, string message, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}

// ============================================================
// Disposable resource class
// ============================================================

public class ManagedResource : IDisposable
{
    public string Name { get; }
    private bool _disposed;

    public ManagedResource(string name)
    {
        Name = name;
        Console.WriteLine($"[{Name}] Opened.");
    }

    public void DoWork()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        Console.WriteLine($"[{Name}] Doing work...");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Console.WriteLine($"[{Name}] Disposed.");
            _disposed = true;
        }
    }
}
