// ============================================================
// Module 3: Collections and LINQ
// Topics: Arrays, List<T>, Dictionary<K,V>, HashSet<T>,
//         Queue<T>, Stack<T>, and LINQ queries.
// ============================================================

using System.Collections.Generic;
using System.Linq;

Console.WriteLine("==============================");
Console.WriteLine("  Module 3: Collections & LINQ");
Console.WriteLine("==============================\n");

// --------------------------------------------------
// 1. Arrays
// --------------------------------------------------
Console.WriteLine("--- 1. Arrays ---");

int[] scores = { 85, 92, 78, 96, 65, 88 };
Console.WriteLine($"Scores  : {string.Join(", ", scores)}");
Console.WriteLine($"Length  : {scores.Length}");
Console.WriteLine($"Sum     : {scores.Sum()}");
Console.WriteLine($"Average : {scores.Average():F1}");

Array.Sort(scores);
Console.WriteLine($"Sorted  : {string.Join(", ", scores)}\n");

// 2D array
int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
Console.WriteLine("3x3 Matrix:");
for (int row = 0; row < 3; row++)
{
    for (int col = 0; col < 3; col++)
        Console.Write($"{matrix[row, col]} ");
    Console.WriteLine();
}
Console.WriteLine();

// --------------------------------------------------
// 2. List<T>
// --------------------------------------------------
Console.WriteLine("--- 2. List<T> ---");

var fruits = new List<string> { "Apple", "Banana", "Cherry" };
fruits.Add("Mango");
fruits.Insert(1, "Avocado");  // insert at index 1
fruits.Remove("Banana");

Console.WriteLine($"Fruits    : {string.Join(", ", fruits)}");
Console.WriteLine($"Count     : {fruits.Count}");
Console.WriteLine($"Has Cherry: {fruits.Contains("Cherry")}");
Console.WriteLine($"Index[2]  : {fruits[2]}\n");

// --------------------------------------------------
// 3. Dictionary<TKey, TValue>
// --------------------------------------------------
Console.WriteLine("--- 3. Dictionary<K,V> ---");

var capitals = new Dictionary<string, string>
{
    ["USA"]    = "Washington D.C.",
    ["France"] = "Paris",
    ["Japan"]  = "Tokyo"
};
capitals["India"] = "New Delhi";  // add new entry

foreach (var (country, capital) in capitals)
    Console.WriteLine($"  {country,-8} -> {capital}");

Console.WriteLine($"France capital: {capitals["France"]}");

// Safe lookup with TryGetValue
if (capitals.TryGetValue("Germany", out string? germanCapital))
    Console.WriteLine($"Germany capital: {germanCapital}");
else
    Console.WriteLine("Germany not found in dictionary\n");

// --------------------------------------------------
// 4. HashSet<T>
// --------------------------------------------------
Console.WriteLine("--- 4. HashSet<T> ---");

var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
var setB = new HashSet<int> { 4, 5, 6, 7, 8 };

var union        = new HashSet<int>(setA); union.UnionWith(setB);
var intersection = new HashSet<int>(setA); intersection.IntersectWith(setB);
var difference   = new HashSet<int>(setA); difference.ExceptWith(setB);

Console.WriteLine($"Set A       : {string.Join(", ", setA)}");
Console.WriteLine($"Set B       : {string.Join(", ", setB)}");
Console.WriteLine($"Union       : {string.Join(", ", union)}");
Console.WriteLine($"Intersection: {string.Join(", ", intersection)}");
Console.WriteLine($"Difference  : {string.Join(", ", difference)}\n");

// --------------------------------------------------
// 5. Queue<T> and Stack<T>
// --------------------------------------------------
Console.WriteLine("--- 5. Queue<T> and Stack<T> ---");

var queue = new Queue<string>();
queue.Enqueue("First");
queue.Enqueue("Second");
queue.Enqueue("Third");
Console.WriteLine($"Queue peek: {queue.Peek()}");
Console.WriteLine($"Dequeued  : {queue.Dequeue()}");
Console.WriteLine($"Queue size: {queue.Count}");

var stack = new Stack<int>();
stack.Push(10);
stack.Push(20);
stack.Push(30);
Console.WriteLine($"Stack peek: {stack.Peek()}");
Console.WriteLine($"Popped    : {stack.Pop()}");
Console.WriteLine($"Stack size: {stack.Count}\n");

// --------------------------------------------------
// 6. LINQ – Query Syntax and Method Syntax
// --------------------------------------------------
Console.WriteLine("--- 6. LINQ ---");

var people = new List<Employee>
{
    new("Alice",   "Engineering", 95_000, 5),
    new("Bob",     "Marketing",   72_000, 3),
    new("Carol",   "Engineering", 88_000, 7),
    new("Dave",    "HR",          65_000, 2),
    new("Eve",     "Engineering", 102_000, 10),
    new("Frank",   "Marketing",   78_000, 4),
    new("Grace",   "HR",          70_000, 6),
};

// Filter + sort (method syntax)
Console.WriteLine("Engineers sorted by salary (desc):");
var engineers = people
    .Where(p => p.Department == "Engineering")
    .OrderByDescending(p => p.Salary)
    .Select(p => $"  {p.Name,-8} ${p.Salary:N0}");

foreach (var e in engineers)
    Console.WriteLine(e);

// Grouping
Console.WriteLine("\nAverage salary by department:");
var avgByDept = people
    .GroupBy(p => p.Department)
    .Select(g => new { Department = g.Key, AvgSalary = g.Average(p => p.Salary) })
    .OrderBy(x => x.Department);

foreach (var dept in avgByDept)
    Console.WriteLine($"  {dept.Department,-14}: ${dept.AvgSalary:N0}");

// Aggregates
Console.WriteLine($"\nTotal payroll : ${people.Sum(p => p.Salary):N0}");
Console.WriteLine($"Highest salary: ${people.Max(p => p.Salary):N0}");
Console.WriteLine($"Avg experience: {people.Average(p => p.YearsExperience):F1} yrs");

// First / Single / Any / All
Console.WriteLine($"\nFirst HR employee    : {people.First(p => p.Department == "HR").Name}");
Console.WriteLine($"Any earning >100k    : {people.Any(p => p.Salary > 100_000)}");
Console.WriteLine($"All have experience  : {people.All(p => p.YearsExperience > 0)}\n");

// --------------------------------------------------
// Simple Employee record used in LINQ examples
// --------------------------------------------------
record Employee(string Name, string Department, decimal Salary, int YearsExperience);
