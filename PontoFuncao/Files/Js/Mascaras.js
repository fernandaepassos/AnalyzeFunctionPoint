/*=============================================================================
// Autor: Fernanda Passos Ferreira
// Empresa: Sisclick Sistemas
// Ano: 2014
// Contato: fernanda@sisclick.com.br
//=============================================================================
*/

function mascaraData(campoData)
{
    var data = campoData.value;
    if (data.length == 2) {
        data = data + '/';
        document.forms[0].data.value = data;
        return true;
    }
    if (data.length == 5) {
        data = data + '/';
        document.forms[0].data.value = data;
        return true;
    }
}

function data(v) {

    v = v.replace(/\D/g, "")
    v = v.replace(/(\d{2})(\d)/, "$1/$2")
    v = v.replace(/(\d{2})(\d)/, "$1/$2")
    return v
}

function mascaraData(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execmascara()", 1)
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}


/*----------------------------------------------------------------------------
Formatação para qualquer mascara
-----------------------------------------------------------------------------*/
function formatar(src, mask) {
    var i = src.value.length;
    var saida = mask.substring(0, 1);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) != saida) {
        src.value += texto.substring(0, 1);
    }
}