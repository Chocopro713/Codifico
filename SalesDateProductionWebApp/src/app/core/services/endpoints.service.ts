import { Injectable } from '@angular/core';
import axiosIns from "../config/axios";

@Injectable({
  providedIn: 'root'
})
export class EndpointsService {

  constructor() { }

  async getData() {
    return await axiosIns.get('/customer/next-order-date');
  }
  async getDataOrder(id: any) {
    return await axiosIns.get('/order/all-order/' + id);
  }
  async getDataEmployees() {
    return await axiosIns.get('/Employee/get-all-employees');
  }
  async getDataShippers() {
    return await axiosIns.get('/shipper/get-all-shippers');
  }
  async getDataProducts() {
    return await axiosIns.get('/product/get-all-products');
  }
  async saveDataOrder(params: any) {
    return await axiosIns.post('/order/create-order-with-detail', params);
  }
}
