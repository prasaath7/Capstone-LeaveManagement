import { Component, OnInit } from '@angular/core';
import { Requests } from '../../_models/requests';
import { AlertifyService } from '../../_services/alertify.service';
import { LeaveService } from '../../_services/leave.service';

@Component({
  selector: 'app-actions',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.css']
})
export class ActionsComponent implements OnInit {
  requests: Requests[];

  constructor(private leaveService: LeaveService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadRequests();
  }

  loadRequests() {
    this.leaveService.getRequests().subscribe((requests: Requests[]) => {
      this.requests = requests;
    }, error => {
      this.alertify.error(error);
    });
  }

}
