using System.Net.Http.Json;
using System.Text;
using AutoMapper;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Persistence.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Radzen;

namespace CansInnov.Client.Components
{
    public partial class EventForm
    {
        [Parameter]
        public EventDto Event { get; set; } = new EventDto();

        [Parameter]
        public bool ExistingEvent { get; set; } = false;

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NotificationService NotificationService { get; set; }

        public async void Submit(EventDto args)
        {
            HttpResponseMessage response;
            if (ExistingEvent)
            {
                response = await Http.PutAsJsonAsync($"api/Event", Mapper.Map<UpdateEventCommand>(args));
            }
            else
            {
                response = await Http.PostAsJsonAsync("api/Event", Mapper.Map<CreateEventCommand>(args));
            }

            if (response.IsSuccessStatusCode)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = ExistingEvent ? "Evènement mis à jour" : "Evènement créé",
                    Duration = 4000
                });
            }
            else
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = "Une erreur est survenue",
                    Detail = await response.Content.ReadAsStringAsync(),
                    Duration = 4000
                });
            }

            DialogService.Close(response.IsSuccessStatusCode);
        }

        public void Cancel()
        {
            DialogService.Close(false);
        }
    }
}