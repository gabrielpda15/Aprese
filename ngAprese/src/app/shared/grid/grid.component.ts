import { Component, OnInit, Input } from '@angular/core';
import { GridModel, GridActionsType } from './grid.model';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html'
})
export class GridComponent implements OnInit {

  @Input() data: GridModel = new GridModel();
  @Input() actions: GridActionsType = GridActionsType.both;

  public ActionsType = GridActionsType;

  constructor() { }

  ngOnInit(): void {
  }

}
