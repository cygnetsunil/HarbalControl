import { Component, OnDestroy, OnInit } from '@angular/core';
import { BoatType } from '../Model/boatType';
import { HttpCallService } from '../service/http-call.service';
import { timer, Subscription, interval } from "rxjs";
import { BoatStatusEnum, BoatTypeEnum } from '../enum/enum';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, OnDestroy {
  countDown: Subscription;
  boatList: BoatType[] = [];
  count: number = 0;
  counter: number = 0;
  windSpeed: any;
  progressbar: number;
  constructor(private httpService: HttpCallService) { }

  ngOnInit() {
    this.GetWindDetails();
  }
  GetWindDetails() {
    this.httpService.GetWindDetails<any>().toPromise().then(result => {
      if (result != null) {
        this.windSpeed = +parseFloat(String((result['wind']['speed'] * 18) / 5)).toFixed(2)
      }
    }).catch((error) => {
      alert("Something went wrong");
    })
  }
  ngOnDestroy() {
    this.countDown.unsubscribe();
  }
  BindData()
  {
    this.counter = 0;
    this.progressbar = 0;
    this.boatList = [];
    this.httpService.get<any>("HarbalControl/RandomBoats/" + this.count).toPromise().then(result => {
      if (result != null) {
        if (result.success) {
          this.boatList = result.data;
          if (this.boatList != null && this.boatList.length > 0) {
            this.NextBoat(this.boatList[0].index);
          }
        }
        else {
          alert(result.message);
        }
      }
    }).catch((error) => {
      alert("Something went wrong");
    })
  }
  public getBoatStatusText(status: number): string {
    switch (status) {
      case BoatStatusEnum.InProgress:
        return 'In Progress';
      case BoatStatusEnum.Completed:
        return 'Completed';
      case BoatStatusEnum.Pending:
        return 'Pending';
      case BoatStatusEnum.CantProcess:
        return 'You are not allowed enter in perimeter.';
    }
  }
  RefreshWindDetails() {
    this.GetWindDetails();
  }
  NextBoat(index) {
    var item = this.boatList.find(x => x.index == index);
    if (item != undefined && item != null) {
      if (item.typeId == BoatTypeEnum.SailBoat && (this.windSpeed < 10 || this.windSpeed > 30)) {
        item.status = BoatStatusEnum.CantProcess;
        this.NextBoat(index + 1);
      }
      else {
        this.BoatInPerimeter(item, index);
      }
    }
  }
  BoatInPerimeter(item: BoatType, index: number) {
    item.status = BoatStatusEnum.InProgress;
    this.counter = item.time / 10;
    this.progressbar = 0;
    this.countDown = interval(1000).subscribe((x) => {
      if (this.counter > 0)
      {
        this.counter = this.counter - 1
        this.progressbar =100 - ((100 * this.counter) / (item.time / 10));
      }
      else {
        this.countDown.unsubscribe();
        item.status = BoatStatusEnum.Completed;
        this.NextBoat(index + 1);
      }
    });
  }
}

