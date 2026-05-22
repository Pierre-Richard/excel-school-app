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
  //Appeler authService.login()
  //Si succès → ...
  //Si erreur → ...

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
      this.authService
        .login(this.loginForm.value.email!, this.loginForm.value.password!)
        .subscribe({
          next: (user) => {
            localStorage.setItem('token', user.token);
            localStorage.setItem('role', user.role);
            this.router.navigate(['/dashboard']);
          },
          error: (err) => {
            console.log('une erreur est survenue', err);
          },
        });
    }
  }
}
