using DigimonCardBattleDatabase.Classes;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DigimonCardBattleDatabase.Pages
{
    public partial class Fusion : ComponentBase
    {
        [Parameter]
        public int CardId { get; set; }

        [Parameter]
        public DigimonCardData? CardData { get; set; }

        private DigimonCardData[]? data;

        protected override async Task OnInitializedAsync()
        {
            data = await Http.GetFromJsonAsync<DigimonCardData[]>("Data/DigimonCardData.json");
            if (data != null)
            {
                Console.WriteLine("data:" + data.Count());
                CardData = data[CardId];
            }
        }

    }

}