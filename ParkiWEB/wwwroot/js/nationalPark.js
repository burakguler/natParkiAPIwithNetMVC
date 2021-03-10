var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/nationalParks/GetAllNationalPark",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" },
            { "data": "location", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/nationalParks/Upsert/${data}" class='btn btn-primary text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/nationalParks/Delete/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                           `;
                }, "width": "30%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title:"Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        swal({
                            title: "Deleted Successfully",
                            icon: "success",
                            buttons: false,
                            dangerMode: false
                        })
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        swal({
                            title: "Delete Proccess Not Successful",
                            icon: "error",
                            buttons: false,
                            dangerMode: true
                        })                      
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
