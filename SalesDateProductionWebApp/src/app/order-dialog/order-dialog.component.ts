import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EndpointsService } from '../core/services/endpoints.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

export interface CustomerData {
  orderId: string;
  requiredDate: string;
  shippedDate: string;
  shipName: string;
  shipAddress: string;
  shipCity: string;
}

export interface Employee {
  empId: number;
  fullName: string;
}
export interface Shippers {
  empId: number;
  fullName: string;
}
export interface Products {
  productId: number;
  productName: string;
}

@Component({
  selector: 'app-order-dialog',
  templateUrl: './order-dialog.component.html',
  styleUrls: ['./order-dialog.component.scss']
})
export class OrderDialogComponent implements OnInit {
  public displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipName', 'shipAddress', 'shipCity'];
  public dataSource = new MatTableDataSource<CustomerData>();
  public employees: Employee[] = [];
  public shippers: Shippers[] = [];
  public products: Products[] = [];
  public saveInfo: any = {
    CreateOrderInput: {
      custId: null,
      EmpId: 1,
      ShipperId: 2,
      ShipName: "Test Ship",
      ShipAddress: "1234 Test St",
      ShipCity: "Test City",
      OrderDate: "2024-01-01",
      RequiredDate: "2024-01-15",
      ShippedDate: null,
      Freight: 15.5,
      ShipCountry: "USA"
    },
    OrderDetailInput: {
      ProductId: 2,
      UnitPrice: 19.99,
      Qty: 10,
      Discount: 0.1
    }
  };

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public dialogRef: MatDialogRef<OrderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private endpointService: EndpointsService,
  ) { }

  async ngOnInit() {
    if (this.data.type === 'list') {
      await this.endpointService.getDataOrder(this.data.userData.custId).then((response: any) => {
        this.dataSource.data = response.data;
      })
    }
    if (this.data.type === 'form') {
      this.saveInfo.CreateOrderInput.custId = this.data.userData.custId;
      await this.endpointService.getDataEmployees().then((response: any) => {
        this.employees = response.data;
      })
      await this.endpointService.getDataShippers().then((response: any) => {
        this.shippers = response.data;
      })
      await this.endpointService.getDataProducts().then((response: any) => {
        this.products = response.data;
      })
    }
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }


  onNoClick(): void {
    this.dialogRef.close();
  }
  saveOrder(): void {
    this.endpointService.saveDataOrder(this.saveInfo).then((response: any) => {
      this.dialogRef.close('save');
    })
    // this.dialogRef.close();
  }
}
