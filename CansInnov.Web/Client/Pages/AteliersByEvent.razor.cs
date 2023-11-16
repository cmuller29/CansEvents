using System.Net.Http.Json;
using Blazored.LocalStorage;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Client.Components;
using CansInnov.Persistence.Models;
using CansInnov.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor.Rendering;

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

        [Inject]
        ILocalStorageService LocalStorage { get; set; }

        public List<AtelierDto> Ateliers
        {
            get { return _ateliers; }
            set
            {
                _ateliers = value;
                StateHasChanged();
            }
        }

        public UserInfo User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<UserInfo>("currentuser");
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

        public void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<AtelierDto> args)
        {
            if (args.Data.Participants.Any(x => x == User.UserMatricule))
            {
                args.Attributes["style"] = "background: red";
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