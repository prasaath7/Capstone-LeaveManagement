import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService} from '../_services/alertify.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;


  constructor(private authService: AuthService, private alertify: AlertifyService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        username: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
        email: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$')]],
        password: ['', Validators.required],
      }
    );
  }

  register(){
     this.authService.register(this.registerForm.value).subscribe(() => {
       this.alertify.success('registration successful');
     }, error => {
       this.alertify.error('Registration error');
     });
    // console.log(this.registerForm.value);
  }

  cancel() {
    this.cancelRegister.emit(false);
    this.alertify.message('cancelled');

  }

}
