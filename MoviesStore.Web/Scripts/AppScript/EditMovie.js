
$(function () {
$('.datepicker').datepicker();
var xyz = @ViewData["counter"];
var counter = xyz + 1;

$("#actorSubmit").click(function () {
    var dataPassed = {
        Name: $('#AName').val(),
        Sex: $('#ASex').val(),
        DOB: $('#ADOB').val(),
        Bio: $('#ABio').val()
    }
    if ($('#AName').val() == 'undefined' || $('#AName').val() == '') {
        $('#ANameError').text("Actor Name is Required");
        return false;
    }
    var $buttonClicked = $(this);
    //var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "POST",
        url: "@Url.Action("AddActor", "Actor")",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataPassed),
        datatype: "json",
        success: function (data) {

            //$('#myModalContent').html(data);
            //$('#myModal').modal(options);

            $('#addActor').removeClass('hidden').css("display", "none");

            $("#Actorform").trigger('reset');

            $.toaster({ priority: 'success', title: 'Title', message: 'Actor Added Successfully' });


        },
        error: function () {
            //alert("Dynamic content load failed.");
            $.toaster({ priority: 'danger', title: 'Error', message: 'Dynamic content load failed !!!' });
        }
    });

});

$("#ProducerName").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/Producer/SearchProducers",
            type: "GET",
            dataType: "json",
            data: { searchTerm: request.term },
            success: function (data) {
                if (!data.length) {
                    $.toaster({ priority: 'danger', title: 'Message', message: 'No Producer Found. Pleae Add !!!' });
                    $('#addProducer').removeClass('hidden').css("display", "inline");
                }
                else {
                    response($.map(data, function (item) {
                        $('#addProducer').removeClass('hidden').css("display", "none");
                        return { label: item.Name, value: item.Name, ProducerID: item.ProducerID };
                    }))
                }


            }
        })
    },
    minLength: 1,
    select: function (event, ui) {
        $("#ProducerID").val(ui.item.ProducerID);
        //do anything u need
        //get ur name  ui.item.Name
        //get ur URL   ui.item.LogoUrl
    }
});

$("#producerSubmit").click(function () {
    var dataPassed = {
        Name: $('#PName').val(),
        Sex: $('#Sex').val(),
        DOB: $('#DOB').val(),
        Bio: $('#Bio').val()
    }
    if ($('#PName').val() == 'undefined' || $('#PName').val() == '') {
        $('#PNameError').text("Producer Name is Required");
        return false;
    }
    var $buttonClicked = $(this);
    //var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "POST",
        url: "@Url.Action("AddProducer", "Producer")",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataPassed),
        datatype: "json",
        success: function (data) {

            //$('#myModalContent').html(data);
            //$('#myModal').modal(options);

            $('#addProducer').removeClass('hidden').css("display", "none");
            $("#Producerform").trigger('reset');

            $.toaster({ priority: 'success', title: 'Status', message: 'Producer Added Successfully' });


        },
        error: function () {
            //alert("Dynamic content load failed.");
            $.toaster({ priority: 'danger', title: 'Error', message: 'Dynamic content load failed !!!' });
        }
    });
    $('#myModal').modal('hide');
});

$('input').focus(function () {
    $('#' + $(this).attr('id') + 'Error').text("");
});

$("#addButton").click(function () {

    if (counter > 10) {
        //alert("Only 10 textboxes allow");
        return false;
    }

    var newTextBoxDiv = $(document.createElement('div'))
        .attr("id", 'TextBoxDiv' + counter);
    newTextBoxDiv.attr("data-id", 'TextBoxDiv');

    newTextBoxDiv.after().html(
        '<input type="text" name="Actors[' + (counter - 1) + '].Name" class="form-control autosuggest" id="Actor' + (counter - 1) + '"  >'
        + '<input type="text" name= "Actors[' + (counter - 1) + '].ActorID" id= "ActorID' + (counter - 1) + '" hidden> ');

    newTextBoxDiv.appendTo("#TextBoxesGroup");


    counter++;
});

$("#YearOfRelease").keydown(function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        // let it happen, don't do anything

        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        $.toaster({ priority: 'danger', title: 'Message', message: 'Please type Numeric Character !!!' });
        e.preventDefault();
    }
});

$("#YearOfRelease").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/Home/GetAllYears",
            type: "GET",
            dataType: "json",
            data: { searchTerm: request.term },
            success: function (data) {
                if (!data.length) {
                    $.toaster({ priority: 'danger', title: 'Message', message: 'No Year Found. !!!' });
                    //$('#addProducer').removeClass('hidden').css("display", "inline");
                }
                else {
                    response($.map(data, function (item) {
                        //$('#addProducer').removeClass('hidden').css("display", "none");
                        return { label: item.Value, value: item.Value, YearID: item.YearID };
                    }))
                }


            }
        })
    },
    minLength: 1,
    select: function (event, ui) {
        $("#YearID").val(ui.item.YearID);
        //do anything u need
        //get ur name  ui.item.Name
        //get ur URL   ui.item.LogoUrl
    }
});

$("#removeButton").click(function () {
    if (counter == 1) {

        $.toaster({ priority: 'danger', title: 'Error', message: 'One Actor is Required' });
        return false;
    }

    counter--;

    $("#TextBoxDiv" + counter).remove();

});


//
$('body').on('focus', ".autosuggest", function () {
    var autosuggestType = $(this).closest('div').attr("TextBoxDiv");
    $(this).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Actor/SearchActors",
                type: "GET",
                dataType: "json",
                data: { searchTerm: request.term },
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    if (!data.length) {
                        $.toaster({ priority: 'danger', title: 'Message', message: 'No Actor Found. Please Add !!!' });
                        $('#addActor').removeClass('hidden').css("display", "inline");
                    }
                    else {
                        response($.map(data, function (item) {
                            $('#addActor').removeClass('hidden').css("display", "none");
                            return { label: item.Name, value: item.Name, ActorID: item.ActorID };
                        }))
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //alert(textStatus);
                    $.toaster({ priority: 'danger', title: 'Error', message: textStatus });
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            var id = $(this).attr('id').substring(5, 7);

            $('#ActorID' + id).val(ui.item.ActorID);
            var d = $('#ActorID' + id).val();
            //$(this).attr('id').val(ui.item.ProducerID);
            //do anything u need
            //get ur name  ui.item.Name
            //get ur URL   ui.item.LogoUrl
        }
    });
});
    });