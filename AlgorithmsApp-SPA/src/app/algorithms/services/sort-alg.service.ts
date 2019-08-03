import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SortAlgService {
  constructor(private http: HttpClient) {}
  configUrl = 'http://localhost:5000/api/values';

  getTimeForInsertAlg() {
    return this.http.get(this.configUrl);
  }
}
