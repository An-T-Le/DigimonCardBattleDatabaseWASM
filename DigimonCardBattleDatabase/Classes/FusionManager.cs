namespace DigimonCardBattleDatabase.Classes
{
    public class FusionManager
    {

        private DigimonCardData _targetCard;
        private Dictionary<string,List<DigimonCardData>> _cardDatabase;
        
        private FusionTree _fusionTree;
        private List<string> _excludeList = new List<string>();
        private Dictionary<string, Dictionary<string, string>> _fusiontypeResults = new Dictionary<string, Dictionary<string, string>>
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
        public FusionManager(DigimonCardData targetCard, DigimonCardData[] cardDatabase)
        {
            _targetCard = targetCard;
            _fusionTree = new FusionTree(_targetCard);
            _cardDatabase = new Dictionary<string, List<DigimonCardData>>
            {
                {
                    "Fire",new List<DigimonCardData>()
                },
                {
                    "Ice",new List<DigimonCardData>()
                },
                {
                    "Nature",new List<DigimonCardData>()
                },
                {
                    "Darkness",new List<DigimonCardData>()
                },
                {
                    "Rare",new List<DigimonCardData>()
                },
                {
                    "Option",new List<DigimonCardData>()
                },
            };
            
            FilterCardList(cardDatabase);
            Console.Out.WriteLine(_cardDatabase.ToString());
        }

        private void FilterCardList(DigimonCardData[] cardDatabase)
        {
            foreach (DigimonCardData card in cardDatabase)
            {
                _cardDatabase[card.Specialty].Add(card);
            }
        }
        public FusionTree GenerateFusionRecipe(FusionTree fusionTree)
        {

            //fusionTree.LeftMaterial
            return (fusionTree);
        }
        private FusionTree RecursiveFusionSearch(FusionTree fusionTree)
        {
            DigimonCardData[] digimonCardDatas = FindFusionCadidates(fusionTree.cardData);            
            
            if(digimonCardDatas[0].FusionMaterialCost > 4)
            {
                fusionTree.LeftMaterial = RecursiveFusionSearch( new FusionTree(digimonCardDatas[0]));
            }
            else
            {
                fusionTree.LeftMaterial = new FusionTree(digimonCardDatas[0]);
            }

            if (digimonCardDatas[1].FusionMaterialCost > 4)
            {
                fusionTree.RightMaterial = RecursiveFusionSearch(new FusionTree(digimonCardDatas[1]));
            }
            else
            {
                fusionTree.RightMaterial= new FusionTree(digimonCardDatas[1]);
            }

            return (fusionTree);
        }

        private DigimonCardData[] FindFusionCadidates(DigimonCardData targetCard)
        {
            DigimonCardData[] result = new DigimonCardData[2];

            return (result);
        }
    }
}
