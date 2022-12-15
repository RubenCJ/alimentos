import { Component } from '@angular/core';
import { Alimento } from './models/alimento';
import { AlimentoService } from './services/alimento.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'APP Alimentos';
  
  constructor() {}

  ngOnInit() {
  }

}
