

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall'},
        "columns": [
        { data: 'name', "width": "10%" },
        { data: 'producent', "width": "10%" },
        { data: 'listPrice', "width": "5%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'productId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/admin/product/upsert?productId=${data}" class="btn btn-primary max-2"> <i class="bi bi-pencil-square"></i> Edytuj </a>
                                <a href="/admin/product/delete/${data}" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Usun </a>
                            </div>`
                },
                "width": "25%"
            },
        ]
    });
}


