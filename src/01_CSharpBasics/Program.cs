// ============================================================
// Module 1: C# Basics
// Topics: Data types, variables, operators, control flow,
//         methods, string interpolation, and nullable types.
// ============================================================

Console.WriteLine("==============================");
Console.WriteLine("  Module 1: C# Basics");
Console.WriteLine("==============================\n");

// --------------------------------------------------
// 1. Variables and Primitive Data Types
// --------------------------------------------------
Console.WriteLine("--- 1. Variables and Data Types ---");

int age = 30;
double salary = 75_000.50;   // underscores improve readability
bool isEmployed = true;
char grade = 'A';
string name = "Alice";

Console.WriteLine($"Name   : {name}");
Console.WriteLine($"Age    : {age}");
Console.WriteLine($"Salary : {salary:C}");
Console.WriteLine($"Grade  : {grade}");
Console.WriteLine($"Employed: {isEmployed}\n");

// --------------------------------------------------
// 2. Type Inference with var
// --------------------------------------------------
Console.WriteLine("--- 2. Type Inference (var) ---");

var city = "New York";      // inferred as string
var population = 8_336_817; // inferred as int
Console.WriteLine($"City: {city}, Population: {population:N0}\n");

// --------------------------------------------------
// 3. Constants
// --------------------------------------------------
Console.WriteLine("--- 3. Constants ---");

const double Pi = 3.14159265358979;
const int MaxRetries = 3;
Console.WriteLine($"Pi = {Pi}");
Console.WriteLine($"Max Retries = {MaxRetries}\n");

// --------------------------------------------------
// 4. Nullable Types
// --------------------------------------------------
Console.WriteLine("--- 4. Nullable Types ---");

int? nullableAge = null;
Console.WriteLine($"Nullable age has value: {nullableAge.HasValue}");
nullableAge = 25;
Console.WriteLine($"Nullable age value: {nullableAge ?? -1}"); // null-coalescing

double? score = null;
double computedScore = score ?? 0.0;  // default to 0 when null
Console.WriteLine($"Score (default 0): {computedScore}\n");

// --------------------------------------------------
// 5. Arithmetic and Comparison Operators
// --------------------------------------------------
Console.WriteLine("--- 5. Operators ---");

int a = 10, b = 3;
Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
Console.WriteLine($"{a} / {b} = {a / b}  (integer division)");
Console.WriteLine($"{a} % {b} = {a % b}  (remainder)");
Console.WriteLine($"{a} == {b}: {a == b}");
Console.WriteLine($"{a} >  {b}: {a > b}\n");

// --------------------------------------------------
// 6. String Operations
// --------------------------------------------------
Console.WriteLine("--- 6. Strings ---");

string firstName = "John";
string lastName  = "Doe";
string fullName  = string.Concat(firstName, " ", lastName);
Console.WriteLine($"Full name    : {fullName}");
Console.WriteLine($"Upper        : {fullName.ToUpper()}");
Console.WriteLine($"Length       : {fullName.Length}");
Console.WriteLine($"Contains 'D' : {fullName.Contains("D")}");
Console.WriteLine($"Starts 'John': {fullName.StartsWith("John")}");
Console.WriteLine($"Substring    : {fullName.Substring(5)}\n");

// Verbatim string literal (no need to escape backslashes)
string path = @"C:\Users\Alice\Documents";
Console.WriteLine($"Path: {path}\n");

// --------------------------------------------------
// 7. Control Flow – if / else / switch expression
// --------------------------------------------------
Console.WriteLine("--- 7. Control Flow ---");

int number = 42;
if (number % 2 == 0)
    Console.WriteLine($"{number} is Even");
else
    Console.WriteLine($"{number} is Odd");

// Switch expression (C# 8+)
string dayType = (number % 7) switch
{
    0 or 6 => "Weekend",
    _      => "Weekday"
};
Console.WriteLine($"Day type: {dayType}\n");

// --------------------------------------------------
// 8. Loops
// --------------------------------------------------
Console.WriteLine("--- 8. Loops ---");

Console.Write("for    : ");
for (int i = 1; i <= 5; i++)
    Console.Write($"{i} ");
Console.WriteLine();

Console.Write("while  : ");
int w = 1;
while (w <= 5)
{
    Console.Write($"{w} ");
    w++;
}
Console.WriteLine();

Console.Write("do     : ");
int d = 1;
do
{
    Console.Write($"{d} ");
    d++;
} while (d <= 5);
Console.WriteLine();

int[] numbers = { 10, 20, 30, 40, 50 };
Console.Write("foreach: ");
foreach (int n in numbers)
    Console.Write($"{n} ");
Console.WriteLine("\n");

// --------------------------------------------------
// 9. Methods
// --------------------------------------------------
Console.WriteLine("--- 9. Methods ---");

int sumResult = Add(5, 7);
Console.WriteLine($"Add(5, 7) = {sumResult}");

double area = CircleArea(4.5);
Console.WriteLine($"Circle area (r=4.5) = {area:F2}");

string greeting = Greet("Bob");
Console.WriteLine(greeting);

// Named and optional parameters
Console.WriteLine(FormatName("Alice", title: "Dr."));
Console.WriteLine(FormatName("Smith"));  // uses default title
Console.WriteLine();

// --------------------------------------------------
// 10. Tuples
// --------------------------------------------------
Console.WriteLine("--- 10. Tuples ---");

var (min, max) = MinMax(new[] { 3, 1, 4, 1, 5, 9, 2, 6 });
Console.WriteLine($"Min = {min}, Max = {max}\n");

// --------------------------------------------------
// Local helper methods
// --------------------------------------------------

static int Add(int x, int y) => x + y;

static double CircleArea(double radius) => Math.PI * radius * radius;

static string Greet(string personName) => $"Hello, {personName}!";

static string FormatName(string surname, string title = "Mr./Ms.")
    => $"{title} {surname}";

static (int Min, int Max) MinMax(int[] arr)
{
    int minVal = arr[0], maxVal = arr[0];
    foreach (int val in arr)
    {
        if (val < minVal) minVal = val;
        if (val > maxVal) maxVal = val;
    }
    return (minVal, maxVal);
}
