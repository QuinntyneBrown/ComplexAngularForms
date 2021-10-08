import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BirthCertificate } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class BirthCertificateService implements IPagableService<BirthCertificate> {

  uniqueIdentifierName: string = "birthCertificateId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<BirthCertificate>> {
    return this._client.get<EntityPage<BirthCertificate>>(`${this._baseUrl}api/birthCertificate/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<BirthCertificate[]> {
    return this._client.get<{ birthCertificates: BirthCertificate[] }>(`${this._baseUrl}api/birthCertificate`)
      .pipe(
        map(x => x.birthCertificates)
      );
  }

  public getById(options: { birthCertificateId: string }): Observable<BirthCertificate> {
    return this._client.get<{ birthCertificate: BirthCertificate }>(`${this._baseUrl}api/birthCertificate/${options.birthCertificateId}`)
      .pipe(
        map(x => x.birthCertificate)
      );
  }

  public remove(options: { birthCertificate: BirthCertificate }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/birthCertificate/${options.birthCertificate.birthCertificateId}`);
  }

  public create(options: { birthCertificate: BirthCertificate }): Observable<{ birthCertificate: BirthCertificate }> {
    return this._client.post<{ birthCertificate: BirthCertificate }>(`${this._baseUrl}api/birthCertificate`, { birthCertificate: options.birthCertificate });
  }
  
  public update(options: { birthCertificate: BirthCertificate }): Observable<{ birthCertificate: BirthCertificate }> {
    return this._client.put<{ birthCertificate: BirthCertificate }>(`${this._baseUrl}api/birthCertificate`, { birthCertificate: options.birthCertificate });
  }
}
