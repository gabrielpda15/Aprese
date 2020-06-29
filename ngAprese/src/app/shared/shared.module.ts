import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalComponent } from './modal/modal.component';
import { GridComponent } from './grid/grid.component';



@NgModule({
  declarations: [ ModalComponent, GridComponent ],
  imports: [ CommonModule ],
  exports: [ ModalComponent, GridComponent ]
})
export class SharedModule { }
