$(() => {
    var connection = new signalR
        .HubConnectionBuilder()
        .withUrl("/signalRServer").build();
    connection.start();
    connection.on("loadData", function () {
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
                                <td>${v.EntityTypeId}</td>
                                <td>${v.Name}</td>
                                <td>${v.IsActive}</td>
                                <td>
                                    <a href='../Attributes/Edit?id=${v.Id}'>Edit</a>
                                    <a href='../Attributes/Delete?id=${v.Id}'>Delete</a>
                                </td>
                           </tr>`
                })

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})