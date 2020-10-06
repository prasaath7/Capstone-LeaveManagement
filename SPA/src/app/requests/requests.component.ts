import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Leaves } from '../_models/leaves';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { LeaveService } from '../_services/leave.service';


@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {

  @Output() cancelRequest = new EventEmitter();
  model: any = {};
  requestsForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  Leaves: Leaves;
  // tslint:disable-next-line: max-line-length
  constructor(private authService: AuthService, private alertify: AlertifyService, private fb: FormBuilder, private leaveService: LeaveService) { }

  ngOnInit() {
    this.getLeaves();
    this.createRequestsForm();
  }

  getLeaves() {
    this.leaveService.getLeaves(this.authService.decodedToken.nameid).subscribe((leaves: Leaves) => {
      this.Leaves = leaves;
      console.log(this.Leaves.paidLeave);
    }, error => {
      this.alertify.error(error);
    });
  }

  createRequestsForm() {
    this.requestsForm = this.fb.group(
      {
        leaveType: ['paid'],
        reason: ['', Validators.required],
        startDate: [null, Validators.required],
        endDate: [null, Validators.required],
        UserId: [this.authService.decodedToken.nameid, Validators.required]
      }
    );
  }

  request() {
    this.leaveService.submitRequest(this.requestsForm.value).subscribe(() => {
      this.alertify.success('Submission successful');
    }, error => {
      this.alertify.error('Submission error');
    });
    console.log(this.requestsForm.value);
  }

  cancel(requestsForm: FormGroup) {
    this.requestsForm.reset();
    this.alertify.message('cancelled');

  }

}
