/*=============================================================================
// Autor: Fernanda Passos Ferreira
// Empresa: Sisclick Sistemas
// Ano: 2014
// Contato: fernanda@sisclick.com.br
//=============================================================================
*/

function ExibeOcultaDiv(ID)
{
    if (document.getElementById(ID).style.display == "none") {
        document.getElementById(ID).style.display = "";
        document.getElementById(ID + "span").innerHTML = " [-] ";
    }
    else {
        document.getElementById(ID).style.display = "none";
        document.getElementById(ID + "span").innerHTML = " [+] ";
    }
}

function selecionatodoschecks(spanchk) {
    //Seleciona todos os cheboxs do mesmo gridview do checkbox do cabecalho
    var oitem = spanchk.children;
    var thebox = (spanchk.type == "checkbox") ? spanchk : spanchk.children.item[0];
    xstate = thebox.checked;
    elm = thebox.form.elements;

    var nomeGridViewThebox = extrairNomeGridView(thebox.id);

    for (i = 0; i < elm.length; i++) {
        if (elm[i].type == "checkbox") {
            var nomeGridViewElm = extrairNomeGridView(elm[i].id);

            if ((elm[i].id != thebox.id) && (nomeGridViewThebox == nomeGridViewElm)) {
                if (elm[i].checked != xstate)
                    elm[i].click();
            }
        }
    }
}

function extrairNomeGridView(idCheckbox) {
    //Retorna o nome do gridview em que o checkbox com o idCheckbox se encontra
    if (idCheckbox == null)
        return "";

    var nomeGridView = "";
    var qtdeUndersCore = 0;
    for (z = (idCheckbox.length - 1) ; z >= 0; z--) //verifica de traz pra frente
    {
        if (qtdeUndersCore >= 2)
            nomeGridView = idCheckbox[z] + nomeGridView;

        if (idCheckbox[z] == "_")
            qtdeUndersCore++;
    }

    return nomeGridView;
}

function SelecionarCheck(corChk, RowState) {
    if (corChk.checked) {
        corChk.parentNode.parentNode.parentNode.style.backgroundColor = '#5790ea';
        corChk.parentNode.parentNode.parentNode.style.color = 'white';
    }
    else {
        if (RowState == 'Normal') {
            corChk.parentNode.parentNode.parentNode.style.backgroundColor = '#EDEDED';
            corChk.parentNode.parentNode.parentNode.style.color = 'black';
        }
        else {
            corChk.parentNode.parentNode.parentNode.style.backgroundColor = '#FAFAFA';
            corChk.parentNode.parentNode.parentNode.style.color = 'black';
        }
    }
}

/*
 *limpa todos os caracteres que não são numeros do campo V.2
 *onkeyup="campoNumero(this);"
 */
function campoNumeroDe0a5(campo) {
    var stringResultado = "";
    var caracter = "";
    stringCampo = campo.value.toString();
    tam = stringCampo.length;

    for (i = 0; i < tam; i++) {
        caracter = stringCampo.substring(i, i + 1);

        if (caracter == "0" ||
            caracter == "1" ||
            caracter == "2" ||
            caracter == "3" ||
            caracter == "4" ||
            caracter == "5")
        {
            stringResultado += caracter;
        }
    }
    campo.value = stringResultado;
    return stringResultado;
}


/*
 *limpa todos os caracteres que não são numeros do campo V.2
 *onkeyup="campoNumero(this);"
 */
function campoNumero(campo) {
    var stringResultado = "";
    var caracter = "";
    stringCampo = campo.value.toString();
    tam = stringCampo.length;

    for (i = 0; i < tam; i++) {
        caracter = stringCampo.substring(i, i + 1);

        if (caracter == "0" ||
            caracter == "1" ||
            caracter == "2" ||
            caracter == "3" ||
            caracter == "4" ||
            caracter == "5" ||
            caracter == "6" ||
            caracter == "7" ||
            caracter == "8" ||
            caracter == "." ||
            caracter == "9") {
            stringResultado += caracter;
        }
    }
    campo.value = stringResultado;
    return stringResultado;
}

function ModifyEnterKeyPressAsTab() {
    if (window.event) {
        if (window.event.keyCode == 13) {
            window.event.keyCode = 9;
        }
    }
}

