// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function limit(element, max_chars) {
    if (element.value.length > max_chars) {
        element.value = element.value.substr(0, max_chars);
    }
}


function peselInputParsing(element) {
    max_chars = 11;
    console.log(element.value);
    if (element.value.length > 0) {
        element.value = element.value.replace('/\D/g', '');
    }

    console.log(element.value);

    if (element.value.length > max_chars) {
        element.value = element.value.substr(0, max_chars);
    }
}
