
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>SignUp Screen</title>
        <!-- <link href="./Assignment1/EAD_S20_BSEF17M030/css/signup.css" rel="stylesheet" type="text/css"> -->
        <!-- <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.3/html5shiv.js"></script> -->
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    </head>
    <body class=" text-center" style="background-color: burlywood">
        <div class="container">
        <form class="mt-4">
            <div class="form-group">
            Name: <input type="text" class="form-control" placeholder="Enter name" id="name" name="name">
            </div>
            <div class="form-group">
            Username: <input type="text" class="form-control" placeholder="Enter login name" id="username" name="username">
            </div>
            <div class="form-group">
            Password: <input type="password" class="form-control" placeholder="Enter password" id="pwd" name="pwd">
            </div>
            <div class="form-group">
            Confirm Password: <input type="password" class="form-control" placeholder="Confirm password" id="cpwd" name="cpwd">
            </div>
            <button type="button" class="btn btn-primary" name="btn" id="btn">Submit</button>
        </form>
        </div>
        <script>
            var n,u,p,cp;
            $(document).ready(function(){
                $('#btn').click(function(){
                    n = $('#name').val();
                    u = $('#username').val();
                    p = $('#pwd').val();
                    cp = $('#cpwd').val();
                    if(cp!=p){
                        alert("Please enter same password...v  c ");
                        return;
                    }
                    else{
                        let obj = {name:n,username:u,pass:p};
                        console.log(obj);
                        var ajaxcall = {
                            type: "POST",
                            dataType: "json",
                            url: "signupapi.php",
                            data: obj,
                            success: successfunc,
                            error: OnError,
                        }
                        $.ajax(ajaxcall);
                    }
                })
            });
            function successfunc(res){
                if(res=="added"){
                window.location.href="login.php";
                }
                else if(res=="error"){
                    alert("Choose another username!!!");
                }
                console.log(res);
            }
            function OnError(res){
                if(res=="added"){
                window.location.href="login.php";
                }
                else if(res=="error"){
                    alert("Choose another username!!!");
                }
                console.log(res);
            }
        </script>
    </body>
</html>
