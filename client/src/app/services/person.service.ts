import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Person } from '../person/model/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private url = "Person";

  constructor(private http: HttpClient) { }

  public GetPersons() : Observable<Person[]> {
    return this.http.get<Person[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updatePerson(id: number, person:Person) : Observable<Person[]> {
    return this.http.put<Person[]>(
      `${environment.apiUrl}/${this.url}/${id}`,
      person
    );
  }

  public createPerson(person:Person) : Observable<Person[]> {
    return this.http.post<Person[]>(
      `${environment.apiUrl}/${this.url}`,
      person
    );
  }

  public deletePerson(id:number) : Observable<Person[]> {
    return this.http.delete<Person[]>(
      `${environment.apiUrl}/${this.url}/${id}`
    );
  }
}
