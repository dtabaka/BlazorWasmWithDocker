using BlazorWasmWithDocker.Models;
using Microsoft.AspNetCore.Components;
using BlazorWasmWithDocker.Shared;
using AntDesign;

namespace BlazorWasmWithDocker.Services
{
    public class AppStateService
    {
        //Repeat for each property you need to track...
        public string? SearchTerm { get; private set; }
        public Tomato[]? Tomatoes { get; private set; }
        public GrowingTip[]? GrowingTips { get; private set; }
        public string? AccessToken { get; private set; }

         //Repeat for each property you update...
        public void UpdateSearchTerm(ComponentBase Source, string SearchTerm)
        {
            this.SearchTerm = SearchTerm;
            NotifyStateChanged(Source, Enums.StateProperty.SearchTerm);
        }
        public void UpdateTomatoList(ComponentBase Source, Tomato[] Tomatoes)
        {
            this.Tomatoes = Tomatoes;
            NotifyStateChanged(Source, Enums.StateProperty.Tomatoes);
        }
        public void UpdateGrowingTips(ComponentBase Source, GrowingTip[] GrowingTips)
        {
            this.GrowingTips = GrowingTips;
            NotifyStateChanged(Source, Enums.StateProperty.GrowingTips);
        }

        public void UpdateAccesToken(ComponentBase Source, string AccessToken)
        {
            this.AccessToken = AccessToken;
            NotifyStateChanged(Source, Enums.StateProperty.AccessToken);
        }

        //Event handler to pass component and property that has changed!
        //public event Action<ComponentBase, string>? StateChanged;
        public event Action<ComponentBase, Enums.StateProperty>? StateChanged;

        //This is called above when property is updated!
        private void NotifyStateChanged(ComponentBase Source, Enums.StateProperty Property) => StateChanged?.Invoke(Source, Property);


    }
}
