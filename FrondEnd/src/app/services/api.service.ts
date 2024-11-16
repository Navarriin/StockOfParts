import { PartsInterface } from './../interfaces/parts.interface';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private readonly url: string = 'http://localhost:5054/api/parts';

  private http = inject(HttpClient);

  getAllParts(): Observable<PartsInterface[]> {
    return this.http.get<PartsInterface[]>(this.url);
  }

  getPartById(id: number): Observable<PartsInterface> {
    return this.http.get<PartsInterface>(`${this.url}/${id}`);
  }

  addNewPart(body: PartsInterface): Observable<PartsInterface> {
    return this.http.post<PartsInterface>(this.url, body);
  }

  updatePart(body: PartsInterface): Observable<PartsInterface> {
    return this.http.put<PartsInterface>(`${this.url}/${body.id}`, body);
  }

  deletePart(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
