using System.Net.Http.Json;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CansInnov.Client.Components
{
    public partial class EventForm
    {
        [Parameter]
        public CreateEventCommand Event { get; set; } = new CreateEventCommand();

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        public async void Submit()
        {
            await Http.PostAsJsonAsync("Event", Event);
        }

        public void Cancel()
        {
            DialogService.Close();
        }
    }
}