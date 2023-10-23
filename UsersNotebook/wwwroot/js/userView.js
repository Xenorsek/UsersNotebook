//remove user
$('#removeUserModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var userId = button.data('user-id');
    var modal = $(this);
    modal.find('#confirmDeleteButton').data('user-id', userId);
});

$(document).on('click', '#confirmDeleteButton', function () {
    var userId = $(this).data('user-id');
    var deleteUrl = $(this).data('delete-url') + '/' + userId;

    $.ajax({
        url: deleteUrl,
        type: 'DELETE',
        success: function () {
            $('#removeUserModal').modal('hide');
            location.reload();
        }
    });
});
//add parameters
let addParameterCounter = 0;
let updateParameterCounter = 0;
function AddParameter() {
    addParameterCounter++;
    GenerateParameter(addParameterCounter, "additionalParametersForm");
}

function updateAddParameter() {
    GenerateParameter(updateParameterCounter, "additionalParametersUpdateForm");
}
function GenerateParameter(index, container, key, value) {
    var containerId = container;
    // Stworzenie nowego wiersza z polami i przyciskiem
    const newRow = document.createElement('div');
    newRow.className = 'row mb-3';
    newRow.id = 'parameterRow' + index;

    // Pole dla klucza
    const keyCol = document.createElement('div');
    keyCol.className = 'col-md-4';
    const keyInput = document.createElement('input');
    keyInput.type = 'text';
    keyInput.className = 'form-control';
    keyInput.name = 'parameters[' + index + '].key';
    keyInput.placeholder = 'Klucz';
    if (typeof key === "string" && key.length > 0) {
        keyInput.value = key;
    }

    keyCol.appendChild(keyInput);

    // Pole dla wartości
    const valueCol = document.createElement('div');
    valueCol.className = 'col-md-6';
    const valueInput = document.createElement('input');
    valueInput.type = 'text';
    valueInput.className = 'form-control';
    valueInput.name = 'parameters[' + index + '].value';
    valueInput.placeholder = 'Wartość';
    if (typeof value == "string" && value.length > 0) {
        valueInput.value = value;
    }
    valueCol.appendChild(valueInput);

    // Przycisk do usunięcia wiersza
    const buttonCol = document.createElement('div');
    buttonCol.className = 'col-md-1';
    const deleteButton = document.createElement('button');
    deleteButton.className = 'btn btn-danger';
    deleteButton.innerText = 'Usuń';
    deleteButton.onclick = function () {
        document.getElementById(containerId).removeChild(newRow);
    };
    buttonCol.appendChild(deleteButton);

    // Dodanie kolumn do nowego wiersza
    newRow.appendChild(keyCol);
    newRow.appendChild(valueCol);
    newRow.appendChild(buttonCol);

    // Dodanie nowego wiersza do elementu formularza
    document.getElementById(containerId).appendChild(newRow);
}

//update user
$('#updateUserForm').submit(function (event) {
    event.preventDefault();
    const parameterRows = document.querySelectorAll('#additionalParametersUpdateForm .row');
    parameterRows.forEach((row, index) => {
        const keyInput = row.querySelector('input[name*=".key"]');
        const valueInput = row.querySelector('input[name*=".value"]');
        keyInput.name = 'parameters[' + index + '].key';
        valueInput.name = 'parameters[' + index + '].value';
    });

    var formData = $(this).serialize();
    $.ajax({
        url: $(this).attr('action'),
        type: 'POST',
        data: formData,
        success: function (response) {
            location.reload();
        }
    });
});

$('#updateUserModal').on('show.bs.modal', function (event) {
    $("#additionalParametersUpdateForm").empty();

    var button = $(event.relatedTarget)
    var user = button.data('user')

    var modal = $(this)
    modal.find('#userId').val(user.Id);
    modal.find('#firstName').val(user.Imie);
    modal.find('#lastName').val(user.Nazwisko);
    modal.find('#birthDate').val(user.DataUrodzenia.split('T')[0]);
    modal.find('#gender').val(user.Plec);
    user.DodatkoweParametry.forEach((parameter, index) => {
        GenerateParameter(index, "additionalParametersUpdateForm", parameter.Key, parameter.Value);
    })
    if (user.DodatkoweParametry) {
        updateParameterCounter = user.DodatkoweParametry.length;
    }
    else {
        updateParameterCounter = 0;
    }
});

// create user
$('#addUserForm').submit(function (event) {
    event.preventDefault();

    const parameterRows = document.querySelectorAll('#additionalParametersForm .row');
    parameterRows.forEach((row, index) => {
        const keyInput = row.querySelector('input[name*=".key"]');
        const valueInput = row.querySelector('input[name*=".value"]');
        keyInput.name = 'parameters[' + index + '].key';
        valueInput.name = 'parameters[' + index + '].value';
    });

    var formData = $(this).serialize();
    $.ajax({
        url: $(this).attr('action'),
        type: 'POST',
        data: formData,
        success: function (response) {
            location.reload();
        }
    });
});   