import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';  
import { Ordenes } from './Model/Ordenes'  
import { ROOT_URL } from '../app/Config/config'  
import { Observable } from 'rxjs';  

@Injectable({
  providedIn: 'root'
})
export class VentasService {

  Ordenes?: Observable<Ordenes[]>;  

  constructor(private http: HttpClient) {  
   }  

  getUsuario() {  
    return this.http.get<Ordenes[]>(ROOT_URL + 'Ordenes/Get');  
}  



EditUsuario(orden:Ordenes) {  
 
const params = new HttpParams().set('ID', orden.Id);  
const headers = new HttpHeaders().set('content-type', 'application/json');  
var body = {  
                Id: orden.Id, 
                Estado: orden.EstadoPedido, 
 
}  
return this.http.put<Ordenes>(ROOT_URL + 'Ordenes/Put?Id=' + orden.Id + "&Estado=" + orden.EstadoPedido, body, { headers, params })  
}

}

