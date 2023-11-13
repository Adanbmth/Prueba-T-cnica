import { Component,OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ListaRefacciones } from '../../modelos/refacciones.interface';
import { AlertasService } from 'src/app/servicios/alertas/alertas.service';
import { ApiService } from 'src/app/servicios/api/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit{

  constructor(private route:ActivatedRoute, private router:Router, private api:ApiService, private alerta:AlertasService){}

  datosParts:ListaRefacciones;
  editarForm = new FormGroup({
    id: new FormControl(),
    proveedor_id: new FormControl(),
    moto_id: new FormControl(),
    nombre: new FormControl(''),
    cantidad: new FormControl(),
    precio_unit: new FormControl(),
    proveedor: new FormControl(null),
    vehiculo: new FormControl(null)
  });

  ngOnInit(): void {
    let refaccion_id = this.route.snapshot.paramMap.get('id');
    this.api.getPart(refaccion_id).subscribe(data =>{
      this.datosParts = data;
      const idNumerico = Number(this.datosParts.id);
      this.editarForm.setValue({
        id:idNumerico,
        proveedor_id: this.datosParts.proveedor_id,
        moto_id: this.datosParts.moto_id,
        nombre: this.datosParts.nombre || null,
        cantidad: this.datosParts.cantidad,
        precio_unit: this.datosParts.precio_unit,
        proveedor: this.datosParts.proveedor || null,
        vehiculo: this.datosParts.vehiculo || null
      });
    });
  }

  postForm(form:Partial<ListaRefacciones>){
    const formWithDefaultValues: ListaRefacciones = {
      ...form,
      nombre: form.nombre,
    };
    this.api.putPart(formWithDefaultValues).subscribe(data => {
      if(data == true){
        this.alerta.showSucces('Datos modificados','Hecho');
      }else{
        this.alerta.showError('Error al modificar datos','Error');
      }
      this.router.navigate(['dashboard']);
    });
    
  }

  eliminar(){
    let datos:Partial<ListaRefacciones> = this.editarForm.value;
    const datosConValorPredeterminado: ListaRefacciones = {
      ...datos,
      nombre: datos.nombre
    };
  
    this.api.deletePart(datosConValorPredeterminado).subscribe(data => {
      if(data == true){
        this.alerta.showSucces('Datos eliminados','Hecho');
      }else{
        this.alerta.showError('Error al eliminar datos','Error');
      }
    });
    this.router.navigate(['dashboard']);
  }

  salir(){
    this.router.navigate(['dashboard']);
  }
}
