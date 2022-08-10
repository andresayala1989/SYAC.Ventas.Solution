import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ordenes } from '../Model/Ordenes';
import { VentasService } from '../ventas.service';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-ventas-list',
  templateUrl: './ventas-list.component.html',
  styleUrls: ['./ventas-list.component.css']
})
export class VentasListComponent implements OnInit {
  resetForm:boolean= false;
  emplist?: Ordenes[];  
  OptionList= ['Confirmar', 'Anular'];
  dataavailbale: Boolean = false;  
  tempemp: Ordenes=new Ordenes();    
  pages: number = 1;
  displayStyle = "none";
  closeResult = '';

constructor(public dataservice:VentasService, private route: Router,private modalService: NgbModal) {  }  
ngOnInit() {  
this.LoadData();  
}  

LoadData() {  
    this.dataservice.getUsuario().subscribe((tempdate) => {  
      this.emplist = tempdate;  
      console.log(this.emplist);  
      if (this.emplist.length > 0) {  
        this.dataavailbale = true;  
      }     
      else {  
        this.dataavailbale = false;  
      }  
    }  
      
    , err => {  
    console.log(err);  
    })  
}  
estadoconfirmation(id: number) {  


   
}  
 
form = new FormGroup({
  estado: new FormControl('', Validators.required)
});

RefreshData() {  
  this.LoadData();  
}  

open(content:any) {
  this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
    this.closeResult = `Closed with: ${result}`;
  }, (reason) => {
    this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
  });
}

private getDismissReason(reason: any): string {
  if (reason === ModalDismissReasons.ESC) {
    return 'by pressing ESC';
  } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
    return 'by clicking on a backdrop';
  } else {
    return  `with: ${reason}`;
  }
}
changeEstado(e:any) {
  console.log(e.target.value);
  this.tempemp.EstadoPedido = e.target.value;
}

submit(){
  console.log(this.form.value);
  this.dataservice.EditUsuario(this.tempemp).subscribe(res => {  
    alert("Actualización Exitosa !!!");  
    this.LoadData();  
    })  
}

}