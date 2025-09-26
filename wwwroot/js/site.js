

$(document).ready(function () {




  $("#IframeGetirButtonId").click(function () {



    var iframe = document.getElementById("IsnetLoginIframeId");
    debugger;



    var ifrm = document.getElementById('IsnetLoginIframeId');
    ifrm = (ifrm.contentWindow) ? ifrm.contentWindow : (ifrm.contentDocument.document) ? ifrm.contentDocument.document : ifrm.contentDocument;

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




 



   