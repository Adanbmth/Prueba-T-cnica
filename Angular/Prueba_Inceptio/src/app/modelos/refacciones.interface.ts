export interface ListaRefacciones{
    id?:number | string;
    proveedor_id?:number;
    moto_id?:number;
    nombre:string | null | undefined;
    cantidad?:number;
    precio_unit?:number;
    proveedor?:null;
    vehiculo?:null;
}