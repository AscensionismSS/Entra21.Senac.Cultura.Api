using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Entra21.Senac.Cultura.Api.Filters
{

    public class ValidationFilter<T> : IAsyncActionFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var dto = context.ActionArguments.Values.OfType<T>().FirstOrDefault();

            if (dto == null)
            {
                context.Result = new BadRequestObjectResult("Objeto inválido ou ausente.");
                return;
            }

            var resultado = await _validator.ValidateAsync(dto);

            if (!resultado.IsValid)
            {
                var errosAgrupados = resultado.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToList()
                    );

                context.Result = new BadRequestObjectResult(new
                {
                    Status = 400,
                    Timestamp = DateTime.UtcNow,
                    Erros = errosAgrupados
                });

                return;
            }

            await next();
        }
    }
}