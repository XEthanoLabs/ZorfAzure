namespace Zorf.Adventure
{
    public enum ItemType
    {
        None = 0,
        Matches,
        Lighter,
        Gas,
        SkeletonKey,
        BrassKey,
        Sword,
        Dagger,
        RubyRing,
        EmeraldRing,
        CobaltRing,
        Pamphlet,
        Underwear,
    }

    public class Item
    {
        public ItemType Type = ItemType.None;
        public string Name = string.Empty;
        public int Weight = 0;
        public string DescL = string.Empty;
        public string Desc = string.Empty;
        public RoomType RoomId;
    }

    public class Items
    {
        static List<Item> s_Items = new List<Item>();

        Items()
        {
            s_Items.Add(new Item() { Type = ItemType.Matches, Desc = "A book of matches", DescL = "A book of matches", Name = "Matches", Weight = 1 });
            s_Items.Add(new Item() { Type = ItemType.Lighter, Desc = "A lighter", DescL = "A greasy lighter found in the back of a pickup truck", Name = "Lighter", Weight = 1 });
        }
    }

}
