using System.Text;

namespace DigimonCardBattleDatabase.Classes
{
    public class FusionManager
    {

        private DigimonCardData _targetCard;
        private Dictionary<string,List<DigimonCardData>> _cardDatabase;
        private DigimonCardFusionCombinations _digimonCardFusionCombinations;
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
            _digimonCardFusionCombinations = new DigimonCardFusionCombinations();
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
            string[,] combinations = _digimonCardFusionCombinations.FusionResultsDictionary[targetCard.Specialty];
            
            //foreach (string combination in combinations)
            //{
            //    Console.WriteLine(combination);
            //}

            
            FilterCardList(cardDatabase);
            
        }

        /// <summary>
        /// Generates and returns a string containing the ingredient list for the fusion
        /// </summary>
        public string GetFusionRecipe()
        {
            if (_targetCard.FusionMaterialCost > 0)
            {
                GenerateFusionRecipe(_fusionTree);

            }
            string result = ParseFusionTree(_fusionTree);
            return (result);
        }

        private string ParseFusionTree(FusionTree fusionTree)
        {
            StringBuilder resultSb = new StringBuilder();

            Dictionary<string, int> entryCount = fusionTree.EntryCount();
            foreach(KeyValuePair<string, int> entry in entryCount)
            {
                resultSb.Append (entry.Key + ":" + entry.Value+"\n");
            }

            return (resultSb.ToString());

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
            Console.WriteLine("FindFusionCadidates for: " + fusionTree.cardData.Name);
            return (RecursiveFusionSearch(fusionTree));
        }
        private FusionTree RecursiveFusionSearch(FusionTree fusionTree)
        {
            DigimonCardData[] digimonCardDatas = FindFusionCadidates(fusionTree.cardData);

            Console.WriteLine("Left material recusion activated");
            Console.WriteLine("FindFusionCadidates for: " + digimonCardDatas[0].Name);
            if (/*!digimonCardDatas[0].Level.Equals("R") ||*/ digimonCardDatas[0].FusionMaterialCost > 9)
            {
                fusionTree.LeftMaterial = RecursiveFusionSearch( new FusionTree(digimonCardDatas[0]));
            }
            else
            {
                fusionTree.LeftMaterial = new FusionTree(digimonCardDatas[0]);
            }

            Console.WriteLine("Right material recusion activated");
            Console.WriteLine("FindFusionCadidates for: " + digimonCardDatas[1].Name);
            if (/*!digimonCardDatas[1].Level.Equals("R") ||*/ digimonCardDatas[1].FusionMaterialCost > 9)
            {
                fusionTree.RightMaterial = RecursiveFusionSearch(new FusionTree(digimonCardDatas[1]));
            }
            else
            {
                fusionTree.RightMaterial= new FusionTree(digimonCardDatas[1]);
            }

            return (fusionTree);
        }
        /// <summary>
        /// Rules of fusion are card 1 material value + card 2 material value = result fusion total
        /// Exception to this rule is that the result cannot be the same card as the material.
        /// for example, Agumon (value 5) + Circle Hitter (Value 5) would give Flarerizamon (total 11)
        /// </summary>
        /// <param name="targetCard">The card being fused to</param>
        /// <returns></returns>
        private DigimonCardData[] FindFusionCadidates(DigimonCardData targetCard)
        {
            DigimonCardData[] results = new DigimonCardData[2];
             int[] targetFusionCosts = new int[2];
            string[,] combinations = _digimonCardFusionCombinations.FusionResultsDictionary[targetCard.Specialty];
            
            
            
            //If the target card is NOT an option card look for a card with the same specialty 1 rank lower
            // to fuse up with an option card half the material points of the target card fusion cost
            if (!targetCard.Specialty.Equals("Option"))
            {
                foreach(DigimonCardData i in _cardDatabase[targetCard.Specialty])
                {
                    if(i.FusionMaterialCost == targetCard.FusionMaterialCost-1)
                    {
                        results[0] = i;
                    }
                }
                results[1] = _cardDatabase["Option"].Find((e) => (e.FusionMaterialPoints == (int)Math.Floor((double)targetCard.FusionMaterialCost / 2)) && e.FusionMaterialCost != 0);
                
                Console.WriteLine(results[0].Name + "+" + results[1].Name);
                return results;
            }

            //calculate the fusion material cost.
            //use math.ceiling/floor for each cost and add/subtract 1 to prevent infinite loop
            // Clamp to not go below 2
            
            targetFusionCosts[0] = Math.Clamp((int)Math.Ceiling((double) targetCard.FusionMaterialCost / 2) ,2,999);
            targetFusionCosts[1] = Math.Clamp((int)Math.Floor((double)targetCard.FusionMaterialCost / 2) ,2,999); 
            

            for (int i = 0; i < results.Length; i++)
            {
                for (int j = 0; j < _cardDatabase[combinations[0,i]].Count; j++)
                {
                    if(_cardDatabase[combinations[0,i]][j].FusionMaterialPoints == targetFusionCosts[i])
                    {
                        results[i] = _cardDatabase[combinations[0,i]][j];
                    }
                }
            }
            Console.WriteLine(targetFusionCosts[0] + " " + targetFusionCosts[1]);
            Console.WriteLine(results[0].Name + "+" + results[1].Name);

            return (results);
        }
    }
}
