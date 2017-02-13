import { Routes } from "@angular/router";


import { OrdersMonitorComponent } from './orders-monitor.component';


// import { DataTableComponent } from './data-table/data-table.component';
// import { TableEditingComponent } from './table-editing/table-editing.component';
// import { TableFilterComponent } from './table-filter/table-filter.component';
// import { TablePagingComponent } from './table-paging/table-paging.component';
// import { TablePinningComponent } from './table-pinning/table-pinning.component';
// import { TableSelectionComponent } from './table-selection/table-selection.component';
// import { TableSortingComponent } from './table-sorting/table-sorting.component';

export const OrdersMonitorRoutes: Routes = [
  {
    path: '',
    children: [{
      path: 'orders-monitor',
      component: OrdersMonitorComponent
    }]
  }
];
