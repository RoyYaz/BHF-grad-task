$(function () {
    $(".radioButton").on('click', function () {
        //console.log($(this));
        var amount = $(this).val();
        $("#donation_Money").val(amount);
    });
    //$(".radioButton").each(function () {
    //    var $this = $(this);
    //    $this.click(function (e) {
    //        // get the value of this radio button
    //        var value = e.valueOf[value];

    //        // put value in text box of that id
    //        $("#donation_Money").val(value);
    //    });        
    //});
});