import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, scheduled } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BusSchedule } from '../models/busSchedule';
import { map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class ScheduleServices {
    constructor(private http: HttpClient){}
    private url = `${environment.apiUrl}BusStopSchedule`;

    getNextTimesForBusStop(busStopId: number): Observable<BusSchedule>
    {
        return this.http.get<BusSchedule>(this.url, { params: {Id: `${busStopId}` }});
    }
}