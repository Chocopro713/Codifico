import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { EndpointsService } from "./core/services/endpoints.service";
import { OrderDialogComponent } from './order-dialog/order-dialog.component';
import { MatDialog } from '@angular/material/dialog';
export interface CustomerData {
  customerName: string;
  lastOrderDate: string;
  nextPredictedOrder: string;
  orders: string;
  nOrder: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'angularProject';
  public displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'orders', 'nOrder'];
  public dataSource = new MatTableDataSource<CustomerData>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private endpointService: EndpointsService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getData();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  openOrderDialog(userData: any, type: any): void {
    const dialogRef = this.dialog.open(OrderDialogComponent, {
      width: '90%',
      data: { userData, type }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      // Aquí puedes manejar el resultado del modal si es necesario
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  async getData() {
    await this.endpointService.getData().then((response) => {
      this.dataSource.data = response.data.map((item: CustomerData) => ({
        ...item,
        orders: '',
        nOrder: ''
      }));
      console.log(this.dataSource.data);
    }).catch((error) => {
      console.log(error);
    });
  }
}
