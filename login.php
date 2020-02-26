<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Screen</title>
    <!-- <link href="./Assignment1/EAD_S20_BSEF17M030/css/signup.css" rel="stylesheet" type="text/css"> -->
    <!-- <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.3/html5shiv.js"></script> -->
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body style="background-color: cadetblue">
    <div class="container">
    <form class="mt-4">
            <div class="form-group">
            User Name: <input type="text" class="form-control" placeholder="Enter your username" id="username" name="username">
            </div>
            <div class="form-group">
            Password: <input type="password" class="form-control" placeholder="Enter your password" id="pwd" name="pwd">
            </div>
            <button type="button" class="btn btn-primary" name="btn" id="btn">Submit</button>
    </form>
    </div>
    <script>
        var u,p;
            $(document).ready(function(){
                $('#btn').click(function(){
                    u = $('#username').val();
                    p = $('#pwd').val();
                    let obj = {'username':u,'pass':p};
                        var ajaxcall = {
                            type: "POST",
                            dataType: "json",
                            url: "loginapi.php",
                            data: obj,
                            success: successfunc,
                            error: OnError,
                        }
                        $.ajax(ajaxcall);
                })
            });  
            function successfunc(res){
                if(res =="confirmed"){
                    window.location.href="home.php";
                }
                else if(res == "error"){
                alert("Username or Password is incorrect!!!");
                }
                console.log(res);
            }
            function OnError(res){
                if(res =="confirmed"){
                    window.location.href="home.php";
                }
                else if(res == "error"){
                alert("Username or Password is incorrect!!!");
                }
                console.log(res);
            }
    </script>
</body>
</html>