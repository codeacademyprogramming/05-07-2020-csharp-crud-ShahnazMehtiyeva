$(document).ready(function () {
    $(document).on("keyup", "#search", function () {
        let inputvalue = $("#search").val().toLowerCase().trim();
        $(" tr td:first-child").each(function () {
            $(this).closest('tr').toggle($(this).text().toLowerCase().indexOf(inputvalue) > -1);
        })
    })


})