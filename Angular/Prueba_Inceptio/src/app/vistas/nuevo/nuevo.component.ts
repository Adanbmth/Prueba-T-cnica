import { Component,OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ListaRefacciones } from 'src/app/modelos/refacciones.interface';
import { ApiService } from 'src/app/servicios/api/api.service';
import { AlertasService } from 'src/app/servicios/alertas/alertas.service';

@Component({
  selector: 'app-nuevo',
  templateUrl: './nuevo.component.html',
  styleUrls: ['./nuevo.component.css']
})
export class NuevoComponent implements OnInit{

    constructor(private router:Router, private api:ApiService, private alert:AlertasService){}

    nuevoForm = new FormGroup({
      proveedor_id: new FormControl(),
      moto_id: new FormControl(),
      nombre: new FormControl(''),
      cantidad: new FormControl(),
      precio_unit: new FormControl()
    });

    ngOnInit(): void {
      
    }

    salir(){
      this.router.navigate(['dashboard']);
    }

    postForm(form:Partial<ListaRefacciones>){
      const formWithDefaultValues: ListaRefacciones = {
        ...form,
        nombre: form.nombre
      };
      this.api.postPart(formWithDefaultValues).subscribe(data =>{
        if(data == true){
          this.alert.showSucces('Refacción agregada','Hecho');
        }else{
          this.alert.showError('Error al agregar refacción','Error');
        }
        this.router.navigate(['dashboard']);
      });
    }
}
