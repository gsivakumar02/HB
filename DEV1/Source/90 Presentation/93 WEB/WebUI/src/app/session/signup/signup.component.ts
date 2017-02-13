import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute, Params } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { AuthenticationService } from '../../_services/index';

let password = new FormControl('', Validators.required);
let confirmPassword = new FormControl('', CustomValidators.equalTo(password));
 let model: any = {};
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
    model: any = {}; 
  public form: FormGroup;
  constructor(private fb: FormBuilder, private router: Router, private authenticationService: AuthenticationService, private activatedRoute: ActivatedRoute) {}
  loading = false;
  success = false;
  error = '';

  ngOnInit() {
      this.activatedRoute.queryParams.subscribe((params: Params) => {
          let key = params['key'];
          console.log(key);
      });

  	this.form = this.fb.group({
      email: [null, Validators.compose([Validators.required, CustomValidators.email])],
      password: password,
      confirmPassword: confirmPassword
      });
  }

  onSubmit() {     
      this.loading = true;
      this.error = '';
      this.authenticationService.register(this.model)
        .subscribe(data => {             
            this.success = true;                         
            this.delayedLogin();
            this.loading = false;
        }, error => {
            console.log(JSON.stringify(error.json()));
            this.error = 'Could not register please try again';
            this.loading = false;
        });
  }

  delayedLogin() {
      let email = this.model.email;
      let pass = this.model.password;
      this.model = {};
      this.form.reset();
      setTimeout(() => {
          this.authenticationService.login(email, pass)
              .subscribe(result => {
                  if (result === true) {
                      this.router.navigate(['/']);
                  } else {
                      this.error = 'Username or password is incorrect';
                      this.loading = false;
                      this.success = false;
                      this.error = 'Registration succeded but could not sign you in.';
                  }
              },
              error => {
                  console.log(error);
                  this.success = false;
                  this.error = 'Registration succeded but could not sign you in.';
                  this.loading = false;
              });
      }, 3000);  
  }

}
