// ============================================================
// Module 5: Async / Await and Task-based Programming
// Topics: async/await, Task, Task<T>, parallel execution,
//         CancellationToken, and progress reporting.
// ============================================================

using System.Threading;
using System.Threading.Tasks;

Console.WriteLine("==============================");
Console.WriteLine("  Module 5: Async / Await");
Console.WriteLine("==============================\n");

// --------------------------------------------------
// 1. Basic async / await
// --------------------------------------------------
Console.WriteLine("--- 1. Basic async/await ---");

string weatherData = await FetchWeatherAsync("New York");
Console.WriteLine($"Weather data: {weatherData}\n");

// --------------------------------------------------
// 2. async method returning Task<T>
// --------------------------------------------------
Console.WriteLine("--- 2. Task<T> ---");

int calculationResult = await ComputeSquareAsync(7);
Console.WriteLine($"Square of 7 = {calculationResult}\n");

// --------------------------------------------------
// 3. Running tasks in parallel with Task.WhenAll
// --------------------------------------------------
Console.WriteLine("--- 3. Task.WhenAll (parallel execution) ---");

var stopwatch = System.Diagnostics.Stopwatch.StartNew();

Task<string>[] cityTasks = {
    FetchWeatherAsync("London"),
    FetchWeatherAsync("Paris"),
    FetchWeatherAsync("Tokyo")
};

string[] results = await Task.WhenAll(cityTasks);

stopwatch.Stop();
Console.WriteLine($"All cities fetched in {stopwatch.ElapsedMilliseconds}ms:");
foreach (string r in results)
    Console.WriteLine($"  {r}");
Console.WriteLine();

// --------------------------------------------------
// 4. Task.WhenAny – first one wins
// --------------------------------------------------
Console.WriteLine("--- 4. Task.WhenAny (first result) ---");

Task<string> fastTask  = SimulateDelayAsync("Fast server",  300);
Task<string> slowTask  = SimulateDelayAsync("Slow server",  900);
Task<string> firstDone = await Task.WhenAny(fastTask, slowTask);

Console.WriteLine($"First completed: {await firstDone}\n");

// --------------------------------------------------
// 5. CancellationToken
// --------------------------------------------------
Console.WriteLine("--- 5. CancellationToken ---");

using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(500));

try
{
    await LongRunningTaskAsync(cts.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Task was cancelled after timeout.\n");
}

// --------------------------------------------------
// 6. async foreach (IAsyncEnumerable)
// --------------------------------------------------
Console.WriteLine("--- 6. IAsyncEnumerable (async streams) ---");

Console.Write("Stream: ");
await foreach (int value in GenerateNumbersAsync(1, 5))
    Console.Write($"{value} ");
Console.WriteLine("\n");

// --------------------------------------------------
// 7. Exception handling in async methods
// --------------------------------------------------
Console.WriteLine("--- 7. Async exception handling ---");

try
{
    await FetchDataWithErrorAsync();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught async exception: {ex.Message}\n");
}

Console.WriteLine("All async examples completed.");

// ============================================================
// Async helper methods
// ============================================================

static async Task<string> FetchWeatherAsync(string city)
{
    // Simulate network delay
    await Task.Delay(200);
    return $"{city}: 22°C, Partly cloudy";
}

static async Task<int> ComputeSquareAsync(int n)
{
    await Task.Delay(50); // simulate CPU-bound work dispatched to thread pool
    return n * n;
}

static async Task<string> SimulateDelayAsync(string name, int delayMs)
{
    await Task.Delay(delayMs);
    return $"{name} responded after {delayMs}ms";
}

static async Task LongRunningTaskAsync(CancellationToken cancellationToken)
{
    Console.WriteLine("Long-running task started...");
    for (int i = 0; i < 10; i++)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.Delay(200, cancellationToken);
        Console.Write(".");
    }
    Console.WriteLine();
}

static async IAsyncEnumerable<int> GenerateNumbersAsync(int start, int count)
{
    for (int i = start; i < start + count; i++)
    {
        await Task.Delay(50); // simulate async data source
        yield return i;
    }
}

static async Task FetchDataWithErrorAsync()
{
    await Task.Delay(50);
    throw new InvalidOperationException("Simulated async failure.");
}
