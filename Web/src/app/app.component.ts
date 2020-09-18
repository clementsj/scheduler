import { Component } from '@angular/core';
import { BusSchedule } from './models/busSchedule';
import { BusStop } from './models/busStop';
import { ScheduleServices } from './services/schedule.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent { 
  selectedStop: number;
  title = 'Bus Schedule';
  busSchedule: BusSchedule;
  busStops: BusStop[] = [
    {
      id: 1,
      name: "Stop 1"
    },
    {
      id: 2,
      name: "Stop 2"
    },
    {
      id: 3,
      name: "Stop 3"
    },
    {
      id: 4,
      name: "Stop 4"
    },
    {
      id: 5,
      name: "Stop 5"
    },
    {
      id: 6,
      name: "Stop 6"
    },
    {
      id: 7,
      name: "Stop 7"
    },
    {
      id: 8,
      name: "Stop 8"
    },
    {
      id: 9,
      name: "Stop 9"
    },
    {
      id: 10,
      name: "Stop 10"
    }
  ];

  constructor(private service: ScheduleServices) { };

  onStopChange($event){
    this.service.getNextTimesForBusStop($event.value).subscribe(
      schedule => this.busSchedule = schedule
    );
  }
}
