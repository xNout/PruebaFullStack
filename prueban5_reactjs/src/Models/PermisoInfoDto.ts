export interface PermisoInfoDto {
    id:               number;
    nombreEmpleado:   string;
    apellidoEmpleado: string;
    tipoPermiso:      TipoPermisoDto;
    fechaPermiso:     Date;
}

export interface TipoPermisoDto {
    id:          number;
    descripcion: string;
}