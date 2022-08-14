namespace DigimonCardBattleDatabase.Classes
{
    public class FusionTree
    {
        public FusionTree? LeftMaterial;
        public FusionTree? RightMaterial;
        public DigimonCardData? cardData;
        
        public FusionTree()
        {
            LeftMaterial = null;
            RightMaterial = null;
            cardData = null;
        }

        public FusionTree(DigimonCardData targetCard)
        {
            LeftMaterial = null;
            RightMaterial = null;
            cardData = targetCard;
        }
        public Dictionary<string, int> EntryCount(Dictionary<string,int>? result = null, FusionTree? node = null )
        {
            if(result == null)
            {
                result = new Dictionary<string, int>();
            }
            if(node == null)
            {
                node = this;
            }

            
            

            if(node.LeftMaterial != null)
            {
                EntryCount(result, node.LeftMaterial);

                if(!result.ContainsKey(node.LeftMaterial.cardData.Name))
                {
                    result.Add(node.LeftMaterial.cardData.Name, 0);                
                }
                result[node.LeftMaterial.cardData.Name]++;

            }
            if(node.RightMaterial != null)
            {
                EntryCount(result, node.RightMaterial);

                if (!result.ContainsKey(node.RightMaterial.cardData.Name))
                {
                    result.Add(node.RightMaterial.cardData.Name, 0);
                }
                result[node.RightMaterial.cardData.Name]++;
            }

            return (result);
        }
    }
}
