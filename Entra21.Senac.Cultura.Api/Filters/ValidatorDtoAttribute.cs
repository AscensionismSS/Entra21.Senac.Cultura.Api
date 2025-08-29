using Microsoft.AspNetCore.Mvc;


namespace Entra21.Senac.Cultura.Api.Filters
{
    public class ValidarDtoAttribute : TypeFilterAttribute
    {
        public ValidarDtoAttribute(Type tipoDto)
            : base(typeof(ValidationFilter<>).MakeGenericType(tipoDto))
        {
        }
    }
}