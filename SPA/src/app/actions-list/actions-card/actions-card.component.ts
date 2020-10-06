import { Component, Input, OnInit } from '@angular/core';
import { Requests } from 'src/app/_models/requests';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { LeaveService } from 'src/app/_services/leave.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-actions-card',
  templateUrl: './actions-card.component.html',
  styleUrls: ['./actions-card.component.css']
})
export class ActionsCardComponent implements OnInit {
  @Input() request: Requests;

  constructor(private leaveService: LeaveService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  accept(userid){
    const msg = { id : userid, leaveapproved : true };
    this.leaveService.sendResponse(msg).subscribe(() => {
      this.alertify.success('Response Sent');
    }, error => {
      this.alertify.error('Response Not Sent');
    }, () => {
      this.router.navigateByUrl('/RefreshComponent', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/actions']);
    });
    });
    console.log(msg);
  }

  reject(userid){
    const msg = { id : userid, leaveapproved : false };
    this.leaveService.sendResponse(msg).subscribe(() => {
      this.alertify.success('Response Sent');
    }, error => {
      this.alertify.error('Response Not Sent');
    }, () => {
      this.router.navigateByUrl('/RefreshComponent', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/actions']);
    });
    });
    console.log(msg);
  }
}
