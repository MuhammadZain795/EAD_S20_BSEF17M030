<?php
    session_start();
    if(isset($_SESSION["username"])==false){
        header('Location:login.php');
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <link rel="stylesheet" href="home.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
   
</head>
<body style="background-color: black">
    <div class="container mt-4" id="main">
        <div class="row"><div class="modalBtn col-6">
        <button onclick="document.getElementById('id01').style.display='block'" class="w3-button w3-white modalBtn">Create a folder</button><hr>
        </div><div class="col-6 logoutBtn">
        <button type="button" id="logout">Log Out</button><hr></div></div><hr>
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content w3-animate-top w3-card-4">
            <header class="w3-container w3-teal pt-4 pb-4">
                Name: <input type="text" id="fname" name="fname" placeholder="Enter folder name..."/><hr>
                <button type="button" id="btn" name="btn" class="w3-button w3-black">Done</button>
            </header>
            </div>
        </div>
        <div class="home">
        <div class="root" name="0" id="folder" style="border: 2px solid black; padding:2px; cursor:pointer; width:100px" >root</div><hr> 
        </div>
        
        <div class="folders"></div>
    </div>
    <script>
        $('#logout').click(function(){
            window.location.replace("logoutapi.php");
        });
        var pid = $('.home .root').attr('name');
        $(document).ready(function(){
            folderDisplay(pid);
        });
        function folderDisplay(parentName){
            let obj={'p':parentName};
            var ajaxcallShow = {
                type: "POST",
                dataType: "json",
                url: "showfolder.php",
                data: obj,
                success: successShow,
                error: errorShow,
                }
                $.ajax(ajaxcallShow);
        }
        function successShow(res){
            for(var i=0;i<res.length;i++){
                let elem1 = $("<div>").attr({"name":res[i][0],"class":"root","id":"folder"}).css({"cursor":"pointer","border":"2px solid black","width":"100px"});
                elem1.html('<i class="fa fa-folder" aria-hidden="true"></i> ' + res[i][1]);
                $(".folders").append(elem1);
                $(".folders").append("<br>"); 
            }
            $('.root').dblclick(function(){
                $('.folders .root').remove();
                $('.folders br').remove();
                let t = $(this).text();
                let n = $(this).attr("name");
                $('.home .root').text(t);
                $('.home .root').attr('name',n);
                folderDisplay(n);
            });
        }
        function errorShow(res){
            for(var i=0;i<res.length;i++){
                var elem1 = $("<span>").attr("name",res[i][0]).attr("class","root");
                elem1.text(res[i][1]);
                $("#main").append(elem1);
                $("#main").append("<hr>");
            }
        }
        $('#btn').click(function(){
                var pid1 = $('.root').attr('name');
                var n = $('#fname').val();
                let obj = {foldername:n,parentid:pid1};
                    var ajaxcall2 = {
                        type: "POST",
                        dataType: "json",
                        url: "creatingfolderapi.php",
                        data: obj,
                        success: successCreate,
                        error: errorCreate,
                    }
                    $.ajax(ajaxcall2);
            });
        function successCreate(res){
            if(res=="samenNameNotAllowed"){
                alert("Same name is not allowed...");
            }
            else{
                $('#id01').hide();
                    $('.folders .root').remove();
                    $('.folders hr').remove();
                    let n1 = $('.home .root').attr('name');
                    folderDisplay(n1);
            }
        }
        function errorCreate(res){
            if(res=="samenNameNotAllowed"){
                alert("Same name is not allowed...");
            }
        }
    </script>
</body>
</html>