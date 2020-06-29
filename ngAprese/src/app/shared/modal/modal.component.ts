import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  constructor() { }

  @Input() public title = 'Modal';
  @Input() public submitText = 'Ok';
  @Output() public exitAction = new EventEmitter<any>();
  @Output() public submitAction = new EventEmitter<any>();

  ngOnInit() {
  }

  public onExit(): void {
    this.exitAction.emit();
  }

  public onSubmit(): void {
    this.submitAction.emit();
  }

}
