$(() => {
    var connection = new signalR
        .HubConnectionBuilder()
        .withUrl("/signalRServer").build();
    connection.start();
    connection.on("LoadData", function () {
        loadData();
    })

    loadData();

    function loadData() {
        var tr = "";

        $.ajax({
            url: "/Attributes/GetAttributes",
            method: "GET",
            success: (result) => {
                $.each(result, (k, v) => {
                    tr += `<tr>
<td>
</tr>`
                })
            }
        });
    }
})