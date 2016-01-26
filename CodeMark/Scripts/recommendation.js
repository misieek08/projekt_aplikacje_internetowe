window.onload = function (event) {
    $('[data-toggle="tooltip"]').tooltip();
    var preview = $(".recommendation-preview");
    $("a.recommendation-preview-btn").click(function (event) {
        //preview.show();
        var data = $(event.currentTarget).data();
        var modalWindow = $('.modal.recommendation');
        modalWindow.find('.modal-title').text(data.name);
        modalWindow.find('img').attr('src', recommendationPreview + '?id=' + data.reccomendationid);
        modalWindow.modal('show');
    });
    $(".recomm-preview-header-close").click(function () {
        preview.hide();
    });
    $('.recommendation-delete').click(function(event){
        var id = $(event.currentTarget).data('reccomendationid');
        location.href = deleteRecommendation + '?id=' + id;
    });
};