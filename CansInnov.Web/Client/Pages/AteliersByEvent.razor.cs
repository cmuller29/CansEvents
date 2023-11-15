using System.Net.Http.Json;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Client.Components;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CansInnov.Client.Pages
{
    public partial class AteliersByEvent
    {
        private List<AtelierDto> _ateliers;

        [Parameter]
        public string EventId { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        public List<AtelierDto> Ateliers
        {
            get { return _ateliers; }
            set
            {
                _ateliers = value;
                StateHasChanged();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Ateliers = await Http.GetFromJsonAsync<List<AtelierDto>>($"api/Event/{EventId}/atelier");
        }

        public async void CreateAtelierClicked()
        {
            bool created = await DialogService.OpenAsync<AtelierForm>("Créer Atelier");

            if (created)
            {
                Ateliers = await Http.GetFromJsonAsync<List<AtelierDto>>($"api/Event/{EventId}/atelier");
            }
        }

        public async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<AtelierDto> args)
        {
            //var data = await DialogService
            //  .OpenAsync<AtelierDetail>(
            //    "Edit Appointment",
            //    new Dictionary<string, object> { { "Appointment", args.Data } },
            //    new DialogOptions() { CloseDialogOnOverlayClick = true });

            //NotificationMessage message;
            //if (data)
            //{
            //    message = new()
            //    {
            //        Severity = NotificationSeverity.Success,
            //        Summary = "Inscrit avec succès",
            //        Detail = $"Vous êtes bien inscrit à l'atelier {args.Data.Titre}",
            //        Duration = 4000
            //    };
            //}
            //else
            //{
            //    message = new()
            //    {
            //        Severity = NotificationSeverity.Error,
            //        Summary = "Impossible de s'inscrire",
            //        Duration = 4000
            //    };
            //}

            //await Task.Delay(500);
            //notificationService.Notify(message);
        }
    }
}