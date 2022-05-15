namespace DigimonCardBattleDatabase.Classes
{
    public class DigimonCardFusionCombinations
    {
        public Dictionary<string, Dictionary<string, string>> FusionResultsDictionary { get; private set; } =  new Dictionary<string,Dictionary<string,string>>
            {
            { "Fire",new Dictionary<string, string>
                {
                    {"Fire","Option"},
                    {"Ice","Darkness"},
                    {"Rare","Darkness"},
                }
            } ,
            { "Ice",new Dictionary<string, string>
                {
                    {"Fire","Rare"},
                    {"Ice","Option"},
                    {"Nature","Darkness"}
                }
            },
            { "Nature",new Dictionary<string, string>
                {
                    {"Fire","Ice"},
                    {"Ice","Rare"},
                    {"Nature","Option"}
                }
            },
            { "Darkness",new Dictionary<string, string>
                {
                    {"Fire","Nature"},
                    {"Nature","Rare"},
                    {"Darkness","Option"}
                }
            },
            { "Rare",new Dictionary<string, string>
                {
                    {"Fire","Darkness"},
                    {"Ice","Nature"},
                    {"Rare","Option"}
                }
            },
            { "Option",new Dictionary<string, string>
                {
                    {"Fire","Fire"},
                    {"Ice","Ice"},
                    {"Nature","Nature"},
                    {"Darkness","Darkness"},
                    {"Rare","Rare"},
                    {"Option","Option"},
                }
            },
        };
    }
}
