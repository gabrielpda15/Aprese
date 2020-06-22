import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  constructor() { }

  @Input() public title = 'Modal';
  @Input() public submitText = 'Ok';
  @Output() public disabled = new EventEmitter<boolean>();
  @Output() public submitAction = new EventEmitter<void>();

  // @ViewChild('form', {static: false}) public form: ElementRef;

  ngOnInit() {
  }

  public onExit(event: any): void {
    this.disabled.emit(true);
  }

  public onSubmit(): void {
    this.submitAction.emit();
  }

}
