$(document).ready(function () {

    $.ajaxSetup({ cache: false });
    

    $(".openDialog").on("click", function (e) {
        e.preventDefault();
       

        $("<div></div>")
            .addClass("modal-content")
            .attr("id", $(this)
            .attr("data-dialog-id"))
            .appendTo("body")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true
            })       
            .load(this.href);    
    });

    $(".close").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".dialog").dialog("close");
    });
});