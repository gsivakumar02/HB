import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from  '@angular/http';
import { Orders } from '../models/orders.model';
import { Observable } from 'rxjs/Rx';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()

export class OrdersService {

    constructor(private http: Http) { }

    //public getByStatus(status: Number): Observable<Orders[]> {

    //    return this.http.get('/api/SampleData/GetOrders')
    //        .map((res: Response) => res.json())
    //        .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));
    //}

    public getByStatus(status: Number): Observable<Orders[]> {
        return this.http.get('http://localhost:49175/api/SampleData/GetOrders')
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));
     
    }

    public getOrderStatusTree() {
        return this.http.get('http://localhost:49175/api/SampleData/OrderStatusTree')
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));
      
    }
}