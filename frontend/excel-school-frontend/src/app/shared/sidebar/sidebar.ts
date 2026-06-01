import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AvatarModule } from 'primeng/avatar';
import { Button } from 'primeng/button';
import { AuthService } from '../../core/services/auth-service';
@Component({
  selector: 'app-sidebar',
  imports: [Button, RouterLink, RouterLinkActive, AvatarModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.scss',
})
export class Sidebar implements OnInit {
  authService = inject(AuthService);
  role: string = '';
  username: string | null = '';

  userRoles = ['Parent', 'Eleve', 'Professeur', 'Administrateur'];

  ngOnInit() {
    // Mettre ici le code à exécuter lors de l'initialisation du composant
    let getUserRole = this.authService.getUserRole();
    this.role = this.userRoles[Number(getUserRole)];

    let userName = this.authService.getUser();
    this.username = userName;
  }
}
