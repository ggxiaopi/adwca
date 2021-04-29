using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;

namespace Mgnb
{
    //All properties and public fields of this class will be saved to file
    public class Settings : ISettings
    {
        [Menu("Enable")]
        public ToggleNode Enable { get; set; }
        [Menu("Azurite Color")]
        public ColorNode AzuriteColor { get; set; } = new ColorNode(Color.Blue);
        [Menu("Currency Color")]
        public ColorNode CurrencyColor { get; set; } = new ColorNode(Color.Yellow);
        [Menu("Fossil Color")]
        public ColorNode FossilColor { get; set; } = new ColorNode(Color.DarkOrange);
        [Menu("Unique Color")]
        public ColorNode UniqueColor { get; set; } = new ColorNode(Color.Orange);
        [Menu("Resonator Color")]
        public ColorNode ResColor { get; set; } = new ColorNode(Color.Gray);
        [Menu("Delve Wall Color")]
        public ColorNode WallColor { get; set; } = new ColorNode(Color.Purple);
        [Menu("Flares Color")]
        public ColorNode FlareColor { get; set; } = new ColorNode(Color.White);
        [Menu("Dynamite Color")]
        public ColorNode DynaColor { get; set; } = new ColorNode(Color.Red);
        [Menu("Arrow Position X")]
        public RangeNode<int> PosX { get; set; } = new RangeNode<int>(960, 0, 2560);
        [Menu("Arrow Position Y")]
        public RangeNode<int> PosY { get; set; } = new RangeNode<int>(540, 0, 1440);
        [Menu("Arrow Size")]
        public RangeNode<int> ArrowSize { get; set; } = new RangeNode<int>(40, 20, 80);
        [Menu("Distance Alert")]
        public RangeNode<int> Dist { get; set; } = new RangeNode<int>(150, 50, 300);

        public Settings()
        {
            Enable = new ToggleNode(true);
        }

    }
}
