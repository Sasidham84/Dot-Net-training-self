// ============================================================
// Module 2: Object-Oriented Programming (OOP) Concepts
// Topics: Classes, constructors, properties, inheritance,
//         interfaces, abstract classes, and polymorphism.
// ============================================================

Console.WriteLine("==============================");
Console.WriteLine("  Module 2: OOP Concepts");
Console.WriteLine("==============================\n");

// --------------------------------------------------
// 1. Basic Class & Object
// --------------------------------------------------
Console.WriteLine("--- 1. Classes and Objects ---");

var person = new Person("Alice", 30);
person.Introduce();
Console.WriteLine($"Is adult: {person.IsAdult}\n");

// --------------------------------------------------
// 2. Inheritance
// --------------------------------------------------
Console.WriteLine("--- 2. Inheritance ---");

var employee = new Employee("Bob", 28, "Engineering", 90_000);
employee.Introduce();
Console.WriteLine($"Department: {employee.Department}");
Console.WriteLine($"Annual bonus: {employee.CalculateBonus():C}\n");

// --------------------------------------------------
// 3. Polymorphism
// --------------------------------------------------
Console.WriteLine("--- 3. Polymorphism ---");

Shape[] shapes = { new Circle(5), new Rectangle(4, 6), new Triangle(3, 8) };

foreach (Shape shape in shapes)
{
    Console.WriteLine($"{shape.GetType().Name,-12}: Area = {shape.Area():F2}, " +
                      $"Description = {shape.Describe()}");
}
Console.WriteLine();

// --------------------------------------------------
// 4. Interfaces
// --------------------------------------------------
Console.WriteLine("--- 4. Interfaces ---");

IPrintable[] printables = { new Invoice(1001, 250.75), new Receipt("R-55", 89.99) };

foreach (IPrintable item in printables)
    item.Print();
Console.WriteLine();

// --------------------------------------------------
// 5. Abstract Classes
// --------------------------------------------------
Console.WriteLine("--- 5. Abstract Classes ---");

Animal[] animals = { new Dog("Rex"), new Cat("Whiskers") };

foreach (Animal animal in animals)
{
    animal.Breathe();
    animal.MakeSound();
}
Console.WriteLine();

// --------------------------------------------------
// 6. Static Members
// --------------------------------------------------
Console.WriteLine("--- 6. Static Members ---");

Console.WriteLine($"Total persons created: {Person.TotalCount}");
var p2 = new Person("Carol", 22);
Console.WriteLine($"Total persons created: {Person.TotalCount}\n");

// --------------------------------------------------
// 7. Records (C# 9+)
// --------------------------------------------------
Console.WriteLine("--- 7. Records ---");

var point1 = new Point(3, 4);
var point2 = new Point(3, 4);
var point3 = point1 with { Y = 10 };

Console.WriteLine($"point1: {point1}");
Console.WriteLine($"point2: {point2}");
Console.WriteLine($"point1 == point2: {point1 == point2}"); // value equality
Console.WriteLine($"point3 (non-destructive copy): {point3}\n");

// ============================================================
// Class Definitions
// ============================================================

// Basic class with properties, constructor, and static member
class Person
{
    public static int TotalCount { get; private set; }

    public string Name { get; }
    public int Age { get; private set; }
    public bool IsAdult => Age >= 18;

    public Person(string name, int age)
    {
        Name = name;
        Age  = age;
        TotalCount++;
    }

    public virtual void Introduce() =>
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
}

// Inheritance – Employee extends Person
class Employee : Person
{
    public string Department { get; }
    public decimal Salary { get; }

    public Employee(string name, int age, string department, decimal salary)
        : base(name, age)
    {
        Department = department;
        Salary     = salary;
    }

    public override void Introduce() =>
        Console.WriteLine($"Hi, I'm {Name}, a {Department} employee.");

    public decimal CalculateBonus() => Salary * 0.10m;
}

// Abstract class
abstract class Shape
{
    public abstract double Area();
    public virtual string Describe() => $"A shape with area {Area():F2}";
}

class Circle : Shape
{
    private readonly double _radius;
    public Circle(double radius) { _radius = radius; }
    public override double Area() => Math.PI * _radius * _radius;
}

class Rectangle : Shape
{
    private readonly double _width, _height;
    public Rectangle(double width, double height) { _width = width; _height = height; }
    public override double Area() => _width * _height;
}

class Triangle : Shape
{
    private readonly double _base, _height;
    public Triangle(double @base, double height) { _base = @base; _height = height; }
    public override double Area() => 0.5 * _base * _height;
    public override string Describe() => $"A triangle with base {_base} and height {_height}";
}

// Interface
interface IPrintable
{
    void Print();
}

class Invoice : IPrintable
{
    public int Number { get; }
    public double Amount { get; }
    public Invoice(int number, double amount) { Number = number; Amount = amount; }
    public void Print() => Console.WriteLine($"INVOICE #{Number}: ${Amount:F2}");
}

class Receipt : IPrintable
{
    public string Id { get; }
    public double Total { get; }
    public Receipt(string id, double total) { Id = id; Total = total; }
    public void Print() => Console.WriteLine($"RECEIPT {Id}: ${Total:F2}");
}

// Abstract Animal class
abstract class Animal
{
    protected string Name { get; }
    protected Animal(string name) { Name = name; }
    public void Breathe() => Console.WriteLine($"{Name} is breathing.");
    public abstract void MakeSound();
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override void MakeSound() => Console.WriteLine($"{Name} says: Woof!");
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }
    public override void MakeSound() => Console.WriteLine($"{Name} says: Meow!");
}

// Record (immutable value type with value-based equality)
record Point(double X, double Y);
