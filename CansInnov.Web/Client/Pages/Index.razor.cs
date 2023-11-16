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
        private List<EventDto>? _events;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public NotificationService NotificationService { get; set; }

        public List<EventDto>? Events
        {
            get { return _events; }
            set
            {
                _events = value;
                StateHasChanged();
            }
        }

        public void EventClicked(Guid eventId)
        {
            NavigationManager.NavigateTo($"event/{eventId}/atelier");
        }

        public async void CreateEventClicked()
        {
            bool? created = await DialogService.OpenAsync<EventForm>("Créer Evènement");

            if (created.HasValue && created.Value)
            {
                Events = await Http.GetFromJsonAsync<List<EventDto>>("api/Event");
            }
        }

        public async void UpdateEventClicked(EventDto @event)
        {
            bool? updated = await DialogService.OpenAsync<EventForm>($"Modifier Evènement {@event.Titre}",
                new Dictionary<string, object> { { nameof(EventForm.Event), @event }, { nameof(EventForm.ExistingEvent), true } });

            if (updated.HasValue && updated.Value)
            {
                Events = await Http.GetFromJsonAsync<List<EventDto>>("api/Event");
            }
        }

        public async void DeleteEventClicked(Guid id)
        {
            HttpResponseMessage response = await Http.DeleteAsync($"api/Event/{id}");
            if (response.IsSuccessStatusCode)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Evènement supprimé",
                    Duration = 4000
                });
                Events = await Http.GetFromJsonAsync<List<EventDto>>("api/Event");
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
            Events = await Http.GetFromJsonAsync<List<EventDto>>("api/Event");
        }
    }
}