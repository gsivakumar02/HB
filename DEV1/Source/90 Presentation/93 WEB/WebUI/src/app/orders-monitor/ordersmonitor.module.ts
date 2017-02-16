import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';


import { MaterialModule,MdDialog, MdCardModule, MdIconModule, MdInputModule, MdRadioModule, MdButtonModule, MdProgressBarModule, MdToolbarModule } from "@angular/material";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { TreeModule } from 'angular2-tree-component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { FlexLayoutModule } from "@angular/flex-layout";

import { OrdersService } from '../_services/orders.service';
import { OrdersMonitorComponent } from './orders-monitor.component';
import { OrdersMonitorRoutes } from './ordersmonitor.routing';
import { OrdersMonitorTreeComponent } from './ordersmonitorTree.component';
import { Imt103Component } from '../forms/incoming/imt103.component';


// import { TablesRoutes } from './tables.routing';
// import { DataTableComponent } from './data-table/data-table.component';
// import { TableEditingComponent } from './table-editing/table-editing.component';
// import { TableFilterComponent } from './table-filter/table-filter.component';
// import { TablePagingComponent } from './table-paging/table-paging.component';
// import { TablePinningComponent } from './table-pinning/table-pinning.component';
// import { TableSelectionComponent } from './table-selection/table-selection.component';
// import { TableSortingComponent } from './table-sorting/table-sorting.component';

@NgModule({
  imports: [CommonModule, RouterModule.forChild(OrdersMonitorRoutes),MaterialModule, MdCardModule, MdIconModule, MdInputModule, MdRadioModule, MdButtonModule, MdProgressBarModule, MdToolbarModule, FlexLayoutModule, NgxDatatableModule, FormsModule, ReactiveFormsModule,  TreeModule],
  declarations: [OrdersMonitorComponent, OrdersMonitorTreeComponent, Imt103Component],
  entryComponents:  [Imt103Component],
  providers: [OrdersService]
})

export class OrdersMonitorModule {}