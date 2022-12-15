import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Alimento } from '../models/alimento';

@Injectable({
  providedIn: 'root'
})
export class AlimentoService {

 private url = 'alimentos';

  constructor( private http: HttpClient ) { }

  public obtenerAlimentos() : Observable<Alimento[]> {
    return this.http.get<Alimento[]>(`${environment.apiUrl}/${this.url}`);
  }

  public obtenerAlimento(idAlimento: number) : Observable<Alimento> {
    return this.http.get<Alimento>(`${environment.apiUrl}/${this.url}/${idAlimento}`);
  }

  public guardarAlimento(alimento: Alimento) {
    return this.http.post(`${environment.apiUrl}/${this.url}/registrar`, alimento);
  }

  public eliminarAlimento(idAlimento?: number) {
    return this.http.post(`${environment.apiUrl}/${this.url}/eliminar/${idAlimento}`, null);
  }
}
