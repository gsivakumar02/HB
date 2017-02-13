import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthenticationService } from '../../_services/index';

@Component({
  moduleId: module.id,
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
 // providers: [UserService]
})

export class SigninComponent implements OnInit {
    model: any = {};
    public form: FormGroup;
    public loading: boolean = false;
    error = '';
    constructor(private fb: FormBuilder, private router: Router, private authenticationService: AuthenticationService) {}

  ngOnInit() {     
  	this.form = this.fb.group({
      uname: [null, Validators.compose([Validators.required])],
      password: [null, Validators.compose([Validators.required])]
      });       
  }

  onSubmit() {
          this.error = '';
          this.loading = true;
          this.authenticationService.login(this.model.username, this.model.password)
              .subscribe(result => {
                  if (result === true) {
                      this.router.navigate(['/']);
                  } else {
                      this.error = 'Username or password is incorrect';                      
                  }
                  this.loading = false;
              },
              error => {
                  console.log(error);
                  this.error = JSON.parse(error._body).error_description;
                  this.loading = false;
              });
      }
  }

