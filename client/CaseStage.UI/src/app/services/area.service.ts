import { Injectable } from '@angular/core';
import { Area } from '../models/area';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  private url = "Area";

  constructor(private http: HttpClient) { }

  public GetAreas() : Observable<Area[]> {
    return this.http.get<Area[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateArea(area:Area) : Observable<Area[]> {
    return this.http.put<Area[]>(
      `${environment.apiUrl}/${this.url}`,
      area
    );
  }

  public createArea(area:Area) : Observable<Area[]> {
    return this.http.post<Area[]>(
      `${environment.apiUrl}/${this.url}`,
      area
    );
  }

  public deleteArea(area:Area) : Observable<Area[]> {
    return this.http.delete<Area[]>(
      `${environment.apiUrl}/${this.url}/${area.id}`
    );
  }
}
