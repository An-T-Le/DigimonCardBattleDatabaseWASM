using DigimonCardBattleDatabase.Classes;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DigimonCardBattleDatabase.Pages
{
    public partial class FetchData : ComponentBase
    {
        //readonly HttpClient? Http = new HttpClient();

       
        private DigimonCardData[]? data;

        protected override async Task OnInitializedAsync()
        {
            data = await Http.GetFromJsonAsync<DigimonCardData[]>("Data/DigimonCardData.json");
        }


    }
}
