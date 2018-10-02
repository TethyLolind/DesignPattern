namespace ConsoleApp10_decorator
{
    internal interface IMaterials
    {
        long Price { get; set; }
        IMaterials X { get; set; }
        long cost();

        string Description { get; set; }

        string GetName();
    }
}