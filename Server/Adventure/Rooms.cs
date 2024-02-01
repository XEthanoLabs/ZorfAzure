namespace Zorf.Adventure
{
    public enum RoomType
    {
        None = 0,
        GrassyField,
        OutsideHouse,
        Foyer,
        Kitchen,
        LivingRoom,
        FamilyRoom,
        BackDesck
    }

    public enum ExitDirs
    {
        N,
        E,
        S,
        W,
        U,
        D
    }

    public class RoomBase
    {
        public string m_szDesc = string.Empty;
        public string m_szDescL = string.Empty;
        public RoomType Id = RoomType.None;
        public Dictionary<ExitDirs, RoomType> Exits = new Dictionary<ExitDirs, RoomType>();
        public bool Lit = false;
    }

    public class Rooms
    {
        static Dictionary<RoomType, RoomBase> m_Rooms = new Dictionary<RoomType, RoomBase>()
        {
            {
                RoomType.GrassyField, new RoomBase()
                {
                    m_szDesc = "Grassy Field",
                    m_szDescL = "You are in a grassy field. It is quiet here. Even the crickets are not playing cricket. The grass is old and dead. There is a house to the north.",
                    Id = RoomType.GrassyField, Exits = new Dictionary<ExitDirs, RoomType>()
                    {
                        { ExitDirs.N, RoomType.Kitchen },
                        { ExitDirs.E, RoomType.Foyer}
                    },
                    Lit = true,
                }
            },
            {
                RoomType.OutsideHouse, new RoomBase()
                {
                    m_szDesc = "Front Porch",
                    m_szDescL = "You are standing on an old rickety porch. A run-down old house is in front of you. The door is slightly ajar. It beckons to you...",
                    Id = RoomType.OutsideHouse, Exits = new Dictionary<ExitDirs, RoomType>()
                    {
                        { ExitDirs.N, RoomType.Kitchen },
                        { ExitDirs.E, RoomType.Foyer}
                    },
                    Lit = true,
                }
            }
        };
    
    }
}
