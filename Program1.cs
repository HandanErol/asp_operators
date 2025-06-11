using System;

namespace EqualityDemoV3
{
    // Value-type implementation; immutable after construction.
    public readonly struct Employee : IEquatable<Employee>
    {
        public int    Id        { get; }
        public string FirstName { get; }
        public string LastName  { get; }

        public Employee(int id, string firstName, string lastName)
        {
            if (id <= 0)                    throw new ArgumentException("ID must be positive.",   nameof(id));
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name cannot be empty.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))  throw new ArgumentException("Last name cannot be empty.",  nameof(lastName));

            Id        = id;
            FirstName = firstName.Trim();
            LastName  = lastName.Trim();
        }

        public override string ToString() =>
            $"Employee(ID: {Id}, Full Name: {FirstName} {LastName})";

        public bool Equals(Employee other) => Id == other.Id;

        public override bool Equals(object? obj) => obj is Employee e && Equals(e);

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Employee a, Employee b) => a.Equals(b);
        public static bool operator !=(Employee a, Employee b) => !a.Equals(b);
    }

    class Program
    {
        static void Main()
        {
            var e1 = new Employee(101, "Sarah",  "Wilson");
            var e2 = new Employee(101, "Michael","Brown");
            var e3 = new Employee(102, "Emma",   "Davis");

            Console.WriteLine(e1);
            Console.WriteLine(e2);
            Console.WriteLine(e3);
            Console.WriteLine();

            Console.WriteLine($"e1 == e2 : {e1 == e2}");
            Console.WriteLine($"e1 != e3 : {e1 != e3}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
