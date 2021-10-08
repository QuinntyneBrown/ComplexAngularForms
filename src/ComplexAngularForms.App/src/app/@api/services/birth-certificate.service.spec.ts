import { TestBed } from '@angular/core/testing';

import { BirthCertificateService } from './birth-certificate.service';

describe('BirthCertificateService', () => {
  let service: BirthCertificateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BirthCertificateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
