import { Component, OnInit } from '@angular/core';
import { ClientService } from '../core/services/client.service';
import { Client } from '../shared/models/client';
import { Interaction } from '../shared/models/interaction';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  ints:Interaction[] | undefined;
  clients:Client[] |undefined;
  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.clientService.getAllClients().subscribe(
      c=>{
        this.clients=c;
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

}
