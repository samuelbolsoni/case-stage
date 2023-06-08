import { Injectable } from '@angular/core';
import { Area } from '../models/area';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  private url = "Areas";

  constructor(private http: HttpClient) { }

  public GetAreas() : Observable<Area[]> {
    return this.http.get<Area[]>(`${environment.apiUrl}/${this.url}`);
  }
}
