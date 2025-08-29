using Cultura.Application.Dtos.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cultura.Application.Validators
{
    public class EventoValidator : AbstractValidator<EventoInputDto>
    {
        public EventoValidator() 
        {

        }
    }
}
