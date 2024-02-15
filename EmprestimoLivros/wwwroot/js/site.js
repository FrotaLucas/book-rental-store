

$(document).ready(function () {


    $('#id-table').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Showing 1 to 5 of 100",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Search:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        },
        "lengthMenu": [5, 10, 20, 50, 100]

    });

    //code 1
     //setTimeout(function () {
     //   ${".alert"}.fadeOut("slow", function () {
     //       $(this).alert('close');
     //   });
     //}, 5000)

     //code 2
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 2000)




})