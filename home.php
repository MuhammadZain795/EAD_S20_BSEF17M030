<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
    <!-- <link href="./Assignment1/EAD_S20_BSEF17M030/css/signup.css" rel="stylesheet" type="text/css"> -->
    <!-- <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.3/html5shiv.js"></script> -->
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body style="background-color: aliceblue">
    <div class="container mt-4" id="main">
    <div class="home">
    <span class="root" name="0" style="border: 2px solid black; padding:2px; cursor:pointer" >root</span><hr> 
    </div>
        <button onclick="document.getElementById('id01').style.display='block'" class="w3-button w3-black">Create a folder</button><hr>
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content w3-animate-top w3-card-4">
            <header class="w3-container w3-teal pt-4 pb-4">
                Name: <input type="text" id="fname" name="fname" placeholder="Enter folder name..."/><hr>
                <button type="button" id="btn" name="btn" class="w3-button w3-black">Done</button>
            </header>
            </div>
        </div>
    </div>
    <script>
        var pid = $('.home .root').attr('name');
        $(document).ready(function(){
            let obj={'p':pid};
            let ajaxcall1 = {
                type: "POST",
                dataType: "json",
                url: "showfolder.php",
                data: obj,
                success: successfunc1,
                error: OnError1,
                }
                $.ajax(ajaxcall1);
        });
        function pageload(){
            let obj={'p':pid};
            let ajaxcall1 = {
                type: "POST",
                dataType: "json",
                url: "showfolder.php",
                data: obj,
                success: successfunc1,
                error: OnError1,
                }
                $.ajax(ajaxcall1);
        }
        function successfunc1(res){
            for(var i=0;i<res.length;i++){
                var elem1 = $("<span>").attr({"name":res[i][0],"class":"root"}).css({"cursor":"pointer","border":"2px solid black"});
                elem1.text(res[i][1]);
                $("#main").append(elem1);
                $("#main").append("<hr>");
            }
            $('.root').dblclick(function(){
                console.log($(this).text());
                let t = $(this).text();
                let n = $(this).attr("name");
                $('.home .root').text(t);
                $('.home .root').attr('name',n);
                pageload();
            });
        }
        function OnError1(res){
            for(var i=0;i<res.length;i++){
                var elem1 = $("<span>").attr("name",res[i][0]).attr("class","root");
                elem1.text(res[i][1]);
                $("#main").append(elem1);
                $("#main").append("<hr>");
            }
            console.log(res[0][1]);
        }
        $(document).ready(function(){
            $('#btn').click(function(){
                var pid1 = $('.root').attr('name');
        var n = $('#fname').val();
                let obj = {foldername:n,parentid:pid1};
                    var ajaxcall2 = {
                        type: "POST",
                        dataType: "json",
                        url: "creatingfolderapi.php",
                        data: obj,
                        success: successfunc2,
                        error: OnError2,
                    }
                    $.ajax(ajaxcall2);
            })
            
        });  
        function successfunc2(res){
            // if(res =="confirmed"){
            //     // window.location.href="home.php";
            // }
            // else if(res == "error"){
            // alert("Username or Password is incorrect!!!");
            // }
            console.log("ok");
            console.log(res);
        }
        function OnError2(res){
            // if(res =="confirmed"){
            //     window.location.href="home.php";
            // }
            // else if(res == "error"){
            // alert("Username or Password is incorrect!!!");
            // }
            console.log("error");
            console.log(res);
        }
        
    </script>
</body>
</html>