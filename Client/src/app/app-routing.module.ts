import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OverviewComponent } from './overview/overview.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientComponent } from './clients/client/client.component';
import { FinancialComponent } from './financial/financial.component';
import { InventoryComponent } from './inventory/inventory.component';
import { NotFoundComponent } from './common/404.component';
import { OrdersComponent } from './orders/orders.component';
import { SalesComponent } from './sales/sales.component';
import { SaleInvoiceComponent } from './sales/saleInvoice/saleInvoice.component';
import { PayableComponent } from './financial/payable/payable.component';
import { ProductSalesComponent } from './sales/product/product.component';
import { ReceivableComponent } from './financial/receivable/receivable.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { PurchaseComponent } from './purchases/purchase/purchase.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { ProductComponent } from './inventory/product/product.component';
import { SupplierComponent } from './suppliers/supplier/supplier.component';
import { SaleOrderComponent } from './orders/saleOrder/saleOrder.component';


const appRoutes: Routes = [
  { path: '', component: OverviewComponent },
  { path: 'clients', component: ClientsComponent },
  { path: 'client/:id', component: ClientComponent },
  { path: 'financial', component: FinancialComponent },
  { path: 'inventory', component: InventoryComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'sales', component: SalesComponent },
  { path: 'sales/product', component: ProductSalesComponent },
  { path: 'sales/product/:id', component: ProductSalesComponent },
  { path: 'saleinvoice/:id', component: SaleInvoiceComponent },
  { path: 'payables', component: PayableComponent },
  { path: 'receivables', component: ReceivableComponent },
  { path: 'product/:id', component: ProductComponent},
  { path: 'purchases', component: PurchasesComponent },
  { path: 'purchase/:id', component: PurchaseComponent },
  { path: 'suppliers', component: SuppliersComponent },
  { path: 'supplier/:id', component: SupplierComponent },
  { path: '404', component: NotFoundComponent},
  { path: 'saleorder/:id', component: SaleOrderComponent },

  { path: '**', component: NotFoundComponent}  // redirect any path that is not found to 404
];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}
