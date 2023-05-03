// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function limit(element, max_chars) {
    if (element.value.length > max_chars) {
        element.value = element.value.substr(0, max_chars);
    }
}

function peselInputParsing(element) {
    // used in customer create and edit
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

function clearFilterInput() {
    document.getElementById("filterInput").value = '';
    var table, tr;
    table = document.getElementById("indexTable");
    tr = table.getElementsByTagName("tr");
    //console.log(tr);
    for (i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
    }
}

function filterFunction() {
    // Declare variables
    var input, filter, table, tr, td, i, j, txtValue;
    input = document.getElementById("filterInput");
    filter = input.value.toUpperCase().trim();

    table = document.getElementById("indexTable");
    tr = table.getElementsByTagName("tr");

    if (filter.length <= 2) {
        for (i = 0; i < tr.length; i++) {
            tr[i].style.display = "";
        }
        return;
    }

    filterArray = filter.split(" ").filter(function (str) {
        return /\S/.test(str);
    });
    //console.log('filterArray= ', filterArray);
    // Loop through all table rows, and hide those who don't match the search query
    for (i = 1; i < tr.length; i++) {
        // from i = 1 to skip header
        td = tr[i].getElementsByTagName("td");

        txtValue = ' ';
        if (td) {
            for (j = 0; j < td.length; j++) {
                txtValue += ' '.concat(td[j].innerText);
            }
            txtValue = txtValue.replace(/(\r\n|\n|\r)/gm, "").replace(/\s\s+/g, ' ').toUpperCase();

            //console.log('txtValue= '.concat(txtValue));

            var isMatch = true;
            for (j = 0; j < filterArray.length; j++) {
                if (txtValue.indexOf(filterArray[j]) == -1) {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
