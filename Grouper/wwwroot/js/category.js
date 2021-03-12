var dataTable;

$(document.ready).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').dataTable({
        "ajax": {
            "url": "/api/category",
            "type": "Get",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", width: "40%" },
            { "data": "displayOrder", width: "30%" },
            { "data": "id", render: function(data) {
                return `<div class="text-center">
                        <a href="/Admin/category/upsert?id=${data}" class="btn btn-success text-white style="cussor:pointer;width:100px;"">
                        <i class="far fe-edit">  </i>Edit                  
                        </a>
                        <a class="btn btn-success text-white style="cussor:pointer;width:100px;"">
                        <i class="far fa-trash-alt">  </i>Delete                  
                        </a>
                        </div>
                        `;
                },"width":"30%"
            }
        ],
        "language": {
            "emptyTable":"no data found"
        },
        "width":"100%"
    });

};
