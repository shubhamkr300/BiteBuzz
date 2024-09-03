$(document).ready(function(){
    loadData();
})

function loadData() {
    $.ajax({
        url: "/Web/List",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        data: { data: obj },
        dataType: "json",
        success: function (result){
            var html = '';
            $.each(result,function(key,item){
                html += '<tr>';
                html += '<td>' + item.UserId +'</td>';
                html += '<td>' + item.Name +'</td>';
                html += '<td>' + item.Gender +'</td>';
                html += '<td>' + item.Email +'</td>';
                html += '<td>' + item.Phone +'</td>';
                html += '<td>' + item.Password +'</td>';
                html += '<td><a href="#" onclick="return getbyID('+ item.UserId + ')">Edit</a> | <a href="#" onclick="Delete('+ item.UserId + ')">Delete</a></td>';
                html += '</tr>';              
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
              alert(errormessage.responseText);
        }
    });
}

//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var obj = {
        Name: $("#nm").val(),
        Gender: $("#gen").val(),
        Email: $("#em").val(),
        Phone: $("#ph").val(),
        Password: $("#pass").val()
    };

    $.ajax({
        url: "/Web/AddUser",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();

        },
        error: function (err) {
            console.error(err);
        }
    });
}