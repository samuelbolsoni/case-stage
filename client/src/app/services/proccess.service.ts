import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Proccess } from '../proccess/model/proccess';
import { ProccessTree } from '../proccess/model/proccess-tree';

@Injectable({
  providedIn: 'root'
})
export class ProccessService {

  private url = "Proccess";
  
  constructor(private http: HttpClient) { }
  
  public GetProccess() : Observable<Proccess[]> {
    return this.http.get<Proccess[]>(`${environment.apiUrl}/${this.url}`);
  }

  public GetProccessById(id:number) : Observable<Proccess[]> {
    return this.http.get<Proccess[]>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public GetProccessTree() : Observable<any[]> {
    return this.http.get<ProccessTree[]>(`${environment.apiUrl}/ProccessTree/GetProccessTree`);
  }

  public updateProccess(id: number, proccess:Proccess) : Observable<Proccess[]> {
    return this.http.put<Proccess[]>(
      `${environment.apiUrl}/${this.url}/${id}`,
      proccess
    );
  }

  public createProccess(proccess:Proccess) : Observable<Proccess[]> {
    return this.http.post<Proccess[]>(
      `${environment.apiUrl}/${this.url}`,
      proccess
    );
  }

  public deleteProccess(id:number) : Observable<Proccess[]> {
    return this.http.delete<Proccess[]>(
      `${environment.apiUrl}/${this.url}/${id}`
    );
  }
}
