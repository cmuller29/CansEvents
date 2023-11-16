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

        public DateTime EventStartDate => _ateliers?.OrderBy(x => x.DateDebut)?.FirstOrDefault()?.DateDebut ?? DateTime.Now;

        protected override async Task OnInitializedAsync()
        {
            Ateliers = await Http.GetFromJsonAsync<List<AtelierDto>>($"api/Event/{EventId}/atelier");
        }

        public async void CreateAtelierClicked()
        {
            bool? created = await DialogService.OpenAsync<AtelierForm>("Créer Atelier",
                new Dictionary<string, object>() { 
                    { nameof(AtelierForm.Atelier), new AtelierDto { EventId = Guid.Parse(EventId) } } 
                });

            if (created.HasValue && created.Value)
            {
                Ateliers = await Http.GetFromJsonAsync<List<AtelierDto>>($"api/Event/{EventId}/atelier");
            }
        }

        public async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<AtelierDto> args)
        {
            bool? updated = await DialogService.OpenAsync<AtelierForm>($"Atelier {args.Data.Titre}",
                new Dictionary<string, object> { 
                    { nameof(AtelierForm.Atelier), args.Data }, 
                    { nameof(AtelierForm.ExistingAtelier), true } 
                });

            if (updated.HasValue && updated.Value)
            {
                Ateliers = await Http.GetFromJsonAsync<List<AtelierDto>>($"api/Event/{EventId}/atelier");
            }
        }
    }
}