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
    }
}
