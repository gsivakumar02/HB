import { Component, OnInit } from '@angular/core';
import { TreeNode, TREE_ACTIONS, KEYS, IActionMapping } from 'angular2-tree-component';
import { Http, Response } from '@angular/http';
import { OrderStatusTree } from './models/OrderStatusTree';
import { Fts_Orders } from './models/fts_orders';
import { Observable } from 'rxjs/Rx';
import { MaterialModule } from '@angular/material';

@Component({
  selector: 'orders-monitor',
  templateUrl: './orders-monitor.component.html',
  styleUrls: ['./orders-monitor.component.scss']
})
export class OrdersMonitorComponent implements OnInit {
   public statusTree: OrderStatusTree[];
   public treeOptions;
   public orders : Fts_Orders[];
   public columns;
   
   getByStatus(status :Number): Observable<Fts_Orders[]> {

        return this.http.get('http://localhost:49175/api/SampleData/GetOrders')
                    .map((res: Response) => res.json())
                    .catch((error: any) => Observable.throw(error.json().error || 'Server Error'));
    }
  getSelectedStatus(newStatus: Number) {
        this.getByStatus(newStatus).subscribe(result => this.orders = result);
    }
   getOrderStatusTree() {
        this.http.get('http://localhost:49175/api/SampleData/OrderStatusTree').subscribe(result => {
            this.statusTree = result.json();
            console.log(result.json());
        });
    }
  constructor(private http: Http  ) {
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
        { name:'id' },
        { name:'msgType' },
        { name:'tun' },
        { name:'valueDate' },
        { name:'amount' },
        { name:'auto_ErrorCode' },
        { name:'auto_ErrorDesc' },
        { name:'status' },
        { name:'benefBank_BIC' },
        { name:'isOnline' },
        { name:'productCode' }

        // { name:'bankId' },
        // { name:'entryDate' },
        // { name:'msgIO' },
        // { name:'reversalTUN' },
        // { name:'currency' },
        // { name:'amount_EUR' },
        // { name:'serviceTypesCode' },
        // { name:'charges_Details' },
        // { name:'fwD_Flag' },
        // { name:'stp_Flag' },
        // { name:'fraud_Flag' },
        // { name:'cover_Flag' },
        // { name:'fwdAction_Flag' },
        // { name:'branchID' },
        // { name:'authUserID' },
        // { name:'modUserId' },
        // { name:'userID' },
        // { name:'traceVersion' },
        // { name:'utimestamp' },
        //{ name:'monPreviousStatus' },
        // { name:'reference' },
        // { name:'counterPartyBIC' },
        // { name:'msgTypeExtension' },
        // { name:'repaymentPriorityFlag' },
     ];




     this.getOrderStatusTree(); 
     this.treeOptions = {displayField: 'description', childrenField: 'orderStatuses' };

      this.getSelectedStatus(1);
  }

}
