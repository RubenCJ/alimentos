import { Ingrediente } from "./ingrediente";

export interface Alimento {
    idAlimento?: number;
    nombre: string;
    costo: number;
    fechaRegistro: Date;
    fechaActualizacion: Date;
    activo: boolean;
    idIngredientes: Ingrediente[];
}
