$(function() {
    $("#btnGo").click(function () {
        $.ajax({
            dataType: "json",
            url: "/Customer/GetPaymentMethodsForCustomer",
            data: { "email": $("#email").val() },
            type: 'POST',
            success: function (data) {
                WriteTable(data);
            },
            error: function (jqXHR, exception) {
                alert("Error");
            }

        });
    });

    $(document).on('click',
        '.edit',
        function() {
            var col = $(this).parent();
            var hidden = col.find('.paymentMethodId');
            var id = hidden.val();
            $.ajax({
                dataType: "json",
                url: "/Customer/MakePrimary",
                data: { "id": id },
                type: 'POST',
                success: function (data) {
                    if (data.message === "Success") {
                        WriteTable(data);
                    } else {
                        alert(data.message);
                    }
                },
                error: function (jqXHR, exception) {
                    alert("Error");
                }

            });
        });

    $(document).on('click',
        '.delete',
        function () {
            var col = $(this).parent();
            var hidden = col.find('.paymentMethodId');
            var id = hidden.val();
            var primary = col.find('.isPrimaryName').val();
            if (primary === "Yes") {
                alert("Cannot delete a primary payment method");
            } else {
                $.ajax({
                    dataType: "json",
                    url: "/Customer/DetachPaymentMethod",
                    data: { "id": id },
                    type: 'POST',
                    success: function(data) {
                        if (data.message === "Success") {
                            WriteTable(data);
                        } else {
                            alert(data.message);
                        }
                    },
                    error: function(jqXHR, exception) {
                        alert("Error");
                    }

                });
            }
        });
});

function WriteTable(data) {
    $("#paymentMethods").empty();
    var strHtml = "";
    strHtml += "<table class='table' id='table'>";
    strHtml += "<tr>";
    strHtml += "<th>Description</th>";
    strHtml += "<th>Is Primary</th>";
    strHtml += "<th></th>";
    strHtml += "</tr>";
    if (data.paymentMethods.length > 0) {
        for (var i = 0; i < data.paymentMethods.length; i++) {
            strHtml += "<tr>";
            strHtml += "<td>" + data.paymentMethods[i].description;
            strHtml += "<td>" + data.paymentMethods[i].isPrimaryName + "</td>";
            strHtml += "<td><a href='#' class='edit'>Make Primary</a>&nbsp;|&nbsp;<a href='#' class='delete'>Delete</a><input type='hidden' class='paymentMethodId' value='" + data.paymentMethods[i].paymentMethodId + "'/><input type='hidden' class='isPrimaryName' value='" + data.paymentMethods[i].isPrimaryName + "'/></td>";
            strHtml += "</tr>";
        }
    }
    strHtml += "</table>";
    $("#paymentMethods").append(strHtml);

}