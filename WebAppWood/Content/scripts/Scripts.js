var contador = 0;
var num = 0;
var tableCont = 1;
var addTree = document.getElementById("addTree");
var mainContent = document.getElementById("tableContent");
var listaArbol = new Array;

addTree.addEventListener("click", getDataMedidaArboles);
function getDataMedidaArboles() {
    var AltoMetros = document.getElementById("AltoMetros").value;
    var Circunferencia = document.getElementById("Circunferencia").value;
    console.log('evento agregar arboles');
    if (contador == 0) {
        console.log(`contador = ${contador}`);
        createTable();
        contador++;
        num++;
        createRowTable(num, AltoMetros, Circunferencia);
    } else if (contador == 20) {
        console.log(`contador = ${contador}`);
        tableCont++;
        createTable();
        contador = 0;
        contador++;
        num++;
        createRowTable(num, AltoMetros, Circunferencia);
    } else {
        console.log(`contador = ${contador}`);
        contador++;
        num++;
        createRowTable(num, AltoMetros, Circunferencia);
    }
}
function createTable() {
    let table = document.createElement('table');
    let tr = document.createElement('tr');
    let numeroHeader = document.createElement('th');
    let altoHeader = document.createElement('th');
    let circunferenciaHeader = document.createElement('th');
    let opcionesHeader = document.createElement('th');
    numeroHeader.textContent = 'Números';
    altoHeader.textContent = 'Alto';
    circunferenciaHeader.textContent = 'Circunferencia';
    opcionesHeader.textContent = 'Opciones';
    table.setAttribute('id', `idTable${tableCont}`);
    table.setAttribute('class', `tableMedidaArbol col-sm-4`);
    table.appendChild(tr);
    tr.appendChild(numeroHeader);
    tr.appendChild(altoHeader);
    tr.appendChild(circunferenciaHeader);
    tr.appendChild(opcionesHeader);
    // contador++;
    mainContent.appendChild(table);
};
function createRowTable(RNumero, RAltosMetros, RCircunferencia) {
    console.log(`contador = ${contador} numero=${RNumero} alto=${RAltosMetros} circunferencia=${RCircunferencia}`);
    var tablaInsert = document.getElementById(`idTable${tableCont}`);
    var tr = document.createElement("tr");
    var tdNumero = document.createElement("td");
    var tdAlto = document.createElement("td");
    var tdCircunferencia = document.createElement("td");
    var tdOpciones = document.createElement("td")
    tdNumero.textContent = RNumero;
    tdAlto.textContent = RAltosMetros;
    tdCircunferencia.textContent = RCircunferencia;
    tdOpciones.textContent = 'Editar';
    tr.appendChild(tdNumero);
    tr.appendChild(tdAlto);
    tr.appendChild(tdCircunferencia);
    tr.appendChild(tdOpciones);
    tablaInsert.appendChild(tr)
    mainContent.appendChild(tablaInsert);
    insertTablaAJson(RNumero, RAltosMetros, RCircunferencia);

}
function insertTablaAJson(PNumber, PAlto, PCircun) {
    listaArbol.push({
        "id": document.getElementById("IdMedicion").value,
        "tipo": document.getElementById("Tipo").value,
        "numero": PNumber,
        "altura": PAlto,
        "circunferencia": PCircun,
    });
    var test=JSON.stringfy(listaArbol);
    localStorage.JsonMedida = test;
    console.log(listaArbol);
    console.log(localStorage.JsonMedida);
}
function EnviarData() {
    var jsondata = JSON.stringify({ 'jsonPost': listaArbol });;
    console.log(jsondata);
    $.ajax({
        type: 'Post',
        url: '/Medir/InsertMedida/',
        dataType: 'json',
        data: jsondata, //value is an array
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
        },
        error: function (xhr, textStatus, errorThrown) {
        }
    });
    //fetch('/Medir/InsertMedida', {
    //    method: 'Post',
    //    dataType: 'json',
    //    body: jsondata, //value is an array
    //    contentType: 'application/json; charset=utf-8',
    //}).then(function (response) {
    //    return response.json();
    //}).then(function (data) {
    //    console.log('DataSend:','ok');
    //});
}
