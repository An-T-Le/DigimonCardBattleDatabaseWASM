namespace DigimonCardBattleDatabase.Classes
{
    public class FusionManager
    {
        private FusionTree _fusionTree;
        private List<string> _excludeList = new List<string>();
        private Dictionary<string, Dictionary<string, string>> fusiontypeResults = new Dictionary<string, Dictionary<string, string>>
        {
            { "Fire",new Dictionary<string, string>
                {
                    {"Fire","Option"},
                    {"Blue","Nature"},
                    {"Nature","Darkness"},
                    {"Darkness","Rare"},
                    {"Rare","Ice"},
                    {"Option","Fire"},
                }
            } ,
            { "Ice",new Dictionary<string, string>
                {
                    {"Blue","Option"},
                    {"Nature","Rare"},
                    {"Darkness","Fire"},
                    {"Rare","Nature"},
                    {"Option","Ice"},
                }
            },
            { "Nature",new Dictionary<string, string>
                {
                    {"Nature","Option"},
                    {"Darkness","Ice"},
                    {"Rare","Darkness"},
                    {"Option","Nature"},
                }
            },
            { "Darkness",new Dictionary<string, string>
                {
                    {"Darkness","Option"},
                    {"Rare","Fire"},
                    {"Option","Darkness"},
                }
            },
            { "Rare",new Dictionary<string, string>
                {
                    {"Rare","Option"},
                    {"Option","Rare"},
                }
            },
            { "Option",new Dictionary<string, string>
                {
                    {"Option","Option"}
                }
            },
        };
        public FusionManager()
        {

        }

        public void GenerateFusionRecipe(FusionTree fusionTree)
        {

        }
    }
}
