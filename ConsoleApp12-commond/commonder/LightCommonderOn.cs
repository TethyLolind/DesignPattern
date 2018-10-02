using ConsoleApp12_commond.actioner;

namespace ConsoleApp12_commond.commonder
{


    class LightCommonderOn : ICommonder
    {
        private BedroomLight _bedroomLight;
        public string tag { get; set; }

        public void SetItem(IActioner actioner)
        {
            this._bedroomLight = (BedroomLight)actioner;
            this.tag = "bedroomLight";
        }
 
        public void TriggerOn()
        {
            this._bedroomLight.OnAction();
        }

        public void Undo()
        {
            this._bedroomLight.OffAction();
        }
    }
}
