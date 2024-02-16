

$(document).ready(function () {


    $('#id-table').DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "",
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
        "lengthMenu": [5, 10, 20, 50, 100],
        /*"autoWidth": true,*/
        scrollX: 400,
        
        });

    //if ($(window).width() < '1024') {
    //    $('#id-table td, #id-table th').css({
    //        'max-width': '200px',
    //        'overflow': 'hidden',
    //        'text-overflow': 'ellipsis',
    //        'white-space': 'nowrap',

    //    });
    //}

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 2000)




})