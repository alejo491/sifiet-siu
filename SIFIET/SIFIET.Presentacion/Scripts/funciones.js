﻿/*$(document).ready(function () {
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



function confirmacionAgregarUsuario() {
    var nombresUsuario = document.getElementById("NOMBRESUSUARIO").value;
    var apellidosUsuario = document.getElementById("APELLIDOSUSUARIO").value;
    var identificacionUsuario = document.getElementById("IDENTIFICACIONUSUARIO").value;
    var passwordUsuario = document.getElementById("PASSWORDUSUARIO").value;
    var emailInstitucionalUsuario = document.getElementById("EMAILINSTITUCIONALUSUARIO").value;
    var roles = document.getElementsByName("roles");

    /*var result = "";
    var opciones = roles.options;
    var opt;

    for (var i = 0, iLen = opciones.length; i < iLen; i++) {
        opt = opciones[i];

        if (opt.selected) {
            result = result + "\n" + opt.text;
        }
    }*/

  

    if (nombresUsuario != "" && apellidosUsuario != "" && identificacionUsuario != "" && passwordUsuario != "" && emailInstitucionalUsuario != "" ) {
        var mensaje = "¿Desea registrar el usuario con la siguiente información? \n\n Nombres: " + nombresUsuario + "\n\n Apellidos: " + apellidosUsuario + "\n\n Identificación: " + identificacionUsuario + "\n\n Password: " + passwordUsuario + "\n\n Email: " + emailInstitucionalUsuario + "\n\n Roles: ";
        return confirm(mensaje);
    }
    else {
        return false;
    }
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

function mensajeNoUsuarios() {
    $(document).ready(function () { alert("No se han encontrado registros con el dato indicado, por favor intentelo de nuevo"); });
}

function getSelectValues(select) {
    var result = [];
    var opciones = select.options;
    var opt;

    for (var i = 0, iLen = opciones.length; i < iLen; i++) {
        opt = opciones[i];

        if (opt.selected) {
            result.push(opt.text);
        }
    }
    return result;
}