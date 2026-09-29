using System;
using Microsoft.AspNetCore.Diagnostics;

namespace excel_school_app.GlobalException
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
            )
        {
           
            int status = 500;
            string title = "Erreur serveur";
            string detail = "Une erreur inattendue est survenue.";

            if (exception is InvalidCredentialsException)
            {
                status = 401;
                title = "Non autorisé";
                detail = "Email ou mot de passe incorrect";
            // 1. Journalisation au niveau LogWarning (ce n'est pas un crash serveur, mais une anomalie de sécurité)
             _logger.LogWarning(exception, "Tentative d'accès non autorisée détectée sur l'URL : {Path}", httpContext.Request.Path);
            }

            else if (exception is EmailAlreadyUsedException)
            {
                status = 409;
                title = "Conflit";
                detail = "Cette email est déjà utilisé";

                   // 1. Journalisation au niveau LogWarning (ce n'est pas un crash serveur, mais une anomalie de sécurité)
             _logger.LogWarning(exception, "Cette email est deja utilisé pour un autre compte : {Path}", httpContext.Request.Path);
            } else
            {           
                    _logger.LogError(exception,"une erreur");
            }
    
            httpContext.Response.StatusCode = status;
            httpContext.Response.ContentType = "application/problem+json";
            
             await httpContext.Response.WriteAsJsonAsync(new 
            {
            Status = status,
            Title = title,
            Detail = detail
            }, cancellationToken);
    
            return true;
        }
    }
}
