namespace DeferredExecution;

internal class Program
{
    static void Main(string[] args)
    {
        DeferredExecution.Example1();
    }
}

internal class DeferredExecution
{
    internal static void Example1()
    {
        var iterations = new List<int> { 1 };
        var iEnumerable = iterations.Select(x => DateTime.Now.ToString());
        var list = iEnumerable.ToList();

        Console.WriteLine($"Example 1");
        Console.WriteLine();
        Console.WriteLine($"We will create 2 lists of strings, one using IEnumerable<string>");
        Console.WriteLine($"and the other using List<string>.");
        Console.WriteLine();
        Console.WriteLine($"Both lists will contain a single string: DateTime.Now.ToList()");
        Console.WriteLine();
        Console.WriteLine($"Both IEnumerable<> and List<> were created now, at the same time,");
        Console.WriteLine($"the List<> was created this way:");
        Console.WriteLine($"    list = iEnumerable.ToList();");
        Console.WriteLine();
        Console.WriteLine($"So, by intuition, we would assume values from both lists would");
        Console.WriteLine($"be the same.");
        Console.WriteLine();
        Console.WriteLine($"This is the DateTime of right after both lists were created: {DateTime.Now}");
        Console.WriteLine();
        Console.WriteLine($"Press any key to show the values of both lists.");

        Console.ReadKey();
        Console.WriteLine();

        Console.WriteLine($"IEnumerable<> value: {iEnumerable.First()}");
        Console.WriteLine();
        Console.WriteLine($"List<> value: {list.First()}");
        Console.WriteLine();
        Console.WriteLine($"Explanation:");
        Console.WriteLine();
        Console.WriteLine($"Items from an IEnumerable<> are only instantiated when the");
        Console.WriteLine($"IEnumerable<> is enumerated, that is, when they are accessed. In our");
        Console.WriteLine($"example they were accessed to write them to the console.");
        Console.WriteLine();
        Console.WriteLine($"You can force this to happen earlier by calling IEnumerable<>.ToList().");
        Console.WriteLine($"That's why the list using List<> got the DateTime.Now from right when");
        Console.WriteLine($"it was created, because it was created using: list = iEnumerable.ToList(),");
        Console.WriteLine($"which enumerated the IEnumerable<>.");
        Console.WriteLine();

        Console.WriteLine($"Press any key to go to example 2.");

        Console.ReadKey();
        Console.Clear();

        Example2();
    }

    internal static void Example2()
    {
        var rnd = new Random();

        var iterations = new List<int> { 1 };
        var iEnumerable = iterations.Select(x => rnd.Next(0, 1000));
        var list = iEnumerable.ToList();

        Console.WriteLine($"Example 2");
        Console.WriteLine();
        Console.WriteLine($"This is an example using Random().");
        Console.WriteLine();
        Console.WriteLine($"An IEnumerable<int> and a List<int> were created. And just like our");
        Console.WriteLine($"previous example, the List<> was created as follows:");
        Console.WriteLine($"    list = iEnumerable.ToList();");
        Console.WriteLine();
        Console.WriteLine($"By intuition, we would assume values from both lists would");
        Console.WriteLine($"be the same.");
        Console.WriteLine();
        Console.WriteLine($"Let's take a look:");
        Console.WriteLine();
        Console.WriteLine($"IEnumerable<> value: {iEnumerable.First()}");
        Console.WriteLine();
        Console.WriteLine($"List<> value: {list.First()}");
        Console.WriteLine();

        Console.WriteLine($"Press any key to go to example 3.");

        Console.ReadKey();
        Console.Clear();

        Example3();
    }

    internal static void Example3()
    {
        var rnd = new Random();

        var iterations = new List<int> { 1 };
        var iEnumerable = iterations.Select(x => rnd.Next(0, 1000));

        Console.WriteLine($"Example 3");
        Console.WriteLine();
        Console.WriteLine($"We will use Random() again, this time passing the iEnumerable list");
        Console.WriteLine($"as parameter to methods in another class. We will use 2 methods, one");
        Console.WriteLine($"receiving a List<int> and the other receiving an IEnumerable<int>.");
        Console.WriteLine();
        Console.WriteLine($"Of course, to call the method that receives the List<int>, we will");
        Console.WriteLine($"need to convert the IEnumerable<> to List<> using .ToList().");
        Console.WriteLine();
        Console.WriteLine($"The IEnumerable<> have been created. Let's call the methods a few times:");

        Console.WriteLine();
        OtherClass.IEnumerableMethod(iEnumerable);
        OtherClass.ListMethod(iEnumerable.ToList());
        OtherClass.IEnumerableMethod(iEnumerable);
        OtherClass.ListMethod(iEnumerable.ToList());
        Console.WriteLine();

        Console.WriteLine($"As you can see, every time we enumrate the IEnumerable<>, a new random");
        Console.WriteLine($"number is generated. Surely it can be useful in some specific situations,");
        Console.WriteLine($"but it can cause a big headache if you implement it this way without knowing");
        Console.WriteLine($"about this behavior and end up causing bugs because of it.");
        Console.WriteLine();
        Console.WriteLine($"Now let's force enumeration on the IEnumerable<>.");
        Console.WriteLine();
        Console.WriteLine($"We could do this from the begining by using .ToList(), even if we are not");
        Console.WriteLine($"dealing with a List<> list:");
        Console.WriteLine($"    var iEnumerable = iterations.Select(x => rnd.Next(0, 1000)).ToList();");
        Console.WriteLine();
        Console.WriteLine($"But as the iEnumerable is already created, we will force its enumeration");
        Console.WriteLine($"by doing:");
        Console.WriteLine($"    iEnumerable = iEnumerable.ToList();");
        Console.WriteLine();
        Console.WriteLine($"Now let's call the methods a few times again:");
        iEnumerable = iEnumerable.ToList();

        Console.WriteLine();
        OtherClass.IEnumerableMethod(iEnumerable);
        OtherClass.ListMethod(iEnumerable.ToList());
        OtherClass.IEnumerableMethod(iEnumerable);
        OtherClass.ListMethod(iEnumerable.ToList());
        Console.WriteLine();

        Console.WriteLine($"Press any key to exit.");
        Console.ReadKey();
    }
}

internal class OtherClass
{
    internal static void IEnumerableMethod(IEnumerable<int> items)
    {
        Console.WriteLine($"IEnumerableMethod: {items.First()}");
    }

    internal static void ListMethod(List<int> items)
    {
        Console.WriteLine($"ListMethod: {items.First()}");
    }
}