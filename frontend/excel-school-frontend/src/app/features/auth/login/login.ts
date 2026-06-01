import { Component, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/services/auth-service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  imports: [ButtonModule, PasswordModule, InputTextModule, CheckboxModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  //Créer le FormGroup avec validators
  //Récupérer les valeurs du formulaire

  public fb = inject(FormBuilder);
  public authService = inject(AuthService);
  public router = inject(Router);
  public user = {};

  loginForm = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });

  onSubmit() {
    //si le formulaire est valide envoyer l requete au backend
    if (this.loginForm.valid) {
      //Appeler authService.login()
      this.authService
        .login(this.loginForm.value.email!, this.loginForm.value.password!)
        .subscribe({
          //Si succès → ajouter le token et le role dans le localstorage,
          // puis redigier le user vers la page dashboard
          next: (user) => {
            localStorage.setItem('token', user.token);
            localStorage.setItem('role', user.role);
            localStorage.setItem('user', user.firstName);
            this.router.navigate(['/dashboard']);
          },
          //Si erreur → pour le moment faire un console.log
          error: (err) => {
            console.log('une erreur est survenue', err);
          },
        });
    }
  }
}
