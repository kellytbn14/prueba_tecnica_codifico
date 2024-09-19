import { Component } from '@angular/core';
import {MenubarModule} from "primeng/menubar";
import {AvatarModule} from "primeng/avatar";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MenubarModule,
    AvatarModule
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

}
