import { HttpHeaders, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth-service';

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  //Les intercepteurs HTTP sont des outils très utiles dans les applications Angular
  // qui permettent de traiter les requêtes et les réponses HTTP
  // avant qu'elles ne soient envoyées ou reçues par le serveu
  let token = authService.getToken();

  if (!token) {
    return next(req);
  }

  const headers = new HttpHeaders({
    Authorization: `Bearer ${token}`,
  });

  const newReq = req.clone({
    headers,
  });

  return next(newReq);
};
