import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Mother } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class MotherService implements IPagableService<Mother> {

  uniqueIdentifierName: string = "motherId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Mother>> {
    return this._client.get<EntityPage<Mother>>(`${this._baseUrl}api/mother/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Mother[]> {
    return this._client.get<{ mothers: Mother[] }>(`${this._baseUrl}api/mother`)
      .pipe(
        map(x => x.mothers)
      );
  }

  public getById(options: { motherId: string }): Observable<Mother> {
    return this._client.get<{ mother: Mother }>(`${this._baseUrl}api/mother/${options.motherId}`)
      .pipe(
        map(x => x.mother)
      );
  }

  public remove(options: { mother: Mother }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/mother/${options.mother.motherId}`);
  }

  public create(options: { mother: Mother }): Observable<{ mother: Mother }> {
    return this._client.post<{ mother: Mother }>(`${this._baseUrl}api/mother`, { mother: options.mother });
  }
  
  public update(options: { mother: Mother }): Observable<{ mother: Mother }> {
    return this._client.put<{ mother: Mother }>(`${this._baseUrl}api/mother`, { mother: options.mother });
  }
}
