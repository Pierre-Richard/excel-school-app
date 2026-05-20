import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
@Component({
  selector: 'app-login',
  imports: [ButtonModule, PasswordModule, InputTextModule, CheckboxModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {}
