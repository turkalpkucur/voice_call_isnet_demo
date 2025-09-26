

$(document).ready(function () {




  $("#IframeGetirButtonId").click(function () {




    debugger;


    let iframe = document.getElementById("IsnetLoginIframeId");

    // iframe'in içindeki document
    let iframeDoc = iframe.contentDocument;

    // örnek: input'u seç
    let input = iframeDoc.querySelector("input[type='text']");



    debugger;

  });



  $("#CallButtonId").click(function () {
 
    $.ajax({
      type: "POST",
      url: "/call",
      contentType: "application/json; charset=utf-8",
      processData: true,
      cache: false,
      success: function () {
        debugger;

      },
      error: function (XMLHttpRequest, textStatus, errorThrown) {
        debugger;
        alert("some error");
        
      },
      complete: function (data) {
        debugger;
      }
    });

  });






  });




 



   