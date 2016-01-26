(function () {
    var scrollTop = 0;

    var uploadImage = function () {
        $('#uploadImageForm').submit(function (event) {
            alert("Handler for .submit() called.");
            event.preventDefault();
        });
    };

    var showPreview = function (event) {
        scrollTop = $('body').scrollTop();
        $('body').scrollTop(0);
        $('body').css('overflow', 'hidden');
        var id = $(event.target).parent().data("id");
        $('#carousel-example-generic div.item').removeClass('active');
        $('#carousel-example-generic div.item[data-imageid="' + id +'"]').addClass('active');
        $('#gallery-preview').show();
        //alert($(this).data("id"));
    };
    var closePreview = function () {
        $('body').scrollTop(scrollTop);
        $('body').css('overflow', 'auto');
        $('#gallery-preview').hide();
    };

   
    $('#gallery-thumbnail .thumbnail').click(showPreview);
    $('#gallery-preview .gallery-preview-close').click(closePreview)
})()