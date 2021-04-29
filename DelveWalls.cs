using ExileCore;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using SharpDX;


namespace DelveWalls
{

    public class DelveWalls : BaseSettingsPlugin<Settings>
    {

        private IngameUIElements _inGameUi;

        public override void OnLoad()
        {
                    Graphics.InitImage("directions.png");
        }

        public override bool Initialise()
        {
            _inGameUi = GameController.IngameState.IngameUi;
            return true;
        }

        public override void Render()
        {
            if (!GameController.InGame)
                return;
            if (GameController.Area.CurrentArea.IsTown)
                return;
            if (GameController.Area.CurrentArea.IsHideout)
                return;
            if (GameController.IsLoading)
                return;
            if (_inGameUi.StashElement.IsVisible)
                return;
            if (_inGameUi.InventoryPanel.IsVisible)
                return;
            if (_inGameUi.OpenLeftPanel.IsVisible)
                return;
            if (_inGameUi.OpenRightPanel.IsVisible)
                return;
            if (_inGameUi.DelveWindow.IsVisible)
                return;
         //   if (GameController.Area.CurrentArea.Name.Contains("Azurite Mine"))
         //       Placeholder for Restricted Area later

            var entities = GameController.Entities;

            if (entities == null)
                return;
            foreach (var e in entities)
            {
                if (e.Path.Contains("Resonator") && DrawArrow(e)
//                     || e.Path.Contains("2_1") && DrawArrow(e)
//                     || e.Path.Contains("1_2") && DrawArrow(e)
//                     || e.Path.Contains("1_3") && DrawArrow(e)
//                     || e.Path.Contains("Unique") && DrawArrow(e)
                    || e.Path.Contains("Currency") && DrawArrow(e)
                    || e.Path.Contains("Fossil") && DrawArrow(e)
//                    || e.Path.Contains("DelveWall") && DrawArrow(e)
//                     || e.Path.Contains("DelveMiningSuppliesFlares") && DrawArrow(e)
//                     || e.Path.Contains("DelveMiningSuppliesDynamite") && DrawArrow(e)
)
                {
                    return;
                }


            }
        }

        public bool DrawArrow(Entity e)
        {
            //    If chest is closed, show arrow. If chest is open, don't show arrow.
                if (!e.IsTargetable)
                return false;


            var delta = e.GridPos - GameController.Player.GridPos;
            var distance = delta.GetPolarCoordinates(out var phi);
            if (distance > Settings.Dist) return false;
            var dir = MathHepler.GetDirectionsUV(phi, distance);
            //LogMessage($"Wall close Distance {distance}  Direction {Dir}", 1);
           
            var center = new Vector2(Settings.PosX, Settings.PosY); // Resolution halfed. 960 x 2 = 1920 (1080p)

            var rectDirection = new RectangleF(center.X -20, center.Y -40, Settings.ArrowSize, Settings.ArrowSize); // Last 40,40 refers to size of arrow icon

            var TextName = new Vector2(Settings.PosX, Settings.PosY);


            // If node contains X or Y chests/walls then change direction arrow color.


//             if (e.Path.Contains("Unique"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.UniqueColor);
//                 Graphics.DrawText(("Unique"), TextName, Color.White, 10, FontAlign.Center);
//             }

            // Rich, Pure azurite nodes
//             if (e.Path.Contains("1_2")
//                 || e.Path.Contains("1_3")
//                 || e.Path.Contains("2_1"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.AzuriteColor);
//                 Graphics.DrawText(("Azurite Node"), TextName, Color.White, 10, FontAlign.Center);
//             }

//             if (e.Path.Contains("Resonator"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.ResColor);
//                 Graphics.DrawText(("Resonator"), TextName, Color.White, 10, FontAlign.Center);
//             }

            if (e.Path.Contains("Currency"))
            {
                Graphics.DrawImage("directions.png", rectDirection, dir, Settings.CurrencyColor);
                Graphics.DrawText(("Currency"), TextName, Color.White, 10, FontAlign.Center);
            }
            if (e.Path.Contains("Fossil"))
            {
                Graphics.DrawImage("directions.png", rectDirection, dir, Settings.FossilColor);
                Graphics.DrawText(("Fossil"), TextName, Color.White, 10, FontAlign.Center);
            }
//             if (e.Path.Contains("DelveWall"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.WallColor);
//                 Graphics.DrawText(("Delve Wall"), TextName, Color.White, 10, FontAlign.Center);
//             }

//             if (e.Path.Contains("DelveMiningSuppliesFlares"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.FlareColor);
//                 Graphics.DrawText(("Flares"), TextName, Color.White, 10, FontAlign.Center);
//             }

//             if (e.Path.Contains("DelveMiningSuppliesDynamite"))
//             {
//                 Graphics.DrawImage("directions.png", rectDirection, dir, Settings.DynaColor);
//                 Graphics.DrawText(("Dynamite"), TextName, Color.White, 10, FontAlign.Center);
//             }

            return true;
        }
    }
}
