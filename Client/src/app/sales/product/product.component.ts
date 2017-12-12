import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { SalesOrdersService } from '../../services/salesOrders.service';

@Component({
    selector: 'product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})

export class ProductSalesComponent implements OnInit {
    private data: string[];
    private id: number;

    constructor(
      private salesService: SalesOrdersService,
      private activatedRoute: ActivatedRoute,
      private router: Router
    ) { }

    ngOnInit(): void {
      let params: any = this.activatedRoute.snapshot.params
      this.id = params.id;

      if(this.id == null)
        return;

      this.salesService.getByProduct(params.id)
                          .then(response => {
                            console.log(response);
                            this.data = response;
                          });
    }

    onSubmit(form) {
      let route = '/sales/product/' + form.value.searchText.toLowerCase();
      this.router.navigateByUrl(route);
    }
}
