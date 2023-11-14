using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using BlazorApp1.Shared;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Application.Features.Events.Queries;
using CansInnov.Client.Components;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CansInnov.Client.Pages
{
    public partial class Index
    {
        //[Inject]
        //public IMediator Mediator { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        public List<EventDto>? Events { get; set; }

        public void CardClicked(Guid eventId)
        {
            NavigationManager.NavigateTo($"event/{eventId}/ateliers");
        }

        public async void CreateEventClicked()
        {
            await DialogService.OpenAsync<EventForm>("Créer Evènement");
        }

        protected override async Task OnInitializedAsync()
        {
            //Events = await Mediator.Send(new GetEventListQuery());
            Events = await Http.GetFromJsonAsync<List<EventDto>>("Event");
        }
    }
}