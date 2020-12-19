import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../core/services/api.service';
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
  closeResult = '';
  createRequest={
    id: 0,
    name:'',
    password:'',
    designation:'',
  }

  id = new FormControl('0');
  empName = new FormControl('');
  empPassword = new FormControl('');
  empDesignation = new FormControl('');

  constructor(
    private empService: EmpService,
    private intService: InteractionService,
    private apiService: ApiService,
    private modalService: NgbModal
    ) { }

  ngOnInit(): void {
    this.onChange();
    this.empService.getAllEmps().subscribe(
      e=>{
        this.emps=e;
      }
    )
  }

  onChange():void{
    this.id.valueChanges.subscribe(
      val => {
        this.apiService.getOne('emp',val).subscribe(
          r=>{
            console.log(r);
            this.empName.setValue(r.name);
            this.empPassword.setValue(r.password);
            this.empDesignation.setValue(r.designation)

          }
        )
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

  deleteEmp(id:number){
    console.log("sending delete for emp ",id)
    this.apiService.delete('emp',id).subscribe(
      r=>{
        console.log(r);
        window.location.reload();
      }
    )
    
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.createRequest.id= this.id.value;
      this.createRequest.name= this.empName.value;
      this.createRequest.password = this.empPassword.value;
      this.createRequest.designation = this.empDesignation.value;
      
      if (this.createRequest.id==0) {
        this.apiService.create('emp',this.createRequest).subscribe(
          r=>{
            console.log(r);
            window.location.reload();
          }
        )
      }
      else{
        this.apiService.update('emp',this.createRequest).subscribe(
          r=>{
            console.log(r);
            window.location.reload();
          }
        )
      }

      
    }

    );
    
  }


}
