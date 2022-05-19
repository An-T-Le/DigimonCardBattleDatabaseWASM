using DigimonCardBattleDatabase.Classes;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DigimonCardBattleDatabase.Pages
{
    public partial class Fusion : ComponentBase
    {
        [Parameter]
        //Set to -1 to indicate there is no value
        public int CardId { get; set; } = -1;

        [Parameter]
        public DigimonCardData? CardData { get; set; }

        private DigimonCardData[]? data;

        private FusionManager? _fusionManager;
        protected override async Task OnInitializedAsync()
        {
            if (CardId >= 0)//95148sanjose
            {
                data = await Http.GetFromJsonAsync<DigimonCardData[]>("Data/DigimonCardData.json");
                if (data != null)
                {
                    Console.WriteLine("data:" + data.Count());
                    CardData = data[CardId];
                }

                _fusionManager = new FusionManager(CardData,data);
            }
        }

    }

}