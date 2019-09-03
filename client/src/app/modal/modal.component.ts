import { Component, OnInit, Input } from '@angular/core';
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { createHostListener } from '@angular/compiler/src/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {


  @Input() title = `Modal header`;
  @Input() c;
  @Input() d;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

}
