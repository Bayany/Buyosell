namespace Buyosell.Core.Models.Categories
{
    public class RealState : Category
    {
        public RealState()
        {
            base.Name = "RealState";
        }

        public bool hasElevator { get; set; }
        public string BArea { get; set; }
        public string BFloorNumber { get; set; }
        public string RoomCount { get; set; }
    }
}