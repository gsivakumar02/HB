import { Component, ViewContainerRef, OnInit, OnDestroy } from '@angular/core';
import { TreeNode, TREE_ACTIONS, KEYS, IActionMapping } from 'angular2-tree-component';
import { Http, Response } from '@angular/http';
import { Orders } from '../models/orders.model';
import { OrderStatusTree} from '../models/orderStatusTree';
import { Observable, Subscription } from 'rxjs/Rx';
import { MaterialModule, MdDialog, MdDialogRef, MdDialogConfig } from '@angular/material';
import { OrdersService } from '../_services/orders.service';
import { Imt103Component } from '../forms/incoming/imt103.component';
import { Pacs008 } from '../models/msgTypes/pacs008';
import { TimerObservable } from 'rxjs/observable/TimerObservable';


@Component({
    selector: 'orders-monitor',
    templateUrl: './orders-monitor.component.html',
    styleUrls: ['./orders-monitor.component.scss']
})

export class OrdersMonitorComponent implements OnInit, OnDestroy {
    private timer;
    private timersub: Subscription;

    constructor(private svc: OrdersService, public dialog: MdDialog, public viewContainerRef: ViewContainerRef) {
        this.timer = TimerObservable.create(0, 5000);
        this.svc.getByStatus(0).subscribe(result => {
            // console.log(JSON.stringify(result)); 
            this.rows = result;
        });
    }
    public dialogRef: MdDialogRef<any>;
    public statusTree: OrderStatusTree[];
    public treeOptions;
    public orders: Orders[];
    public columns;

    getSelectedStatus(newStatus: Number) {
        this.svc.getByStatus(newStatus).subscribe(result => this.orders = result);
    }
    getOrderStatusTree() {
        console.log('fetch counters ');
        // this.svc.getOrderStatusTree().subscribe(result => {
        //     this.statusTree = result;
        // });
        this.statusTree = this.svc.getOrderStatusTree();
    }

    getCurrentOrder() {
        this.svc.getOrderFromJSon(this.selected[0].id).subscribe(result => {
            //            this.statusTree = result;
            let config = new MdDialogConfig();
            config.viewContainerRef = this.viewContainerRef;

            // let order = new Pacs008();
            let order = result;
            // order.Sender = this.selected[0].id;
            // order.MsgIO = this.selected[0].charges_Details;
            // order.Receiver = this.selected[0].benefBank_BIC;
            this.dialogRef = this.dialog.open(Imt103Component, config);
            this.dialogRef.componentInstance.order = order;
        });
    }

    rows: any[] = [];
    selected: any[] = [];
    showOrder() {
        let config = new MdDialogConfig();
        config.viewContainerRef = this.viewContainerRef;
        this.dialogRef = this.dialog.open(Imt103Component, config);
    }

    fetch(cb) {
        // let req = new XMLHttpRequest();
        // req.open('GET', `http://localhost:49175/api/SampleData/GetOrders`);

        // req.onload = () => {
        //     cb(JSON.parse(req.response));
        // };
        this.svc.getByStatus(0).subscribe(result => {
            console.log(JSON.stringify(result));
            this.rows = result;
        });
        //req.send();
    }

    onSelect(event) {
        this.getCurrentOrder();
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

        // this.timersub = this.timer.subscribe(t => this.getOrderStatusTree(), 1);


        //this.getOrderStatusTree();
        this.treeOptions = { childrenField: 'orderStatuses' };

        this.getSelectedStatus(1);
    }

    ngOnDestroy() {
        this.timersub.unsubscribe();
    }
}
