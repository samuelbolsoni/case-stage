import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Area } from '../area/model/area';
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

  public GetAreaProccessTree() : Observable<Area[]> {
    return this.http.get<Area[]>(`${environment.apiUrl}/AreaProccessTree`);
  }

  public updateArea(id: number, area:Area) : Observable<Area[]> {
    return this.http.put<Area[]>(
      `${environment.apiUrl}/${this.url}/${id}`,
      area
    );
  }

  public createArea(area:Area) : Observable<Area[]> {
    return this.http.post<Area[]>(
      `${environment.apiUrl}/${this.url}`,
      area
    );
  }

  public deleteArea(id:number) : Observable<Area[]> {
    return this.http.delete<Area[]>(
      `${environment.apiUrl}/${this.url}/${id}`
    );
  }
}
