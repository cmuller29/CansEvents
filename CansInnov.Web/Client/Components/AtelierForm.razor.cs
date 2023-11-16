using System.Net.Http.Json;
using AutoMapper;
using Blazored.LocalStorage;
using CansInnov.Application.Features.Ateliers.Commands;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Radzen;

namespace CansInnov.Client.Components
{
    public partial class AtelierForm
    {
        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public NotificationService NotificationService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Parameter]
        public AtelierDto Atelier { get; set; } = new AtelierDto(); 
        
        [Parameter]
        public bool ExistingAtelier { get; set; } = false;

        public bool DeleteButtonDisabled => !ExistingAtelier;

        public bool SubscribeDisabled => 
            Atelier.Participants.Count >= Atelier.NbParticipantMax || Atelier.Participants.Any(x => x == User?.UserMatricule);

        public UserInfo User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await LocalStorage.GetItemAsync<UserInfo>("currentuser");
        }

        public async void Submit(AtelierDto args)
        {
            HttpResponseMessage response;
            if (ExistingAtelier)
            {
                response = await Http.PutAsJsonAsync($"api/Atelier", Mapper.Map<UpdateAtelierCommand>(args));
            }
            else
            {
                response = await Http.PostAsJsonAsync("api/Atelier", Mapper.Map<CreateAtelierCommand>(args));
            }

            if (response.IsSuccessStatusCode)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = ExistingAtelier ? "Atelier mis à jour" : "Atelier créé",
                    Duration = 4000
                });
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

            DialogService.Close(response.IsSuccessStatusCode);
        }

        public async void Subscribe()
        {
            HttpResponseMessage response = await Http.PostAsJsonAsync("api/Atelier/subscribe", new SubscribeToAtelierCommand
            {
                AtelierId = Atelier.Id,
                Matricule = User.UserMatricule
            });

            if (response.IsSuccessStatusCode)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Succès",
                    Detail = $"Vous êtes bien inscrit à {Atelier.Titre}",
                    Duration = 4000
                });
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

            DialogService.Close(response.IsSuccessStatusCode);
        }

        public void Cancel()
        {
            DialogService.Close(false);
        }

        public async Task Delete()
        {
            HttpResponseMessage response = await Http.DeleteAsync($"api/Atelier/{Atelier.Id}");

            if (response.IsSuccessStatusCode)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Atelier supprimé",
                    Duration = 4000
                });
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

            DialogService.Close(response.IsSuccessStatusCode);
        }
    }
}