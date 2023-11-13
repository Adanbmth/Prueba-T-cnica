import { Injectable } from '@angular/core';
import  {HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { ListaRefacciones } from '../../modelos/refacciones.interface';
import { ResponseI } from 'src/app/modelos/response.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url:string = "https://localhost:7207/";

  constructor(private http:HttpClient) { }

  getAllParts(page:string):Observable<ListaRefacciones[]>{
    let direccion = this.url + page;
    return this.http.get<ListaRefacciones[]>(direccion);
  }

  getPart(id:any):Observable<ListaRefacciones>{
    let direccion = this.url +"buscarRefaccion?id="+ id;
    return this.http.get<ListaRefacciones>(direccion); 
  }

  putPart(form:ListaRefacciones):Observable<boolean>{
    let direccion = this.url + "modificarRefaccion";
    return this.http.put<boolean>(direccion, form);
  }

  deletePart(form:ListaRefacciones):Observable<boolean>{
    let direccion = this.url + "quitarRefaccion?id=" + form.id;
    let Options = {
      headers: new HttpHeaders({
        'Conten-type': 'application/json'
      }),
      body:from
    }
    return this.http.delete<boolean>(direccion, Options);
  }

  postPart(form:ListaRefacciones):Observable<boolean>{
    let direccion = this.url + "agregarRefaccion";
    return this.http.post<boolean>(direccion, form);
  }

}
