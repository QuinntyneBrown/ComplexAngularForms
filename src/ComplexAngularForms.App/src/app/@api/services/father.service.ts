import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Father } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class FatherService implements IPagableService<Father> {

  uniqueIdentifierName: string = "fatherId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Father>> {
    return this._client.get<EntityPage<Father>>(`${this._baseUrl}api/father/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Father[]> {
    return this._client.get<{ fathers: Father[] }>(`${this._baseUrl}api/father`)
      .pipe(
        map(x => x.fathers)
      );
  }

  public getById(options: { fatherId: string }): Observable<Father> {
    return this._client.get<{ father: Father }>(`${this._baseUrl}api/father/${options.fatherId}`)
      .pipe(
        map(x => x.father)
      );
  }

  public remove(options: { father: Father }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/father/${options.father.fatherId}`);
  }

  public create(options: { father: Father }): Observable<{ father: Father }> {
    return this._client.post<{ father: Father }>(`${this._baseUrl}api/father`, { father: options.father });
  }
  
  public update(options: { father: Father }): Observable<{ father: Father }> {
    return this._client.put<{ father: Father }>(`${this._baseUrl}api/father`, { father: options.father });
  }
}
