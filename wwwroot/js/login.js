/* -------------------------------------------
            Jquery login functions
-------------------------------------------- */

$(document).ready(function(){

    $("#btn").click(function(){
        
        getUsers();
    });
});

function login(){


}

function getUsers(){

    $.ajax({

        url: "http://localhost:5000/api/users/login",
        type: "POST",
        dataType: "Json",
        success: function(response){

            console.log(response)
        },
        error: function(error){

            console.log(error)
        }
    });
}