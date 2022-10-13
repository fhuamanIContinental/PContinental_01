using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pruebaED01.Model.Common;
using pruebaED01.Model.RequestResponse;

namespace pruebaED01.Midleware
{
    public class ErrorMidleware
    {
        private readonly RequestDelegate next;
        public ErrorMidleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (SqlException ex) // SQL SERVER // MYSQLDATABASEXECPTIONS
            {
                CustomException exx = new CustomException("Error no controlado, base de datos", 510, ex.Number, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (DbUpdateException ex)
            {
                var err = ex.GetBaseException() as SqlException;
                //ex.InnerException.
                CustomException exx = new CustomException("Error no controlado", 511, err.Number, "Data base", ex);
                await HandleExceptionAsync(context, exx);
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error no controlado", 500, 500, "", ex);
                await HandleExceptionAsync(context, exx);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            var controllerActionDescriptor = context.GetEndpoint().Metadata.GetMetadata<ControllerActionDescriptor>();
            var controllerName = controllerActionDescriptor.ControllerName;
            var actionName = controllerActionDescriptor.ActionName;


            InfoRequest info = new InfoRequest();
            info = HelperHttpContext.GetInfoRequest(context);
            ErrorResponse error = new ErrorResponse();
            //ErrorBussniess errorDominio = new ErrorBussniess();
            //error = errorDominio.Register(ex, info);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.httpCode;

            //return context.Response.WriteAsync(JsonConvert.SerializeObject(error));

            return context.Response.WriteAsJsonAsync(error);

        }
    }
}