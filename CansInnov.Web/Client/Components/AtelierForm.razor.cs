using AutoMapper;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;
using Microsoft.AspNetCore.Components;
using Radzen;
using static System.Net.WebRequestMethods;

namespace CansInnov.Client.Components
{
    public partial class AtelierForm
    {
        [Inject]
        public DialogService DialogService { get; set; }

        public AtelierDto Atelier { get; set; }

        public async void Submit(AtelierDto args)
        {

        }

        public void Cancel()
        {
            DialogService.Close(false);
        }
    }
}