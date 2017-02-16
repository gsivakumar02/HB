import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { MdDialogRef } from '@angular/material';
import { Pacs008 } from '../../models/msgTypes/pacs008';

let password = new FormControl('', Validators.required);
let confirmPassword = new FormControl('', CustomValidators.equalTo(password));

@Component({
  selector: 'app-form-validation',
  templateUrl: './imt103.component.html',
  styleUrls: ['./imt103.component.scss'],
  providers:[FormBuilder]
})
export class Imt103Component implements OnInit {
  constructor(private fb: FormBuilder, public dialogRef : MdDialogRef<any>) {}
  public form: FormGroup;
  public order: any;

  ngOnInit() {
    this.form = this.fb.group({
      Sender: [null, Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(10)])],
      // XMT1003Schema:[""],
      // msgIO:[""],
      Receiver:[""],
      // f2_MSGPRIORITY:[],
      // f2_OBSPERIOD:[]

      // email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      // range: [null, Validators.compose([Validators.required, CustomValidators.range([5, 9])])],
      // url: [null, Validators.compose([Validators.required, CustomValidators.url])],
      // date: [null, Validators.compose([Validators.required, CustomValidators.date])],
      // creditCard: [null, Validators.compose([Validators.required, CustomValidators.creditCard])],
      // phone: [null, Validators.compose([Validators.required, CustomValidators.phone('en-US')])],
      // gender: [null, Validators.required],
      // password: password,
      // confirmPassword: confirmPassword
    });
    if (this.order != null ){
    var xmlData = JSON.parse(this.order.xmL_Data);
    this.form.patchValue(xmlData.XMT103Schema.XMT103, {onlySelf: true});
    }
  }
}
