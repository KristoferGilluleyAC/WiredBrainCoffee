// See https://aka.ms/new-console-template for more information
public class Stack<T>
{
    private readonly T[] _item;
    private int _currentIndex = -1;
    public Stack() => _item = new T[10];

    public int Count => _currentIndex + 1;

    public void Push(T item) =>_item[++_currentIndex] = item;

    public T Pop() =>_item[_currentIndex--];

}