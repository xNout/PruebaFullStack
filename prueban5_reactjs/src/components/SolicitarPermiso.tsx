import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import Layout from './Layout';
import { actionCreators } from '../store/permisos/creators'
import Swal from '../Common/Swal';


type props = ApplicationState & typeof actionCreators;

interface SolicitarPermisoState {
    Id: string;
}
class SolicitarPermiso extends React.Component<props, SolicitarPermisoState>
{
    constructor(props: any)
    {
        super(props);
        this.Solicitar = this.Solicitar.bind(this);
        this.HandleChange = this.HandleChange.bind(this);
        this.state = {
            Id: ""
        };
    }

    HandleChange(e: React.FormEvent<HTMLInputElement | HTMLSelectElement>) {
        const { name, value, className } = e.currentTarget;

        this.setState({
            ...this.state,
            [name]: value
        });
    }
    componentDidMount()
    {
        
    }

    Solicitar()
    {
        const { Id } = this.state;

        if(!Id)
        {
            Swal.Error("Debes ingresar un ID");
            return;
        }

        this.props.get(Number(Id));
    }
    public render() {
        const { Id } = this.state;

        const { solicitado } = this.props.permisos;
        return <Layout>
            <div className="pure-u-1 modulo_obtpermisos">

                <div className="w-100"></div>
                <form className="pure-form">
                    <fieldset>
                        <legend>Solictar permiso</legend>
                        <input type="number" name="Id" min={1} value={Id} onChange={this.HandleChange} placeholder="ID Permiso" />
                        <button type="button" onClick={this.Solicitar} className="pure-button pure-button-primary">Buscar</button>
                    </fieldset>
                </form>
                <form className="pure-form pure-form-aligned">
                    <fieldset>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Nombres</label>
                            <span className="pure-u-12-24">{solicitado?.nombreEmpleado || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Apellidos</label>
                            <span className="pure-u-12-24">{solicitado?.apellidoEmpleado || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Tipo Permiso</label>
                            <span className="pure-u-12-24">{solicitado?.tipoPermiso?.descripcion || ""}</span>
                        </div>
                        <div className="pure-control-group">
                            <label className="pure-u-3-24">Fecha Asignacion</label>
                            <span className="pure-u-12-24">{solicitado?.fechaPermiso ? 
                            new Date(solicitado?.fechaPermiso).toLocaleString() : ""}</span>
                        </div>
                    </fieldset>
                </form>
            </div>
        </Layout>
    }
}

export default connect((state: ApplicationState) => ({
    permisos: state.permisos
  }), actionCreators)(SolicitarPermiso as any)

