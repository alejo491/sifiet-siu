/*$(document).ready(function () {
    alert('Pagina Cargada Exitosamente');
});*/

function comfirmarAgregarRol() {
    var nombre = document.getElementById("NOMROL").value;
    var descripcion = document.getElementById("DESCROL").value;
    var mensaje;
    if (nombre.trim() == "" || descripcion.trim() == "") {
        mensaje = "Hay datos que son requeridos para poder guardar el registro,\n por favor diligencie todos los campos";
        alert(mensaje);
        return true;
    } else {
        mensaje = 'Nombre: ' + nombre + '\n'
            + 'Descripcion:' + descripcion + '\n\n'
            + 'El Rol Puede: \n'
            + document.getElementById("Plan de Estudios").value + " Plan de Estudios |\t" + document.getElementById("Usuarios").value + ' Usuarios\n'
            + document.getElementById("Programas").value + " Programas |\t" + document.getElementById("Infraestructura").value + ' Infraestructura\n'
            + document.getElementById("Asignaturas").value + " Asignaturas |\t" + document.getElementById("Salones").value + ' Salones\n';
        return confirm(mensaje);
    }
}

function mensajeNoRoles() {
    $(document).ready(function() { alert("No se ha encontrado ningun Rol con la informacion\que se ha ingresado, por favor intentelo nuevamente"); });
}

function confirmSalirRol() {
    var r = confirm('¿Confirma que desea cacelar la accion?\nTodos los datos se perderan');
    var url = window.location.pathname;
    var pathArray = url.split('/');        // <-- no need in "string()"
    var host = pathArray[0];
    var newHost = '/rol';
    if (r == true) {
        window.location = host + newHost;
    }
    return false;                     
}