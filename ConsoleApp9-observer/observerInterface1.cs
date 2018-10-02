namespace ConsoleApp9_observer
{
    internal interface IObserber1
    {
        void update(int parameter1, int parameter2);
        void register();
        void remove();
    }
}