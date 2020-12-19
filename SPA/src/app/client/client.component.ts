import { Component, OnInit } from '@angular/core';
import { ApiService } from '../core/services/api.service';
import { ClientService } from '../core/services/client.service';
import { Client } from '../shared/models/client';
import { Interaction } from '../shared/models/interaction';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  ints:Interaction[] | undefined;
  clients:Client[] |undefined;
  closeResult = '';

  createRequest={
    id: 0,
    name:'',
    email:'',
    phones:'',
    address:''
  }
  id = new FormControl('0');
  clientName = new FormControl('');
  clientEmail = new FormControl('');
  clientPhones = new FormControl('');
  clientAddress = new FormControl('');

  constructor(
    private clientService: ClientService,
    private apiService: ApiService,
    private modalService: NgbModal
    ) { }

  ngOnInit(): void {
    this.onChange();
    this.clientService.getAllClients().subscribe(
      c=>{
        this.clients=c;
      }
    )
  }

  onChange():void{
    this.id.valueChanges.subscribe(
      val => {
        this.apiService.getOne('client',val).subscribe(
          r=>{
            console.log(r);
            this.clientName.setValue(r.name);
            this.clientEmail.setValue(r.email);
            this.clientPhones.setValue(r.phones)
            this.clientAddress.setValue(r.address)

          }
        )
      }
    )
  }

  listIntByClient(id:number){
    this.clientService.listIntByClient(id).subscribe(
      c=>{
        console.log(c);
        this.ints=c
      }
    )
  }

  deleteClient(id:number){
    console.log("sending delete for client ",id)
    this.apiService.delete('client',id).subscribe(
      r=>{
        console.log(r);
        window.location.reload();
      }
    )
    
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.createRequest.id = this.id.value;
      this.createRequest.name= this.clientName.value;
      this.createRequest.email = this.clientEmail.value;
      this.createRequest.phones = this.clientPhones.value;
      this.createRequest.address = this.clientAddress.value;
      if (this.createRequest.id==0) {
        this.apiService.create('client',this.createRequest).subscribe(
          r=>{
            console.log(r);
            window.location.reload();
          }
        )
      }
      else{
        this.apiService.update('client',this.createRequest).subscribe(
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
