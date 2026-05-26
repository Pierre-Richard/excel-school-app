import { Component } from '@angular/core';
import { DrawerModule } from 'primeng/drawer';
import { Button } from 'primeng/button';
@Component({
  selector: 'app-sidebar',
  imports: [DrawerModule, Button],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.scss',
})
export class Sidebar {
  visible: boolean = true;
}
