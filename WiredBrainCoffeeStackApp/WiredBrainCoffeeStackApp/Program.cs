StackDoubles();
StackString();

Console.ReadLine();

static void StackDoubles()
{
    var stack = new Stack<double>();
    stack.Push(1.2);
    stack.Push(2.8);
    stack.Push(3.0);

    double sum = 0.0;

    while (stack.Count > 0)
    {
        double item = (double)stack.Pop();
        Console.WriteLine($"Item: {item}");
        sum += item;
    }
    Console.WriteLine($"Sum: {sum}");
}

void StackString()
{
    var stack = new Stack<string>();
    stack.Push("Wired Brain Coffee");
    stack.Push("Plural Sight");

    while(stack.Count > 0)
    {
        Console.WriteLine(stack.Pop());
    }
}