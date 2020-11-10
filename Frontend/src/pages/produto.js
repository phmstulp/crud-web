import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import SaveIcon from '@material-ui/icons/Save';
import { makeStyles } from '@material-ui/core/styles';
import Api from '../Api';
import { useEffect } from 'react';

var edit = false;

function Produto() {
    const [cdProduto, setCdProduto] = React.useState("");
    const [dsProduto, setDsProduto] = React.useState("");
    const [cdMarca, setCdMarca] = React.useState("");
    const [dsObs, setDsObs] = React.useState("");
    const [nrValor, setNrValor] = React.useState("");
    const [data, setData] = React.useState([]);

    const useStyles = makeStyles((theme) => ({
        button: {
            margin: theme.spacing(1),
        },
    }));
    const classes = useStyles();

    async function Save(event) {
        if (edit) {
            const produto = {
                "cdProduto": id,
                "dsProduto": dsProduto,
                "cdMarca": cdMarca,
                "dsObs": dsObs,
                "nrValor": nrValor
            };
            const respPost = await Api.put(`produto/${id}`, produto);
            window.location.href = "http://localhost:3000/produto-list";
        } else {
            const next = await Api.get('produto/NextId');
            var id = next.data;
            const produto = {
                "cdProduto": id,
                "dsProduto": dsProduto,
                "cdMarca": cdMarca,
                "dsObs": dsObs,
                "nrValor": nrValor
            };
            const respPost = await Api.post('produto', produto);
            window.location.href = "http://localhost:3000/produto-list";
        }
    }

    useEffect(() => {
        //const id = this.props.match.params.id;
        //const response = await Api.get('produto/' + 1);
        const id = 1;
        const GetData = async () => {
            const response = await Api.get(`produto/${id}`);
            setData(response.data);
        };
        GetData();
        console.log(data);
        setCdProduto(data.cdProduto);
        setDsProduto(data.dsProduto);
        setCdMarca(data.cdMarca);
        setDsObs(data.dsObs);
        setNrValor(data.nrValor);
    }, []);


    return (
        <div>
            <h1> Cadastro de Produto </h1>
            <div>
                <div>
                    <TextField id="cdProduto" label="Código" value={cdProduto} onChange={e => setCdProduto(e.target.value)} required fullWidth />
                </div>
                <div>
                    <TextField id="dsProduto" label="Descrição" value={dsProduto} onChange={e => setDsProduto(e.target.value)} required fullWidth />
                </div>
                <div>
                    <TextField id="cdMarca" label="Marca" value={cdMarca} onChange={e => setCdMarca(e.target.value)} required fullWidth />
                </div>
                <div>
                    <TextField id="dsObs" label="Observação" value={dsObs} onChange={e => setDsObs(e.target.value)} required fullWidth />
                </div>
                <div>
                    <TextField id="nrValor" label="Valor" value={nrValor} onChange={e => setNrValor(e.target.value)} required fullWidth />
                </div>
            </div>
            <div>
                <Button
                    variant="contained"
                    color="secondary"
                    size="large"
                    className={classes.button}
                    startIcon={<SaveIcon />}
                    onClick={Save}>
                    Salvar
                </Button>
            </div>
        </div>
    );
}

export default Produto;