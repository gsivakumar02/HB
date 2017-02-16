import { Component, OnInit } from '@angular/core';
import { TreeNode, TREE_ACTIONS, KEYS, IActionMapping } from 'angular2-tree-component';
import { Http, Response } from '@angular/http';
import { OrderStatusTree } from '../models/OrderStatusTree';
import { Orders } from '../models/orders.model';
import { Observable } from 'rxjs/Rx';
import { MaterialModule } from '@angular/material';
import { OrdersService } from '../_services/orders.service';

@Component({
    selector: 'orders-monitor',
    templateUrl: './orders-monitor.component.html',
    styleUrls: ['./orders-monitor.component.scss']
})

export class OrdersMonitorComponent implements OnInit {
    public statusTree: OrderStatusTree[];
    public treeOptions;
    public orders: Orders[];
    public columns;


    getSelectedStatus(newStatus: Number) {
        this.svc.getByStatus(newStatus).subscribe(result => this.orders = result);
    }
    getOrderStatusTree() {
        this.svc.getOrderStatusTree().subscribe(result => {
            this.statusTree = result;
        });
    }

    constructor(private svc: OrdersService) {
        this.fetch((data) => {
            this.rows = data;
        });
    }
    rows: any[] = [];
    selected: any[] = [];

    fetch(cb) {
        let req = new XMLHttpRequest();
        req.open('GET', `http://localhost:49175/api/SampleData/GetOrders`);

        req.onload = () => {
            cb(JSON.parse(req.response));
        };

        req.send();
    }

    onSelect(event) {
        console.log('Event: select', event, this.selected);
    }
    /*
    <th>Id</th>
                      <th>Msg Type</th>
                      <th>TUN</th>
                      <th>Value Date</th>
                      <th>Currency</th>
                      <th>Amount</th>
                      <th>Service Type Code</th>
                      <th>Auto Error Code</th>
                      <th>Auto Error Descr</th>
                      <th>Status</th>
                      <th>Benef Bank BIC</th>
                      <th>Is Online</th>
                      <th>Product Code</th>
  */
    ngOnInit() {
        this.columns = [
            { name: 'id' },
            { name: 'msgType' },
            { name: 'tun' },
            { name: 'valueDate' },
            { name: 'amount' },
            { name: 'auto_ErrorCode' },
            { name: 'auto_ErrorDesc' },
            { name: 'status' },
            { name: 'benefBank_BIC' },
            { name: 'isOnline' },
            { name: 'productCode' }

        ];




        this.getOrderStatusTree();
        this.treeOptions = { childrenField: 'orderStatuses' };

        this.getSelectedStatus(1);
    }

}
