import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from 'src/app/shared/models/client';
import { Interaction } from 'src/app/shared/models/interaction';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private apiService: ApiService) { }

  getAllClients(): Observable<Client[]> {
    var res = this.apiService.getAll('Client');
    console.log(res)
    return res;
  }

  listIntByClient(id:number):Observable<Interaction[]>{
    var res = this.apiService.getAll('int/client',id);
    console.log('clientid',id)
    console.log(res)
    return res;
  }
}
