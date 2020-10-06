import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { LeaveService } from 'src/app/_services/leave.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-days-edit',
  templateUrl: './days-edit.component.html',
  styleUrls: ['./days-edit.component.scss']
})
export class DaysEditComponent implements OnInit {
  days: number;
  editMode = false;

  constructor(private leaveService: LeaveService, private alertify: AlertifyService,  private router: Router) { }

  ngOnInit() {
    this.loadDays();
  }

  loadDays() {
    this.leaveService.getDays().subscribe((days: number) => {
      this.days = days;
    }, error => {
      this.alertify.error(error);
    });
  }

  editToggle() {
    this.editMode = true;
  }

  changeDays(change) {
    console.log(change);
    this.leaveService.setDays(change).subscribe(() => {
      this.alertify.success('Days Updated');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigateByUrl('/RefreshComponent', { skipLocationChange: true }).then(() => {
        this.router.navigate(['/actions']);
    });
    });
    this.editMode = false;
  }

}
