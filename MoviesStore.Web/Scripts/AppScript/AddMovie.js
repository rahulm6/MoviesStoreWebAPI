
$(document).ready(function () {

        $("#ProducerID").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Producer/SearchProducers",
                    type: "GET",
                    dataType: "json",
                    data: { searchTerm: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.Name, value: item.Name };
                        }))

                    }
                })
            },
            messages: {
                noResults: "", results: ""
            }
        });
    })
