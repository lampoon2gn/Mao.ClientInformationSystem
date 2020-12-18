import { Component, OnInit } from '@angular/core';
import { EmpService } from '../core/services/emp.service';
import { InteractionService } from '../core/services/interaction.service';
import { Emp } from '../shared/models/emp';
import { Interaction } from '../shared/models/interaction';
@Component({
  selector: 'app-emp',
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css']
})
export class EmpComponent implements OnInit {

  ints:Interaction[] | undefined;
  emps:Emp[] |undefined;
  constructor(
    private empService: EmpService,
    private intService: InteractionService
    ) { }

  ngOnInit(): void {
    this.empService.getAllEmps().subscribe(
      e=>{
        this.emps=e;
      }
    )
  }

  listIntByEmp(id:number){
    this.empService.listIntByEmp(id).subscribe(
      e=>{
        console.log(e);
        this.ints=e;
      }
    )
  }

}
