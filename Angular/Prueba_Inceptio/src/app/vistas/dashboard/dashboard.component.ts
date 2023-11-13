import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../servicios/api/api.service';
import { Router } from '@angular/router';
import{ListaRefacciones} from '../../modelos/refacciones.interface';
import { NuevoComponent } from '../nuevo/nuevo.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit{

  refacciones:ListaRefacciones[] = [];

  constructor(private api:ApiService, private router:Router){}
  
  ngOnInit(): void {
    this.api.getAllParts("obtenerRefacciones").subscribe(data =>{
      this.refacciones = data;
    });
  }

  editarRefaccion(id:any)
  {
    this.router.navigate(['editar', id]);
  }

  nuevaRefaccion()
  {
    this.router.navigate(["nuevo"]);
  }


}
