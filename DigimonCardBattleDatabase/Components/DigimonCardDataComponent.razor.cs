using Microsoft.AspNetCore.Components;
using DigimonCardBattleDatabase.Classes;

namespace DigimonCardBattleDatabase.Components
{
    public partial class DigimonCardDataComponent : ComponentBase
    {
        [Parameter]
        public DigimonCardData CardData { get; set; }

        private bool isButtonVisible { get; set; } = false;

        private void ToggleButtonVisiblity()
        {
            //Disable the button when used on other pages
            if (NavigationManager.Uri.Contains("fetchdata"))
            {
                isButtonVisible = !isButtonVisible;
            }
        }
        private void FusionClickEvent()
        {
            Console.WriteLine("FusionClickEvent:" + CardData.Number);
            NavigationManager.NavigateTo("Fusion/" + CardData.Number);

        }
    }

}
