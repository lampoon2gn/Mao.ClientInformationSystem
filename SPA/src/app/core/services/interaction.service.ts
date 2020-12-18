import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Interaction } from 'src/app/shared/models/interaction';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  constructor(private apiService: ApiService) { }

  // listIntByEmp(): Observable<Interaction[]> {
  //   var res = this.apiService.getAll('Emp');
  //   console.log(res)
  //   return res;
  // }
}
