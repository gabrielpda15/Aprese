import { Component, OnInit } from '@angular/core';
import { GridModel, GridActionsType } from 'src/app/shared/grid/grid.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  public gridData: GridModel;
  public actionsType: GridActionsType = GridActionsType.onlyView;

  constructor() {
    this.gridData = new GridModel();
    this.gridData.fields = [
      { key: 'id', name: 'Id' },
      { key: 'field_1', name: 'Campo 1' },
      { key: 'field_2', name: 'Campo 2' }
    ];
    this.gridData.values = [
      { id: 1, field_1: 'Teste a', field_2: 'Teste b' },
      { id: 2, field_1: 'Banana', field_2: 'Pera' },
      { id: 3, field_1: 'Abacate', field_2: 'Cenoura' },
      { id: 4, field_1: 'Teste c', field_2: 'Teste d' }
    ];
   }

  ngOnInit(): void {
  }

}
