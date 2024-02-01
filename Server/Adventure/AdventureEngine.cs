using System.Numerics;
using System.Collections;

namespace Grpc3.Adventure
{
    public class User
    {
        public string id;
        public string name;

    }

    public class RoomBase
    {
        string m_szDesc;
        string m_szShortDesc;
        public int m_id;

    }

    struct Command
    {
        public string Verb;
        public string Second;
        public string Indirect;
    }

    public class AdventureEngine
    {
        public static AdventureEngine s_pEngine = new AdventureEngine();
        public List<RoomBase> m_Rooms = new List<RoomBase>();
        public Dictionary<string, User> m_Users = new Dictionary<string, User>();

        Command ParseCommand(string szCmd)
        {
            string[] szWords = szCmd.Split(' ');
            Command c = new Command();
            c.Verb = szWords[0];
            if( szWords.Length > 1 )
            {
                c.Second = szWords[1];
            }
            if( szWords.Length > 2 )
            {
                c.Indirect = szWords[2];
            }
            return c;
        }

        public string Command( string szUserId, string szCommand )
        {
            szCommand = szCommand.ToUpper();

            User pUser;
            Command c = ParseCommand(szCommand);

            if (!m_Users.ContainsKey(szUserId))
            {
                if( c.Verb != "LOGIN" )
                {
                    return "You can't do anything until you login.\n" +
                        "Type LOGIN YourName Password\n" +
                        "(If you don't have an account, it will be created. If you already have an account, the password must match.";
                }

                if( c.Second == "" )
                {
                    return "You must type LOGIN NAME PASSWORD";
                }

                // if that person already exists, then say so
                foreach( KeyValuePair<string, User> kvp in m_Users )
                {
                    if( kvp.Value.name == c.Second )
                    {
                        return "That user is already a user. Pick a different name.\n";
                    }

                    // what happens if they log out, but we don't take them out of the list?
                }

                // need to add this user
                pUser = new User();
                pUser.id = szUserId;
                pUser.name = c.Second;
                m_Users.Add(szUserId, pUser);

                return "You have successfully logged in, " + c.Second + "\n";
            }
            else
            {
                pUser = m_Users[szUserId];
            }

            if( szCommand == "LOOK" )
            {
                return "You're standing in a grassy field\n";
            }

            return "Unknown command.\n";
        }



    }
}
