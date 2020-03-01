<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home</title>
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
        <button type="button" id="logout" style="background-color:danger">Log Out</button><hr>
        <div class="folders"></div>
    </div>
    <script>
        $('#logout').click(function(){
            window.location.replace("login.php");
        });
        var pid = $('.home .root').attr('name');
        $(document).ready(function(){
            let obj={'p':pid};
            var ajaxcall1 = {
                type: "POST",
                dataType: "json",
                url: "showfolder.php",
                data: obj,
                success: successfunc1,
                error: OnError1,
                }
                $.ajax(ajaxcall1);
        });
        function successfunc1(res){
            for(var i=0;i<res.length;i++){
                let elem1 = $("<span>").attr({"name":res[i][0],"class":"root"}).css({"cursor":"pointer","border":"2px solid black"});
                elem1.text(res[i][1]);
                $(".folders").append(elem1);
                $(".folders").append("<hr>");
            }
            $('.root').dblclick(function(){
                $('.folders .root').remove();
                $('.folders hr').remove();
                let t = $(this).text();
                let n = $(this).attr("name");
                $('.home .root').text(t);
                $('.home .root').attr('name',n);
                let pageload=function(){
                    let obj={'p':n};
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
                        success: successfunc2,
                        error: OnError2,
                    }
                    $.ajax(ajaxcall2);
                    $('#id01').hide();
                    let n1 = $(this).attr("name");
                    let obj1={'p':n1};
                    var ajaxcall3 = {
                    type: "POST",
                    dataType: "json",
                    url: "showfolder.php",
                    data: obj1,
                    success: successfunc3,
                    error: OnError3,
                    }
                    $.ajax(ajaxcall3);
            });
        function successfunc2(res){
            if(res=="samenNameNotAllowed"){
                alert("Same name is not allowed...");
            }
            console.log(res);
        }
        function OnError2(res){
            if(res=="samenNameNotAllowed"){
                alert("Same name is not allowed...");
            }
            console.log(res);
        }
        function successfunc3(res){
            successfunc1(res);
        }
        function OnError3(res){
            OnError1(res);
        }
    </script>
</body>
</html>