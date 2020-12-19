import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from 'src/app/core/services/api.service';
import { InteractionService } from 'src/app/core/services/interaction.service';
import { Interaction } from '../../models/interaction';

@Component({
  selector: 'app-interactions',
  templateUrl: './interactions.component.html',
  styleUrls: ['./interactions.component.css']
})
export class InteractionsComponent implements OnInit {


  @Input() ints:Interaction[] | undefined;

  closeResult = '';
  createRequest={
    id: 0,
    clientId:'',
    empId:'',
    intType:'',
    intDate:'',
    remarks:'',
  }

  id = new FormControl('0');
  clientId = new FormControl('');
  empId = new FormControl('');
  intType = new FormControl('');
  intDate = new FormControl('');
  remarks = new FormControl('');

  constructor(
    private modalService: NgbModal,
    private apiService:ApiService
    
    ) { }

  ngOnInit(): void {
    this.onChange();
  }

  onChange():void{
    this.id.valueChanges.subscribe(
      val => {
        this.apiService.getOne('int',val).subscribe(
          r=>{
            console.log(r);
            this.clientId.setValue(r.id);
            this.empId.setValue(r.empId);
            this.intDate.setValue(r.intDate),
            this.intType.setValue(r.intType),
            this.remarks.setValue(r.remarks)
          }
        )
      }
    )
  }

  deleteInt(id:number){
    console.log("sending delete for int ",id)
    this.apiService.delete('int',id).subscribe(
      r=>{
        console.log(r);
        //window.location.reload();
      }
    )
    
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.createRequest.id = this.id.value;
      this.createRequest.clientId= this.clientId.value;
      this.createRequest.empId = this.empId.value;
      this.createRequest.intType = this.intType.value;
      this.createRequest.intDate = this.intDate.value.year + '-' + this.intDate.value.month + '-'+ this.intDate.value.day ;
      this.createRequest.remarks = this.remarks.value;
      console.log(this.createRequest)

      if (this.createRequest.id==0) {
        this.apiService.create('int',this.createRequest).subscribe(
          r=>{
            console.log(r);
            window.location.reload();
          }
        )
      }
      else{
        this.apiService.update('int',this.createRequest).subscribe(
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
