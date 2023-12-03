using BlazorWasmWithDocker.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmWithDocker.Services
{
    public class AppStateService
    {
        //Repeat for each property you need to track...
        public string? SearchTerm { get; private set; }
        public Tomato[]? Tomatoes { get; private set; }

         //Repeat for each property you update...
        public void UpdateSearchTerm(ComponentBase Source, string SearchTerm)
        {
            this.SearchTerm = SearchTerm;
            NotifyStateChanged(Source, "SearchTerm");
        }
        public void UpdateTomatoList(ComponentBase Source, Tomato[] Tomatoes)
        {
            this.Tomatoes = Tomatoes;
            NotifyStateChanged(Source, "Tomatoes");
        }

        //Event handler to pass component and property that has changed!
        public event Action<ComponentBase, string>? StateChanged;

        //This is called above when property is updated!
        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);


    }
}
