// Genera formato de fecha requerido "HoraInicio a HoraFin"
function formatoHorario(strFechaInicio, strFechaFin) {
    var fechaInicio = new Date(strFechaInicio);
    var fechaFin = new Date(strFechaFin);

    return fechaInicio.getHours().toString().padStart(2, '0') + ":" + fechaInicio.getMinutes().toString().padStart(2, '0')
        + " a " + fechaFin.getHours().toString().padStart(2, '0') + ":" + fechaFin.getMinutes().toString().padStart(2, '0');
}


// Hace la busqueda de las sesiones asignadas al estudiante
function busquedaSesionesAsignadas() {
    var estudiante = document.getElementById("cmbEstudiantes").value;

    // Iniciar Lista de Estudiantes
    var cmbAsignaciones = document.getElementById("cmbAsignaciones");
    cmbAsignaciones.innerHTML = "";

    fetch(`${apiBaseUrl}/api/Asignacion/Estudiante/` + estudiante)
        .then(response => response.json())
        .then(data => {
            data.forEach(function (item) {
                var option = document.createElement('option');
                option.value = item.id;
                option.textContent = item.sesion.nombre;
                option.setAttribute("data-start", item.sesion.startDateTime);
                option.setAttribute("data-end", item.sesion.endDateTime);
                cmbAsignaciones.appendChild(option);
            });
        })
        .then(() => {
            detalleSesion();
        })
        .catch(error => console.error("Error msg: ", error));
}

// Muestra el detalle de la sesion luego de hacer clic en el boton de la sesion seleccionada.
function detalleSesion() {
    var cmbAsignaciones = document.getElementById("cmbAsignaciones");
    var selectedOption = cmbAsignaciones.options[cmbAsignaciones.selectedIndex];

    if (selectedOption != null) {
        var horario = formatoHorario(selectedOption.dataset.start, selectedOption.dataset.end);
        //var fechaInicial = new Date(data.startDateTime);
        const fechaInicioFormateada = moment(selectedOption.dataset.start).format('dddd D [de] MMMM');
        const fechaFinFormateada = moment(selectedOption.dataset.end).format('dddd D [de] MMMM');
        // Cargar informacion de lectura sobre sesion.
        colocarDatosForm(cmbAsignaciones.value, fechaInicioFormateada, fechaFinFormateada, horario);
    }
    else {
        colocarDatosForm("", "", "", "");
    }
}

// Actualiza en la vista los valores de los campos
function colocarDatosForm(id, inicio, fin, horario) {
    document.getElementById("lblAsignacion").textContent = id;
    document.getElementById("lblFechaInicio").textContent = inicio;
    document.getElementById("lblFechaFin").textContent = fin;
    document.getElementById("lblHorario").textContent = horario;
}