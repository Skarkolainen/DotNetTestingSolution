



//Creates object in Gen 0

MyClass obj1 = new();

DoWork();

GC.Collect(0);
Console.WriteLine("GC gen 0 collected");


MyClass obj2 = new();


static void DoWork()
{
    for (int i = 0; i < 100; i++)
    {
        MyClass tempbObj = new();
    }
}
class MyClass
{
    public int MyProperty { get; set; }
}