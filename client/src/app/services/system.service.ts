import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { System } from '../system/model/system';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SystemService {

  private url = "SystemApp";

  constructor(private http: HttpClient) { }

  public GetSystems() : Observable<System[]> {
    return this.http.get<System[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateSystem(id: number, system:System) : Observable<System[]> {
    return this.http.put<System[]>(
      `${environment.apiUrl}/${this.url}/${id}`,
      system
    );
  }

  public createSystem(system:System) : Observable<System[]> {
    return this.http.post<System[]>(
      `${environment.apiUrl}/${this.url}`,
      system
    );
  }

  public deleteSystem(id:number) : Observable<System[]> {
    return this.http.delete<System[]>(
      `${environment.apiUrl}/${this.url}/${id}`
    );
  }
}