// Editar Tela em carater modal
function EditarModal(idPaginaOrigem, nomeTelaModal) {
    aleat = Math.random();
    var WinSettings = "center:yes;status:no;resizable:no;dialogHeight:500px;dialogwidth:700px"
    window.showModalDialog(nomeTelaModal + '?Id=0&random=' + aleat, null, WinSettings);

    //Se o id da pagina origem for == 0 sera substituido
    var novaURL = window.location.href;
    if (novaURL.indexOf("Id=0") > 0) {
        var _idPaginaOrigem = "Id=" + idPaginaOrigem;
        window.location.href = novaURL.replace("Id=0", _idPaginaOrigem);
    }
    else {
        window.location = window.location;
    }
}

function FormatMaskSetValor(nomeObjTextBox, mascara, valor) {
    document.getElementById(nomeObjTextBox).alt = mascara;

    if (document.all)//para IE
        document.getElementById(nomeObjTextBox).innerText = valor;
    else // Para FF
        document.getElementById(nomeObjTextBox).value = valor;
}

function Trim(str) {
    if (str != "") {
        return str.replace(/^\s+|\s+$/g, "");
    }
    else {
        return "";
    }
}

function formataCNPJ(campo, evt) {
    //99.999.999/9999-99
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam >= 2 && tam < 5)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2);
    else if (tam >= 5 && tam < 8)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5);
    else if (tam >= 8 && tam < 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8);
    else if (tam >= 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8, 4) + '-' + vr.substr(12);
    MovimentaCursor(campo, xPos);
}

function formataCPF(campo, evt) {
    //123.123.123-99
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;


    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;

        if (tam == 1)
            campo.value = "0-0" + vr;
        if (tam == 2)
            campo.value = "0-" + vr;

        if ((tam > 2) && (tam <= 5))
            campo.value = vr.substr(0, tam - 2) + '-' + vr.substr(tam - 2, tam);

        if ((tam >= 6) && (tam <= 8))
            campo.value = vr.substr(0, tam - 5) + '.' + vr.substr(tam - 5, 3) + '-' + vr.substr(tam - 2, tam);

        if ((tam >= 9) && (tam <= 11))
            campo.value = vr.substr(0, tam - 8) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + '-' + vr.substr(tam - 2, tam);



        // if ((tam >= 10) && (tam <= 12))
        // {
        //  campo.value = vr.substr(0, tam - 10) + '.' + vr.substr(tam - 10, 3) + '.' + vr.substr(tam - 6, 3) + '-' + vr.substr(tam - 2, tam);
        // }  
    }
    MovimentaCursor(campo, xPos);
}

function formataRG(campo, evt) {
    //1.123.123
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;

        if (tam == 1)
            campo.value = "0.00" + vr;
        if (tam == 2)
            campo.value = "0.0" + vr;
        if (tam == 3)
            campo.value = "0." + vr;

        if ((tam > 3) && (tam <= 5))
            campo.value = vr.substr(0, tam - 3) + '.' + vr.substr(tam - 3, tam);
        if ((tam >= 6) && (tam <= 8))
            campo.value = vr.substr(0, tam - 6) + '.' + vr.substr(tam - 6, 3) + '.' + vr.substr(tam - 3, tam);
        if ((tam >= 9) && (tam <= 11))
            campo.value = vr.substr(0, tam - 9) + '.' + vr.substr(tam - 9, 3) + '.' + vr.substr(tam - 6, 3) + '.' + vr.substr(tam - 3, tam);
    }
    MovimentaCursor(campo, xPos);
}


// Formata o campo CEP
function formataCEP(campo, evt) {
    //312555-650
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;

    if (tam < 5)
        campo.value = vr;
    else if (tam == 5)
        campo.value = vr + '-';
    else if (tam > 5)
        campo.value = vr.substr(0, 5) + '-' + vr.substr(5);
    MovimentaCursor(campo, xPos);
}

function validaDat(campo, valor) {
    if (valor == "") return;
    var date = valor;
    var ardt = new Array;
    var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
    ardt = date.split("/");
    erro = false;
    if (date.search(ExpReg) == -1) {
        erro = true;
    }
    else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
        erro = true;
    else if (ardt[1] == 2) {
        if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
            erro = true;
        if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
            erro = true;
    }
    if (erro) {
        alert("A data " + valor + " não esta em um forma correto. \n Informe uma data no formato DD/MM/AAAA.");
        campo.focus();
        campo.value = "";
        return false;
    }
    return true;
}