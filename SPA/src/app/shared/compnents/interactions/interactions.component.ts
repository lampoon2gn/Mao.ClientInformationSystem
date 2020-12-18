import { Component, Input, OnInit } from '@angular/core';
import { Interaction } from '../../models/interaction';

@Component({
  selector: 'app-interactions',
  templateUrl: './interactions.component.html',
  styleUrls: ['./interactions.component.css']
})
export class InteractionsComponent implements OnInit {

  @Input() ints:Interaction[] | undefined;
  constructor() { }

  ngOnInit(): void {
  }

}
