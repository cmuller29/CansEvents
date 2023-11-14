using System.Diagnostics.Tracing;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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

        [Inject]
        public NotificationService NotificationService { get; set; }

        public List<EventDto>? Events { get; set; }

        public void EventClicked(Guid eventId)
        {
            NavigationManager.NavigateTo($"event/{eventId}/ateliers");
        }

        public async void CreateEventClicked()
        {
            bool created = await DialogService.OpenAsync<EventForm>("Créer Evènement");

            if (created)
            {
                Events = null;
                StateHasChanged();
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Evènement créé",
                    Duration = 4000
                });
                Events = await Http.GetFromJsonAsync<List<EventDto>>("Event");
                StateHasChanged();
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Une erreur est survenue",
                    Duration = 4000
                });
            }
        }

        public async void DeleteEventClicked(Guid id)
        {
            HttpResponseMessage response = await Http.DeleteAsync($"Event/{id}");
            if (response.IsSuccessStatusCode)
            {
                Events = null;
                StateHasChanged();
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Evènement supprimé",
                    Duration = 4000
                });
                Events = await Http.GetFromJsonAsync<List<EventDto>>("Event");
                StateHasChanged();
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Une erreur est survenue",
                    Duration = 4000
                });
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Events = await Http.GetFromJsonAsync<List<EventDto>>("Event");
        }
    }
}