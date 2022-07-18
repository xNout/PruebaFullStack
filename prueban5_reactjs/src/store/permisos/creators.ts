import { AppThunkAction } from "..";
import { PermisosActions } from "./actions";
import axios, { AxiosResponse } from 'axios';
import { API } from "../../settings";
import { PermisoInfoDto, TipoPermisoDto } from '../../Models/PermisoInfoDto';
import Swal from "../../Common/Swal";
import { ModificarPermisoDto } from "../../Models/ModificarPermisoDto";

export const actionCreators = {

    loadTipoPermisos: ():AppThunkAction<PermisosActions> => (dispatch, getState) => {

        axios.get<TipoPermisoDto[]>(`${API.url}${API.modulo.tipoPermiso}`)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }

            dispatch({ type:"RECEIVE_TIPO_PERMISOS", data: data });
        })
        .catch(err => {
            
        });
    },
    modificar:(id: number, Model: ModificarPermisoDto):AppThunkAction<PermisosActions> => (dispatch, getState) => {
        axios.put(`${API.url}${API.modulo.permisos}/${id}`, Model)
        .then((result: AxiosResponse) => {
            const { data, status } = result;
            if(status == 404)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }
            Swal.Exito("Permiso modificado con éxito");
        })
        .catch(err => {
            Swal.Info("El permiso a modificar no existe");
        });

    },
    get: (id: number):AppThunkAction<PermisosActions> => (dispatch, getState) => {

        const { permisos: { id_solicitado }} = getState();

        if(id_solicitado !== undefined && id_solicitado === id)
        {
            Swal.Error("Ya se solicito el mismo permiso!");
            return;
        }

        dispatch({ type:"REQUEST_SOLC_PERMISO", id: id });

        axios.get<PermisoInfoDto>(`${API.url}${API.modulo.permisos}/${id}`)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }

            dispatch({ type:"RECEIVE_SOLC_PERMISO", data: data });
        })
        .catch(err => {
            Swal.Info("El permiso solicitado no existe");
            dispatch({ type:"RECEIVE_SOLC_PERMISO", data: undefined });
        });
    },

    getAll: ():AppThunkAction<PermisosActions> => (dispatch, getState) => {
        axios.get<PermisoInfoDto[]>(`${API.url}${API.modulo.permisos}`)
        .then(result => {
            const { data, status } = result;
            if(status != 200)
            {
                Swal.Error("No se recibió respuesta por parte del API");
                return;
            }

            dispatch({ type:"RECEIVE_PERMISOS", data: data });
        })
        .catch(err => {
            Swal.Error("Ocurrió un error interno");
        });
    },
    enviarFormOCCaja:(): AppThunkAction<PermisosActions> => (dispatch, getState) => {

        

    }
};