using ConsoleApp12_commond.actioner;

namespace ConsoleApp12_commond.commonder
{
    public interface ICommonder
    {
        string tag { get; set; }
        void SetItem(IActioner actioner);
        void TriggerOn();

        void Undo();
    }
}
