import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Orders } from '../models/orders.model';
import { Pacs008 } from '../models/msgTypes/pacs008';
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
    private baseUrl =  'http://localhost:1692';
    public getByStatus(status: Number): Observable<Orders[]> {
        var data = {
            "bankId": 1,
            "fromDate": "2017-02-02",
            "toDate": "2017-02-10",
            "currency": "EUR",
            "status": -1,
            "msgIO": "O",
            "nrRows": 100
        };

        return this.http.post(this.baseUrl +  '/api/orders/OrdersList', data)
            .map((res: Response) => res.json().ds.ftS_InOrders)
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));

    }

    public getOrderStatusTree() {
        return this.http.get('http://localhost:49175/api/SampleData/OrderStatusTree')
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));

    }

    public getOrderById(id: number) {
        return this.http.get('http://localhost:49175/api/SampleData/OrderbyId')
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));

    }

    public getOrderFromJSon(id: number) {
        return this.http.get(this.baseUrl + '/api/orders/InOrderById/'+ id ) 
            .map((res: Response) => res.json().ds.ftS_InOrders[0])
            .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));
    }
}