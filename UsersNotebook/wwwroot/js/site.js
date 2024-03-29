﻿function showToast(message) {
    var toastHtml = `
        <div class="toast" role="alert" aria-live="assertive" aria-atomic="true" data-delay="5000" style="z-index:2000;">
            <div class="toast-header">
                <strong class="mr-auto">Błąd</strong>
                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="toast-body">${message}</div>
        </div>`;
    var toastElement = $(toastHtml);
    $('#toastContainer').append(toastElement);
    toastElement.toast('show');
}

$(document).ajaxError(function (event, jqxhr, settings, thrownError) {
    if (jqxhr.responseText) {
        showToast(jqxhr.responseText);
    } else {
        showToast('Wystąpił nieznany błąd');
    }
});