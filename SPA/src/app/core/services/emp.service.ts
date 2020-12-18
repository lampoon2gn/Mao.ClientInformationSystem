import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Emp } from 'src/app/shared/models/emp';
import { Interaction } from 'src/app/shared/models/interaction';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EmpService {

  constructor(private apiService: ApiService) { }

  getAllEmps(): Observable<Emp[]> {
    var res = this.apiService.getAll('Emp');
    console.log(res)
    return res;
  }

  listIntByEmp(id:number):Observable<Interaction[]>{
    var res = this.apiService.getAll('int/emp',id);
    console.log(res)
    return res;
  }
  

}








